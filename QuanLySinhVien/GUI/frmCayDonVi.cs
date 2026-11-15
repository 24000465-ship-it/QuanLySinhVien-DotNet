using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    /// <summary>Khai báo delegate: "con trỏ hàm" trỏ tới phương thức nhận mã và họ tên sinh viên.</summary>
    public delegate void ChonSinhVienHandler(string maSV, string hoTen);

    /// <summary>
    /// Hiển thị cây phân cấp Khoa → Ngành → Lớp (TreeView); chọn lớp thì hiện danh sách sinh viên.
    /// Nhấp đúp một sinh viên sẽ phát sự kiện SinhVienDuocChon để form khác (frmBangDiem) nhận
    /// mã sinh viên — truyền dữ liệu giữa các form bằng delegate / event.
    /// </summary>
    public partial class frmCayDonVi : Form
    {
        /// <summary>Sự kiện phát ra khi người dùng nhấp đúp chọn một sinh viên.</summary>
        public event ChonSinhVienHandler SinhVienDuocChon;

        private readonly IDanhMucBUS<Khoa> khoaBus = new KhoaBUS();
        private readonly IDanhMucBUS<Nganh> nganhBus = new NganhBUS();
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();
        private readonly ISinhVienBUS sinhVienBus = new SinhVienBUS();

        public frmCayDonVi()
        {
            InitializeComponent();
        }

        private void frmCayDonVi_Load(object sender, EventArgs e)
        {
            GiaoDien.DinhDangLuoi(dgvSinhVien);
            try
            {
                TaoCay();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        /// <summary>Dựng cây: mỗi khoa là một nút gốc, ngành là nút con, lớp là nút cháu.</summary>
        private void TaoCay()
        {
            DataTable dsKhoa = khoaBus.LayDanhSach("");
            DataTable dsNganh = nganhBus.LayDanhSach("");
            DataTable dsLop = lopBus.LayDanhSach("");

            tvDonVi.BeginUpdate();
            tvDonVi.Nodes.Clear();
            foreach (DataRow khoa in dsKhoa.Rows)
            {
                TreeNode nutKhoa = new TreeNode(khoa["TenKhoa"].ToString());
                nutKhoa.Tag = "KHOA";
                foreach (DataRow nganh in dsNganh.Select("MaKhoa = '" + khoa["MaKhoa"] + "'"))
                {
                    TreeNode nutNganh = new TreeNode(nganh["MaNganh"] + " - " + nganh["TenNganh"]);
                    nutNganh.Tag = "NGANH";
                    foreach (DataRow lop in dsLop.Select("MaNganh = '" + nganh["MaNganh"] + "'", "KhoaHoc DESC"))
                    {
                        TreeNode nutLop = new TreeNode(lop["MaLop"] + " - " + lop["TenLop"] + " (" + lop["SiSo"] + " SV)");
                        nutLop.Tag = "LOP:" + lop["MaLop"];
                        nutNganh.Nodes.Add(nutLop);
                    }
                    nutKhoa.Nodes.Add(nutNganh);
                }
                tvDonVi.Nodes.Add(nutKhoa);
            }
            tvDonVi.EndUpdate();
        }

        private void tvDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string tag = Convert.ToString(e.Node.Tag);
            if (!tag.StartsWith("LOP:"))
            {
                lblTieuDe.Text = "Chọn một lớp để xem danh sách sinh viên";
                dgvSinhVien.DataSource = null;
                return;
            }
            string maLop = tag.Substring(4);
            dgvSinhVien.DataSource = sinhVienBus.LayDanhSach("", maLop);
            GiaoDien.DatTieuDeCot(dgvSinhVien, "MaSV", "Mã SV", "HoTen", "Họ tên",
                "NgaySinh", "Ngày sinh", "GioiTinh", "Giới tính", "SoDienThoai", "Điện thoại");
            lblTieuDe.Text = "Lớp " + maLop + ": " + dgvSinhVien.Rows.Count + " sinh viên" +
                (SinhVienDuocChon != null ? " — nhấp đúp để chọn sinh viên" : "");
        }

        private void dgvSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || SinhVienDuocChon == null) return;
            DataGridViewRow dong = dgvSinhVien.Rows[e.RowIndex];
            // Gọi delegate: mọi phương thức đã đăng ký (+=) với sự kiện sẽ được thực thi
            SinhVienDuocChon(dong.Cells["MaSV"].Value.ToString(), dong.Cells["HoTen"].Value.ToString());
            Close();
        }
    }
}

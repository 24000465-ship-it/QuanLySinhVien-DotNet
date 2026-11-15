using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    /// <summary>
    /// MODULE MẪU — Quản lý khoa (F04).
    /// Form kế thừa frmDanhMucBase nên các nút Thêm/Sửa/Xóa/Lưu/Hủy, tìm kiếm, xuất Excel đã có sẵn.
    /// Ở đây chỉ cần ghi đè (override) các phương thức để làm phần riêng của khoa.
    /// Luồng một thao tác: GUI (form này) → BUS (KhoaBUS kiểm tra quy tắc) → DAL (KhoaDAL gọi thủ tục) → MySQL.
    /// </summary>
    public partial class frmKhoa : frmDanhMucBase
    {
        // Khai báo theo kiểu interface: form chỉ biết "làm gì", không phụ thuộc cách làm
        private readonly IDanhMucBUS<Khoa> khoaBus = new KhoaBUS();

        public frmKhoa()
        {
            InitializeComponent();
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            dgvDanhSach.DataSource = khoaBus.LayDanhSach(tuKhoa);
            GiaoDien.DatTieuDeCot(dgvDanhSach, "MaKhoa", "Mã khoa", "TenKhoa", "Tên khoa");
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtMaKhoa.Text = O(dong, "MaKhoa");
            txtTenKhoa.Text = O(dong, "TenKhoa");
        }

        protected override void XoaTrang()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtMaKhoa.ReadOnly = !(choPhep && dangThem);   // mã chỉ nhập khi thêm mới, không sửa được
            txtTenKhoa.ReadOnly = !choPhep;
            if (choPhep)
                (dangThem ? txtMaKhoa : txtTenKhoa).Focus();
        }

        /// <summary>Gom dữ liệu các ô nhập thành đối tượng Khoa.</summary>
        private Khoa DocForm()
        {
            return new Khoa { MaKhoa = txtMaKhoa.Text, TenKhoa = txtTenKhoa.Text };
        }

        protected override void LuuThem()
        {
            khoaBus.Them(DocForm());
        }

        protected override void LuuSua()
        {
            khoaBus.Sua(DocForm());
        }

        protected override void XoaBanGhi()
        {
            khoaBus.Xoa(txtMaKhoa.Text);
        }

        protected override string MoTaBanGhiDangChon()
        {
            return "khoa \"" + txtTenKhoa.Text + "\"";
        }
    }
}

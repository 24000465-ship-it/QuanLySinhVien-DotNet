using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmPhanCong : Form
    {
        private readonly IPhanCongBUS phanCongBus = new PhanCongBUS();
        private readonly IXepMonBUS xepMonBus = new XepMonBUS();
        private readonly IGiangVienBUS giangVienBus = new GiangVienBUS();
        private readonly IDanhMucBUS<HocKy> hocKyBus = new HocKyBUS();
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();

        public frmPhanCong()
        {
            InitializeComponent();
        }

        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            GiaoDien.DinhDangLuoi(dgvMonCuaLop);
            try
            {
                GiaoDien.NapHocKy(cboHocKy, hocKyBus.LayDanhSach(""));
                GiaoDien.NapComboBox(cboLop, lopBus.LayDanhSach(""), "TenLop", "MaLop", false);
                GiaoDien.NapComboBox(cboGiangVien, giangVienBus.LayDanhSach("", ""), "HoTen", "MaGV", false);
                cboHocKy.SelectedIndexChanged += BoLoc_Changed;
                cboLop.SelectedIndexChanged += BoLoc_Changed;
                TaiLai();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void BoLoc_Changed(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void TaiLai()
        {
            string maLop = GiaoDien.GiaTri(cboLop);
            string maHocKy = GiaoDien.GiaTri(cboHocKy);
            if (maLop == "" || maHocKy == "") return;
            try
            {
                System.Data.DataTable monDaXep = xepMonBus.LayMonDaXep(maLop, maHocKy);
                dgvMonCuaLop.DataSource = monDaXep;
                GiaoDien.DatTieuDeCot(dgvMonCuaLop, "MaMon", "Mã môn", "TenMon", "Tên môn",
                    "SoTinChi", "Tín chỉ", "GiangVien", "Giảng viên đang dạy");
                GiaoDien.NapComboBox(cboMonHoc, monDaXep, "TenMon", "MaMon", false);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi(ex.Message);
            }
        }

        private void dgvMonCuaLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonCuaLop.CurrentRow != null)
                cboMonHoc.SelectedValue = dgvMonCuaLop.CurrentRow.Cells["MaMon"].Value;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                PhanCong pc = new PhanCong
                {
                    MaLop = GiaoDien.GiaTri(cboLop),
                    MaMon = GiaoDien.GiaTri(cboMonHoc),
                    MaHocKy = GiaoDien.GiaTri(cboHocKy),
                    MaGV = GiaoDien.GiaTri(cboGiangVien)
                };
                phanCongBus.Luu(pc);
                GiaoDien.ThongBao("Đã phân công " + cboGiangVien.Text + " dạy môn " + cboMonHoc.Text + ".");
                TaiLai();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không lưu được: " + ex.Message);
            }
        }
    }
}

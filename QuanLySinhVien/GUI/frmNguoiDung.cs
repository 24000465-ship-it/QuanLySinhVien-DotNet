using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmNguoiDung : frmDanhMucBase
    {
        private readonly INguoiDungBUS nguoiDungBus = new NguoiDungBUS();

        public frmNguoiDung()
        {
            InitializeComponent();
        }

        protected override void KhoiTao()
        {
            btnXoa.Visible = false;
            DataTable vaiTro = new DataTable();
            vaiTro.Columns.Add("Ma");
            vaiTro.Columns.Add("Ten");
            vaiTro.Rows.Add(NguoiDung.VaiTroAdmin, NguoiDung.TenVaiTro(NguoiDung.VaiTroAdmin));
            vaiTro.Rows.Add(NguoiDung.VaiTroCanBoDaoTao, NguoiDung.TenVaiTro(NguoiDung.VaiTroCanBoDaoTao));
            vaiTro.Rows.Add(NguoiDung.VaiTroGiangVien, NguoiDung.TenVaiTro(NguoiDung.VaiTroGiangVien));
            GiaoDien.NapComboBox(cboVaiTro, vaiTro, "Ten", "Ma", false);
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            DataTable bang = nguoiDungBus.LayDanhSach(tuKhoa);
            bang.Columns.Add("TenVaiTro");
            bang.Columns.Add("TinhTrang");
            foreach (DataRow dong in bang.Rows)
            {
                dong["TenVaiTro"] = NguoiDung.TenVaiTro(dong["VaiTro"].ToString());
                dong["TinhTrang"] = Convert.ToBoolean(dong["TrangThai"]) ? "Hoạt động" : "Đã khóa";
            }
            dgvDanhSach.DataSource = bang;
            GiaoDien.DatTieuDeCot(dgvDanhSach, "TenDangNhap", "Tên đăng nhập", "HoTen", "Họ tên",
                "TenVaiTro", "Vai trò", "TinhTrang", "Tình trạng");
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtTenDangNhap.Text = O(dong, "TenDangNhap");
            txtHoTen.Text = O(dong, "HoTen");
            cboVaiTro.SelectedValue = O(dong, "VaiTro");
            txtMatKhau.Clear();
            btnKhoa.Text = O(dong, "TinhTrang") == "Hoạt động" ? "Khóa tài khoản" : "Mở khóa";
        }

        protected override void XoaTrang()
        {
            txtTenDangNhap.Clear();
            txtHoTen.Clear();
            txtMatKhau.Text = NguoiDungBUS.MatKhauMacDinh;
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtTenDangNhap.ReadOnly = !(choPhep && dangThem);
            txtHoTen.ReadOnly = !choPhep;
            cboVaiTro.Enabled = choPhep;
            txtMatKhau.Enabled = choPhep && dangThem;
            btnKhoa.Enabled = !choPhep;
            btnCapLaiMatKhau.Enabled = !choPhep;
        }

        private NguoiDung DocForm()
        {
            return new NguoiDung
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                HoTen = txtHoTen.Text,
                VaiTro = GiaoDien.GiaTri(cboVaiTro)
            };
        }

        protected override void LuuThem() { nguoiDungBus.Them(DocForm(), txtMatKhau.Text); }

        protected override void LuuSua() { nguoiDungBus.Sua(DocForm()); }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow == null) return;
            bool dangHoatDong = O(dgvDanhSach.CurrentRow, "TinhTrang") == "Hoạt động";
            string hanhDong = dangHoatDong ? "khóa" : "mở khóa";
            if (!GiaoDien.XacNhan("Bạn có chắc muốn " + hanhDong + " tài khoản " + txtTenDangNhap.Text + "?"))
                return;
            try
            {
                nguoiDungBus.KhoaHoacMoKhoa(txtTenDangNhap.Text, !dangHoatDong);
                NapLai();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi(ex.Message);
            }
        }

        private void btnCapLaiMatKhau_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow == null) return;
            if (!GiaoDien.XacNhan("Cấp lại mật khẩu mặc định cho tài khoản " + txtTenDangNhap.Text + "?"))
                return;
            try
            {
                string matKhau = nguoiDungBus.CapLaiMatKhau(txtTenDangNhap.Text);
                GiaoDien.ThongBao("Mật khẩu mới của " + txtTenDangNhap.Text + " là: " + matKhau +
                    "\nHãy yêu cầu người dùng đổi mật khẩu sau khi đăng nhập.");
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi(ex.Message);
            }
        }
    }
}

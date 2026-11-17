using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmGiangVien : frmDanhMucBase
    {
        private readonly IGiangVienBUS giangVienBus = new GiangVienBUS();
        private readonly IDanhMucBUS<Khoa> khoaBus = new KhoaBUS();

        public frmGiangVien()
        {
            InitializeComponent();
        }

        protected override void KhoiTao()
        {
            GiaoDien.NapComboBox(cboMaKhoa, khoaBus.LayDanhSach(""), "TenKhoa", "MaKhoa", false);
            GiaoDien.NapComboBox(cboLocKhoa, khoaBus.LayDanhSach(""), "TenKhoa", "MaKhoa", true);
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            dgvDanhSach.DataSource = giangVienBus.LayDanhSach(tuKhoa, GiaoDien.GiaTri(cboLocKhoa));
            GiaoDien.DatTieuDeCot(dgvDanhSach, "MaGV", "Mã GV", "HoTen", "Họ tên", "NgaySinh", "Ngày sinh",
                "GioiTinh", "Giới tính", "SoDienThoai", "Điện thoại", "Email", "Email",
                "TenKhoa", "Khoa", "TenDangNhap", "Tài khoản");
        }

        private void cboLocKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocKhoa.Focused) NapLai();
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtMaGV.Text = O(dong, "MaGV");
            txtHoTen.Text = O(dong, "HoTen");
            dtpNgaySinh.Value = dong.Cells["NgaySinh"].Value is DateTime
                ? (DateTime)dong.Cells["NgaySinh"].Value : new DateTime(1985, 1, 1);
            cboGioiTinh.SelectedItem = O(dong, "GioiTinh");
            txtSoDienThoai.Text = O(dong, "SoDienThoai");
            txtEmail.Text = O(dong, "Email");
            cboMaKhoa.SelectedValue = O(dong, "MaKhoa");
            txtTenDangNhap.Text = O(dong, "TenDangNhap");
        }

        protected override void XoaTrang()
        {
            txtMaGV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(1985, 1, 1);
            cboGioiTinh.SelectedIndex = 0;
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtTenDangNhap.Clear();
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtMaGV.ReadOnly = !(choPhep && dangThem);
            txtHoTen.ReadOnly = !choPhep;
            dtpNgaySinh.Enabled = choPhep;
            cboGioiTinh.Enabled = choPhep;
            txtSoDienThoai.ReadOnly = !choPhep;
            txtEmail.ReadOnly = !choPhep;
            cboMaKhoa.Enabled = choPhep;
            txtTenDangNhap.ReadOnly = !choPhep;
        }

        private GiangVien DocForm()
        {
            GiangVien gv = new GiangVien();
            gv.MaGV = txtMaGV.Text;
            gv.HoTen = txtHoTen.Text;
            gv.NgaySinh = dtpNgaySinh.Value.Date;
            gv.GioiTinh = Convert.ToString(cboGioiTinh.SelectedItem);
            gv.SoDienThoai = txtSoDienThoai.Text;
            gv.Email = txtEmail.Text.Trim();
            gv.MaKhoa = GiaoDien.GiaTri(cboMaKhoa);
            gv.TenDangNhap = txtTenDangNhap.Text;
            return gv;
        }

        protected override void LuuThem() { giangVienBus.Them(DocForm()); }

        protected override void LuuSua() { giangVienBus.Sua(DocForm()); }

        protected override void XoaBanGhi() { giangVienBus.Xoa(txtMaGV.Text); }

        protected override string MoTaBanGhiDangChon()
        {
            return "giảng viên \"" + txtHoTen.Text + "\"";
        }
    }
}

using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmSinhVien : frmDanhMucBase
    {
        private const string ChuMaTuSinh = "(tự sinh khi lưu)";

        private readonly ISinhVienBUS sinhVienBus = new SinhVienBUS();
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();

        public frmSinhVien()
        {
            InitializeComponent();
        }

        protected override void KhoiTao()
        {
            GiaoDien.NapComboBox(cboMaLop, lopBus.LayDanhSach(""), "TenLop", "MaLop", false);
            GiaoDien.NapComboBox(cboLocLop, lopBus.LayDanhSach(""), "TenLop", "MaLop", true);
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            dgvDanhSach.DataSource = sinhVienBus.LayDanhSach(tuKhoa, GiaoDien.GiaTri(cboLocLop));
            GiaoDien.DatTieuDeCot(dgvDanhSach, "MaSV", "Mã SV", "HoTen", "Họ tên", "NgaySinh", "Ngày sinh",
                "GioiTinh", "Giới tính", "SoDienThoai", "Điện thoại", "TenLop", "Lớp");
        }

        private void cboLocLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocLop.Focused) NapLai();
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtMaSV.Text = O(dong, "MaSV");
            txtHoTen.Text = O(dong, "HoTen");
            dtpNgaySinh.Value = (DateTime)dong.Cells["NgaySinh"].Value;
            rdoNam.Checked = O(dong, "GioiTinh") == "Nam";
            rdoNu.Checked = !rdoNam.Checked;
            txtSoDienThoai.Text = O(dong, "SoDienThoai");
            cboMaLop.SelectedValue = O(dong, "MaLop");
        }

        protected override void XoaTrang()
        {
            txtMaSV.Text = ChuMaTuSinh;
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(DateTime.Today.Year - 18, 1, 1);
            rdoNam.Checked = true;
            txtSoDienThoai.Clear();
            if (GiaoDien.GiaTri(cboLocLop) != "")
                cboMaLop.SelectedValue = GiaoDien.GiaTri(cboLocLop);
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtHoTen.ReadOnly = !choPhep;
            dtpNgaySinh.Enabled = choPhep;
            pnlGioiTinh.Enabled = choPhep;
            txtSoDienThoai.ReadOnly = !choPhep;
            cboMaLop.Enabled = choPhep;
            if (choPhep) txtHoTen.Focus();
        }

        private SinhVien DocForm()
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text == ChuMaTuSinh ? null : txtMaSV.Text;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value.Date;
            sv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
            sv.SoDienThoai = txtSoDienThoai.Text;
            sv.MaLop = GiaoDien.GiaTri(cboMaLop);
            return sv;
        }

        protected override void LuuThem()
        {
            string maMoi = sinhVienBus.Them(DocForm());
            txtTimKiem.Text = maMoi;
        }

        protected override void LuuSua() { sinhVienBus.Sua(DocForm()); }

        protected override void XoaBanGhi() { sinhVienBus.Xoa(txtMaSV.Text); }

        protected override string MoTaBanGhiDangChon()
        {
            return "sinh viên " + txtMaSV.Text + " - " + txtHoTen.Text;
        }

        protected override string TieuDeXuatExcel()
        {
            return "Danh sách sinh viên";
        }
    }
}

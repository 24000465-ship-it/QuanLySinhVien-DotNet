using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmLop : frmDanhMucBase
    {
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();
        private readonly IDanhMucBUS<Nganh> nganhBus = new NganhBUS();

        public frmLop()
        {
            InitializeComponent();
        }

        protected override void KhoiTao()
        {
            nudKhoaHoc.Maximum = DateTime.Today.Year + 1;
            nudKhoaHoc.Value = DateTime.Today.Year;
            GiaoDien.NapComboBox(cboMaNganh, nganhBus.LayDanhSach(""), "TenNganh", "MaNganh", false);
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            dgvDanhSach.DataSource = lopBus.LayDanhSach(tuKhoa);
            GiaoDien.DatTieuDeCot(dgvDanhSach, "MaLop", "Mã lớp", "TenLop", "Tên lớp",
                "TenNganh", "Ngành", "KhoaHoc", "Năm nhập học", "SiSo", "Sĩ số");
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtMaLop.Text = O(dong, "MaLop");
            txtTenLop.Text = O(dong, "TenLop");
            cboMaNganh.SelectedValue = O(dong, "MaNganh");
            nudKhoaHoc.Value = Convert.ToDecimal(dong.Cells["KhoaHoc"].Value);
        }

        protected override void XoaTrang()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            nudKhoaHoc.Value = DateTime.Today.Year;
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtMaLop.ReadOnly = !(choPhep && dangThem);
            txtTenLop.ReadOnly = !choPhep;
            cboMaNganh.Enabled = choPhep;
            nudKhoaHoc.Enabled = choPhep;
            if (choPhep && dangThem) GoiYMaVaTen();
        }

        private void GoiYMaVaTen()
        {
            if (cheDoHienTai != CheDo.Them || cboMaNganh.SelectedItem == null) return;
            string maNganh = GiaoDien.GiaTri(cboMaNganh);
            int nam = (int)nudKhoaHoc.Value;
            txtMaLop.Text = LopBUS.GoiYMaLop(maNganh, nam);
            txtTenLop.Text = ((DataRowView)cboMaNganh.SelectedItem)["TenNganh"] + " K" + (nam % 100).ToString("00");
        }

        private void cboMaNganh_SelectedIndexChanged(object sender, EventArgs e) { GoiYMaVaTen(); }

        private void nudKhoaHoc_ValueChanged(object sender, EventArgs e) { GoiYMaVaTen(); }

        private Lop DocForm()
        {
            return new Lop
            {
                MaLop = txtMaLop.Text,
                TenLop = txtTenLop.Text,
                MaNganh = GiaoDien.GiaTri(cboMaNganh),
                KhoaHoc = (int)nudKhoaHoc.Value
            };
        }

        protected override void LuuThem() { lopBus.Them(DocForm()); }

        protected override void LuuSua() { lopBus.Sua(DocForm()); }

        protected override void XoaBanGhi() { lopBus.Xoa(txtMaLop.Text); }

        protected override string MoTaBanGhiDangChon()
        {
            return "lớp \"" + txtTenLop.Text + "\"";
        }
    }
}

using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmNganh : frmDanhMucBase
    {
        private readonly IDanhMucBUS<Nganh> nganhBus = new NganhBUS();
        private readonly IDanhMucBUS<Khoa> khoaBus = new KhoaBUS();

        public frmNganh()
        {
            InitializeComponent();
        }

        protected override void KhoiTao()
        {
            GiaoDien.NapComboBox(cboMaKhoa, khoaBus.LayDanhSach(""), "TenKhoa", "MaKhoa", false);
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            dgvDanhSach.DataSource = nganhBus.LayDanhSach(tuKhoa);
            GiaoDien.DatTieuDeCot(dgvDanhSach, "MaNganh", "Mã ngành", "TenNganh", "Tên ngành", "TenKhoa", "Khoa");
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtMaNganh.Text = O(dong, "MaNganh");
            txtTenNganh.Text = O(dong, "TenNganh");
            cboMaKhoa.SelectedValue = O(dong, "MaKhoa");
        }

        protected override void XoaTrang()
        {
            txtMaNganh.Clear();
            txtTenNganh.Clear();
            cboMaKhoa.SelectedIndex = cboMaKhoa.Items.Count > 0 ? 0 : -1;
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtMaNganh.ReadOnly = !(choPhep && dangThem);
            txtTenNganh.ReadOnly = !choPhep;
            cboMaKhoa.Enabled = choPhep;
        }

        private Nganh DocForm()
        {
            return new Nganh
            {
                MaNganh = txtMaNganh.Text,
                TenNganh = txtTenNganh.Text,
                MaKhoa = GiaoDien.GiaTri(cboMaKhoa)
            };
        }

        protected override void LuuThem() { nganhBus.Them(DocForm()); }

        protected override void LuuSua() { nganhBus.Sua(DocForm()); }

        protected override void XoaBanGhi() { nganhBus.Xoa(txtMaNganh.Text); }

        protected override string MoTaBanGhiDangChon()
        {
            return "ngành \"" + txtTenNganh.Text + "\"";
        }
    }
}

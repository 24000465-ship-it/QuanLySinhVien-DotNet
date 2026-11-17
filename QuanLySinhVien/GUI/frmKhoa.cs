using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmKhoa : frmDanhMucBase
    {
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
            txtMaKhoa.ReadOnly = !(choPhep && dangThem);
            txtTenKhoa.ReadOnly = !choPhep;
            if (choPhep)
                (dangThem ? txtMaKhoa : txtTenKhoa).Focus();
        }

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

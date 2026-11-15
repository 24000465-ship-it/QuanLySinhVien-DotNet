using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    /// <summary>Quản lý học kỳ (F04, R11).</summary>
    public partial class frmHocKy : frmDanhMucBase
    {
        private readonly IDanhMucBUS<HocKy> hocKyBus = new HocKyBUS();

        public frmHocKy()
        {
            InitializeComponent();
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            dgvDanhSach.DataSource = hocKyBus.LayDanhSach(tuKhoa);
            GiaoDien.DatTieuDeCot(dgvDanhSach, "MaHocKy", "Mã học kỳ", "TenHocKy", "Tên học kỳ");
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtMaHocKy.Text = O(dong, "MaHocKy");
            txtTenHocKy.Text = O(dong, "TenHocKy");
        }

        protected override void XoaTrang()
        {
            txtMaHocKy.Clear();
            txtTenHocKy.Clear();
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtMaHocKy.ReadOnly = !(choPhep && dangThem);
            txtTenHocKy.ReadOnly = !choPhep;
        }

        /// <summary>Gõ đủ mã học kỳ hợp lệ thì tự điền tên học kỳ.</summary>
        private void txtMaHocKy_TextChanged(object sender, EventArgs e)
        {
            if (cheDoHienTai == CheDo.Them && TienIch.LaMaHocKyHopLe(txtMaHocKy.Text))
                txtTenHocKy.Text = TienIch.TaoTenHocKy(txtMaHocKy.Text);
        }

        private HocKy DocForm()
        {
            return new HocKy { MaHocKy = txtMaHocKy.Text.Trim(), TenHocKy = txtTenHocKy.Text.Trim() };
        }

        protected override void LuuThem() { hocKyBus.Them(DocForm()); }

        protected override void LuuSua() { hocKyBus.Sua(DocForm()); }

        protected override void XoaBanGhi() { hocKyBus.Xoa(txtMaHocKy.Text); }

        protected override string MoTaBanGhiDangChon()
        {
            return "\"" + txtTenHocKy.Text + "\"";
        }
    }
}

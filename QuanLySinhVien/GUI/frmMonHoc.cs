using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmMonHoc : frmDanhMucBase
    {
        private readonly IDanhMucBUS<MonHoc> monHocBus = new MonHocBUS();

        public frmMonHoc()
        {
            InitializeComponent();
        }

        protected override void TaiDuLieu(string tuKhoa)
        {
            dgvDanhSach.DataSource = monHocBus.LayDanhSach(tuKhoa);
            GiaoDien.DatTieuDeCot(dgvDanhSach, "MaMon", "Mã môn", "TenMon", "Tên môn", "SoTinChi", "Số tín chỉ");
        }

        protected override void HienThiDong(DataGridViewRow dong)
        {
            txtMaMon.Text = O(dong, "MaMon");
            txtTenMon.Text = O(dong, "TenMon");
            nudSoTinChi.Value = Convert.ToDecimal(dong.Cells["SoTinChi"].Value);
        }

        protected override void XoaTrang()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            nudSoTinChi.Value = 3;
        }

        protected override void ChoPhepNhap(bool choPhep, bool dangThem)
        {
            txtMaMon.ReadOnly = !(choPhep && dangThem);
            txtTenMon.ReadOnly = !choPhep;
            nudSoTinChi.Enabled = choPhep;
        }

        private MonHoc DocForm()
        {
            return new MonHoc
            {
                MaMon = txtMaMon.Text,
                TenMon = txtTenMon.Text,
                SoTinChi = (int)nudSoTinChi.Value
            };
        }

        protected override void LuuThem() { monHocBus.Them(DocForm()); }

        protected override void LuuSua() { monHocBus.Sua(DocForm()); }

        protected override void XoaBanGhi() { monHocBus.Xoa(txtMaMon.Text); }

        protected override string MoTaBanGhiDangChon()
        {
            return "môn \"" + txtTenMon.Text + "\"";
        }
    }
}

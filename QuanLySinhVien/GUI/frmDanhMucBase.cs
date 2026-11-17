using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.GUI
{
    public partial class frmDanhMucBase : Form
    {
        protected enum CheDo { Xem, Them, Sua }

        protected CheDo cheDoHienTai = CheDo.Xem;

        public frmDanhMucBase()
        {
            InitializeComponent();
        }


        protected virtual void KhoiTao() { }

        protected virtual void TaiDuLieu(string tuKhoa) { }

        protected virtual void HienThiDong(DataGridViewRow dong) { }

        protected virtual void XoaTrang() { }

        protected virtual void ChoPhepNhap(bool choPhep, bool dangThem) { }

        protected virtual void LuuThem() { }

        protected virtual void LuuSua() { }

        protected virtual void XoaBanGhi() { }

        protected virtual string MoTaBanGhiDangChon()
        {
            return "bản ghi này";
        }

        protected virtual string TieuDeXuatExcel()
        {
            return Text;
        }


        private void frmDanhMucBase_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            GiaoDien.DinhDangLuoi(dgvDanhSach);
            try
            {
                KhoiTao();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu ban đầu: " + ex.Message);
            }
            ChuyenCheDo(CheDo.Xem);
            NapLai();
        }

        protected void NapLai()
        {
            try
            {
                TaiDuLieu(txtTimKiem.Text.Trim());
                lblTongSo.Text = "Tổng số: " + dgvDanhSach.Rows.Count;
                if (dgvDanhSach.Rows.Count > 0 && dgvDanhSach.CurrentRow == null)
                {
                    foreach (DataGridViewColumn cot in dgvDanhSach.Columns)
                    {
                        if (!cot.Visible) continue;
                        dgvDanhSach.CurrentCell = dgvDanhSach.Rows[0].Cells[cot.Index];
                        break;
                    }
                }
                if (dgvDanhSach.CurrentRow != null)
                    HienThiDong(dgvDanhSach.CurrentRow);
                else
                    XoaTrang();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        protected void ChuyenCheDo(CheDo cheDo)
        {
            cheDoHienTai = cheDo;
            bool dangNhap = cheDo != CheDo.Xem;
            ChoPhepNhap(dangNhap, cheDo == CheDo.Them);
            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnLuu.Enabled = dangNhap;
            btnHuy.Enabled = dangNhap;
            dgvDanhSach.Enabled = !dangNhap;
            txtTimKiem.Enabled = !dangNhap;
            errorProvider.Clear();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            NapLai();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            NapLai();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDoHienTai == CheDo.Xem && dgvDanhSach.CurrentRow != null)
                HienThiDong(dgvDanhSach.CurrentRow);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaTrang();
            ChuyenCheDo(CheDo.Them);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow == null)
            {
                GiaoDien.BaoLoi("Vui lòng chọn một dòng để sửa.");
                return;
            }
            ChuyenCheDo(CheDo.Sua);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                if (cheDoHienTai == CheDo.Them)
                    LuuThem();
                else
                    LuuSua();
                GiaoDien.ThongBao("Lưu thành công.");
                ChuyenCheDo(CheDo.Xem);
                NapLai();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.HienLoi(loi, pnlNhapLieu, errorProvider);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không lưu được: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ChuyenCheDo(CheDo.Xem);
            if (dgvDanhSach.CurrentRow != null)
                HienThiDong(dgvDanhSach.CurrentRow);
            else
                XoaTrang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow == null)
            {
                GiaoDien.BaoLoi("Vui lòng chọn một dòng để xóa.");
                return;
            }
            if (!GiaoDien.XacNhan("Bạn có chắc muốn xóa " + MoTaBanGhiDangChon() + "?"))
                return;
            try
            {
                XoaBanGhi();
                GiaoDien.ThongBao("Đã xóa.");
                NapLai();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không xóa được: " + ex.Message);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatExcel.TuLuoi(dgvDanhSach, TieuDeXuatExcel());
        }

        protected static string O(DataGridViewRow dong, string tenCot)
        {
            object giaTri = dong.Cells[tenCot].Value;
            return giaTri == null || giaTri == DBNull.Value ? "" : giaTri.ToString();
        }
    }
}

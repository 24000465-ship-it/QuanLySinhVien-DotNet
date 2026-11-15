using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.GUI
{
    /// <summary>
    /// Form cơ sở cho mọi màn hình quản lý danh mục (Khoa, Ngành, Lớp, Sinh viên...).
    /// Lo sẵn phần chung: tìm kiếm, các nút Thêm/Sửa/Xóa/Lưu/Hủy, hỏi xác nhận khi xóa,
    /// bắt lỗi và báo lỗi đúng ô nhập. Form con kế thừa và chỉ ghi đè (override) các
    /// phương thức virtual bên dưới để làm phần riêng của mình (kế thừa + đa hình).
    /// </summary>
    public partial class frmDanhMucBase : Form
    {
        /// <summary>Trạng thái màn hình: đang xem, đang thêm mới hoặc đang sửa.</summary>
        protected enum CheDo { Xem, Them, Sua }

        protected CheDo cheDoHienTai = CheDo.Xem;

        public frmDanhMucBase()
        {
            InitializeComponent();
        }

        // ===================== Các phương thức form con ghi đè =====================

        /// <summary>Chuẩn bị riêng của form con (nạp ComboBox...), chạy một lần trước khi tải danh sách.</summary>
        protected virtual void KhoiTao() { }

        /// <summary>Nạp danh sách lên lưới theo từ khóa tìm kiếm.</summary>
        protected virtual void TaiDuLieu(string tuKhoa) { }

        /// <summary>Đưa dữ liệu dòng đang chọn lên các ô nhập.</summary>
        protected virtual void HienThiDong(DataGridViewRow dong) { }

        /// <summary>Xóa trắng các ô nhập (khi bấm Thêm).</summary>
        protected virtual void XoaTrang() { }

        /// <summary>Bật/tắt các ô nhập; dangThem = true khi thêm mới (lúc này mới được nhập mã).</summary>
        protected virtual void ChoPhepNhap(bool choPhep, bool dangThem) { }

        /// <summary>Đọc các ô nhập, gọi BUS để thêm mới.</summary>
        protected virtual void LuuThem() { }

        /// <summary>Đọc các ô nhập, gọi BUS để cập nhật.</summary>
        protected virtual void LuuSua() { }

        /// <summary>Gọi BUS để xóa bản ghi đang chọn.</summary>
        protected virtual void XoaBanGhi() { }

        /// <summary>Tên hiển thị của bản ghi đang chọn, dùng trong câu hỏi xác nhận xóa.</summary>
        protected virtual string MoTaBanGhiDangChon()
        {
            return "bản ghi này";
        }

        /// <summary>Tiêu đề file Excel khi xuất danh sách.</summary>
        protected virtual string TieuDeXuatExcel()
        {
            return Text;
        }

        // ===================== Phần xử lý chung =====================

        private void frmDanhMucBase_Load(object sender, EventArgs e)
        {
            // Không chạy khi đang mở form trong cửa sổ thiết kế của Visual Studio
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

        /// <summary>Nạp lại danh sách theo ô tìm kiếm, bắt lỗi kết nối nếu có.</summary>
        protected void NapLai()
        {
            try
            {
                TaiDuLieu(txtTimKiem.Text.Trim());
                lblTongSo.Text = "Tổng số: " + dgvDanhSach.Rows.Count;
                // Có dữ liệu thì chọn sẵn dòng đầu để các ô thông tin hiện bản ghi tương ứng
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
            // R08: mọi thao tác xóa phải hỏi xác nhận
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

        /// <summary>Giá trị ô của dòng theo tên cột (rỗng nếu NULL).</summary>
        protected static string O(DataGridViewRow dong, string tenCot)
        {
            object giaTri = dong.Cells[tenCot].Value;
            return giaTri == null || giaTri == DBNull.Value ? "" : giaTri.ToString();
        }
    }
}

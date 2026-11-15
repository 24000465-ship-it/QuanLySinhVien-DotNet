using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    /// <summary>Nghiệp vụ quản lý khoa (F04). Đây là module mẫu: các danh mục khác viết theo đúng khuôn này.</summary>
    public class KhoaBUS : IDanhMucBUS<Khoa>
    {
        private readonly KhoaDAL dal = new KhoaDAL();

        public DataTable LayDanhSach(string tuKhoa)
        {
            return dal.LayDanhSach(tuKhoa ?? "");
        }

        public void Them(Khoa khoa)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(khoa);
            dal.Them(khoa);
        }

        public void Sua(Khoa khoa)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(khoa);
            dal.Sua(khoa);
        }

        public void Xoa(string maKhoa)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            // R08: không xóa khoa đang có ngành hoặc giảng viên
            if (dal.DemPhuThuoc(maKhoa) > 0)
                throw new LoiNghiepVu("Không thể xóa khoa đang có ngành hoặc giảng viên.");
            dal.Xoa(maKhoa);
        }

        /// <summary>Kiểm tra dữ liệu trước khi lưu (R09: trường bắt buộc không để trống).</summary>
        private void KiemTra(Khoa khoa)
        {
            if (string.IsNullOrWhiteSpace(khoa.MaKhoa))
                throw new LoiNghiepVu("Mã khoa không được để trống.", "MaKhoa");
            if (khoa.MaKhoa.Trim().Length > 10)
                throw new LoiNghiepVu("Mã khoa tối đa 10 ký tự.", "MaKhoa");
            if (string.IsNullOrWhiteSpace(khoa.TenKhoa))
                throw new LoiNghiepVu("Tên khoa không được để trống.", "TenKhoa");
            khoa.MaKhoa = khoa.MaKhoa.Trim().ToUpper();
            khoa.TenKhoa = khoa.TenKhoa.Trim();
        }
    }
}

using System.Data;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>
    /// Hợp đồng chung cho các danh mục đơn giản (Khoa, Ngành, Lớp, Học kỳ, Môn học):
    /// interface định nghĩa "làm gì", mỗi lớp BUS định nghĩa "làm như thế nào".
    /// </summary>
    /// <typeparam name="T">Lớp thực thể của danh mục, ví dụ Khoa.</typeparam>
    public interface IDanhMucBUS<T>
    {
        /// <summary>Lấy danh sách, lọc theo từ khóa (mã hoặc tên); từ khóa rỗng = lấy tất cả.</summary>
        DataTable LayDanhSach(string tuKhoa);

        /// <summary>Kiểm tra hợp lệ rồi thêm mới.</summary>
        void Them(T doiTuong);

        /// <summary>Kiểm tra hợp lệ rồi cập nhật (không đổi mã).</summary>
        void Sua(T doiTuong);

        /// <summary>Kiểm tra ràng buộc xóa (R08) rồi xóa.</summary>
        void Xoa(string ma);
    }
}

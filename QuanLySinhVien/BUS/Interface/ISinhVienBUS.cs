using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>Nghiệp vụ quản lý sinh viên (F03).</summary>
    public interface ISinhVienBUS
    {
        DataTable LayDanhSach(string tuKhoa, string maLop);

        /// <summary>Thêm sinh viên; hệ thống tự sinh mã (R05) và trả về mã vừa sinh.</summary>
        string Them(SinhVien sinhVien);

        /// <summary>Sửa thông tin; không cho đổi lớp nếu sinh viên đã có điểm (R08).</summary>
        void Sua(SinhVien sinhVien);

        /// <summary>Xóa; không cho xóa sinh viên đã có điểm (R08).</summary>
        void Xoa(string maSV);
    }
}

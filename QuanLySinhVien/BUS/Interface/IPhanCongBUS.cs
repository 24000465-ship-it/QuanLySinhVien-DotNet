using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>Nghiệp vụ phân công giảng viên (F07, R12).</summary>
    public interface IPhanCongBUS
    {
        DataTable LayDanhSach(string maLop, string maHocKy);

        void Luu(PhanCong phanCong);

        /// <summary>Các lớp - môn giảng viên được phân công trong học kỳ (R07).</summary>
        DataTable LayCuaGiangVien(string maGV, string maHocKy);
    }
}

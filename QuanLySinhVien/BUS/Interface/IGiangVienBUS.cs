using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>Nghiệp vụ quản lý giảng viên (F04).</summary>
    public interface IGiangVienBUS
    {
        DataTable LayDanhSach(string tuKhoa, string maKhoa);

        void Them(GiangVien giangVien);

        void Sua(GiangVien giangVien);

        void Xoa(string maGV);
    }
}

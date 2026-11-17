using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    public interface IPhanCongBUS
    {
        DataTable LayDanhSach(string maLop, string maHocKy);

        void Luu(PhanCong phanCong);

        DataTable LayCuaGiangVien(string maGV, string maHocKy);
    }
}

using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    public interface ISinhVienBUS
    {
        DataTable LayDanhSach(string tuKhoa, string maLop);

        string Them(SinhVien sinhVien);

        void Sua(SinhVien sinhVien);

        void Xoa(string maSV);
    }
}

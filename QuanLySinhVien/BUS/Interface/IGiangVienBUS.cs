using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    public interface IGiangVienBUS
    {
        DataTable LayDanhSach(string tuKhoa, string maKhoa);

        void Them(GiangVien giangVien);

        void Sua(GiangVien giangVien);

        void Xoa(string maGV);
    }
}

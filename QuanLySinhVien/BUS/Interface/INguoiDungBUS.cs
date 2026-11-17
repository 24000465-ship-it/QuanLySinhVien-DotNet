using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    public interface INguoiDungBUS
    {
        NguoiDung DangNhap(string tenDangNhap, string matKhau);

        void DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhan);

        DataTable LayDanhSach(string tuKhoa);

        void Them(NguoiDung nguoiDung, string matKhau);

        void Sua(NguoiDung nguoiDung);

        void KhoaHoacMoKhoa(string tenDangNhap, bool hoatDong);

        string CapLaiMatKhau(string tenDangNhap);
    }
}

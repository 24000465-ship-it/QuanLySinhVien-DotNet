using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>Nghiệp vụ tài khoản: đăng nhập, đổi mật khẩu (F01) và quản lý tài khoản (F02).</summary>
    public interface INguoiDungBUS
    {
        NguoiDung DangNhap(string tenDangNhap, string matKhau);

        void DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhan);

        DataTable LayDanhSach(string tuKhoa);

        void Them(NguoiDung nguoiDung, string matKhau);

        void Sua(NguoiDung nguoiDung);

        void KhoaHoacMoKhoa(string tenDangNhap, bool hoatDong);

        /// <summary>Đặt lại mật khẩu mặc định, trả về mật khẩu mới để báo cho người dùng.</summary>
        string CapLaiMatKhau(string tenDangNhap);
    }
}

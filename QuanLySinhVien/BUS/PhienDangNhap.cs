using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public static class PhienDangNhap
    {
        public static NguoiDung NguoiDungHienTai { get; private set; }

        public static bool DaDangNhap
        {
            get { return NguoiDungHienTai != null; }
        }

        public static void BatDau(NguoiDung nguoiDung)
        {
            NguoiDungHienTai = nguoiDung;
        }

        public static void KetThuc()
        {
            NguoiDungHienTai = null;
        }

        public static void YeuCauQuanLyDaoTao()
        {
            if (!DaDangNhap || !NguoiDungHienTai.LaQuanLyDaoTao)
                throw new LoiNghiepVu("Bạn không có quyền thực hiện chức năng này.");
        }

        public static void YeuCauAdmin()
        {
            if (!DaDangNhap || NguoiDungHienTai.VaiTro != NguoiDung.VaiTroAdmin)
                throw new LoiNghiepVu("Chỉ quản trị viên mới được thực hiện chức năng này.");
        }
    }
}

using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public class NguoiDungBUS : INguoiDungBUS
    {
        public const string MatKhauMacDinh = "123456";
        private const int DoDaiMatKhauToiThieu = 6;

        private readonly NguoiDungDAL dal = new NguoiDungDAL();

        public bool KiemTraKetNoi(out string thongBaoLoi)
        {
            return DBHelper.KiemTraKetNoi(out thongBaoLoi);
        }

        public NguoiDung DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new LoiNghiepVu("Vui lòng nhập tên đăng nhập.", "TenDangNhap");
            if (string.IsNullOrEmpty(matKhau))
                throw new LoiNghiepVu("Vui lòng nhập mật khẩu.", "MatKhau");

            NguoiDung nd = dal.DangNhap(tenDangNhap.Trim(), TienIch.BamMatKhau(matKhau));
            if (nd == null)
                throw new LoiNghiepVu("Tên đăng nhập hoặc mật khẩu không đúng.", "MatKhau");
            if (!nd.TrangThai)
                throw new LoiNghiepVu("Tài khoản đã bị khóa, vui lòng liên hệ quản trị viên.");

            PhienDangNhap.BatDau(nd);
            return nd;
        }

        public void DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhan)
        {
            if (string.IsNullOrEmpty(matKhauCu))
                throw new LoiNghiepVu("Vui lòng nhập mật khẩu hiện tại.", "MatKhauCu");
            KiemTraMatKhauMoi(matKhauMoi, "MatKhauMoi");
            if (matKhauMoi != xacNhan)
                throw new LoiNghiepVu("Mật khẩu xác nhận không khớp.", "XacNhan");
            if (matKhauMoi == matKhauCu)
                throw new LoiNghiepVu("Mật khẩu mới phải khác mật khẩu hiện tại.", "MatKhauMoi");

            int soDong = dal.DoiMatKhau(PhienDangNhap.NguoiDungHienTai.TenDangNhap,
                TienIch.BamMatKhau(matKhauCu), TienIch.BamMatKhau(matKhauMoi));
            if (soDong == 0)
                throw new LoiNghiepVu("Mật khẩu hiện tại không đúng.", "MatKhauCu");
        }

        public DataTable LayDanhSach(string tuKhoa)
        {
            PhienDangNhap.YeuCauAdmin();
            return dal.LayDanhSach(tuKhoa ?? "");
        }

        public void Them(NguoiDung nguoiDung, string matKhau)
        {
            PhienDangNhap.YeuCauAdmin();
            KiemTraThongTin(nguoiDung);
            KiemTraMatKhauMoi(matKhau, "MatKhau");
            if (dal.TonTai(nguoiDung.TenDangNhap))
                throw new LoiNghiepVu("Tên đăng nhập đã tồn tại.", "TenDangNhap");
            dal.Them(nguoiDung, TienIch.BamMatKhau(matKhau));
        }

        public void Sua(NguoiDung nguoiDung)
        {
            PhienDangNhap.YeuCauAdmin();
            KiemTraThongTin(nguoiDung);
            if (nguoiDung.TenDangNhap == PhienDangNhap.NguoiDungHienTai.TenDangNhap
                && nguoiDung.VaiTro != NguoiDung.VaiTroAdmin)
                throw new LoiNghiepVu("Không thể tự bỏ quyền quản trị của chính mình.", "VaiTro");
            dal.Sua(nguoiDung);
        }

        public void KhoaHoacMoKhoa(string tenDangNhap, bool hoatDong)
        {
            PhienDangNhap.YeuCauAdmin();
            if (!hoatDong && tenDangNhap == PhienDangNhap.NguoiDungHienTai.TenDangNhap)
                throw new LoiNghiepVu("Không thể tự khóa tài khoản đang đăng nhập.");
            dal.DatTrangThai(tenDangNhap, hoatDong);
        }

        public string CapLaiMatKhau(string tenDangNhap)
        {
            PhienDangNhap.YeuCauAdmin();
            dal.CapLaiMatKhau(tenDangNhap, TienIch.BamMatKhau(MatKhauMacDinh));
            return MatKhauMacDinh;
        }

        private void KiemTraThongTin(NguoiDung nd)
        {
            if (string.IsNullOrWhiteSpace(nd.TenDangNhap))
                throw new LoiNghiepVu("Tên đăng nhập không được để trống.", "TenDangNhap");
            if (nd.TenDangNhap.Contains(" "))
                throw new LoiNghiepVu("Tên đăng nhập không được chứa khoảng trắng.", "TenDangNhap");
            if (string.IsNullOrWhiteSpace(nd.HoTen))
                throw new LoiNghiepVu("Họ tên không được để trống.", "HoTen");
            if (string.IsNullOrEmpty(nd.VaiTro))
                throw new LoiNghiepVu("Vui lòng chọn vai trò.", "VaiTro");
            nd.HoTen = TienIch.ChuanHoaHoTen(nd.HoTen);
        }

        private void KiemTraMatKhauMoi(string matKhau, string tenTruong)
        {
            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < DoDaiMatKhauToiThieu)
                throw new LoiNghiepVu("Mật khẩu phải có ít nhất " + DoDaiMatKhauToiThieu + " ký tự.", tenTruong);
        }
    }
}

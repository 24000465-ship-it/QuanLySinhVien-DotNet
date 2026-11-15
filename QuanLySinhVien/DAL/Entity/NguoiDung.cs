namespace QuanLySinhVien.DAL.Entity
{
    /// <summary>
    /// Tài khoản đăng nhập phần mềm.
    /// </summary>
    public class NguoiDung
    {
        public const string VaiTroAdmin = "Admin";
        public const string VaiTroCanBoDaoTao = "CanBoDaoTao";
        public const string VaiTroGiangVien = "GiangVien";

        public string TenDangNhap { get; set; }

        public string HoTen { get; set; }

        /// <summary>Một trong ba giá trị: Admin, CanBoDaoTao, GiangVien.</summary>
        public string VaiTro { get; set; }

        /// <summary>true: đang hoạt động; false: bị khóa.</summary>
        public bool TrangThai { get; set; }

        /// <summary>Mã giảng viên gắn với tài khoản (chỉ có khi vai trò là GiangVien).</summary>
        public string MaGV { get; set; }

        /// <summary>Admin có toàn bộ quyền của Cán bộ đào tạo.</summary>
        public bool LaQuanLyDaoTao
        {
            get { return VaiTro == VaiTroAdmin || VaiTro == VaiTroCanBoDaoTao; }
        }

        /// <summary>Tên vai trò tiếng Việt để hiển thị.</summary>
        public static string TenVaiTro(string vaiTro)
        {
            switch (vaiTro)
            {
                case VaiTroAdmin: return "Quản trị";
                case VaiTroCanBoDaoTao: return "Cán bộ đào tạo";
                case VaiTroGiangVien: return "Giảng viên";
                default: return vaiTro;
            }
        }
    }
}

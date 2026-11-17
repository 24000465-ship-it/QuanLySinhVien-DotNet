namespace QuanLySinhVien.DAL.Entity
{
    public class NguoiDung
    {
        public const string VaiTroAdmin = "Admin";
        public const string VaiTroCanBoDaoTao = "CanBoDaoTao";
        public const string VaiTroGiangVien = "GiangVien";

        public string TenDangNhap { get; set; }

        public string HoTen { get; set; }

        public string VaiTro { get; set; }

        public bool TrangThai { get; set; }

        public string MaGV { get; set; }

        public bool LaQuanLyDaoTao
        {
            get { return VaiTro == VaiTroAdmin || VaiTro == VaiTroCanBoDaoTao; }
        }

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

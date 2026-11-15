namespace QuanLySinhVien.DAL.Entity
{
    /// <summary>
    /// Giảng viên — kế thừa lớp Nguoi, bổ sung mã GV, email, khoa và tài khoản đăng nhập.
    /// </summary>
    public class GiangVien : Nguoi
    {
        public string MaGV { get; set; }

        public string Email { get; set; }

        public string MaKhoa { get; set; }

        /// <summary>Tài khoản dùng để nhập điểm; để trống nếu giảng viên chưa có tài khoản.</summary>
        public string TenDangNhap { get; set; }

        public override string MaDinhDanh
        {
            get { return MaGV; }
        }

        public override string VaiTro()
        {
            return "Giảng viên";
        }
    }
}

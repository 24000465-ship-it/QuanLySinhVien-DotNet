namespace QuanLySinhVien.DAL.Entity
{
    public class GiangVien : Nguoi
    {
        public string MaGV { get; set; }

        public string Email { get; set; }

        public string MaKhoa { get; set; }

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

namespace QuanLySinhVien.DAL.Entity
{
    public class SinhVien : Nguoi
    {
        public static int SoLuongDaTao { get; private set; }

        public string MaSV { get; set; }

        public string MaLop { get; set; }

        public SinhVien()
        {
            SoLuongDaTao++;
        }

        public override string MaDinhDanh
        {
            get { return MaSV; }
        }

        public override string VaiTro()
        {
            return "Sinh viên";
        }
    }
}

namespace QuanLySinhVien.DAL.Entity
{
    /// <summary>
    /// Sinh viên — kế thừa lớp Nguoi, bổ sung mã sinh viên và lớp.
    /// </summary>
    public class SinhVien : Nguoi
    {
        /// <summary>Số đối tượng SinhVien đã tạo trong chương trình (thành viên static, dùng chung cho cả lớp).</summary>
        public static int SoLuongDaTao { get; private set; }

        /// <summary>Mã sinh viên do hệ thống tự sinh (R05), không sửa được.</summary>
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

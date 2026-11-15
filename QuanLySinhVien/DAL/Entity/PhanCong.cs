namespace QuanLySinhVien.DAL.Entity
{
    /// <summary>Giảng viên dạy một môn cho một lớp trong một học kỳ (R12: mỗi bộ ba chỉ một giảng viên).</summary>
    public class PhanCong
    {
        public string MaLop { get; set; }

        public string MaMon { get; set; }

        public string MaHocKy { get; set; }

        public string MaGV { get; set; }
    }
}

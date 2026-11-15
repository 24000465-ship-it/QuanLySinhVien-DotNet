namespace QuanLySinhVien.DAL.Entity
{
    public class Lop
    {
        public string MaLop { get; set; }

        public string TenLop { get; set; }

        public string MaNganh { get; set; }

        /// <summary>Năm nhập học của lớp, ví dụ 2026.</summary>
        public int KhoaHoc { get; set; }
    }
}

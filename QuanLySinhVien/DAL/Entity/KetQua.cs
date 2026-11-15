using QuanLySinhVien.BUS;

namespace QuanLySinhVien.DAL.Entity
{
    /// <summary>
    /// Kết quả học tập của một sinh viên với một môn trong một học kỳ.
    /// Các điểm thành phần tự kiểm tra hợp lệ khi gán (R01); điểm học phần được lớp BUS tính.
    /// </summary>
    public class KetQua
    {
        private decimal? diemCC;
        private decimal? diemGK;
        private decimal? diemKTHP;

        public string MaSV { get; set; }

        public string MaMon { get; set; }

        public string MaHocKy { get; set; }

        public decimal? DiemCC
        {
            get { return diemCC; }
            set { diemCC = KiemTraDiem(value, "chuyên cần"); }
        }

        public decimal? DiemGK
        {
            get { return diemGK; }
            set { diemGK = KiemTraDiem(value, "giữa kỳ"); }
        }

        public decimal? DiemKTHP
        {
            get { return diemKTHP; }
            set { diemKTHP = KiemTraDiem(value, "kết thúc học phần"); }
        }

        public decimal? DiemHP { get; set; }

        public string DiemChu { get; set; }

        public decimal? DiemHe4 { get; set; }

        /// <summary>Đủ 3 điểm thành phần thì mới tính điểm học phần (R10).</summary>
        public bool DuDiemThanhPhan
        {
            get { return diemCC.HasValue && diemGK.HasValue && diemKTHP.HasValue; }
        }

        private decimal? KiemTraDiem(decimal? diem, string tenDiem)
        {
            if (diem.HasValue && !QuyTacDiem.LaDiemHopLe(diem.Value))
            {
                throw new LoiNghiepVu(string.Format(
                    "Sinh viên {0}: điểm {1} phải từ 0 đến 10 và có tối đa 1 chữ số thập phân.", MaSV, tenDiem));
            }
            return diem;
        }
    }
}

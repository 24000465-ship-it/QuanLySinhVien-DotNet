using QuanLySinhVien.BUS;

namespace QuanLySinhVien.DAL.Entity
{
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

using System;

namespace QuanLySinhVien.BUS
{
    /// <summary>
    /// Các quy tắc tính điểm (R01–R04) viết thành phương thức tĩnh để mọi nơi dùng chung một công thức.
    /// </summary>
    public static class QuyTacDiem
    {
        public const decimal HeSoCC = 0.1m;
        public const decimal HeSoGK = 0.3m;
        public const decimal HeSoKTHP = 0.6m;

        /// <summary>R01: điểm từ 0 đến 10, tối đa 1 chữ số thập phân.</summary>
        public static bool LaDiemHopLe(decimal diem)
        {
            return diem >= 0 && diem <= 10 && decimal.Round(diem, 1) == diem;
        }

        /// <summary>
        /// R02: điểm học phần = CC × 10% + GK × 30% + KTHP × 60%, làm tròn 1 chữ số thập phân
        /// (làm tròn kiểu thông thường: 0,05 → 0,1). Ví dụ: 9; 7; 6 → 6,6.
        /// </summary>
        public static decimal TinhDiemHocPhan(decimal cc, decimal gk, decimal kthp)
        {
            decimal diem = cc * HeSoCC + gk * HeSoGK + kthp * HeSoKTHP;
            return Math.Round(diem, 1, MidpointRounding.AwayFromZero);
        }

        /// <summary>R03: quy đổi điểm học phần sang điểm chữ.</summary>
        public static string QuyDoiDiemChu(decimal diemHP)
        {
            if (diemHP >= 8.5m) return "A";
            if (diemHP >= 7.0m) return "B";
            if (diemHP >= 5.5m) return "C";
            if (diemHP >= 4.0m) return "D";
            return "F";
        }

        /// <summary>R03: quy đổi điểm học phần sang thang 4.</summary>
        public static decimal QuyDoiHe4(decimal diemHP)
        {
            if (diemHP >= 8.5m) return 4;
            if (diemHP >= 7.0m) return 3;
            if (diemHP >= 5.5m) return 2;
            if (diemHP >= 4.0m) return 1;
            return 0;
        }

        /// <summary>R03: điểm dưới 4,0 là trượt.</summary>
        public static bool LaDat(decimal diemHP)
        {
            return diemHP >= 4.0m;
        }

        /// <summary>R04: xếp loại theo điểm trung bình học kỳ thang 4.</summary>
        public static string XepLoaiHocKy(decimal diemTB)
        {
            if (diemTB >= 3.6m) return "Xuất sắc";
            if (diemTB >= 3.2m) return "Giỏi";
            if (diemTB >= 2.5m) return "Khá";
            if (diemTB >= 2.0m) return "Trung bình";
            return "Yếu";
        }
    }
}

using System;

namespace QuanLySinhVien.BUS
{
    public static class QuyTacDiem
    {
        public const decimal HeSoCC = 0.1m;
        public const decimal HeSoGK = 0.3m;
        public const decimal HeSoKTHP = 0.6m;

        public static bool LaDiemHopLe(decimal diem)
        {
            return diem >= 0 && diem <= 10 && decimal.Round(diem, 1) == diem;
        }

        public static decimal TinhDiemHocPhan(decimal cc, decimal gk, decimal kthp)
        {
            decimal diem = cc * HeSoCC + gk * HeSoGK + kthp * HeSoKTHP;
            return Math.Round(diem, 1, MidpointRounding.AwayFromZero);
        }

        public static string QuyDoiDiemChu(decimal diemHP)
        {
            if (diemHP >= 8.5m) return "A";
            if (diemHP >= 7.0m) return "B";
            if (diemHP >= 5.5m) return "C";
            if (diemHP >= 4.0m) return "D";
            return "F";
        }

        public static decimal QuyDoiHe4(decimal diemHP)
        {
            if (diemHP >= 8.5m) return 4;
            if (diemHP >= 7.0m) return 3;
            if (diemHP >= 5.5m) return 2;
            if (diemHP >= 4.0m) return 1;
            return 0;
        }

        public static bool LaDat(decimal diemHP)
        {
            return diemHP >= 4.0m;
        }

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

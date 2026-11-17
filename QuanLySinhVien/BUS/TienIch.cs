using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien.BUS
{
    public static class TienIch
    {
        public static string BamMatKhau(string matKhau)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bam = sha.ComputeHash(Encoding.UTF8.GetBytes(matKhau ?? ""));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bam)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static bool LaSoDienThoaiHopLe(string soDienThoai)
        {
            return soDienThoai != null && Regex.IsMatch(soDienThoai.Trim(), @"^\d{10}$");
        }

        public static bool LaEmailHopLe(string email)
        {
            return string.IsNullOrWhiteSpace(email)
                || Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static string ChuanHoaHoTen(string hoTen)
        {
            string gon = Regex.Replace((hoTen ?? "").Trim(), @"\s+", " ").ToLower();
            return CultureInfo.GetCultureInfo("vi-VN").TextInfo.ToTitleCase(gon);
        }

        public static bool LaMaHocKyHopLe(string maHocKy)
        {
            return maHocKy != null && Regex.IsMatch(maHocKy, @"^\d{4}[1-3]$");
        }

        public static string MaHocKyHienTai(DateTime ngay)
        {
            int namBatDau = ngay.Month >= 8 ? ngay.Year : ngay.Year - 1;
            int ky = (ngay.Month >= 8 || ngay.Month == 1) ? 1 : 2;
            return namBatDau.ToString() + ky;
        }

        public static string TaoTenHocKy(string maHocKy)
        {
            int nam = int.Parse(maHocKy.Substring(0, 4));
            return string.Format("Học kỳ {0} năm học {1}-{2}", maHocKy[4], nam, nam + 1);
        }

        public static decimal? DocDiem(string chuoi)
        {
            if (string.IsNullOrWhiteSpace(chuoi))
            {
                return null;
            }
            decimal diem;
            string chuan = chuoi.Trim().Replace(',', '.');
            if (!decimal.TryParse(chuan, NumberStyles.Number, CultureInfo.InvariantCulture, out diem))
            {
                throw new LoiNghiepVu("Điểm \"" + chuoi + "\" không phải là số.");
            }
            return diem;
        }
    }
}

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien.BUS
{
    /// <summary>
    /// Các phương thức tiện ích dùng chung (class method — phương thức tĩnh, gọi qua tên lớp,
    /// không cần tạo đối tượng). Ví dụ: TienIch.BamMatKhau("123456").
    /// </summary>
    public static class TienIch
    {
        /// <summary>Băm mật khẩu bằng SHA-256, trả về chuỗi hex 64 ký tự thường (khớp hàm SHA2 của MySQL).</summary>
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

        /// <summary>Số điện thoại hợp lệ: đúng 10 chữ số (R09).</summary>
        public static bool LaSoDienThoaiHopLe(string soDienThoai)
        {
            return soDienThoai != null && Regex.IsMatch(soDienThoai.Trim(), @"^\d{10}$");
        }

        /// <summary>Email hợp lệ (cho phép để trống).</summary>
        public static bool LaEmailHopLe(string email)
        {
            return string.IsNullOrWhiteSpace(email)
                || Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        /// <summary>Chuẩn hóa họ tên: bỏ khoảng trắng thừa, viết hoa chữ cái đầu mỗi từ. "  nguyễn  văn a" → "Nguyễn Văn A".</summary>
        public static string ChuanHoaHoTen(string hoTen)
        {
            string gon = Regex.Replace((hoTen ?? "").Trim(), @"\s+", " ").ToLower();
            return CultureInfo.GetCultureInfo("vi-VN").TextInfo.ToTitleCase(gon);
        }

        /// <summary>Mã học kỳ hợp lệ dạng NNNNK, ví dụ 20261 (R11).</summary>
        public static bool LaMaHocKyHopLe(string maHocKy)
        {
            return maHocKy != null && Regex.IsMatch(maHocKy, @"^\d{4}[1-3]$");
        }

        /// <summary>
        /// Mã học kỳ đang diễn ra theo ngày hôm nay: năm học bắt đầu tháng 8;
        /// tháng 8 - tháng 1 là học kỳ 1, tháng 2 - tháng 7 là học kỳ 2. Ví dụ 13/11/2026 → 20261.
        /// </summary>
        public static string MaHocKyHienTai(DateTime ngay)
        {
            int namBatDau = ngay.Month >= 8 ? ngay.Year : ngay.Year - 1;
            int ky = (ngay.Month >= 8 || ngay.Month == 1) ? 1 : 2;
            return namBatDau.ToString() + ky;
        }

        /// <summary>Tên học kỳ từ mã: 20261 → "Học kỳ 1 năm học 2026-2027".</summary>
        public static string TaoTenHocKy(string maHocKy)
        {
            int nam = int.Parse(maHocKy.Substring(0, 4));
            return string.Format("Học kỳ {0} năm học {1}-{2}", maHocKy[4], nam, nam + 1);
        }

        /// <summary>Đổi chuỗi người dùng nhập thành điểm; ô trống trả về null. Chấp nhận cả dấu phẩy và dấu chấm.</summary>
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

using System;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.DAL.Entity
{
    /// <summary>
    /// Lớp trừu tượng chứa thông tin chung của một người (trừu tượng hóa).
    /// SinhVien và GiangVien kế thừa lớp này (kế thừa).
    /// </summary>
    public abstract class Nguoi
    {
        private string hoTen;
        private string soDienThoai;

        /// <summary>Họ tên: bắt buộc, tự chuẩn hóa khoảng trắng và viết hoa chữ cái đầu (đóng gói).</summary>
        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new LoiNghiepVu("Họ tên không được để trống.", "HoTen");
                hoTen = TienIch.ChuanHoaHoTen(value);
            }
        }

        public DateTime NgaySinh { get; set; }

        public string GioiTinh { get; set; }

        /// <summary>Số điện thoại: đúng 10 chữ số (R09).</summary>
        public string SoDienThoai
        {
            get { return soDienThoai; }
            set
            {
                if (!TienIch.LaSoDienThoaiHopLe(value))
                    throw new LoiNghiepVu("Số điện thoại phải gồm đúng 10 chữ số.", "SoDienThoai");
                soDienThoai = value.Trim();
            }
        }

        /// <summary>Mã định danh của người (mã SV hoặc mã GV) — mỗi lớp con tự định nghĩa.</summary>
        public abstract string MaDinhDanh { get; }

        /// <summary>Tên vai trò hiển thị — mỗi lớp con trả về khác nhau (đa hình).</summary>
        public abstract string VaiTro();

        /// <summary>Tuổi tính theo năm hiện tại.</summary>
        public int Tuoi()
        {
            return DateTime.Today.Year - NgaySinh.Year;
        }

        /// <summary>Ghi đè ToString của lớp object (đa hình lúc chạy).</summary>
        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", VaiTro(), MaDinhDanh, HoTen);
        }
    }
}

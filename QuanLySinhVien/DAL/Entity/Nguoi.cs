using System;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.DAL.Entity
{
    public abstract class Nguoi
    {
        private string hoTen;
        private string soDienThoai;

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

        public abstract string MaDinhDanh { get; }

        public abstract string VaiTro();

        public int Tuoi()
        {
            return DateTime.Today.Year - NgaySinh.Year;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", VaiTro(), MaDinhDanh, HoTen);
        }
    }
}

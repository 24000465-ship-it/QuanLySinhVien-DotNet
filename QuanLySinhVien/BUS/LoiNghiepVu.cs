using System;

namespace QuanLySinhVien.BUS
{
    public class LoiNghiepVu : ApplicationException
    {
        public string TenTruong { get; private set; }

        public LoiNghiepVu(string thongBao) : base(thongBao)
        {
        }

        public LoiNghiepVu(string thongBao, string tenTruong) : base(thongBao)
        {
            TenTruong = tenTruong;
        }
    }
}

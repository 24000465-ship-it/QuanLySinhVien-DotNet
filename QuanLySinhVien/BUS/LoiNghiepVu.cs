using System;

namespace QuanLySinhVien.BUS
{
    /// <summary>
    /// Ngoại lệ do vi phạm quy tắc nghiệp vụ (nhập sai, trùng mã, không đủ quyền...).
    /// Kế thừa ApplicationException — lớp cơ sở cho ngoại lệ do chương trình tự định nghĩa.
    /// Giao diện bắt ngoại lệ này để báo lỗi đúng ô nhập sai.
    /// </summary>
    public class LoiNghiepVu : ApplicationException
    {
        /// <summary>Tên thuộc tính bị lỗi (ví dụ "HoTen"); form tìm ô nhập có tên kết thúc bằng giá trị này.</summary>
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

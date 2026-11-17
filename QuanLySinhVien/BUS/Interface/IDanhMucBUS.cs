using System.Data;

namespace QuanLySinhVien.BUS.Interface
{
    public interface IDanhMucBUS<T>
    {
        DataTable LayDanhSach(string tuKhoa);

        void Them(T doiTuong);

        void Sua(T doiTuong);

        void Xoa(string ma);
    }
}

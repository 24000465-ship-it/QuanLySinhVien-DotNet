using System.Collections.Generic;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>Nghiệp vụ điểm: nhập điểm (F08), tự tính điểm (F09), xem bảng điểm (F10).</summary>
    public interface IKetQuaBUS
    {
        DataTable LayBangDiemLopMon(string maLop, string maMon, string maHocKy);

        DataTable LayBangDiemSinhVien(string maSV);

        /// <summary>Tính điểm học phần, điểm chữ, thang 4 cho một kết quả (R02, R03, R10).</summary>
        void TinhDiem(KetQua ketQua);

        /// <summary>Kiểm tra quyền (R07), tính điểm rồi lưu cả bảng điểm.</summary>
        void LuuBangDiem(string maLop, string maMon, string maHocKy, List<KetQua> danhSach);
    }
}

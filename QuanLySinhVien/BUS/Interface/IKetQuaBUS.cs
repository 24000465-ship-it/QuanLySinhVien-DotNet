using System.Collections.Generic;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS.Interface
{
    public interface IKetQuaBUS
    {
        DataTable LayBangDiemLopMon(string maLop, string maMon, string maHocKy);

        DataTable LayBangDiemSinhVien(string maSV);

        void TinhDiem(KetQua ketQua);

        void LuuBangDiem(string maLop, string maMon, string maHocKy, List<KetQua> danhSach);
    }
}

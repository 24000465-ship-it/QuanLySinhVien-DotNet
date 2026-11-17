using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    public class LopDAL
    {
        public DataTable LayDanhSach(string tuKhoa)
        {
            return DBHelper.LayBang("sp_Lop_LayDanhSach", DBHelper.TS("@p_TuKhoa", tuKhoa));
        }

        public void Them(Lop lop)
        {
            DBHelper.ThucThi("sp_Lop_Them",
                DBHelper.TS("@p_MaLop", lop.MaLop),
                DBHelper.TS("@p_TenLop", lop.TenLop),
                DBHelper.TS("@p_MaNganh", lop.MaNganh),
                DBHelper.TS("@p_KhoaHoc", lop.KhoaHoc));
        }

        public void Sua(Lop lop)
        {
            DBHelper.ThucThi("sp_Lop_Sua",
                DBHelper.TS("@p_MaLop", lop.MaLop),
                DBHelper.TS("@p_TenLop", lop.TenLop),
                DBHelper.TS("@p_MaNganh", lop.MaNganh),
                DBHelper.TS("@p_KhoaHoc", lop.KhoaHoc));
        }

        public void Xoa(string maLop)
        {
            DBHelper.ThucThi("sp_Lop_Xoa", DBHelper.TS("@p_MaLop", maLop));
        }

        public int DemPhuThuoc(string maLop)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_Lop_DemPhuThuoc", DBHelper.TS("@p_MaLop", maLop)));
        }
    }
}

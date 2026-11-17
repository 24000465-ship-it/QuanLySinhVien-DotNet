using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    public class MonHocDAL
    {
        public DataTable LayDanhSach(string tuKhoa)
        {
            return DBHelper.LayBang("sp_MonHoc_LayDanhSach", DBHelper.TS("@p_TuKhoa", tuKhoa));
        }

        public void Them(MonHoc mon)
        {
            DBHelper.ThucThi("sp_MonHoc_Them",
                DBHelper.TS("@p_MaMon", mon.MaMon),
                DBHelper.TS("@p_TenMon", mon.TenMon),
                DBHelper.TS("@p_SoTinChi", mon.SoTinChi));
        }

        public void Sua(MonHoc mon)
        {
            DBHelper.ThucThi("sp_MonHoc_Sua",
                DBHelper.TS("@p_MaMon", mon.MaMon),
                DBHelper.TS("@p_TenMon", mon.TenMon),
                DBHelper.TS("@p_SoTinChi", mon.SoTinChi));
        }

        public void Xoa(string maMon)
        {
            DBHelper.ThucThi("sp_MonHoc_Xoa", DBHelper.TS("@p_MaMon", maMon));
        }

        public int DemPhuThuoc(string maMon)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_MonHoc_DemPhuThuoc", DBHelper.TS("@p_MaMon", maMon)));
        }
    }
}

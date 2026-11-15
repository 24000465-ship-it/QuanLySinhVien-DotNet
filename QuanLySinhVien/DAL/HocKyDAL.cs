using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    /// <summary>Truy cập bảng HocKy.</summary>
    public class HocKyDAL
    {
        public DataTable LayDanhSach(string tuKhoa)
        {
            return DBHelper.LayBang("sp_HocKy_LayDanhSach", DBHelper.TS("@p_TuKhoa", tuKhoa));
        }

        public void Them(HocKy hocKy)
        {
            DBHelper.ThucThi("sp_HocKy_Them",
                DBHelper.TS("@p_MaHocKy", hocKy.MaHocKy),
                DBHelper.TS("@p_TenHocKy", hocKy.TenHocKy));
        }

        public void Sua(HocKy hocKy)
        {
            DBHelper.ThucThi("sp_HocKy_Sua",
                DBHelper.TS("@p_MaHocKy", hocKy.MaHocKy),
                DBHelper.TS("@p_TenHocKy", hocKy.TenHocKy));
        }

        public void Xoa(string maHocKy)
        {
            DBHelper.ThucThi("sp_HocKy_Xoa", DBHelper.TS("@p_MaHocKy", maHocKy));
        }

        public int DemPhuThuoc(string maHocKy)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_HocKy_DemPhuThuoc", DBHelper.TS("@p_MaHocKy", maHocKy)));
        }
    }
}

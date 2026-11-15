using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    /// <summary>Truy cập bảng Nganh.</summary>
    public class NganhDAL
    {
        public DataTable LayDanhSach(string tuKhoa)
        {
            return DBHelper.LayBang("sp_Nganh_LayDanhSach", DBHelper.TS("@p_TuKhoa", tuKhoa));
        }

        public void Them(Nganh nganh)
        {
            DBHelper.ThucThi("sp_Nganh_Them",
                DBHelper.TS("@p_MaNganh", nganh.MaNganh),
                DBHelper.TS("@p_TenNganh", nganh.TenNganh),
                DBHelper.TS("@p_MaKhoa", nganh.MaKhoa));
        }

        public void Sua(Nganh nganh)
        {
            DBHelper.ThucThi("sp_Nganh_Sua",
                DBHelper.TS("@p_MaNganh", nganh.MaNganh),
                DBHelper.TS("@p_TenNganh", nganh.TenNganh),
                DBHelper.TS("@p_MaKhoa", nganh.MaKhoa));
        }

        public void Xoa(string maNganh)
        {
            DBHelper.ThucThi("sp_Nganh_Xoa", DBHelper.TS("@p_MaNganh", maNganh));
        }

        /// <summary>Số lớp thuộc ngành (R08).</summary>
        public int DemPhuThuoc(string maNganh)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_Nganh_DemPhuThuoc", DBHelper.TS("@p_MaNganh", maNganh)));
        }
    }
}

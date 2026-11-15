using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    /// <summary>Truy cập bảng Khoa.</summary>
    public class KhoaDAL
    {
        public DataTable LayDanhSach(string tuKhoa)
        {
            return DBHelper.LayBang("sp_Khoa_LayDanhSach", DBHelper.TS("@p_TuKhoa", tuKhoa));
        }

        public void Them(Khoa khoa)
        {
            DBHelper.ThucThi("sp_Khoa_Them",
                DBHelper.TS("@p_MaKhoa", khoa.MaKhoa),
                DBHelper.TS("@p_TenKhoa", khoa.TenKhoa));
        }

        public void Sua(Khoa khoa)
        {
            DBHelper.ThucThi("sp_Khoa_Sua",
                DBHelper.TS("@p_MaKhoa", khoa.MaKhoa),
                DBHelper.TS("@p_TenKhoa", khoa.TenKhoa));
        }

        public void Xoa(string maKhoa)
        {
            DBHelper.ThucThi("sp_Khoa_Xoa", DBHelper.TS("@p_MaKhoa", maKhoa));
        }

        /// <summary>Số ngành + giảng viên thuộc khoa (R08).</summary>
        public int DemPhuThuoc(string maKhoa)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_Khoa_DemPhuThuoc", DBHelper.TS("@p_MaKhoa", maKhoa)));
        }
    }
}

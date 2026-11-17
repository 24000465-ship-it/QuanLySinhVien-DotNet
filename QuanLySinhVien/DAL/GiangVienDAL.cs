using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    public class GiangVienDAL
    {
        public DataTable LayDanhSach(string tuKhoa, string maKhoa)
        {
            return DBHelper.LayBang("sp_GiangVien_LayDanhSach",
                DBHelper.TS("@p_TuKhoa", tuKhoa),
                DBHelper.TS("@p_MaKhoa", maKhoa));
        }

        public void Them(GiangVien gv)
        {
            DBHelper.ThucThi("sp_GiangVien_Them", TaoThamSo(gv));
        }

        public void Sua(GiangVien gv)
        {
            DBHelper.ThucThi("sp_GiangVien_Sua", TaoThamSo(gv));
        }

        public void Xoa(string maGV)
        {
            DBHelper.ThucThi("sp_GiangVien_Xoa", DBHelper.TS("@p_MaGV", maGV));
        }

        public int DemPhuThuoc(string maGV)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_GiangVien_DemPhuThuoc", DBHelper.TS("@p_MaGV", maGV)));
        }

        private MySql.Data.MySqlClient.MySqlParameter[] TaoThamSo(GiangVien gv)
        {
            return new[]
            {
                DBHelper.TS("@p_MaGV", gv.MaGV),
                DBHelper.TS("@p_HoTen", gv.HoTen),
                DBHelper.TS("@p_NgaySinh", gv.NgaySinh),
                DBHelper.TS("@p_GioiTinh", gv.GioiTinh),
                DBHelper.TS("@p_SoDienThoai", gv.SoDienThoai),
                DBHelper.TS("@p_Email", gv.Email),
                DBHelper.TS("@p_MaKhoa", gv.MaKhoa),
                DBHelper.TS("@p_TenDangNhap", gv.TenDangNhap ?? "")
            };
        }
    }
}

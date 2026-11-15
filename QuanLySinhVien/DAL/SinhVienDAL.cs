using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    /// <summary>Truy cập bảng SinhVien.</summary>
    public class SinhVienDAL
    {
        /// <summary>Tìm theo mã SV / họ tên và lọc theo lớp (để trống = không lọc).</summary>
        public DataTable LayDanhSach(string tuKhoa, string maLop)
        {
            return DBHelper.LayBang("sp_SinhVien_LayDanhSach",
                DBHelper.TS("@p_TuKhoa", tuKhoa),
                DBHelper.TS("@p_MaLop", maLop));
        }

        /// <summary>Sinh mã sinh viên tiếp theo cho lớp theo quy tắc R05.</summary>
        public string SinhMa(string maLop)
        {
            return Convert.ToString(DBHelper.LayGiaTri("sp_SinhVien_SinhMa", DBHelper.TS("@p_MaLop", maLop)));
        }

        public void Them(SinhVien sv)
        {
            DBHelper.ThucThi("sp_SinhVien_Them", TaoThamSo(sv));
        }

        public void Sua(SinhVien sv)
        {
            DBHelper.ThucThi("sp_SinhVien_Sua", TaoThamSo(sv));
        }

        public void Xoa(string maSV)
        {
            DBHelper.ThucThi("sp_SinhVien_Xoa", DBHelper.TS("@p_MaSV", maSV));
        }

        /// <summary>Số môn sinh viên đã có điểm (R08).</summary>
        public int DemDiem(string maSV)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_SinhVien_DemDiem", DBHelper.TS("@p_MaSV", maSV)));
        }

        public string LayMaLop(string maSV)
        {
            return Convert.ToString(DBHelper.LayGiaTri("sp_SinhVien_LayMaLop", DBHelper.TS("@p_MaSV", maSV)));
        }

        private MySql.Data.MySqlClient.MySqlParameter[] TaoThamSo(SinhVien sv)
        {
            return new[]
            {
                DBHelper.TS("@p_MaSV", sv.MaSV),
                DBHelper.TS("@p_HoTen", sv.HoTen),
                DBHelper.TS("@p_NgaySinh", sv.NgaySinh),
                DBHelper.TS("@p_GioiTinh", sv.GioiTinh),
                DBHelper.TS("@p_SoDienThoai", sv.SoDienThoai),
                DBHelper.TS("@p_MaLop", sv.MaLop)
            };
        }
    }
}

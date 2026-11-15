using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    /// <summary>Truy cập bảng PhanCong.</summary>
    public class PhanCongDAL
    {
        public DataTable LayDanhSach(string maLop, string maHocKy)
        {
            return DBHelper.LayBang("sp_PhanCong_LayDanhSach",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaHocKy", maHocKy));
        }

        /// <summary>Số dòng kết quả của lớp - môn - học kỳ: bằng 0 nghĩa là chưa xếp môn (R12).</summary>
        public int DemDaXepMon(string maLop, string maMon, string maHocKy)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_PhanCong_DemDaXepMon",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaMon", maMon),
                DBHelper.TS("@p_MaHocKy", maHocKy)));
        }

        /// <summary>Thêm mới, hoặc đổi giảng viên nếu lớp - môn - học kỳ đã có người dạy.</summary>
        public void Luu(PhanCong pc)
        {
            DBHelper.ThucThi("sp_PhanCong_Luu",
                DBHelper.TS("@p_MaLop", pc.MaLop),
                DBHelper.TS("@p_MaMon", pc.MaMon),
                DBHelper.TS("@p_MaHocKy", pc.MaHocKy),
                DBHelper.TS("@p_MaGV", pc.MaGV));
        }

        /// <summary>Các lớp - môn được phân công cho giảng viên trong học kỳ (R07).</summary>
        public DataTable LayCuaGiangVien(string maGV, string maHocKy)
        {
            return DBHelper.LayBang("sp_PhanCong_LayCuaGiangVien",
                DBHelper.TS("@p_MaGV", maGV),
                DBHelper.TS("@p_MaHocKy", maHocKy));
        }
    }
}

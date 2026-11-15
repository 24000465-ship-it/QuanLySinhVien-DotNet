using System;
using System.Data;

namespace QuanLySinhVien.DAL
{
    /// <summary>Xếp môn cho lớp (tạo các dòng KetQua chưa có điểm).</summary>
    public class XepMonDAL
    {
        /// <summary>Trả về số sinh viên vừa được xếp môn (chỉ bổ sung sinh viên còn thiếu).</summary>
        public int XepMonTheoLop(string maLop, string maMon, string maHocKy)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_XepMon_TheoLop",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaMon", maMon),
                DBHelper.TS("@p_MaHocKy", maHocKy)));
        }

        public DataTable LayDanhSach(string maLop, string maHocKy)
        {
            return DBHelper.LayBang("sp_XepMon_LayDanhSach",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaHocKy", maHocKy));
        }

        public DataTable LayTongTinChi(string maLop, string maHocKy)
        {
            return DBHelper.LayBang("sp_XepMon_TongTinChi",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaHocKy", maHocKy));
        }
    }
}

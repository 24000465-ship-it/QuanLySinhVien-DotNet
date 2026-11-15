using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    /// <summary>Truy cập bảng KetQua (điểm).</summary>
    public class KetQuaDAL
    {
        public DataTable LayTheoLopMon(string maLop, string maMon, string maHocKy)
        {
            return DBHelper.LayBang("sp_KetQua_LayTheoLopMon",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaMon", maMon),
                DBHelper.TS("@p_MaHocKy", maHocKy));
        }

        public DataTable LayTheoSinhVien(string maSV)
        {
            return DBHelper.LayBang("sp_KetQua_LayTheoSinhVien", DBHelper.TS("@p_MaSV", maSV));
        }

        /// <summary>Dữ liệu (mã SV, họ tên, số tín chỉ, điểm hệ 4) để tính điểm trung bình học kỳ.</summary>
        public DataTable LayTheoLopHocKy(string maLop, string maHocKy)
        {
            return DBHelper.LayBang("sp_KetQua_LayTheoLopHocKy",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaHocKy", maHocKy));
        }

        /// <summary>Lưu cả bảng điểm trong một giao dịch: lỗi một dòng thì không lưu dòng nào.</summary>
        public void CapNhatNhieu(List<KetQua> danhSach)
        {
            List<KeyValuePair<string, MySqlParameter[]>> lenh = new List<KeyValuePair<string, MySqlParameter[]>>();
            foreach (KetQua kq in danhSach)
            {
                lenh.Add(new KeyValuePair<string, MySqlParameter[]>("sp_KetQua_CapNhat", new[]
                {
                    DBHelper.TS("@p_MaSV", kq.MaSV),
                    DBHelper.TS("@p_MaMon", kq.MaMon),
                    DBHelper.TS("@p_MaHocKy", kq.MaHocKy),
                    DBHelper.TS("@p_DiemCC", kq.DiemCC),
                    DBHelper.TS("@p_DiemGK", kq.DiemGK),
                    DBHelper.TS("@p_DiemKTHP", kq.DiemKTHP),
                    DBHelper.TS("@p_DiemHP", kq.DiemHP),
                    DBHelper.TS("@p_DiemChu", kq.DiemChu),
                    DBHelper.TS("@p_DiemHe4", kq.DiemHe4)
                }));
            }
            DBHelper.ThucThiGiaoDich(lenh);
        }
    }
}

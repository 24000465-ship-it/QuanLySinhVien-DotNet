using System.Data;

namespace QuanLySinhVien.DAL
{
    public class ThongKeDAL
    {
        public DataTable SinhVienDiemCaoNhat(string maLop, string maHocKy, int soLuong)
        {
            return DBHelper.LayBang("sp_TK_SinhVienDiemCaoNhat",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaHocKy", maHocKy),
                DBHelper.TS("@p_SoLuong", soLuong));
        }

        public DataTable MonTiLeTruotCaoNhat(string maHocKy, int soLuong)
        {
            return DBHelper.LayBang("sp_TK_MonTiLeTruotCaoNhat",
                DBHelper.TS("@p_MaHocKy", maHocKy),
                DBHelper.TS("@p_SoLuong", soLuong));
        }

        public DataTable QuyMoTheoKhoa()
        {
            return DBHelper.LayBang("sp_TK_QuyMoTheoKhoa");
        }

        public DataTable BaoCaoDanhSachSinhVien(string maLop)
        {
            return DBHelper.LayBang("sp_BaoCao_DanhSachSinhVien", DBHelper.TS("@p_MaLop", maLop));
        }

        public DataTable BaoCaoBangDiemLopMon(string maLop, string maMon, string maHocKy)
        {
            return DBHelper.LayBang("sp_BaoCao_BangDiemLopMon",
                DBHelper.TS("@p_MaLop", maLop),
                DBHelper.TS("@p_MaMon", maMon),
                DBHelper.TS("@p_MaHocKy", maHocKy));
        }

        public DataTable BaoCaoBangDiemSinhVien(string maSV)
        {
            return DBHelper.LayBang("sp_BaoCao_BangDiemSinhVien", DBHelper.TS("@p_MaSV", maSV));
        }
    }
}

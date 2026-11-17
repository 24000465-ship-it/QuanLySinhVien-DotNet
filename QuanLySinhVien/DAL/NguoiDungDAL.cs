using System;
using System.Data;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.DAL
{
    public class NguoiDungDAL
    {
        public NguoiDung DangNhap(string tenDangNhap, string matKhauBam)
        {
            DataTable bang = DBHelper.LayBang("sp_NguoiDung_DangNhap",
                DBHelper.TS("@p_TenDangNhap", tenDangNhap),
                DBHelper.TS("@p_MatKhau", matKhauBam));
            if (bang.Rows.Count == 0)
            {
                return null;
            }
            DataRow dong = bang.Rows[0];
            return new NguoiDung
            {
                TenDangNhap = dong["TenDangNhap"].ToString(),
                HoTen = dong["HoTen"].ToString(),
                VaiTro = dong["VaiTro"].ToString(),
                TrangThai = Convert.ToBoolean(dong["TrangThai"]),
                MaGV = dong["MaGV"] == DBNull.Value ? null : dong["MaGV"].ToString()
            };
        }

        public int DoiMatKhau(string tenDangNhap, string matKhauCuBam, string matKhauMoiBam)
        {
            object ketQua = DBHelper.LayGiaTri("sp_NguoiDung_DoiMatKhau",
                DBHelper.TS("@p_TenDangNhap", tenDangNhap),
                DBHelper.TS("@p_MatKhauCu", matKhauCuBam),
                DBHelper.TS("@p_MatKhauMoi", matKhauMoiBam));
            return Convert.ToInt32(ketQua);
        }

        public DataTable LayDanhSach(string tuKhoa)
        {
            return DBHelper.LayBang("sp_NguoiDung_LayDanhSach", DBHelper.TS("@p_TuKhoa", tuKhoa));
        }

        public bool TonTai(string tenDangNhap)
        {
            return Convert.ToInt32(DBHelper.LayGiaTri("sp_NguoiDung_DemTheoTen",
                DBHelper.TS("@p_TenDangNhap", tenDangNhap))) > 0;
        }

        public void Them(NguoiDung nd, string matKhauBam)
        {
            DBHelper.ThucThi("sp_NguoiDung_Them",
                DBHelper.TS("@p_TenDangNhap", nd.TenDangNhap),
                DBHelper.TS("@p_MatKhau", matKhauBam),
                DBHelper.TS("@p_HoTen", nd.HoTen),
                DBHelper.TS("@p_VaiTro", nd.VaiTro));
        }

        public void Sua(NguoiDung nd)
        {
            DBHelper.ThucThi("sp_NguoiDung_Sua",
                DBHelper.TS("@p_TenDangNhap", nd.TenDangNhap),
                DBHelper.TS("@p_HoTen", nd.HoTen),
                DBHelper.TS("@p_VaiTro", nd.VaiTro));
        }

        public void DatTrangThai(string tenDangNhap, bool hoatDong)
        {
            DBHelper.ThucThi("sp_NguoiDung_DatTrangThai",
                DBHelper.TS("@p_TenDangNhap", tenDangNhap),
                DBHelper.TS("@p_TrangThai", hoatDong ? 1 : 0));
        }

        public void CapLaiMatKhau(string tenDangNhap, string matKhauBam)
        {
            DBHelper.ThucThi("sp_NguoiDung_CapLaiMatKhau",
                DBHelper.TS("@p_TenDangNhap", tenDangNhap),
                DBHelper.TS("@p_MatKhau", matKhauBam));
        }
    }
}

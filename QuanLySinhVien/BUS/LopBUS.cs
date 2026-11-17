using System;
using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public class LopBUS : IDanhMucBUS<Lop>
    {
        private readonly LopDAL dal = new LopDAL();

        public DataTable LayDanhSach(string tuKhoa)
        {
            return dal.LayDanhSach(tuKhoa ?? "");
        }

        public void Them(Lop lop)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(lop);
            dal.Them(lop);
        }

        public void Sua(Lop lop)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(lop);
            dal.Sua(lop);
        }

        public void Xoa(string maLop)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (dal.DemPhuThuoc(maLop) > 0)
                throw new LoiNghiepVu("Không thể xóa lớp đang có sinh viên hoặc đã được phân công giảng dạy.");
            dal.Xoa(maLop);
        }

        public static string GoiYMaLop(string maNganh, int khoaHoc)
        {
            return "DH" + (khoaHoc % 100).ToString("00") + maNganh;
        }

        private void KiemTra(Lop lop)
        {
            if (string.IsNullOrWhiteSpace(lop.MaLop))
                throw new LoiNghiepVu("Mã lớp không được để trống.", "MaLop");
            if (string.IsNullOrWhiteSpace(lop.TenLop))
                throw new LoiNghiepVu("Tên lớp không được để trống.", "TenLop");
            if (string.IsNullOrEmpty(lop.MaNganh))
                throw new LoiNghiepVu("Vui lòng chọn ngành.", "MaNganh");
            if (lop.KhoaHoc < 2000 || lop.KhoaHoc > DateTime.Today.Year + 1)
                throw new LoiNghiepVu("Năm nhập học không hợp lệ.", "KhoaHoc");
            lop.MaLop = lop.MaLop.Trim().ToUpper();
            lop.TenLop = lop.TenLop.Trim();
        }
    }
}

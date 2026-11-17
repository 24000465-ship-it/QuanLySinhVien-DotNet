using System;
using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public class GiangVienBUS : IGiangVienBUS
    {
        private readonly GiangVienDAL dal = new GiangVienDAL();

        public DataTable LayDanhSach(string tuKhoa, string maKhoa)
        {
            return dal.LayDanhSach(tuKhoa ?? "", maKhoa ?? "");
        }

        public void Them(GiangVien gv)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(gv);
            dal.Them(gv);
        }

        public void Sua(GiangVien gv)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(gv);
            dal.Sua(gv);
        }

        public void Xoa(string maGV)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (dal.DemPhuThuoc(maGV) > 0)
                throw new LoiNghiepVu("Không thể xóa giảng viên đã được phân công giảng dạy.");
            dal.Xoa(maGV);
        }

        private void KiemTra(GiangVien gv)
        {
            if (string.IsNullOrWhiteSpace(gv.MaGV))
                throw new LoiNghiepVu("Mã giảng viên không được để trống.", "MaGV");
            if (string.IsNullOrEmpty(gv.MaKhoa))
                throw new LoiNghiepVu("Vui lòng chọn khoa.", "MaKhoa");
            if (!TienIch.LaEmailHopLe(gv.Email))
                throw new LoiNghiepVu("Email không đúng định dạng.", "Email");
            if (gv.Tuoi() < 22 || gv.Tuoi() > 80)
                throw new LoiNghiepVu("Ngày sinh không hợp lệ (tuổi giảng viên từ 22 đến 80).", "NgaySinh");
            gv.MaGV = gv.MaGV.Trim().ToUpper();
            gv.TenDangNhap = string.IsNullOrWhiteSpace(gv.TenDangNhap) ? null : gv.TenDangNhap.Trim();
        }
    }
}

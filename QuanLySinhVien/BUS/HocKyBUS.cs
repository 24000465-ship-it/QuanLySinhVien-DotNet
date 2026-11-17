using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public class HocKyBUS : IDanhMucBUS<HocKy>
    {
        private readonly HocKyDAL dal = new HocKyDAL();

        public DataTable LayDanhSach(string tuKhoa)
        {
            return dal.LayDanhSach(tuKhoa ?? "");
        }

        public void Them(HocKy hocKy)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(hocKy);
            dal.Them(hocKy);
        }

        public void Sua(HocKy hocKy)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(hocKy);
            dal.Sua(hocKy);
        }

        public void Xoa(string maHocKy)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (dal.DemPhuThuoc(maHocKy) > 0)
                throw new LoiNghiepVu("Không thể xóa học kỳ đã có môn được xếp hoặc phân công.");
            dal.Xoa(maHocKy);
        }

        private void KiemTra(HocKy hocKy)
        {
            if (!TienIch.LaMaHocKyHopLe(hocKy.MaHocKy))
                throw new LoiNghiepVu("Mã học kỳ phải có dạng NNNNK, ví dụ 20261 = HK1 năm học 2026-2027.", "MaHocKy");
            if (string.IsNullOrWhiteSpace(hocKy.TenHocKy))
                hocKy.TenHocKy = TienIch.TaoTenHocKy(hocKy.MaHocKy);
        }
    }
}

using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public class MonHocBUS : IDanhMucBUS<MonHoc>
    {
        private readonly MonHocDAL dal = new MonHocDAL();

        public DataTable LayDanhSach(string tuKhoa)
        {
            return dal.LayDanhSach(tuKhoa ?? "");
        }

        public void Them(MonHoc mon)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(mon);
            dal.Them(mon);
        }

        public void Sua(MonHoc mon)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(mon);
            dal.Sua(mon);
        }

        public void Xoa(string maMon)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (dal.DemPhuThuoc(maMon) > 0)
                throw new LoiNghiepVu("Không thể xóa môn học đã được xếp lớp hoặc đã có điểm.");
            dal.Xoa(maMon);
        }

        private void KiemTra(MonHoc mon)
        {
            if (string.IsNullOrWhiteSpace(mon.MaMon))
                throw new LoiNghiepVu("Mã môn không được để trống.", "MaMon");
            if (string.IsNullOrWhiteSpace(mon.TenMon))
                throw new LoiNghiepVu("Tên môn không được để trống.", "TenMon");
            if (mon.SoTinChi < 1 || mon.SoTinChi > 10)
                throw new LoiNghiepVu("Số tín chỉ phải từ 1 đến 10.", "SoTinChi");
            mon.MaMon = mon.MaMon.Trim().ToUpper();
            mon.TenMon = mon.TenMon.Trim();
        }
    }
}

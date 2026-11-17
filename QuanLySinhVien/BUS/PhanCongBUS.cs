using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public class PhanCongBUS : IPhanCongBUS
    {
        private readonly PhanCongDAL dal = new PhanCongDAL();

        public DataTable LayDanhSach(string maLop, string maHocKy)
        {
            return dal.LayDanhSach(maLop, maHocKy);
        }

        public void Luu(PhanCong pc)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (string.IsNullOrEmpty(pc.MaMon))
                throw new LoiNghiepVu("Vui lòng chọn môn học.", "MonHoc");
            if (string.IsNullOrEmpty(pc.MaGV))
                throw new LoiNghiepVu("Vui lòng chọn giảng viên.", "GiangVien");
            if (dal.DemDaXepMon(pc.MaLop, pc.MaMon, pc.MaHocKy) == 0)
                throw new LoiNghiepVu("Lớp chưa được xếp môn này trong học kỳ, hãy xếp môn trước.", "MonHoc");
            dal.Luu(pc);
        }

        public DataTable LayCuaGiangVien(string maGV, string maHocKy)
        {
            return dal.LayCuaGiangVien(maGV ?? "", maHocKy);
        }
    }
}

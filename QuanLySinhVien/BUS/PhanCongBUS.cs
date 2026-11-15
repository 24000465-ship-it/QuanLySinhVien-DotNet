using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    /// <summary>Nghiệp vụ phân công giảng viên (F07).</summary>
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
            // R12: chỉ phân công cho lớp - môn - học kỳ đã được xếp môn
            if (dal.DemDaXepMon(pc.MaLop, pc.MaMon, pc.MaHocKy) == 0)
                throw new LoiNghiepVu("Lớp chưa được xếp môn này trong học kỳ, hãy xếp môn trước.", "MonHoc");
            // R12: mỗi lớp - môn - học kỳ chỉ một giảng viên → thủ tục tự thay giảng viên cũ nếu đã có
            dal.Luu(pc);
        }

        public DataTable LayCuaGiangVien(string maGV, string maHocKy)
        {
            return dal.LayCuaGiangVien(maGV ?? "", maHocKy);
        }
    }
}

using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;

namespace QuanLySinhVien.BUS
{
    /// <summary>Nghiệp vụ xếp môn theo cả lớp (F06).</summary>
    public class XepMonBUS : IXepMonBUS
    {
        private readonly XepMonDAL dal = new XepMonDAL();
        private readonly SinhVienDAL sinhVienDal = new SinhVienDAL();

        public int XepMon(string maLop, string maMon, string maHocKy)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (string.IsNullOrEmpty(maHocKy))
                throw new LoiNghiepVu("Vui lòng chọn học kỳ.", "HocKy");
            if (string.IsNullOrEmpty(maLop))
                throw new LoiNghiepVu("Vui lòng chọn lớp.", "Lop");
            if (string.IsNullOrEmpty(maMon))
                throw new LoiNghiepVu("Vui lòng chọn môn học.", "MonHoc");
            if (sinhVienDal.LayDanhSach("", maLop).Rows.Count == 0)
                throw new LoiNghiepVu("Lớp chưa có sinh viên.");

            // R06: thủ tục chỉ thêm sinh viên chưa có môn này trong học kỳ (không tạo trùng)
            int soDongThem = dal.XepMonTheoLop(maLop, maMon, maHocKy);
            if (soDongThem == 0)
                throw new LoiNghiepVu("Lớp đã được xếp môn này đầy đủ.");
            return soDongThem;
        }

        public DataTable LayMonDaXep(string maLop, string maHocKy)
        {
            return dal.LayDanhSach(maLop, maHocKy);
        }

        public DataTable LayTongTinChi(string maLop, string maHocKy)
        {
            return dal.LayTongTinChi(maLop, maHocKy);
        }
    }
}

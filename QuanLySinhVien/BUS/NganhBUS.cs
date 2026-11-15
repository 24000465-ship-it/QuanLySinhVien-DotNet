using System.Data;
using System.Text.RegularExpressions;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    /// <summary>Nghiệp vụ quản lý ngành (F04).</summary>
    public class NganhBUS : IDanhMucBUS<Nganh>
    {
        private readonly NganhDAL dal = new NganhDAL();

        public DataTable LayDanhSach(string tuKhoa)
        {
            return dal.LayDanhSach(tuKhoa ?? "");
        }

        public void Them(Nganh nganh)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(nganh);
            dal.Them(nganh);
        }

        public void Sua(Nganh nganh)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(nganh);
            dal.Sua(nganh);
        }

        public void Xoa(string maNganh)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            // R08: không xóa ngành đang có lớp
            if (dal.DemPhuThuoc(maNganh) > 0)
                throw new LoiNghiepVu("Không thể xóa ngành đang có lớp.");
            dal.Xoa(maNganh);
        }

        private void KiemTra(Nganh nganh)
        {
            // Mã ngành đúng 2 chữ số vì được dùng để sinh mã sinh viên (R05)
            if (string.IsNullOrWhiteSpace(nganh.MaNganh) || !Regex.IsMatch(nganh.MaNganh.Trim(), @"^\d{2}$"))
                throw new LoiNghiepVu("Mã ngành phải gồm đúng 2 chữ số, ví dụ 01.", "MaNganh");
            if (string.IsNullOrWhiteSpace(nganh.TenNganh))
                throw new LoiNghiepVu("Tên ngành không được để trống.", "TenNganh");
            if (string.IsNullOrEmpty(nganh.MaKhoa))
                throw new LoiNghiepVu("Vui lòng chọn khoa.", "MaKhoa");
            nganh.MaNganh = nganh.MaNganh.Trim();
            nganh.TenNganh = nganh.TenNganh.Trim();
        }
    }
}

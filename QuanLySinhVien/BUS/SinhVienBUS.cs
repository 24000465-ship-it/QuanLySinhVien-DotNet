using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    public class SinhVienBUS : ISinhVienBUS
    {
        private const int TuoiToiThieu = 16;
        private const int TuoiToiDa = 60;

        private readonly SinhVienDAL dal = new SinhVienDAL();

        public DataTable LayDanhSach(string tuKhoa, string maLop)
        {
            return dal.LayDanhSach(tuKhoa ?? "", maLop ?? "");
        }

        public string Them(SinhVien sv)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(sv);
            sv.MaSV = dal.SinhMa(sv.MaLop);
            dal.Them(sv);
            return sv.MaSV;
        }

        public void Sua(SinhVien sv)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            KiemTra(sv);
            string lopCu = dal.LayMaLop(sv.MaSV);
            if (lopCu != sv.MaLop && dal.DemDiem(sv.MaSV) > 0)
                throw new LoiNghiepVu("Không thể đổi lớp cho sinh viên đã có điểm.", "MaLop");
            dal.Sua(sv);
        }

        public void Xoa(string maSV)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (dal.DemDiem(maSV) > 0)
                throw new LoiNghiepVu("Không thể xóa sinh viên đã có điểm.");
            dal.Xoa(maSV);
        }

        private void KiemTra(SinhVien sv)
        {
            if (string.IsNullOrEmpty(sv.MaLop))
                throw new LoiNghiepVu("Vui lòng chọn lớp.", "MaLop");
            if (string.IsNullOrEmpty(sv.GioiTinh))
                throw new LoiNghiepVu("Vui lòng chọn giới tính.", "GioiTinh");
            int tuoi = sv.Tuoi();
            if (tuoi < TuoiToiThieu || tuoi > TuoiToiDa)
                throw new LoiNghiepVu(string.Format("Ngày sinh không hợp lệ (tuổi từ {0} đến {1}).",
                    TuoiToiThieu, TuoiToiDa), "NgaySinh");
        }
    }
}

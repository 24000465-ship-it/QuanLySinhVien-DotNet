using System.Collections.Generic;
using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.BUS
{
    /// <summary>Nghiệp vụ điểm (F08, F09, F10).</summary>
    public class KetQuaBUS : IKetQuaBUS
    {
        private readonly KetQuaDAL dal = new KetQuaDAL();
        private readonly PhanCongDAL phanCongDal = new PhanCongDAL();

        public DataTable LayBangDiemLopMon(string maLop, string maMon, string maHocKy)
        {
            KiemTraQuyenXem(maLop, maMon, maHocKy);
            return dal.LayTheoLopMon(maLop, maMon, maHocKy);
        }

        public DataTable LayBangDiemSinhVien(string maSV)
        {
            return dal.LayTheoSinhVien(maSV);
        }

        /// <summary>
        /// F09: đủ 3 điểm thành phần thì tính điểm học phần, điểm chữ, thang 4 (R02, R03);
        /// thiếu điểm thì để trống điểm học phần (R10).
        /// </summary>
        public void TinhDiem(KetQua kq)
        {
            if (kq.DuDiemThanhPhan)
            {
                decimal diemHP = QuyTacDiem.TinhDiemHocPhan(kq.DiemCC.Value, kq.DiemGK.Value, kq.DiemKTHP.Value);
                kq.DiemHP = diemHP;
                kq.DiemChu = QuyTacDiem.QuyDoiDiemChu(diemHP);
                kq.DiemHe4 = QuyTacDiem.QuyDoiHe4(diemHP);
            }
            else
            {
                kq.DiemHP = null;
                kq.DiemChu = null;
                kq.DiemHe4 = null;
            }
        }

        public void LuuBangDiem(string maLop, string maMon, string maHocKy, List<KetQua> danhSach)
        {
            // R07: chỉ giảng viên được phân công mới được nhập, sửa điểm lớp - môn này
            NguoiDung nd = PhienDangNhap.NguoiDungHienTai;
            if (nd == null || nd.VaiTro != NguoiDung.VaiTroGiangVien)
                throw new LoiNghiepVu("Chỉ giảng viên mới được nhập điểm.");
            if (!DuocPhanCong(nd.MaGV, maLop, maMon, maHocKy))
                throw new LoiNghiepVu("Bạn không được phân công dạy lớp - môn này nên không thể nhập điểm.");

            foreach (KetQua kq in danhSach)
            {
                kq.MaMon = maMon;
                kq.MaHocKy = maHocKy;
                TinhDiem(kq);
            }
            dal.CapNhatNhieu(danhSach);
        }

        /// <summary>Giảng viên chỉ xem bảng điểm lớp mình dạy; cán bộ đào tạo xem được tất cả.</summary>
        public void KiemTraQuyenXem(string maLop, string maMon, string maHocKy)
        {
            NguoiDung nd = PhienDangNhap.NguoiDungHienTai;
            if (nd != null && nd.VaiTro == NguoiDung.VaiTroGiangVien
                && !DuocPhanCong(nd.MaGV, maLop, maMon, maHocKy))
                throw new LoiNghiepVu("Bạn chỉ được xem bảng điểm các lớp - môn mình dạy.");
        }

        private bool DuocPhanCong(string maGV, string maLop, string maMon, string maHocKy)
        {
            DataTable ds = phanCongDal.LayCuaGiangVien(maGV ?? "", maHocKy);
            foreach (DataRow dong in ds.Rows)
            {
                if (dong["MaLop"].ToString() == maLop && dong["MaMon"].ToString() == maMon)
                    return true;
            }
            return false;
        }
    }
}

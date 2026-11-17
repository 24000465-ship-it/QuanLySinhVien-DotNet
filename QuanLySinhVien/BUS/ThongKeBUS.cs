using System;
using System.Collections.Generic;
using System.Data;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL;

namespace QuanLySinhVien.BUS
{
    public class ThongKeBUS : IThongKeBUS
    {
        private static readonly string[] CacMucXepLoai = { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu" };

        private readonly KetQuaDAL ketQuaDal = new KetQuaDAL();
        private readonly ThongKeDAL dal = new ThongKeDAL();

        public DataTable XepLoaiSinhVien(string maLop, string maHocKy)
        {
            DataTable duLieu = ketQuaDal.LayTheoLopHocKy(maLop, maHocKy);

            DataTable ketQua = new DataTable();
            ketQua.Columns.Add("MaSV", typeof(string));
            ketQua.Columns.Add("HoTen", typeof(string));
            ketQua.Columns.Add("SoTinChi", typeof(int));
            ketQua.Columns.Add("DiemTBHe4", typeof(decimal));
            ketQua.Columns.Add("XepLoai", typeof(string));

            Dictionary<string, DataRow> theoSinhVien = new Dictionary<string, DataRow>();
            Dictionary<string, decimal> tongDiem = new Dictionary<string, decimal>();
            foreach (DataRow dong in duLieu.Rows)
            {
                string maSV = dong["MaSV"].ToString();
                if (!theoSinhVien.ContainsKey(maSV))
                {
                    DataRow moi = ketQua.NewRow();
                    moi["MaSV"] = maSV;
                    moi["HoTen"] = dong["HoTen"];
                    moi["SoTinChi"] = 0;
                    ketQua.Rows.Add(moi);
                    theoSinhVien[maSV] = moi;
                    tongDiem[maSV] = 0;
                }
                if (dong["DiemHe4"] == DBNull.Value)
                {
                    continue;
                }
                int tinChi = Convert.ToInt32(dong["SoTinChi"]);
                theoSinhVien[maSV]["SoTinChi"] = (int)theoSinhVien[maSV]["SoTinChi"] + tinChi;
                tongDiem[maSV] += Convert.ToDecimal(dong["DiemHe4"]) * tinChi;
            }

            foreach (KeyValuePair<string, DataRow> cap in theoSinhVien)
            {
                int tongTinChi = (int)cap.Value["SoTinChi"];
                if (tongTinChi == 0)
                {
                    cap.Value["XepLoai"] = "Chưa có điểm";
                    continue;
                }
                decimal diemTB = Math.Round(tongDiem[cap.Key] / tongTinChi, 2, MidpointRounding.AwayFromZero);
                cap.Value["DiemTBHe4"] = diemTB;
                cap.Value["XepLoai"] = QuyTacDiem.XepLoaiHocKy(diemTB);
            }
            return ketQua;
        }

        public DataTable DemTheoXepLoai(string maLop, string maHocKy)
        {
            DataTable chiTiet = XepLoaiSinhVien(maLop, maHocKy);
            DataTable bang = new DataTable();
            bang.Columns.Add("XepLoai", typeof(string));
            bang.Columns.Add("SoSinhVien", typeof(int));
            bang.Columns.Add("TiLe", typeof(string));

            int tong = 0;
            foreach (DataRow d in chiTiet.Rows)
            {
                if (d["DiemTBHe4"] != DBNull.Value) tong++;
            }
            foreach (string muc in CacMucXepLoai)
            {
                int dem = 0;
                foreach (DataRow d in chiTiet.Rows)
                {
                    if (d["XepLoai"].ToString() == muc) dem++;
                }
                string tiLe = tong == 0 ? "0%" : Math.Round(100.0 * dem / tong, 1) + "%";
                bang.Rows.Add(muc, dem, tiLe);
            }
            return bang;
        }

        public DataTable SinhVienDiemCaoNhat(string maLop, string maHocKy, int soLuong)
        {
            return dal.SinhVienDiemCaoNhat(maLop, maHocKy, soLuong);
        }

        public DataTable MonTiLeTruotCaoNhat(string maHocKy, int soLuong)
        {
            return dal.MonTiLeTruotCaoNhat(maHocKy, soLuong);
        }

        public DataTable QuyMoTheoKhoa()
        {
            return dal.QuyMoTheoKhoa();
        }

        public DataTable BaoCaoDanhSachSinhVien(string maLop)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (string.IsNullOrEmpty(maLop))
                throw new LoiNghiepVu("Vui lòng chọn lớp.");
            DataTable bang = dal.BaoCaoDanhSachSinhVien(maLop);
            bang.Columns.Add("NgaySinhText", typeof(string));
            foreach (DataRow dong in bang.Rows)
                dong["NgaySinhText"] = Convert.ToDateTime(dong["NgaySinh"]).ToString("dd/MM/yyyy");
            return bang;
        }

        public DataTable BaoCaoBangDiemLopMon(string maLop, string maMon, string maHocKy)
        {
            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(maMon) || string.IsNullOrEmpty(maHocKy))
                throw new LoiNghiepVu("Vui lòng chọn đủ học kỳ, lớp và môn học.");
            new KetQuaBUS().KiemTraQuyenXem(maLop, maMon, maHocKy);
            return dal.BaoCaoBangDiemLopMon(maLop, maMon, maHocKy);
        }

        public DataTable BaoCaoBangDiemSinhVien(string maSV)
        {
            PhienDangNhap.YeuCauQuanLyDaoTao();
            if (string.IsNullOrWhiteSpace(maSV))
                throw new LoiNghiepVu("Vui lòng nhập mã sinh viên.");
            return dal.BaoCaoBangDiemSinhVien(maSV.Trim().ToUpper());
        }
    }
}

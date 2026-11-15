using System.Data;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>Nghiệp vụ thống kê (F11) và lấy dữ liệu báo cáo (F12, F13).</summary>
    public interface IThongKeBUS
    {
        /// <summary>Điểm trung bình học kỳ và xếp loại của từng sinh viên trong lớp (R04, R10).</summary>
        DataTable XepLoaiSinhVien(string maLop, string maHocKy);

        /// <summary>Số sinh viên theo từng mức xếp loại của lớp.</summary>
        DataTable DemTheoXepLoai(string maLop, string maHocKy);

        DataTable SinhVienDiemCaoNhat(string maLop, string maHocKy, int soLuong);

        DataTable MonTiLeTruotCaoNhat(string maHocKy, int soLuong);

        DataTable QuyMoTheoKhoa();

        DataTable BaoCaoDanhSachSinhVien(string maLop);

        DataTable BaoCaoBangDiemLopMon(string maLop, string maMon, string maHocKy);

        DataTable BaoCaoBangDiemSinhVien(string maSV);
    }
}

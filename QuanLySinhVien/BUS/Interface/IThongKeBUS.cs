using System.Data;

namespace QuanLySinhVien.BUS.Interface
{
    public interface IThongKeBUS
    {
        DataTable XepLoaiSinhVien(string maLop, string maHocKy);

        DataTable DemTheoXepLoai(string maLop, string maHocKy);

        DataTable SinhVienDiemCaoNhat(string maLop, string maHocKy, int soLuong);

        DataTable MonTiLeTruotCaoNhat(string maHocKy, int soLuong);

        DataTable QuyMoTheoKhoa();

        DataTable BaoCaoDanhSachSinhVien(string maLop);

        DataTable BaoCaoBangDiemLopMon(string maLop, string maMon, string maHocKy);

        DataTable BaoCaoBangDiemSinhVien(string maSV);
    }
}

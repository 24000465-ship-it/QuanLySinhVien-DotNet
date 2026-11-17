using System.Data;

namespace QuanLySinhVien.BUS.Interface
{
    public interface IXepMonBUS
    {
        int XepMon(string maLop, string maMon, string maHocKy);

        DataTable LayMonDaXep(string maLop, string maHocKy);

        DataTable LayTongTinChi(string maLop, string maHocKy);
    }
}

using System.Data;

namespace QuanLySinhVien.BUS.Interface
{
    /// <summary>Nghiệp vụ xếp môn theo cả lớp (F06, R06).</summary>
    public interface IXepMonBUS
    {
        /// <summary>Xếp môn cho mọi sinh viên của lớp; trả về số sinh viên được thêm.</summary>
        int XepMon(string maLop, string maMon, string maHocKy);

        DataTable LayMonDaXep(string maLop, string maHocKy);

        DataTable LayTongTinChi(string maLop, string maHocKy);
    }
}

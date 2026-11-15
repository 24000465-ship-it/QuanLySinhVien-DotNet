using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.DAL
{
    /// <summary>
    /// Lớp dùng chung để làm việc với MySQL qua ADO.NET:
    /// mở kết nối, gọi Stored Procedure có tham số, đổ dữ liệu vào DataTable.
    /// Mọi lớp DAL khác chỉ gọi các phương thức ở đây.
    /// </summary>
    public static class DBHelper
    {
        // Mã lỗi MySQL thường gặp
        private const int LoiTrungKhoa = 1062;        // trùng khóa chính / UNIQUE
        private const int LoiDangDuocThamChieu = 1451; // xóa bản ghi đang được bảng khác tham chiếu
        private const int LoiKhoaNgoai = 1452;         // khóa ngoại không tồn tại
        private const int LoiViPhamCheck = 3819;       // vi phạm ràng buộc CHECK

        /// <summary>Chuỗi kết nối đọc từ App.config (đổi máy chỉ cần sửa App.config).</summary>
        public static string ChuoiKetNoi
        {
            get { return ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString; }
        }

        /// <summary>Tạo tham số cho Stored Procedure; giá trị null được đổi thành DBNull.</summary>
        public static MySqlParameter TS(string ten, object giaTri)
        {
            return new MySqlParameter(ten, giaTri ?? DBNull.Value);
        }

        /// <summary>Kiểm tra có kết nối được CSDL không (dùng khi mở chương trình).</summary>
        public static bool KiemTraKetNoi(out string thongBaoLoi)
        {
            thongBaoLoi = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ChuoiKetNoi))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                thongBaoLoi = ex.Message;
                return false;
            }
        }

        /// <summary>Gọi thủ tục trả về nhiều dòng (SELECT) → DataTable (mô hình không kết nối).</summary>
        public static DataTable LayBang(string tenThuTuc, params MySqlParameter[] thamSo)
        {
            DataTable bang = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ChuoiKetNoi))
                using (MySqlCommand cmd = TaoLenh(conn, tenThuTuc, thamSo))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(bang);
                }
            }
            catch (MySqlException ex)
            {
                throw DichLoi(ex);
            }
            return bang;
        }

        /// <summary>Gọi thủ tục thêm / sửa / xóa → số dòng bị ảnh hưởng.</summary>
        public static int ThucThi(string tenThuTuc, params MySqlParameter[] thamSo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ChuoiKetNoi))
                using (MySqlCommand cmd = TaoLenh(conn, tenThuTuc, thamSo))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw DichLoi(ex);
            }
        }

        /// <summary>Gọi thủ tục trả về một giá trị đơn (COUNT, mã mới...) → ExecuteScalar.</summary>
        public static object LayGiaTri(string tenThuTuc, params MySqlParameter[] thamSo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ChuoiKetNoi))
                using (MySqlCommand cmd = TaoLenh(conn, tenThuTuc, thamSo))
                {
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (MySqlException ex)
            {
                throw DichLoi(ex);
            }
        }

        /// <summary>
        /// Chạy nhiều thủ tục trong một giao dịch (transaction): tất cả cùng thành công,
        /// hoặc có một lệnh lỗi thì hủy hết (dùng khi lưu cả bảng điểm).
        /// </summary>
        public static void ThucThiGiaoDich(List<KeyValuePair<string, MySqlParameter[]>> danhSachLenh)
        {
            using (MySqlConnection conn = new MySqlConnection(ChuoiKetNoi))
            {
                conn.Open();
                MySqlTransaction giaoDich = conn.BeginTransaction();
                try
                {
                    foreach (KeyValuePair<string, MySqlParameter[]> lenh in danhSachLenh)
                    {
                        using (MySqlCommand cmd = TaoLenh(conn, lenh.Key, lenh.Value))
                        {
                            cmd.Transaction = giaoDich;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    giaoDich.Commit();
                }
                catch (MySqlException ex)
                {
                    giaoDich.Rollback();
                    throw DichLoi(ex);
                }
                catch
                {
                    giaoDich.Rollback();
                    throw;
                }
            }
        }

        private static MySqlCommand TaoLenh(MySqlConnection conn, string tenThuTuc, MySqlParameter[] thamSo)
        {
            MySqlCommand cmd = new MySqlCommand(tenThuTuc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (thamSo != null)
            {
                cmd.Parameters.AddRange(thamSo);
            }
            return cmd;
        }

        /// <summary>Đổi lỗi kỹ thuật của MySQL thành thông báo tiếng Việt dễ hiểu.</summary>
        private static Exception DichLoi(MySqlException ex)
        {
            switch (ex.Number)
            {
                case LoiTrungKhoa:
                    return new LoiNghiepVu("Mã hoặc tên này đã tồn tại, vui lòng nhập giá trị khác.");
                case LoiDangDuocThamChieu:
                    return new LoiNghiepVu("Không xóa được vì đang có dữ liệu khác liên quan đến bản ghi này.");
                case LoiKhoaNgoai:
                    return new LoiNghiepVu("Dữ liệu liên kết (khoa, ngành, lớp, môn...) không tồn tại.");
                case LoiViPhamCheck:
                    return new LoiNghiepVu("Dữ liệu không đúng quy định: " + ex.Message);
                default:
                    return new Exception("Lỗi cơ sở dữ liệu: " + ex.Message, ex);
            }
        }
    }
}

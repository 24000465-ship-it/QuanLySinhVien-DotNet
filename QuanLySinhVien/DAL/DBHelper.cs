using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.DAL
{
    public static class DBHelper
    {
        private const int LoiTrungKhoa = 1062;
        private const int LoiDangDuocThamChieu = 1451;
        private const int LoiKhoaNgoai = 1452;
        private const int LoiViPhamCheck = 3819;

        public static string ChuoiKetNoi
        {
            get { return ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString; }
        }

        public static MySqlParameter TS(string ten, object giaTri)
        {
            return new MySqlParameter(ten, giaTri ?? DBNull.Value);
        }

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

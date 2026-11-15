using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLySinhVien.GUI
{
    /// <summary>
    /// Xuất dữ liệu ra Excel (F12). Máy có cài Microsoft Excel thì điều khiển Excel trực tiếp
    /// (Office Interop, gọi muộn qua "dynamic" nên không cần thêm tham chiếu);
    /// không có Excel thì lưu file CSV mở được bằng Excel.
    /// </summary>
    public static class XuatExcel
    {
        /// <summary>Xuất các cột đang hiển thị của DataGridView.</summary>
        public static void TuLuoi(DataGridView dgv, string tieuDe)
        {
            if (dgv.Rows.Count == 0)
            {
                GiaoDien.BaoLoi("Không có dữ liệu để xuất.");
                return;
            }
            DataTable bang = new DataTable();
            foreach (DataGridViewColumn cot in dgv.Columns)
            {
                if (cot.Visible) bang.Columns.Add(cot.HeaderText);
            }
            foreach (DataGridViewRow dong in dgv.Rows)
            {
                if (dong.IsNewRow) continue;
                DataRow moi = bang.NewRow();
                int i = 0;
                foreach (DataGridViewColumn cot in dgv.Columns)
                {
                    if (!cot.Visible) continue;
                    moi[i++] = dong.Cells[cot.Index].FormattedValue;
                }
                bang.Rows.Add(moi);
            }
            Xuat(bang, tieuDe);
        }

        public static void Xuat(DataTable bang, string tieuDe)
        {
            Type kieuExcel = Type.GetTypeFromProgID("Excel.Application");
            if (kieuExcel == null)
            {
                LuuCsv(bang, tieuDe);
                return;
            }
            try
            {
                dynamic excel = Activator.CreateInstance(kieuExcel);
                dynamic sach = excel.Workbooks.Add();
                dynamic trang = sach.ActiveSheet;

                // Dòng 1: tiêu đề báo cáo; dòng 3: tiêu đề cột; từ dòng 4: dữ liệu
                trang.Cells[1, 1] = tieuDe;
                trang.Cells[1, 1].Font.Bold = true;
                trang.Cells[1, 1].Font.Size = 14;
                for (int c = 0; c < bang.Columns.Count; c++)
                {
                    trang.Cells[3, c + 1] = bang.Columns[c].ColumnName;
                    trang.Cells[3, c + 1].Font.Bold = true;
                    trang.Cells[3, c + 1].Interior.Color = 0xEBD8C6; // nền xanh nhạt (BGR)
                }

                // Ghi cả khối dữ liệu một lần cho nhanh
                object[,] duLieu = new object[bang.Rows.Count, bang.Columns.Count];
                for (int r = 0; r < bang.Rows.Count; r++)
                    for (int c = 0; c < bang.Columns.Count; c++)
                        duLieu[r, c] = bang.Rows[r][c] == DBNull.Value ? "" : bang.Rows[r][c].ToString();
                if (bang.Rows.Count > 0)
                {
                    dynamic oDau = trang.Cells[4, 1];
                    dynamic oCuoi = trang.Cells[3 + bang.Rows.Count, bang.Columns.Count];
                    trang.Range[oDau, oCuoi].Value2 = duLieu;
                    trang.Range[trang.Cells[3, 1], oCuoi].Borders.LineStyle = 1;
                }
                trang.Columns.AutoFit();
                excel.Visible = true;
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không mở được Excel (" + ex.Message + "). Chương trình sẽ lưu ra file CSV.");
                LuuCsv(bang, tieuDe);
            }
        }

        private static void LuuCsv(DataTable bang, string tieuDe)
        {
            using (SaveFileDialog hopThoai = new SaveFileDialog())
            {
                hopThoai.Filter = "File CSV (mở bằng Excel)|*.csv";
                hopThoai.FileName = tieuDe.Replace(" ", "_") + ".csv";
                if (hopThoai.ShowDialog() != DialogResult.OK) return;

                StringBuilder sb = new StringBuilder();
                string[] tenCot = new string[bang.Columns.Count];
                for (int c = 0; c < bang.Columns.Count; c++) tenCot[c] = Csv(bang.Columns[c].ColumnName);
                sb.AppendLine(string.Join(",", tenCot));
                foreach (DataRow dong in bang.Rows)
                {
                    string[] o = new string[bang.Columns.Count];
                    for (int c = 0; c < bang.Columns.Count; c++) o[c] = Csv(dong[c].ToString());
                    sb.AppendLine(string.Join(",", o));
                }
                // UTF-8 có BOM để Excel hiển thị đúng tiếng Việt
                File.WriteAllText(hopThoai.FileName, sb.ToString(), new UTF8Encoding(true));
                GiaoDien.ThongBao("Đã lưu file: " + hopThoai.FileName);
            }
        }

        private static string Csv(string giaTri)
        {
            return "\"" + (giaTri ?? "").Replace("\"", "\"\"") + "\"";
        }
    }
}

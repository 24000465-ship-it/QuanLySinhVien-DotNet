using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.GUI
{
    public static class GiaoDien
    {
        public const string TieuDeUngDung = "Phần mềm Quản lý Sinh viên";

        public static void ThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, TieuDeUngDung, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void BaoLoi(string noiDung)
        {
            MessageBox.Show(noiDung, TieuDeUngDung, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool XacNhan(string cauHoi)
        {
            return MessageBox.Show(cauHoi, TieuDeUngDung, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes;
        }

        public static void HienLoi(LoiNghiepVu loi, Control vungNhap, ErrorProvider errorProvider)
        {
            Control o = string.IsNullOrEmpty(loi.TenTruong) ? null : TimO(vungNhap, loi.TenTruong);
            if (o != null && errorProvider != null)
            {
                errorProvider.SetError(o, loi.Message);
                o.Focus();
            }
            BaoLoi(loi.Message);
        }

        private static Control TimO(Control cha, string tenTruong)
        {
            foreach (Control con in cha.Controls)
            {
                if (!(con is Label) && con.Name.EndsWith(tenTruong, StringComparison.OrdinalIgnoreCase))
                    return con;
                Control timThay = TimO(con, tenTruong);
                if (timThay != null)
                    return timThay;
            }
            return null;
        }

        public static void NapComboBox(ComboBox cbo, DataTable nguon, string cotHienThi, string cotGiaTri, bool coDongTatCa)
        {
            DataTable bang = nguon.Copy();
            if (coDongTatCa)
            {
                DataRow dong = bang.NewRow();
                dong[cotHienThi] = "(Tất cả)";
                dong[cotGiaTri] = "";
                bang.Rows.InsertAt(dong, 0);
            }
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.DisplayMember = cotHienThi;
            cbo.ValueMember = cotGiaTri;
            cbo.DataSource = bang;
        }

        public static void NapHocKy(ComboBox cbo, DataTable dsHocKy)
        {
            NapComboBox(cbo, dsHocKy, "TenHocKy", "MaHocKy", false);
            string hienTai = TienIch.MaHocKyHienTai(DateTime.Today);
            if (dsHocKy.Select("MaHocKy = '" + hienTai + "'").Length > 0)
                cbo.SelectedValue = hienTai;
        }

        public static string GiaTri(ComboBox cbo)
        {
            return cbo.SelectedValue == null ? "" : cbo.SelectedValue.ToString();
        }

        public static void DatTieuDeCot(DataGridView dgv, params string[] tenVaTieuDe)
        {
            foreach (DataGridViewColumn cot in dgv.Columns)
            {
                cot.Visible = false;
            }
            for (int i = 0; i + 1 < tenVaTieuDe.Length; i += 2)
            {
                DataGridViewColumn cot = dgv.Columns[tenVaTieuDe[i]];
                if (cot == null) continue;
                cot.HeaderText = tenVaTieuDe[i + 1];
                cot.Visible = true;
                cot.DisplayIndex = i / 2;
                if (cot.ValueType == typeof(DateTime))
                    cot.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        public static void DinhDangLuoi(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = System.Drawing.SystemColors.Window;
        }
    }
}

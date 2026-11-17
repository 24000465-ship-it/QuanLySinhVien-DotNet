using System;
using System.Windows.Forms;
using QuanLySinhVien.GUI;

namespace QuanLySinhVien
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Khởi động Phần mềm Quản lý Sinh viên (bản Debug)");
#endif

            Application.ThreadException += (s, e) =>
                MessageBox.Show("Đã xảy ra lỗi không mong muốn:\n" + e.Exception.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            using (frmDangNhap dangNhap = new frmDangNhap())
            {
                if (dangNhap.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            Application.Run(new frmMain());
        }
    }
}

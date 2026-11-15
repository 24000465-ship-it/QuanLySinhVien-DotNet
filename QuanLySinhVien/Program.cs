using System;
using System.Windows.Forms;
using QuanLySinhVien.GUI;

namespace QuanLySinhVien
{
    internal static class Program
    {
        /// <summary>
        /// Điểm bắt đầu chương trình: mở form đăng nhập, đăng nhập thành công thì mở form chính.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            // Chỉ thị biên dịch (chương 6): bản Debug ghi thêm thông tin để lập trình viên theo dõi
            System.Diagnostics.Debug.WriteLine("Khởi động Phần mềm Quản lý Sinh viên (bản Debug)");
#endif

            // Bắt mọi lỗi chưa được xử lý để chương trình không bị tắt đột ngột (bẫy lỗi)
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

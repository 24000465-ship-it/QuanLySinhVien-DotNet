using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.GUI
{
    public partial class frmDangNhap : Form
    {
        private readonly NguoiDungBUS nguoiDungBus = new NguoiDungBUS();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            string loi;
            if (!nguoiDungBus.KiemTraKetNoi(out loi))
            {
                GiaoDien.BaoLoi("Không kết nối được cơ sở dữ liệu MySQL.\n\n" + loi +
                    "\n\nHãy kiểm tra: dịch vụ MySQL đang chạy, đã chạy file Database\\QLSV.sql, " +
                    "và chuỗi kết nối trong file QuanLySinhVien.exe.config.");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                nguoiDungBus.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.HienLoi(loi, this, errorProvider);
                txtMatKhau.SelectAll();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Lỗi khi đăng nhập: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
    }
}

using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.GUI
{
    /// <summary>Đổi mật khẩu của người đang đăng nhập (F01).</summary>
    public partial class frmDoiMatKhau : Form
    {
        private readonly NguoiDungBUS nguoiDungBus = new NguoiDungBUS();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                nguoiDungBus.DoiMatKhau(txtMatKhauCu.Text, txtMatKhauMoi.Text, txtXacNhan.Text);
                GiaoDien.ThongBao("Đổi mật khẩu thành công.");
                Close();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.HienLoi(loi, this, errorProvider);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

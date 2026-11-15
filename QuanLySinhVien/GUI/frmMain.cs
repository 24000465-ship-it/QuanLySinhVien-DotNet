using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    /// <summary>Form chính: menu chỉ hiện chức năng đúng vai trò người dùng (yêu cầu phi chức năng).</summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            NguoiDung nd = PhienDangNhap.NguoiDungHienTai;
            lblNguoiDung.Text = "Xin chào, " + nd.HoTen;
            lblVaiTro.Text = "Vai trò: " + NguoiDung.TenVaiTro(nd.VaiTro);
            lblNgay.Text = DateTime.Today.ToString("dd/MM/yyyy");

            bool laAdmin = nd.VaiTro == NguoiDung.VaiTroAdmin;
            bool laQuanLy = nd.LaQuanLyDaoTao;
            bool laGiangVien = nd.VaiTro == NguoiDung.VaiTroGiangVien;

            mnuQuanLyTaiKhoan.Visible = laAdmin;           // F02
            mnuDanhMuc.Visible = laQuanLy;                 // F04, F05
            mnuSinhVien.Visible = laQuanLy;                // F03
            mnuDaoTao.Visible = laQuanLy;                  // F06, F07
            mnuNhapDiem.Visible = laGiangVien;             // F08
            mnuThongKe.Visible = laQuanLy;                 // F11
        }

        /// <summary>Mở form con trong cửa sổ chính; form đã mở thì chỉ đưa lên trước.</summary>
        private void MoForm<T>() where T : Form, new()
        {
            foreach (Form con in MdiChildren)
            {
                if (con is T)
                {
                    con.Activate();
                    return;
                }
            }
            T form = new T();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau f = new frmDoiMatKhau())
            {
                f.ShowDialog(this);
            }
        }

        private void mnuQuanLyTaiKhoan_Click(object sender, EventArgs e) { MoForm<frmNguoiDung>(); }
        private void mnuKhoa_Click(object sender, EventArgs e) { MoForm<frmKhoa>(); }
        private void mnuNganh_Click(object sender, EventArgs e) { MoForm<frmNganh>(); }
        private void mnuLop_Click(object sender, EventArgs e) { MoForm<frmLop>(); }
        private void mnuHocKy_Click(object sender, EventArgs e) { MoForm<frmHocKy>(); }
        private void mnuMonHoc_Click(object sender, EventArgs e) { MoForm<frmMonHoc>(); }
        private void mnuGiangVien_Click(object sender, EventArgs e) { MoForm<frmGiangVien>(); }
        private void mnuCayDonVi_Click(object sender, EventArgs e) { MoForm<frmCayDonVi>(); }
        private void mnuQuanLySinhVien_Click(object sender, EventArgs e) { MoForm<frmSinhVien>(); }
        private void mnuXepMon_Click(object sender, EventArgs e) { MoForm<frmXepMon>(); }
        private void mnuPhanCong_Click(object sender, EventArgs e) { MoForm<frmPhanCong>(); }
        private void mnuNhapDiem_Click(object sender, EventArgs e) { MoForm<frmNhapDiem>(); }
        private void mnuBangDiem_Click(object sender, EventArgs e) { MoForm<frmBangDiem>(); }
        private void mnuThongKe_Click(object sender, EventArgs e) { MoForm<frmThongKe>(); }
        private void mnuBaoCao_Click(object sender, EventArgs e) { MoForm<frmBaoCao>(); }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (!GiaoDien.XacNhan("Bạn muốn đăng xuất?")) return;
            PhienDangNhap.KetThuc();
            Application.Restart();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            GiaoDien.ThongBao("Phần mềm Quản lý Sinh viên\n" +
                "Đề tài: Xây dựng phần mềm quản lý sinh viên bằng công nghệ .NET\n" +
                "Học phần Lập trình .NET (IT3212) — Trường Đại học Công nghệ Đông Á\n" +
                "C# WinForms (.NET Framework 4.8) · ADO.NET · MySQL · Crystal Reports");
        }
    }
}

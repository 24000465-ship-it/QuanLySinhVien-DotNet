namespace QuanLySinhVien.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuChinh = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNganh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHocKy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiangVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCayDonVi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLySinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDaoTao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXepMon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhanCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhTrangThai = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVaiTro = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNgay = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuChinh.SuspendLayout();
            this.thanhTrangThai.SuspendLayout();
            this.SuspendLayout();
            this.menuChinh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuHeThong, this.mnuDanhMuc, this.mnuSinhVien, this.mnuDaoTao,
                this.mnuDiem, this.mnuBaoCaoThongKe, this.mnuCuaSo, this.mnuTroGiup });
            this.menuChinh.Location = new System.Drawing.Point(0, 0);
            this.menuChinh.MdiWindowListItem = this.mnuCuaSo;
            this.menuChinh.Name = "menuChinh";
            this.menuChinh.Size = new System.Drawing.Size(1100, 24);
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuDoiMatKhau, this.mnuQuanLyTaiKhoan, this.mnuDangXuat, this.mnuThoat });
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Text = "&Hệ thống";
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Text = "Đổi mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            this.mnuQuanLyTaiKhoan.Name = "mnuQuanLyTaiKhoan";
            this.mnuQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.mnuQuanLyTaiKhoan.Click += new System.EventHandler(this.mnuQuanLyTaiKhoan_Click);
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuKhoa, this.mnuNganh, this.mnuLop, this.mnuHocKy, this.mnuMonHoc,
                this.mnuGiangVien, this.mnuCayDonVi });
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Text = "&Danh mục";
            this.mnuKhoa.Name = "mnuKhoa";
            this.mnuKhoa.Text = "Khoa";
            this.mnuKhoa.Click += new System.EventHandler(this.mnuKhoa_Click);
            this.mnuNganh.Name = "mnuNganh";
            this.mnuNganh.Text = "Ngành";
            this.mnuNganh.Click += new System.EventHandler(this.mnuNganh_Click);
            this.mnuLop.Name = "mnuLop";
            this.mnuLop.Text = "Lớp";
            this.mnuLop.Click += new System.EventHandler(this.mnuLop_Click);
            this.mnuHocKy.Name = "mnuHocKy";
            this.mnuHocKy.Text = "Học kỳ";
            this.mnuHocKy.Click += new System.EventHandler(this.mnuHocKy_Click);
            this.mnuMonHoc.Name = "mnuMonHoc";
            this.mnuMonHoc.Text = "Môn học";
            this.mnuMonHoc.Click += new System.EventHandler(this.mnuMonHoc_Click);
            this.mnuGiangVien.Name = "mnuGiangVien";
            this.mnuGiangVien.Text = "Giảng viên";
            this.mnuGiangVien.Click += new System.EventHandler(this.mnuGiangVien_Click);
            this.mnuCayDonVi.Name = "mnuCayDonVi";
            this.mnuCayDonVi.Text = "Cây Khoa - Ngành - Lớp";
            this.mnuCayDonVi.Click += new System.EventHandler(this.mnuCayDonVi_Click);
            this.mnuSinhVien.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuQuanLySinhVien });
            this.mnuSinhVien.Name = "mnuSinhVien";
            this.mnuSinhVien.Text = "&Sinh viên";
            this.mnuQuanLySinhVien.Name = "mnuQuanLySinhVien";
            this.mnuQuanLySinhVien.Text = "Quản lý sinh viên";
            this.mnuQuanLySinhVien.Click += new System.EventHandler(this.mnuQuanLySinhVien_Click);
            this.mnuDaoTao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuXepMon, this.mnuPhanCong });
            this.mnuDaoTao.Name = "mnuDaoTao";
            this.mnuDaoTao.Text = "Đà&o tạo";
            this.mnuXepMon.Name = "mnuXepMon";
            this.mnuXepMon.Text = "Xếp môn theo lớp";
            this.mnuXepMon.Click += new System.EventHandler(this.mnuXepMon_Click);
            this.mnuPhanCong.Name = "mnuPhanCong";
            this.mnuPhanCong.Text = "Phân công giảng viên";
            this.mnuPhanCong.Click += new System.EventHandler(this.mnuPhanCong_Click);
            this.mnuDiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuNhapDiem, this.mnuBangDiem });
            this.mnuDiem.Name = "mnuDiem";
            this.mnuDiem.Text = "Đ&iểm";
            this.mnuNhapDiem.Name = "mnuNhapDiem";
            this.mnuNhapDiem.Text = "Nhập điểm";
            this.mnuNhapDiem.Click += new System.EventHandler(this.mnuNhapDiem_Click);
            this.mnuBangDiem.Name = "mnuBangDiem";
            this.mnuBangDiem.Text = "Xem bảng điểm";
            this.mnuBangDiem.Click += new System.EventHandler(this.mnuBangDiem_Click);
            this.mnuBaoCaoThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuThongKe, this.mnuBaoCao });
            this.mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            this.mnuBaoCaoThongKe.Text = "&Thống kê - Báo cáo";
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Text = "Thống kê";
            this.mnuThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Text = "Báo cáo (Crystal Report)";
            this.mnuBaoCao.Click += new System.EventHandler(this.mnuBaoCao_Click);
            this.mnuCuaSo.Name = "mnuCuaSo";
            this.mnuCuaSo.Text = "&Cửa sổ";
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuGioiThieu });
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Text = "Trợ &giúp";
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Text = "Giới thiệu";
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click);
            this.thanhTrangThai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblNguoiDung, this.lblVaiTro, this.lblNgay });
            this.thanhTrangThai.Name = "thanhTrangThai";
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Spring = true;
            this.lblNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblNgay.Name = "lblNgay";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.thanhTrangThai);
            this.Controls.Add(this.menuChinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuChinh;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuChinh.ResumeLayout(false);
            this.menuChinh.PerformLayout();
            this.thanhTrangThai.ResumeLayout(false);
            this.thanhTrangThai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuChinh;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuKhoa;
        private System.Windows.Forms.ToolStripMenuItem mnuNganh;
        private System.Windows.Forms.ToolStripMenuItem mnuLop;
        private System.Windows.Forms.ToolStripMenuItem mnuHocKy;
        private System.Windows.Forms.ToolStripMenuItem mnuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuGiangVien;
        private System.Windows.Forms.ToolStripMenuItem mnuCayDonVi;
        private System.Windows.Forms.ToolStripMenuItem mnuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLySinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuDaoTao;
        private System.Windows.Forms.ToolStripMenuItem mnuXepMon;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanCong;
        private System.Windows.Forms.ToolStripMenuItem mnuDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBangDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        private System.Windows.Forms.StatusStrip thanhTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel lblVaiTro;
        private System.Windows.Forms.ToolStripStatusLabel lblNgay;
    }
}

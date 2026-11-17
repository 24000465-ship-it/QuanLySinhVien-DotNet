namespace QuanLySinhVien.GUI
{
    partial class frmNguoiDung
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
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnCapLaiMatKhau = new System.Windows.Forms.Button();
            this.pnlNhapLieu.SuspendLayout();
            this.pnlNut.SuspendLayout();
            this.SuspendLayout();
            this.pnlNhapLieu.Controls.Add(this.lblTenDangNhap);
            this.pnlNhapLieu.Controls.Add(this.txtTenDangNhap);
            this.pnlNhapLieu.Controls.Add(this.lblHoTen);
            this.pnlNhapLieu.Controls.Add(this.txtHoTen);
            this.pnlNhapLieu.Controls.Add(this.lblVaiTro);
            this.pnlNhapLieu.Controls.Add(this.cboVaiTro);
            this.pnlNhapLieu.Controls.Add(this.lblMatKhau);
            this.pnlNhapLieu.Controls.Add(this.txtMatKhau);
            this.pnlNut.Controls.Add(this.btnKhoa);
            this.pnlNut.Controls.Add(this.btnCapLaiMatKhau);
            this.grpThongTin.Size = new System.Drawing.Size(900, 110);
            this.grpThongTin.Text = "Thông tin tài khoản";
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(15, 15);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            this.txtTenDangNhap.Location = new System.Drawing.Point(115, 12);
            this.txtTenDangNhap.MaxLength = 30;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(150, 23);
            this.txtTenDangNhap.TabIndex = 0;
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(290, 15);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên:";
            this.txtHoTen.Location = new System.Drawing.Point(345, 12);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(250, 23);
            this.txtHoTen.TabIndex = 1;
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(15, 50);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Text = "Vai trò:";
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Location = new System.Drawing.Point(115, 47);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(150, 23);
            this.cboVaiTro.TabIndex = 2;
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(290, 50);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu:";
            this.txtMatKhau.Location = new System.Drawing.Point(345, 47);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(150, 23);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(120, 30);
            this.btnKhoa.Text = "Khóa tài khoản";
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            this.btnCapLaiMatKhau.Name = "btnCapLaiMatKhau";
            this.btnCapLaiMatKhau.Size = new System.Drawing.Size(140, 30);
            this.btnCapLaiMatKhau.Text = "Cấp lại mật khẩu";
            this.btnCapLaiMatKhau.Click += new System.EventHandler(this.btnCapLaiMatKhau_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmNguoiDung";
            this.Text = "Quản lý tài khoản";
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.pnlNut.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnCapLaiMatKhau;
    }
}

namespace QuanLySinhVien.GUI
{
    partial class frmGiangVien
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
            this.lblLocKhoa = new System.Windows.Forms.Label();
            this.cboLocKhoa = new System.Windows.Forms.ComboBox();
            this.lblMaGV = new System.Windows.Forms.Label();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.cboMaKhoa = new System.Windows.Forms.ComboBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.pnlTimKiem.SuspendLayout();
            this.pnlNhapLieu.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTimKiem: thêm bộ lọc theo khoa
            //
            this.pnlTimKiem.Controls.Add(this.lblLocKhoa);
            this.pnlTimKiem.Controls.Add(this.cboLocKhoa);
            this.lblLocKhoa.AutoSize = true;
            this.lblLocKhoa.Location = new System.Drawing.Point(495, 13);
            this.lblLocKhoa.Name = "lblLocKhoa";
            this.lblLocKhoa.Text = "Khoa:";
            this.cboLocKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocKhoa.Location = new System.Drawing.Point(540, 10);
            this.cboLocKhoa.Name = "cboLocKhoa";
            this.cboLocKhoa.Size = new System.Drawing.Size(220, 23);
            this.cboLocKhoa.TabIndex = 2;
            this.cboLocKhoa.SelectedIndexChanged += new System.EventHandler(this.cboLocKhoa_SelectedIndexChanged);
            //
            // pnlNhapLieu
            //
            this.pnlNhapLieu.Controls.Add(this.lblMaGV);
            this.pnlNhapLieu.Controls.Add(this.txtMaGV);
            this.pnlNhapLieu.Controls.Add(this.lblHoTen);
            this.pnlNhapLieu.Controls.Add(this.txtHoTen);
            this.pnlNhapLieu.Controls.Add(this.lblNgaySinh);
            this.pnlNhapLieu.Controls.Add(this.dtpNgaySinh);
            this.pnlNhapLieu.Controls.Add(this.lblGioiTinh);
            this.pnlNhapLieu.Controls.Add(this.cboGioiTinh);
            this.pnlNhapLieu.Controls.Add(this.lblSoDienThoai);
            this.pnlNhapLieu.Controls.Add(this.txtSoDienThoai);
            this.pnlNhapLieu.Controls.Add(this.lblEmail);
            this.pnlNhapLieu.Controls.Add(this.txtEmail);
            this.pnlNhapLieu.Controls.Add(this.lblMaKhoa);
            this.pnlNhapLieu.Controls.Add(this.cboMaKhoa);
            this.pnlNhapLieu.Controls.Add(this.lblTenDangNhap);
            this.pnlNhapLieu.Controls.Add(this.txtTenDangNhap);
            //
            // grpThongTin
            //
            this.grpThongTin.Size = new System.Drawing.Size(900, 140);
            this.grpThongTin.Text = "Thông tin giảng viên";
            //
            // dòng 1
            //
            this.lblMaGV.AutoSize = true;
            this.lblMaGV.Location = new System.Drawing.Point(15, 15);
            this.lblMaGV.Name = "lblMaGV";
            this.lblMaGV.Text = "Mã GV:";
            this.txtMaGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaGV.Location = new System.Drawing.Point(100, 12);
            this.txtMaGV.MaxLength = 10;
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(110, 23);
            this.txtMaGV.TabIndex = 0;
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(230, 15);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên:";
            this.txtHoTen.Location = new System.Drawing.Point(290, 12);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(230, 23);
            this.txtHoTen.TabIndex = 1;
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(540, 15);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(615, 12);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(120, 23);
            this.dtpNgaySinh.TabIndex = 2;
            //
            // dòng 2
            //
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(15, 50);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Text = "Giới tính:";
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Location = new System.Drawing.Point(100, 47);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(110, 23);
            this.cboGioiTinh.TabIndex = 3;
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(230, 50);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "Điện thoại:";
            this.txtSoDienThoai.Location = new System.Drawing.Point(290, 47);
            this.txtSoDienThoai.MaxLength = 10;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(120, 23);
            this.txtSoDienThoai.TabIndex = 4;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(540, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email:";
            this.txtEmail.Location = new System.Drawing.Point(615, 47);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 23);
            this.txtEmail.TabIndex = 5;
            //
            // dòng 3
            //
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Location = new System.Drawing.Point(15, 85);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Text = "Khoa:";
            this.cboMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaKhoa.Location = new System.Drawing.Point(100, 82);
            this.cboMaKhoa.Name = "cboMaKhoa";
            this.cboMaKhoa.Size = new System.Drawing.Size(310, 23);
            this.cboMaKhoa.TabIndex = 6;
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(540, 85);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Text = "Tài khoản:";
            this.txtTenDangNhap.Location = new System.Drawing.Point(615, 82);
            this.txtTenDangNhap.MaxLength = 30;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(150, 23);
            this.txtTenDangNhap.TabIndex = 7;
            //
            // frmGiangVien
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmGiangVien";
            this.Text = "Quản lý giảng viên";
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblLocKhoa;
        private System.Windows.Forms.ComboBox cboLocKhoa;
        private System.Windows.Forms.Label lblMaGV;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.ComboBox cboMaKhoa;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
    }
}

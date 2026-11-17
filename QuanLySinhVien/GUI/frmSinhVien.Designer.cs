namespace QuanLySinhVien.GUI
{
    partial class frmSinhVien
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
            this.lblLocLop = new System.Windows.Forms.Label();
            this.cboLocLop = new System.Windows.Forms.ComboBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.pnlGioiTinh = new System.Windows.Forms.Panel();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.cboMaLop = new System.Windows.Forms.ComboBox();
            this.pnlTimKiem.SuspendLayout();
            this.pnlNhapLieu.SuspendLayout();
            this.pnlGioiTinh.SuspendLayout();
            this.SuspendLayout();
            this.pnlTimKiem.Controls.Add(this.lblLocLop);
            this.pnlTimKiem.Controls.Add(this.cboLocLop);
            this.lblLocLop.AutoSize = true;
            this.lblLocLop.Location = new System.Drawing.Point(495, 13);
            this.lblLocLop.Name = "lblLocLop";
            this.lblLocLop.Text = "Lớp:";
            this.cboLocLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLop.Location = new System.Drawing.Point(530, 10);
            this.cboLocLop.Name = "cboLocLop";
            this.cboLocLop.Size = new System.Drawing.Size(230, 23);
            this.cboLocLop.TabIndex = 2;
            this.cboLocLop.SelectedIndexChanged += new System.EventHandler(this.cboLocLop_SelectedIndexChanged);
            this.pnlNhapLieu.Controls.Add(this.lblMaSV);
            this.pnlNhapLieu.Controls.Add(this.txtMaSV);
            this.pnlNhapLieu.Controls.Add(this.lblHoTen);
            this.pnlNhapLieu.Controls.Add(this.txtHoTen);
            this.pnlNhapLieu.Controls.Add(this.lblNgaySinh);
            this.pnlNhapLieu.Controls.Add(this.dtpNgaySinh);
            this.pnlNhapLieu.Controls.Add(this.lblGioiTinh);
            this.pnlNhapLieu.Controls.Add(this.pnlGioiTinh);
            this.pnlNhapLieu.Controls.Add(this.lblSoDienThoai);
            this.pnlNhapLieu.Controls.Add(this.txtSoDienThoai);
            this.pnlNhapLieu.Controls.Add(this.lblMaLop);
            this.pnlNhapLieu.Controls.Add(this.cboMaLop);
            this.grpThongTin.Size = new System.Drawing.Size(900, 110);
            this.grpThongTin.Text = "Thông tin sinh viên";
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(15, 15);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Text = "Mã SV:";
            this.txtMaSV.Location = new System.Drawing.Point(80, 12);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.ReadOnly = true;
            this.txtMaSV.Size = new System.Drawing.Size(130, 23);
            this.txtMaSV.TabStop = false;
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(230, 15);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên:";
            this.txtHoTen.Location = new System.Drawing.Point(285, 12);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(230, 23);
            this.txtHoTen.TabIndex = 0;
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(540, 15);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(615, 12);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(120, 23);
            this.dtpNgaySinh.TabIndex = 1;
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(15, 50);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Text = "Giới tính:";
            this.pnlGioiTinh.Controls.Add(this.rdoNam);
            this.pnlGioiTinh.Controls.Add(this.rdoNu);
            this.pnlGioiTinh.Location = new System.Drawing.Point(80, 45);
            this.pnlGioiTinh.Name = "pnlGioiTinh";
            this.pnlGioiTinh.Size = new System.Drawing.Size(130, 28);
            this.pnlGioiTinh.TabIndex = 2;
            this.rdoNam.AutoSize = true;
            this.rdoNam.Checked = true;
            this.rdoNam.Location = new System.Drawing.Point(3, 4);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(65, 4);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Text = "Nữ";
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(230, 50);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "Điện thoại:";
            this.txtSoDienThoai.Location = new System.Drawing.Point(300, 47);
            this.txtSoDienThoai.MaxLength = 10;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(130, 23);
            this.txtSoDienThoai.TabIndex = 3;
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(540, 50);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Text = "Lớp:";
            this.cboMaLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaLop.Location = new System.Drawing.Point(615, 47);
            this.cboMaLop.Name = "cboMaLop";
            this.cboMaLop.Size = new System.Drawing.Size(250, 23);
            this.cboMaLop.TabIndex = 4;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmSinhVien";
            this.Text = "Quản lý sinh viên";
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.pnlGioiTinh.ResumeLayout(false);
            this.pnlGioiTinh.PerformLayout();
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblLocLop;
        private System.Windows.Forms.ComboBox cboLocLop;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Panel pnlGioiTinh;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.ComboBox cboMaLop;
    }
}

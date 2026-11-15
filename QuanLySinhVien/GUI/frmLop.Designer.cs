namespace QuanLySinhVien.GUI
{
    partial class frmLop
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
            this.lblMaNganh = new System.Windows.Forms.Label();
            this.cboMaNganh = new System.Windows.Forms.ComboBox();
            this.lblKhoaHoc = new System.Windows.Forms.Label();
            this.nudKhoaHoc = new System.Windows.Forms.NumericUpDown();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.pnlNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKhoaHoc)).BeginInit();
            this.SuspendLayout();
            //
            // pnlNhapLieu
            //
            this.pnlNhapLieu.Controls.Add(this.lblMaNganh);
            this.pnlNhapLieu.Controls.Add(this.cboMaNganh);
            this.pnlNhapLieu.Controls.Add(this.lblKhoaHoc);
            this.pnlNhapLieu.Controls.Add(this.nudKhoaHoc);
            this.pnlNhapLieu.Controls.Add(this.lblMaLop);
            this.pnlNhapLieu.Controls.Add(this.txtMaLop);
            this.pnlNhapLieu.Controls.Add(this.lblTenLop);
            this.pnlNhapLieu.Controls.Add(this.txtTenLop);
            //
            // grpThongTin
            //
            this.grpThongTin.Size = new System.Drawing.Size(900, 110);
            this.grpThongTin.Text = "Thông tin lớp";
            //
            // lblMaNganh
            //
            this.lblMaNganh.AutoSize = true;
            this.lblMaNganh.Location = new System.Drawing.Point(15, 15);
            this.lblMaNganh.Name = "lblMaNganh";
            this.lblMaNganh.Text = "Ngành:";
            //
            // cboMaNganh
            //
            this.cboMaNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNganh.Location = new System.Drawing.Point(110, 12);
            this.cboMaNganh.Name = "cboMaNganh";
            this.cboMaNganh.Size = new System.Drawing.Size(330, 23);
            this.cboMaNganh.TabIndex = 0;
            this.cboMaNganh.SelectedIndexChanged += new System.EventHandler(this.cboMaNganh_SelectedIndexChanged);
            //
            // lblKhoaHoc
            //
            this.lblKhoaHoc.AutoSize = true;
            this.lblKhoaHoc.Location = new System.Drawing.Point(470, 15);
            this.lblKhoaHoc.Name = "lblKhoaHoc";
            this.lblKhoaHoc.Text = "Năm nhập học:";
            //
            // nudKhoaHoc
            //
            this.nudKhoaHoc.Location = new System.Drawing.Point(570, 12);
            this.nudKhoaHoc.Maximum = new decimal(new int[] { 2099, 0, 0, 0 });
            this.nudKhoaHoc.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.nudKhoaHoc.Name = "nudKhoaHoc";
            this.nudKhoaHoc.Size = new System.Drawing.Size(80, 23);
            this.nudKhoaHoc.TabIndex = 1;
            this.nudKhoaHoc.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            this.nudKhoaHoc.ValueChanged += new System.EventHandler(this.nudKhoaHoc_ValueChanged);
            //
            // lblMaLop
            //
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(15, 50);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Text = "Mã lớp:";
            //
            // txtMaLop
            //
            this.txtMaLop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaLop.Location = new System.Drawing.Point(110, 47);
            this.txtMaLop.MaxLength = 15;
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(120, 23);
            this.txtMaLop.TabIndex = 2;
            //
            // lblTenLop
            //
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(250, 50);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Text = "Tên lớp:";
            //
            // txtTenLop
            //
            this.txtTenLop.Location = new System.Drawing.Point(310, 47);
            this.txtTenLop.MaxLength = 100;
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(340, 23);
            this.txtTenLop.TabIndex = 3;
            //
            // frmLop
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmLop";
            this.Text = "Quản lý lớp";
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKhoaHoc)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblMaNganh;
        private System.Windows.Forms.ComboBox cboMaNganh;
        private System.Windows.Forms.Label lblKhoaHoc;
        private System.Windows.Forms.NumericUpDown nudKhoaHoc;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
    }
}

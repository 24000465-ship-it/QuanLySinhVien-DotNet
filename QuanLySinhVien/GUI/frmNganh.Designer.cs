namespace QuanLySinhVien.GUI
{
    partial class frmNganh
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
            this.txtMaNganh = new System.Windows.Forms.TextBox();
            this.lblTenNganh = new System.Windows.Forms.Label();
            this.txtTenNganh = new System.Windows.Forms.TextBox();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.cboMaKhoa = new System.Windows.Forms.ComboBox();
            this.pnlNhapLieu.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlNhapLieu
            //
            this.pnlNhapLieu.Controls.Add(this.lblMaNganh);
            this.pnlNhapLieu.Controls.Add(this.txtMaNganh);
            this.pnlNhapLieu.Controls.Add(this.lblTenNganh);
            this.pnlNhapLieu.Controls.Add(this.txtTenNganh);
            this.pnlNhapLieu.Controls.Add(this.lblMaKhoa);
            this.pnlNhapLieu.Controls.Add(this.cboMaKhoa);
            //
            // grpThongTin
            //
            this.grpThongTin.Size = new System.Drawing.Size(900, 110);
            this.grpThongTin.Text = "Thông tin ngành";
            //
            // lblMaNganh
            //
            this.lblMaNganh.AutoSize = true;
            this.lblMaNganh.Location = new System.Drawing.Point(15, 15);
            this.lblMaNganh.Name = "lblMaNganh";
            this.lblMaNganh.Text = "Mã ngành (2 số):";
            //
            // txtMaNganh
            //
            this.txtMaNganh.Location = new System.Drawing.Point(125, 12);
            this.txtMaNganh.MaxLength = 2;
            this.txtMaNganh.Name = "txtMaNganh";
            this.txtMaNganh.Size = new System.Drawing.Size(60, 23);
            this.txtMaNganh.TabIndex = 0;
            //
            // lblTenNganh
            //
            this.lblTenNganh.AutoSize = true;
            this.lblTenNganh.Location = new System.Drawing.Point(215, 15);
            this.lblTenNganh.Name = "lblTenNganh";
            this.lblTenNganh.Text = "Tên ngành:";
            //
            // txtTenNganh
            //
            this.txtTenNganh.Location = new System.Drawing.Point(295, 12);
            this.txtTenNganh.MaxLength = 100;
            this.txtTenNganh.Name = "txtTenNganh";
            this.txtTenNganh.Size = new System.Drawing.Size(400, 23);
            this.txtTenNganh.TabIndex = 1;
            //
            // lblMaKhoa
            //
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Location = new System.Drawing.Point(15, 50);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Text = "Thuộc khoa:";
            //
            // cboMaKhoa
            //
            this.cboMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaKhoa.Location = new System.Drawing.Point(125, 47);
            this.cboMaKhoa.Name = "cboMaKhoa";
            this.cboMaKhoa.Size = new System.Drawing.Size(300, 23);
            this.cboMaKhoa.TabIndex = 2;
            //
            // frmNganh
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmNganh";
            this.Text = "Quản lý ngành";
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblMaNganh;
        private System.Windows.Forms.TextBox txtMaNganh;
        private System.Windows.Forms.Label lblTenNganh;
        private System.Windows.Forms.TextBox txtTenNganh;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.ComboBox cboMaKhoa;
    }
}

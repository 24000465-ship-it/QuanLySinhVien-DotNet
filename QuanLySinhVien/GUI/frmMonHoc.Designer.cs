namespace QuanLySinhVien.GUI
{
    partial class frmMonHoc
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
            this.lblMaMon = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblSoTinChi = new System.Windows.Forms.Label();
            this.nudSoTinChi = new System.Windows.Forms.NumericUpDown();
            this.pnlNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTinChi)).BeginInit();
            this.SuspendLayout();
            this.pnlNhapLieu.Controls.Add(this.lblMaMon);
            this.pnlNhapLieu.Controls.Add(this.txtMaMon);
            this.pnlNhapLieu.Controls.Add(this.lblTenMon);
            this.pnlNhapLieu.Controls.Add(this.txtTenMon);
            this.pnlNhapLieu.Controls.Add(this.lblSoTinChi);
            this.pnlNhapLieu.Controls.Add(this.nudSoTinChi);
            this.grpThongTin.Size = new System.Drawing.Size(900, 110);
            this.grpThongTin.Text = "Thông tin môn học";
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Location = new System.Drawing.Point(15, 15);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Text = "Mã môn:";
            this.txtMaMon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaMon.Location = new System.Drawing.Point(90, 12);
            this.txtMaMon.MaxLength = 10;
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(120, 23);
            this.txtMaMon.TabIndex = 0;
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(230, 15);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Text = "Tên môn:";
            this.txtTenMon.Location = new System.Drawing.Point(295, 12);
            this.txtTenMon.MaxLength = 100;
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(400, 23);
            this.txtTenMon.TabIndex = 1;
            this.lblSoTinChi.AutoSize = true;
            this.lblSoTinChi.Location = new System.Drawing.Point(15, 50);
            this.lblSoTinChi.Name = "lblSoTinChi";
            this.lblSoTinChi.Text = "Số tín chỉ:";
            this.nudSoTinChi.Location = new System.Drawing.Point(90, 47);
            this.nudSoTinChi.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudSoTinChi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoTinChi.Name = "nudSoTinChi";
            this.nudSoTinChi.Size = new System.Drawing.Size(60, 23);
            this.nudSoTinChi.TabIndex = 2;
            this.nudSoTinChi.Value = new decimal(new int[] { 3, 0, 0, 0 });
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmMonHoc";
            this.Text = "Quản lý môn học";
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTinChi)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblSoTinChi;
        private System.Windows.Forms.NumericUpDown nudSoTinChi;
    }
}

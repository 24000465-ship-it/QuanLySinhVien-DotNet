namespace QuanLySinhVien.GUI
{
    partial class frmHocKy
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
            this.lblMaHocKy = new System.Windows.Forms.Label();
            this.txtMaHocKy = new System.Windows.Forms.TextBox();
            this.lblGoiY = new System.Windows.Forms.Label();
            this.lblTenHocKy = new System.Windows.Forms.Label();
            this.txtTenHocKy = new System.Windows.Forms.TextBox();
            this.pnlNhapLieu.SuspendLayout();
            this.SuspendLayout();
            this.pnlNhapLieu.Controls.Add(this.lblMaHocKy);
            this.pnlNhapLieu.Controls.Add(this.txtMaHocKy);
            this.pnlNhapLieu.Controls.Add(this.lblGoiY);
            this.pnlNhapLieu.Controls.Add(this.lblTenHocKy);
            this.pnlNhapLieu.Controls.Add(this.txtTenHocKy);
            this.grpThongTin.Size = new System.Drawing.Size(900, 110);
            this.grpThongTin.Text = "Thông tin học kỳ";
            this.lblMaHocKy.AutoSize = true;
            this.lblMaHocKy.Location = new System.Drawing.Point(15, 15);
            this.lblMaHocKy.Name = "lblMaHocKy";
            this.lblMaHocKy.Text = "Mã học kỳ:";
            this.txtMaHocKy.Location = new System.Drawing.Point(100, 12);
            this.txtMaHocKy.MaxLength = 5;
            this.txtMaHocKy.Name = "txtMaHocKy";
            this.txtMaHocKy.Size = new System.Drawing.Size(80, 23);
            this.txtMaHocKy.TabIndex = 0;
            this.txtMaHocKy.TextChanged += new System.EventHandler(this.txtMaHocKy_TextChanged);
            this.lblGoiY.AutoSize = true;
            this.lblGoiY.ForeColor = System.Drawing.Color.DimGray;
            this.lblGoiY.Location = new System.Drawing.Point(190, 15);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Text = "Dạng NNNNK, ví dụ 20261 = học kỳ 1 năm học 2026-2027";
            this.lblTenHocKy.AutoSize = true;
            this.lblTenHocKy.Location = new System.Drawing.Point(15, 50);
            this.lblTenHocKy.Name = "lblTenHocKy";
            this.lblTenHocKy.Text = "Tên học kỳ:";
            this.txtTenHocKy.Location = new System.Drawing.Point(100, 47);
            this.txtTenHocKy.MaxLength = 50;
            this.txtTenHocKy.Name = "txtTenHocKy";
            this.txtTenHocKy.Size = new System.Drawing.Size(330, 23);
            this.txtTenHocKy.TabIndex = 1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmHocKy";
            this.Text = "Quản lý học kỳ";
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblMaHocKy;
        private System.Windows.Forms.TextBox txtMaHocKy;
        private System.Windows.Forms.Label lblGoiY;
        private System.Windows.Forms.Label lblTenHocKy;
        private System.Windows.Forms.TextBox txtTenHocKy;
    }
}

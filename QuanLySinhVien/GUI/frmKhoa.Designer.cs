namespace QuanLySinhVien.GUI
{
    partial class frmKhoa
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
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            this.lblTenKhoa = new System.Windows.Forms.Label();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.pnlNhapLieu.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlNhapLieu
            //
            this.pnlNhapLieu.Controls.Add(this.lblMaKhoa);
            this.pnlNhapLieu.Controls.Add(this.txtMaKhoa);
            this.pnlNhapLieu.Controls.Add(this.lblTenKhoa);
            this.pnlNhapLieu.Controls.Add(this.txtTenKhoa);
            //
            // grpThongTin
            //
            this.grpThongTin.Size = new System.Drawing.Size(900, 100);
            this.grpThongTin.Text = "Thông tin khoa";
            //
            // lblMaKhoa
            //
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Location = new System.Drawing.Point(15, 15);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Text = "Mã khoa:";
            //
            // txtMaKhoa
            //
            this.txtMaKhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaKhoa.Location = new System.Drawing.Point(90, 12);
            this.txtMaKhoa.MaxLength = 10;
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Size = new System.Drawing.Size(150, 23);
            this.txtMaKhoa.TabIndex = 0;
            //
            // lblTenKhoa
            //
            this.lblTenKhoa.AutoSize = true;
            this.lblTenKhoa.Location = new System.Drawing.Point(270, 15);
            this.lblTenKhoa.Name = "lblTenKhoa";
            this.lblTenKhoa.Text = "Tên khoa:";
            //
            // txtTenKhoa
            //
            this.txtTenKhoa.Location = new System.Drawing.Point(345, 12);
            this.txtTenKhoa.MaxLength = 100;
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(380, 23);
            this.txtTenKhoa.TabIndex = 1;
            //
            // frmKhoa
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "frmKhoa";
            this.Text = "Quản lý khoa";
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.Label lblTenKhoa;
        private System.Windows.Forms.TextBox txtTenKhoa;
    }
}

namespace QuanLySinhVien.GUI
{
    partial class frmDoiMatKhau
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
            this.components = new System.ComponentModel.Container();
            this.lblMatKhauCu = new System.Windows.Forms.Label();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblXacNhan = new System.Windows.Forms.Label();
            this.txtXacNhan = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Location = new System.Drawing.Point(25, 28);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Text = "Mật khẩu hiện tại:";
            this.txtMatKhauCu.Location = new System.Drawing.Point(160, 25);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(220, 23);
            this.txtMatKhauCu.TabIndex = 0;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Location = new System.Drawing.Point(25, 64);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            this.txtMatKhauMoi.Location = new System.Drawing.Point(160, 61);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(220, 23);
            this.txtMatKhauMoi.TabIndex = 1;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            this.lblXacNhan.AutoSize = true;
            this.lblXacNhan.Location = new System.Drawing.Point(25, 100);
            this.lblXacNhan.Name = "lblXacNhan";
            this.lblXacNhan.Text = "Nhập lại mật khẩu mới:";
            this.txtXacNhan.Location = new System.Drawing.Point(160, 97);
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.Size = new System.Drawing.Size(220, 23);
            this.txtXacNhan.TabIndex = 2;
            this.txtXacNhan.UseSystemPasswordChar = true;
            this.btnLuu.Location = new System.Drawing.Point(160, 140);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(105, 30);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnHuy.Location = new System.Drawing.Point(275, 140);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(105, 30);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.errorProvider.ContainerControl = this;
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(420, 195);
            this.Controls.Add(this.lblMatKhauCu);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.lblMatKhauMoi);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.lblXacNhan);
            this.Controls.Add(this.txtXacNhan);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblXacNhan;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

namespace QuanLySinhVien.GUI
{
    partial class frmPhanCong
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
            this.pnlChon = new System.Windows.Forms.Panel();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.cboGiangVien = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.dgvMonCuaLop = new System.Windows.Forms.DataGridView();
            this.pnlChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonCuaLop)).BeginInit();
            this.SuspendLayout();
            //
            // pnlChon
            //
            this.pnlChon.Controls.Add(this.lblHocKy);
            this.pnlChon.Controls.Add(this.cboHocKy);
            this.pnlChon.Controls.Add(this.lblLop);
            this.pnlChon.Controls.Add(this.cboLop);
            this.pnlChon.Controls.Add(this.lblMonHoc);
            this.pnlChon.Controls.Add(this.cboMonHoc);
            this.pnlChon.Controls.Add(this.lblGiangVien);
            this.pnlChon.Controls.Add(this.cboGiangVien);
            this.pnlChon.Controls.Add(this.btnLuu);
            this.pnlChon.Controls.Add(this.lblGhiChu);
            this.pnlChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChon.Name = "pnlChon";
            this.pnlChon.Size = new System.Drawing.Size(1000, 110);
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(12, 15);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Text = "Học kỳ:";
            this.cboHocKy.Location = new System.Drawing.Point(85, 12);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(260, 23);
            this.cboHocKy.TabIndex = 0;
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(365, 15);
            this.lblLop.Name = "lblLop";
            this.lblLop.Text = "Lớp:";
            this.cboLop.Location = new System.Drawing.Point(410, 12);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(300, 23);
            this.cboLop.TabIndex = 1;
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(12, 48);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Text = "Môn đã xếp:";
            this.cboMonHoc.Location = new System.Drawing.Point(85, 45);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(260, 23);
            this.cboMonHoc.TabIndex = 2;
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Location = new System.Drawing.Point(365, 48);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Text = "Giảng viên:";
            this.cboGiangVien.Location = new System.Drawing.Point(440, 45);
            this.cboGiangVien.Name = "cboGiangVien";
            this.cboGiangVien.Size = new System.Drawing.Size(270, 23);
            this.cboGiangVien.TabIndex = 3;
            this.btnLuu.Location = new System.Drawing.Point(730, 42);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(130, 30);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu phân công";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChu.Location = new System.Drawing.Point(12, 82);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Text = "Chỉ phân công được môn lớp đã xếp; mỗi lớp - môn - học kỳ chỉ một giảng viên (lưu lại sẽ thay giảng viên cũ).";
            //
            // dgvMonCuaLop
            //
            this.dgvMonCuaLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonCuaLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonCuaLop.Name = "dgvMonCuaLop";
            this.dgvMonCuaLop.TabIndex = 5;
            this.dgvMonCuaLop.SelectionChanged += new System.EventHandler(this.dgvMonCuaLop_SelectionChanged);
            //
            // frmPhanCong
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.dgvMonCuaLop);
            this.Controls.Add(this.pnlChon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmPhanCong";
            this.Text = "Phân công giảng viên";
            this.Load += new System.EventHandler(this.frmPhanCong_Load);
            this.pnlChon.ResumeLayout(false);
            this.pnlChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonCuaLop)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlChon;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblGiangVien;
        private System.Windows.Forms.ComboBox cboGiangVien;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.DataGridView dgvMonCuaLop;
    }
}

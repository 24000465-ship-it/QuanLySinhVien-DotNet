namespace QuanLySinhVien.GUI
{
    partial class frmBangDiem
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
            this.tabChinh = new System.Windows.Forms.TabControl();
            this.tabLopMon = new System.Windows.Forms.TabPage();
            this.dgvLopMon = new System.Windows.Forms.DataGridView();
            this.pnlLopMon = new System.Windows.Forms.Panel();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.btnXemLopMon = new System.Windows.Forms.Button();
            this.btnXuatExcelLopMon = new System.Windows.Forms.Button();
            this.lblTomTatLopMon = new System.Windows.Forms.Label();
            this.tabSinhVien = new System.Windows.Forms.TabPage();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.pnlSinhVien = new System.Windows.Forms.Panel();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.btnXemSinhVien = new System.Windows.Forms.Button();
            this.btnChonTuCay = new System.Windows.Forms.Button();
            this.btnXuatExcelSinhVien = new System.Windows.Forms.Button();
            this.lblTomTatSinhVien = new System.Windows.Forms.Label();
            this.tabChinh.SuspendLayout();
            this.tabLopMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopMon)).BeginInit();
            this.pnlLopMon.SuspendLayout();
            this.tabSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.pnlSinhVien.SuspendLayout();
            this.SuspendLayout();
            this.tabChinh.Controls.Add(this.tabLopMon);
            this.tabChinh.Controls.Add(this.tabSinhVien);
            this.tabChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChinh.Name = "tabChinh";
            this.tabChinh.SelectedIndex = 0;
            this.tabChinh.Size = new System.Drawing.Size(1000, 560);
            this.tabLopMon.Controls.Add(this.dgvLopMon);
            this.tabLopMon.Controls.Add(this.pnlLopMon);
            this.tabLopMon.Name = "tabLopMon";
            this.tabLopMon.Text = "Theo lớp - môn";
            this.pnlLopMon.Controls.Add(this.lblHocKy);
            this.pnlLopMon.Controls.Add(this.cboHocKy);
            this.pnlLopMon.Controls.Add(this.lblLop);
            this.pnlLopMon.Controls.Add(this.cboLop);
            this.pnlLopMon.Controls.Add(this.lblMonHoc);
            this.pnlLopMon.Controls.Add(this.cboMonHoc);
            this.pnlLopMon.Controls.Add(this.btnXemLopMon);
            this.pnlLopMon.Controls.Add(this.btnXuatExcelLopMon);
            this.pnlLopMon.Controls.Add(this.lblTomTatLopMon);
            this.pnlLopMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLopMon.Name = "pnlLopMon";
            this.pnlLopMon.Size = new System.Drawing.Size(992, 80);
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(10, 13);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Text = "Học kỳ:";
            this.cboHocKy.Location = new System.Drawing.Point(65, 10);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(240, 23);
            this.cboHocKy.TabIndex = 0;
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(320, 13);
            this.lblLop.Name = "lblLop";
            this.lblLop.Text = "Lớp:";
            this.cboLop.Location = new System.Drawing.Point(355, 10);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(250, 23);
            this.cboLop.TabIndex = 1;
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(620, 13);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Text = "Môn:";
            this.cboMonHoc.Location = new System.Drawing.Point(660, 10);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(250, 23);
            this.cboMonHoc.TabIndex = 2;
            this.btnXemLopMon.Location = new System.Drawing.Point(65, 43);
            this.btnXemLopMon.Name = "btnXemLopMon";
            this.btnXemLopMon.Size = new System.Drawing.Size(110, 29);
            this.btnXemLopMon.TabIndex = 3;
            this.btnXemLopMon.Text = "Xem bảng điểm";
            this.btnXemLopMon.Click += new System.EventHandler(this.btnXemLopMon_Click);
            this.btnXuatExcelLopMon.Location = new System.Drawing.Point(185, 43);
            this.btnXuatExcelLopMon.Name = "btnXuatExcelLopMon";
            this.btnXuatExcelLopMon.Size = new System.Drawing.Size(100, 29);
            this.btnXuatExcelLopMon.TabIndex = 4;
            this.btnXuatExcelLopMon.Text = "Xuất Excel";
            this.btnXuatExcelLopMon.Click += new System.EventHandler(this.btnXuatExcelLopMon_Click);
            this.lblTomTatLopMon.AutoSize = true;
            this.lblTomTatLopMon.ForeColor = System.Drawing.Color.FromArgb(0, 84, 147);
            this.lblTomTatLopMon.Location = new System.Drawing.Point(300, 49);
            this.lblTomTatLopMon.Name = "lblTomTatLopMon";
            this.dgvLopMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopMon.Name = "dgvLopMon";
            this.tabSinhVien.Controls.Add(this.dgvSinhVien);
            this.tabSinhVien.Controls.Add(this.pnlSinhVien);
            this.tabSinhVien.Name = "tabSinhVien";
            this.tabSinhVien.Text = "Theo sinh viên";
            this.pnlSinhVien.Controls.Add(this.lblMaSV);
            this.pnlSinhVien.Controls.Add(this.txtMaSV);
            this.pnlSinhVien.Controls.Add(this.btnXemSinhVien);
            this.pnlSinhVien.Controls.Add(this.btnChonTuCay);
            this.pnlSinhVien.Controls.Add(this.btnXuatExcelSinhVien);
            this.pnlSinhVien.Controls.Add(this.lblTomTatSinhVien);
            this.pnlSinhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSinhVien.Name = "pnlSinhVien";
            this.pnlSinhVien.Size = new System.Drawing.Size(992, 80);
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(10, 13);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Text = "Mã sinh viên:";
            this.txtMaSV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaSV.Location = new System.Drawing.Point(95, 10);
            this.txtMaSV.MaxLength = 9;
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(130, 23);
            this.txtMaSV.TabIndex = 0;
            this.btnXemSinhVien.Location = new System.Drawing.Point(235, 7);
            this.btnXemSinhVien.Name = "btnXemSinhVien";
            this.btnXemSinhVien.Size = new System.Drawing.Size(110, 29);
            this.btnXemSinhVien.TabIndex = 1;
            this.btnXemSinhVien.Text = "Xem bảng điểm";
            this.btnXemSinhVien.Click += new System.EventHandler(this.btnXemSinhVien_Click);
            this.btnChonTuCay.Location = new System.Drawing.Point(355, 7);
            this.btnChonTuCay.Name = "btnChonTuCay";
            this.btnChonTuCay.Size = new System.Drawing.Size(150, 29);
            this.btnChonTuCay.TabIndex = 2;
            this.btnChonTuCay.Text = "Chọn từ cây đơn vị...";
            this.btnChonTuCay.Click += new System.EventHandler(this.btnChonTuCay_Click);
            this.btnXuatExcelSinhVien.Location = new System.Drawing.Point(515, 7);
            this.btnXuatExcelSinhVien.Name = "btnXuatExcelSinhVien";
            this.btnXuatExcelSinhVien.Size = new System.Drawing.Size(100, 29);
            this.btnXuatExcelSinhVien.TabIndex = 3;
            this.btnXuatExcelSinhVien.Text = "Xuất Excel";
            this.btnXuatExcelSinhVien.Click += new System.EventHandler(this.btnXuatExcelSinhVien_Click);
            this.lblTomTatSinhVien.AutoSize = true;
            this.lblTomTatSinhVien.ForeColor = System.Drawing.Color.FromArgb(0, 84, 147);
            this.lblTomTatSinhVien.Location = new System.Drawing.Point(10, 49);
            this.lblTomTatSinhVien.Name = "lblTomTatSinhVien";
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.tabChinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmBangDiem";
            this.Text = "Xem bảng điểm";
            this.Load += new System.EventHandler(this.frmBangDiem_Load);
            this.tabChinh.ResumeLayout(false);
            this.tabLopMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopMon)).EndInit();
            this.pnlLopMon.ResumeLayout(false);
            this.pnlLopMon.PerformLayout();
            this.tabSinhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.pnlSinhVien.ResumeLayout(false);
            this.pnlSinhVien.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabChinh;
        private System.Windows.Forms.TabPage tabLopMon;
        private System.Windows.Forms.DataGridView dgvLopMon;
        private System.Windows.Forms.Panel pnlLopMon;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Button btnXemLopMon;
        private System.Windows.Forms.Button btnXuatExcelLopMon;
        private System.Windows.Forms.Label lblTomTatLopMon;
        private System.Windows.Forms.TabPage tabSinhVien;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Panel pnlSinhVien;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Button btnXemSinhVien;
        private System.Windows.Forms.Button btnChonTuCay;
        private System.Windows.Forms.Button btnXuatExcelSinhVien;
        private System.Windows.Forms.Label lblTomTatSinhVien;
    }
}

namespace QuanLySinhVien.GUI
{
    partial class frmBaoCao
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
            this.lblLoaiBaoCao = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.crvBaoCao = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dgvXemTruoc = new System.Windows.Forms.DataGridView();
            this.pnlChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXemTruoc)).BeginInit();
            this.SuspendLayout();
            //
            // pnlChon
            //
            this.pnlChon.Controls.Add(this.lblLoaiBaoCao);
            this.pnlChon.Controls.Add(this.cboLoaiBaoCao);
            this.pnlChon.Controls.Add(this.lblHocKy);
            this.pnlChon.Controls.Add(this.cboHocKy);
            this.pnlChon.Controls.Add(this.lblLop);
            this.pnlChon.Controls.Add(this.cboLop);
            this.pnlChon.Controls.Add(this.lblMonHoc);
            this.pnlChon.Controls.Add(this.cboMonHoc);
            this.pnlChon.Controls.Add(this.lblMaSV);
            this.pnlChon.Controls.Add(this.txtMaSV);
            this.pnlChon.Controls.Add(this.btnXem);
            this.pnlChon.Controls.Add(this.btnXuatExcel);
            this.pnlChon.Controls.Add(this.lblTrangThai);
            this.pnlChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChon.Name = "pnlChon";
            this.pnlChon.Size = new System.Drawing.Size(1000, 85);
            this.lblLoaiBaoCao.AutoSize = true;
            this.lblLoaiBaoCao.Location = new System.Drawing.Point(12, 15);
            this.lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            this.lblLoaiBaoCao.Text = "Loại báo cáo:";
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(95, 12);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(230, 23);
            this.cboLoaiBaoCao.TabIndex = 0;
            this.cboLoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBaoCao_SelectedIndexChanged);
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(340, 15);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Text = "Học kỳ:";
            this.cboHocKy.Location = new System.Drawing.Point(395, 12);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(230, 23);
            this.cboHocKy.TabIndex = 1;
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(12, 50);
            this.lblLop.Name = "lblLop";
            this.lblLop.Text = "Lớp:";
            this.cboLop.Location = new System.Drawing.Point(95, 47);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(230, 23);
            this.cboLop.TabIndex = 2;
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(340, 50);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Text = "Môn:";
            this.cboMonHoc.Location = new System.Drawing.Point(395, 47);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(230, 23);
            this.cboMonHoc.TabIndex = 3;
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(340, 15);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Text = "Mã SV:";
            this.txtMaSV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaSV.Location = new System.Drawing.Point(395, 12);
            this.txtMaSV.MaxLength = 9;
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(130, 23);
            this.txtMaSV.TabIndex = 4;
            this.btnXem.Location = new System.Drawing.Point(645, 9);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(110, 29);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem báo cáo";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            this.btnXuatExcel.Location = new System.Drawing.Point(765, 9);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(110, 29);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "Xuất file";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(0, 84, 147);
            this.lblTrangThai.Location = new System.Drawing.Point(645, 50);
            this.lblTrangThai.Name = "lblTrangThai";
            //
            // crvBaoCao
            //
            this.crvBaoCao.ActiveViewIndex = -1;
            this.crvBaoCao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBaoCao.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBaoCao.Name = "crvBaoCao";
            this.crvBaoCao.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            //
            // dgvXemTruoc
            //
            this.dgvXemTruoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXemTruoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXemTruoc.Name = "dgvXemTruoc";
            this.dgvXemTruoc.Visible = false;
            //
            // frmBaoCao
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.crvBaoCao);
            this.Controls.Add(this.dgvXemTruoc);
            this.Controls.Add(this.pnlChon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmBaoCao";
            this.Text = "Báo cáo (Crystal Report)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBaoCao_FormClosed);
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.pnlChon.ResumeLayout(false);
            this.pnlChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXemTruoc)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlChon;
        private System.Windows.Forms.Label lblLoaiBaoCao;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label lblTrangThai;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBaoCao;
        private System.Windows.Forms.DataGridView dgvXemTruoc;
    }
}

namespace QuanLySinhVien.GUI
{
    partial class frmXepMon
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
            this.btnXepMon = new System.Windows.Forms.Button();
            this.splitKetQua = new System.Windows.Forms.SplitContainer();
            this.grpMonDaXep = new System.Windows.Forms.GroupBox();
            this.dgvMonDaXep = new System.Windows.Forms.DataGridView();
            this.grpTongTinChi = new System.Windows.Forms.GroupBox();
            this.dgvTongTinChi = new System.Windows.Forms.DataGridView();
            this.pnlChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitKetQua)).BeginInit();
            this.splitKetQua.Panel1.SuspendLayout();
            this.splitKetQua.Panel2.SuspendLayout();
            this.splitKetQua.SuspendLayout();
            this.grpMonDaXep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonDaXep)).BeginInit();
            this.grpTongTinChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongTinChi)).BeginInit();
            this.SuspendLayout();
            this.pnlChon.Controls.Add(this.lblHocKy);
            this.pnlChon.Controls.Add(this.cboHocKy);
            this.pnlChon.Controls.Add(this.lblLop);
            this.pnlChon.Controls.Add(this.cboLop);
            this.pnlChon.Controls.Add(this.lblMonHoc);
            this.pnlChon.Controls.Add(this.cboMonHoc);
            this.pnlChon.Controls.Add(this.btnXepMon);
            this.pnlChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChon.Name = "pnlChon";
            this.pnlChon.Size = new System.Drawing.Size(1000, 80);
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(12, 15);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Text = "Học kỳ:";
            this.cboHocKy.Location = new System.Drawing.Point(70, 12);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(260, 23);
            this.cboHocKy.TabIndex = 0;
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(350, 15);
            this.lblLop.Name = "lblLop";
            this.lblLop.Text = "Lớp:";
            this.cboLop.Location = new System.Drawing.Point(390, 12);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(300, 23);
            this.cboLop.TabIndex = 1;
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(12, 48);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Text = "Môn học:";
            this.cboMonHoc.Location = new System.Drawing.Point(70, 45);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(410, 23);
            this.cboMonHoc.TabIndex = 2;
            this.btnXepMon.Location = new System.Drawing.Point(500, 42);
            this.btnXepMon.Name = "btnXepMon";
            this.btnXepMon.Size = new System.Drawing.Size(190, 30);
            this.btnXepMon.TabIndex = 3;
            this.btnXepMon.Text = "Xếp môn cho cả lớp";
            this.btnXepMon.Click += new System.EventHandler(this.btnXepMon_Click);
            this.splitKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitKetQua.Name = "splitKetQua";
            this.splitKetQua.Panel1.Controls.Add(this.grpMonDaXep);
            this.splitKetQua.Panel2.Controls.Add(this.grpTongTinChi);
            this.splitKetQua.Size = new System.Drawing.Size(1000, 480);
            this.splitKetQua.SplitterDistance = 560;
            this.grpMonDaXep.Controls.Add(this.dgvMonDaXep);
            this.grpMonDaXep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMonDaXep.Name = "grpMonDaXep";
            this.grpMonDaXep.Text = "Các môn đã xếp";
            this.dgvMonDaXep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonDaXep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonDaXep.Name = "dgvMonDaXep";
            this.grpTongTinChi.Controls.Add(this.dgvTongTinChi);
            this.grpTongTinChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTongTinChi.Name = "grpTongTinChi";
            this.grpTongTinChi.Text = "Tổng tín chỉ học kỳ của từng sinh viên";
            this.dgvTongTinChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongTinChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTongTinChi.Name = "dgvTongTinChi";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.splitKetQua);
            this.Controls.Add(this.pnlChon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmXepMon";
            this.Text = "Xếp môn theo lớp";
            this.Load += new System.EventHandler(this.frmXepMon_Load);
            this.pnlChon.ResumeLayout(false);
            this.pnlChon.PerformLayout();
            this.splitKetQua.Panel1.ResumeLayout(false);
            this.splitKetQua.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKetQua)).EndInit();
            this.splitKetQua.ResumeLayout(false);
            this.grpMonDaXep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonDaXep)).EndInit();
            this.grpTongTinChi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongTinChi)).EndInit();
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
        private System.Windows.Forms.Button btnXepMon;
        private System.Windows.Forms.SplitContainer splitKetQua;
        private System.Windows.Forms.GroupBox grpMonDaXep;
        private System.Windows.Forms.DataGridView dgvMonDaXep;
        private System.Windows.Forms.GroupBox grpTongTinChi;
        private System.Windows.Forms.DataGridView dgvTongTinChi;
    }
}

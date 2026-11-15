namespace QuanLySinhVien.GUI
{
    partial class frmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea vungVe = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series cotSoSV = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title tieuDeBieuDo = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pnlChon = new System.Windows.Forms.Panel();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.tabChinh = new System.Windows.Forms.TabControl();
            this.tabXepLoai = new System.Windows.Forms.TabPage();
            this.splitXepLoai = new System.Windows.Forms.SplitContainer();
            this.dgvXepLoai = new System.Windows.Forms.DataGridView();
            this.chartXepLoai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            this.tabDiemCao = new System.Windows.Forms.TabPage();
            this.dgvDiemCao = new System.Windows.Forms.DataGridView();
            this.tabMonTruot = new System.Windows.Forms.TabPage();
            this.dgvMonTruot = new System.Windows.Forms.DataGridView();
            this.tabQuyMo = new System.Windows.Forms.TabPage();
            this.dgvQuyMo = new System.Windows.Forms.DataGridView();
            this.pnlChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.tabChinh.SuspendLayout();
            this.tabXepLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitXepLoai)).BeginInit();
            this.splitXepLoai.Panel1.SuspendLayout();
            this.splitXepLoai.Panel2.SuspendLayout();
            this.splitXepLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXepLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartXepLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).BeginInit();
            this.tabDiemCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemCao)).BeginInit();
            this.tabMonTruot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonTruot)).BeginInit();
            this.tabQuyMo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyMo)).BeginInit();
            this.SuspendLayout();
            //
            // pnlChon
            //
            this.pnlChon.Controls.Add(this.lblHocKy);
            this.pnlChon.Controls.Add(this.cboHocKy);
            this.pnlChon.Controls.Add(this.lblLop);
            this.pnlChon.Controls.Add(this.cboLop);
            this.pnlChon.Controls.Add(this.lblSoLuong);
            this.pnlChon.Controls.Add(this.nudSoLuong);
            this.pnlChon.Controls.Add(this.btnThongKe);
            this.pnlChon.Controls.Add(this.btnXuatExcel);
            this.pnlChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChon.Name = "pnlChon";
            this.pnlChon.Size = new System.Drawing.Size(1000, 48);
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(12, 15);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Text = "Học kỳ:";
            this.cboHocKy.Location = new System.Drawing.Point(65, 12);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(230, 23);
            this.cboHocKy.TabIndex = 0;
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(310, 15);
            this.lblLop.Name = "lblLop";
            this.lblLop.Text = "Lớp:";
            this.cboLop.Location = new System.Drawing.Point(345, 12);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(250, 23);
            this.cboLop.TabIndex = 1;
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(610, 15);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Text = "Top:";
            this.nudSoLuong.Location = new System.Drawing.Point(645, 12);
            this.nudSoLuong.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(55, 23);
            this.nudSoLuong.TabIndex = 2;
            this.nudSoLuong.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.btnThongKe.Location = new System.Drawing.Point(715, 9);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 29);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            this.btnXuatExcel.Location = new System.Drawing.Point(825, 9);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 29);
            this.btnXuatExcel.TabIndex = 4;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            //
            // tabChinh
            //
            this.tabChinh.Controls.Add(this.tabXepLoai);
            this.tabChinh.Controls.Add(this.tabDiemCao);
            this.tabChinh.Controls.Add(this.tabMonTruot);
            this.tabChinh.Controls.Add(this.tabQuyMo);
            this.tabChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChinh.Name = "tabChinh";
            this.tabChinh.SelectedIndex = 0;
            //
            // tabXepLoai
            //
            this.tabXepLoai.Controls.Add(this.splitXepLoai);
            this.tabXepLoai.Name = "tabXepLoai";
            this.tabXepLoai.Text = "Xếp loại theo lớp";
            this.splitXepLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitXepLoai.Name = "splitXepLoai";
            this.splitXepLoai.Panel1.Controls.Add(this.dgvXepLoai);
            this.splitXepLoai.Panel2.Controls.Add(this.chartXepLoai);
            this.splitXepLoai.Panel2.Controls.Add(this.dgvTongHop);
            this.splitXepLoai.Size = new System.Drawing.Size(992, 480);
            this.splitXepLoai.SplitterDistance = 560;
            this.dgvXepLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXepLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXepLoai.Name = "dgvXepLoai";
            this.dgvTongHop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongHop.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.Size = new System.Drawing.Size(428, 170);
            //
            // chartXepLoai
            //
            vungVe.AxisX.Interval = 1;
            vungVe.Name = "VungVe";
            this.chartXepLoai.ChartAreas.Add(vungVe);
            this.chartXepLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            // Biểu đồ báo lỗi nếu bị co về chiều cao 0 khi cửa sổ nhỏ → giữ kích thước tối thiểu
            this.chartXepLoai.MinimumSize = new System.Drawing.Size(200, 150);
            this.chartXepLoai.Name = "chartXepLoai";
            cotSoSV.ChartArea = "VungVe";
            cotSoSV.IsValueShownAsLabel = true;
            cotSoSV.Name = "SoSinhVien";
            this.chartXepLoai.Series.Add(cotSoSV);
            tieuDeBieuDo.Name = "TieuDe";
            tieuDeBieuDo.Text = "Số sinh viên theo xếp loại";
            this.chartXepLoai.Titles.Add(tieuDeBieuDo);
            //
            // tabDiemCao
            //
            this.tabDiemCao.Controls.Add(this.dgvDiemCao);
            this.tabDiemCao.Name = "tabDiemCao";
            this.tabDiemCao.Text = "Sinh viên điểm cao nhất lớp";
            this.dgvDiemCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiemCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiemCao.Name = "dgvDiemCao";
            //
            // tabMonTruot
            //
            this.tabMonTruot.Controls.Add(this.dgvMonTruot);
            this.tabMonTruot.Name = "tabMonTruot";
            this.tabMonTruot.Text = "Môn có tỉ lệ trượt cao nhất";
            this.dgvMonTruot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonTruot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonTruot.Name = "dgvMonTruot";
            //
            // tabQuyMo
            //
            this.tabQuyMo.Controls.Add(this.dgvQuyMo);
            this.tabQuyMo.Name = "tabQuyMo";
            this.tabQuyMo.Text = "Quy mô theo khoa";
            this.dgvQuyMo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuyMo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuyMo.Name = "dgvQuyMo";
            //
            // frmThongKe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.tabChinh);
            this.Controls.Add(this.pnlChon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmThongKe";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.pnlChon.ResumeLayout(false);
            this.pnlChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.tabChinh.ResumeLayout(false);
            this.tabXepLoai.ResumeLayout(false);
            this.splitXepLoai.Panel1.ResumeLayout(false);
            this.splitXepLoai.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitXepLoai)).EndInit();
            this.splitXepLoai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXepLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartXepLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).EndInit();
            this.tabDiemCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemCao)).EndInit();
            this.tabMonTruot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonTruot)).EndInit();
            this.tabQuyMo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyMo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlChon;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.TabControl tabChinh;
        private System.Windows.Forms.TabPage tabXepLoai;
        private System.Windows.Forms.SplitContainer splitXepLoai;
        private System.Windows.Forms.DataGridView dgvXepLoai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartXepLoai;
        private System.Windows.Forms.DataGridView dgvTongHop;
        private System.Windows.Forms.TabPage tabDiemCao;
        private System.Windows.Forms.DataGridView dgvDiemCao;
        private System.Windows.Forms.TabPage tabMonTruot;
        private System.Windows.Forms.DataGridView dgvMonTruot;
        private System.Windows.Forms.TabPage tabQuyMo;
        private System.Windows.Forms.DataGridView dgvQuyMo;
    }
}

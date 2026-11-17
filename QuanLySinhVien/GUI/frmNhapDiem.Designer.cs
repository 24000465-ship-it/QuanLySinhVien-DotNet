namespace QuanLySinhVien.GUI
{
    partial class frmNhapDiem
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
            System.Windows.Forms.DataGridViewCellStyle kieuONhap = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlChon = new System.Windows.Forms.Panel();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblLopMon = new System.Windows.Forms.Label();
            this.cboLopMon = new System.Windows.Forms.ComboBox();
            this.btnTai = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemGK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemKTHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemHe4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetLuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.SuspendLayout();
            this.pnlChon.Controls.Add(this.lblHocKy);
            this.pnlChon.Controls.Add(this.cboHocKy);
            this.pnlChon.Controls.Add(this.lblLopMon);
            this.pnlChon.Controls.Add(this.cboLopMon);
            this.pnlChon.Controls.Add(this.btnTai);
            this.pnlChon.Controls.Add(this.btnLuu);
            this.pnlChon.Controls.Add(this.btnXuatExcel);
            this.pnlChon.Controls.Add(this.lblThongBao);
            this.pnlChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChon.Name = "pnlChon";
            this.pnlChon.Size = new System.Drawing.Size(1000, 85);
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(12, 15);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Text = "Học kỳ:";
            this.cboHocKy.Location = new System.Drawing.Point(70, 12);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(250, 23);
            this.cboHocKy.TabIndex = 0;
            this.lblLopMon.AutoSize = true;
            this.lblLopMon.Location = new System.Drawing.Point(340, 15);
            this.lblLopMon.Name = "lblLopMon";
            this.lblLopMon.Text = "Lớp - môn:";
            this.cboLopMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopMon.Location = new System.Drawing.Point(410, 12);
            this.cboLopMon.Name = "cboLopMon";
            this.cboLopMon.Size = new System.Drawing.Size(300, 23);
            this.cboLopMon.TabIndex = 1;
            this.btnTai.Location = new System.Drawing.Point(720, 9);
            this.btnTai.Name = "btnTai";
            this.btnTai.Size = new System.Drawing.Size(120, 29);
            this.btnTai.TabIndex = 2;
            this.btnTai.Text = "Tải danh sách";
            this.btnTai.Click += new System.EventHandler(this.btnTai_Click);
            this.btnLuu.Location = new System.Drawing.Point(720, 45);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 29);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu bảng điểm";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnXuatExcel.Location = new System.Drawing.Point(848, 45);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(110, 29);
            this.btnXuatExcel.TabIndex = 4;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(0, 84, 147);
            this.lblThongBao.Location = new System.Drawing.Point(12, 48);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(700, 26);
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaSV, this.colHoTen, this.colDiemCC, this.colDiemGK, this.colDiemKTHP,
                this.colDiemHP, this.colDiemChu, this.colDiemHe4, this.colKetLuan });
            this.dgvDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.RowHeadersVisible = false;
            this.dgvDiem.TabIndex = 5;
            this.dgvDiem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellEndEdit);
            kieuONhap.BackColor = System.Drawing.Color.LightYellow;
            this.colMaSV.HeaderText = "Mã SV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.ReadOnly = true;
            this.colHoTen.FillWeight = 200F;
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colDiemCC.DefaultCellStyle = kieuONhap;
            this.colDiemCC.HeaderText = "Chuyên cần (10%)";
            this.colDiemCC.Name = "colDiemCC";
            this.colDiemGK.DefaultCellStyle = kieuONhap;
            this.colDiemGK.HeaderText = "Giữa kỳ (30%)";
            this.colDiemGK.Name = "colDiemGK";
            this.colDiemKTHP.DefaultCellStyle = kieuONhap;
            this.colDiemKTHP.HeaderText = "Kết thúc HP (60%)";
            this.colDiemKTHP.Name = "colDiemKTHP";
            this.colDiemHP.HeaderText = "Điểm HP";
            this.colDiemHP.Name = "colDiemHP";
            this.colDiemHP.ReadOnly = true;
            this.colDiemChu.HeaderText = "Điểm chữ";
            this.colDiemChu.Name = "colDiemChu";
            this.colDiemChu.ReadOnly = true;
            this.colDiemHe4.HeaderText = "Thang 4";
            this.colDiemHe4.Name = "colDiemHe4";
            this.colDiemHe4.ReadOnly = true;
            this.colKetLuan.HeaderText = "Kết quả";
            this.colKetLuan.Name = "colKetLuan";
            this.colKetLuan.ReadOnly = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.dgvDiem);
            this.Controls.Add(this.pnlChon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmNhapDiem";
            this.Text = "Nhập điểm";
            this.Load += new System.EventHandler(this.frmNhapDiem_Load);
            this.pnlChon.ResumeLayout(false);
            this.pnlChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlChon;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblLopMon;
        private System.Windows.Forms.ComboBox cboLopMon;
        private System.Windows.Forms.Button btnTai;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemGK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemKTHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemHe4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetLuan;
    }
}

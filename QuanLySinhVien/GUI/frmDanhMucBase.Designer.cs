namespace QuanLySinhVien.GUI
{
    partial class frmDanhMucBase
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
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.pnlNhapLieu = new System.Windows.Forms.Panel();
            this.pnlNut = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTimKiem.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.pnlNut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            this.pnlTimKiem.Controls.Add(this.lblTongSo);
            this.pnlTimKiem.Controls.Add(this.btnLamMoi);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(0, 0);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(900, 42);
            this.pnlTimKiem.TabIndex = 0;
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(12, 13);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Text = "Tìm kiếm (mã, tên):";
            this.txtTimKiem.Location = new System.Drawing.Point(130, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(260, 23);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.btnLamMoi.Location = new System.Drawing.Point(398, 9);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(80, 25);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.lblTongSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongSo.Location = new System.Drawing.Point(720, 13);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(170, 18);
            this.lblTongSo.Text = "Tổng số: 0";
            this.lblTongSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.grpThongTin.Controls.Add(this.pnlNhapLieu);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Location = new System.Drawing.Point(0, 42);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(900, 130);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            this.pnlNhapLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNhapLieu.Location = new System.Drawing.Point(3, 19);
            this.pnlNhapLieu.Name = "pnlNhapLieu";
            this.pnlNhapLieu.Size = new System.Drawing.Size(894, 108);
            this.pnlNhapLieu.TabIndex = 0;
            this.pnlNut.Controls.Add(this.btnThem);
            this.pnlNut.Controls.Add(this.btnSua);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.pnlNut.Controls.Add(this.btnLuu);
            this.pnlNut.Controls.Add(this.btnHuy);
            this.pnlNut.Controls.Add(this.btnXuatExcel);
            this.pnlNut.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNut.Location = new System.Drawing.Point(0, 172);
            this.pnlNut.Name = "pnlNut";
            this.pnlNut.Padding = new System.Windows.Forms.Padding(8, 6, 0, 0);
            this.pnlNut.Size = new System.Drawing.Size(900, 44);
            this.pnlNut.TabIndex = 2;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 30);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 30);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 30);
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.Location = new System.Drawing.Point(0, 216);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(900, 334);
            this.dgvDanhSach.TabIndex = 3;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);
            this.errorProvider.ContainerControl = this;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.pnlNut);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlTimKiem);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmDanhMucBase";
            this.Text = "Danh mục";
            this.Load += new System.EventHandler(this.frmDanhMucBase_Load);
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.pnlNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        protected System.Windows.Forms.Panel pnlTimKiem;
        protected System.Windows.Forms.Label lblTimKiem;
        protected System.Windows.Forms.TextBox txtTimKiem;
        protected System.Windows.Forms.Button btnLamMoi;
        protected System.Windows.Forms.Label lblTongSo;
        protected System.Windows.Forms.GroupBox grpThongTin;
        protected System.Windows.Forms.Panel pnlNhapLieu;
        protected System.Windows.Forms.FlowLayoutPanel pnlNut;
        protected System.Windows.Forms.Button btnThem;
        protected System.Windows.Forms.Button btnSua;
        protected System.Windows.Forms.Button btnXoa;
        protected System.Windows.Forms.Button btnLuu;
        protected System.Windows.Forms.Button btnHuy;
        protected System.Windows.Forms.Button btnXuatExcel;
        protected System.Windows.Forms.DataGridView dgvDanhSach;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}

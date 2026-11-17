namespace QuanLySinhVien.GUI
{
    partial class frmCayDonVi
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
            this.splitChinh = new System.Windows.Forms.SplitContainer();
            this.tvDonVi = new System.Windows.Forms.TreeView();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.lblTieuDe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitChinh)).BeginInit();
            this.splitChinh.Panel1.SuspendLayout();
            this.splitChinh.Panel2.SuspendLayout();
            this.splitChinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();
            this.splitChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChinh.Location = new System.Drawing.Point(0, 0);
            this.splitChinh.Name = "splitChinh";
            this.splitChinh.Panel1.Controls.Add(this.tvDonVi);
            this.splitChinh.Panel2.Controls.Add(this.dgvSinhVien);
            this.splitChinh.Panel2.Controls.Add(this.lblTieuDe);
            this.splitChinh.Size = new System.Drawing.Size(1000, 560);
            this.splitChinh.SplitterDistance = 380;
            this.tvDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDonVi.HideSelection = false;
            this.tvDonVi.Name = "tvDonVi";
            this.tvDonVi.TabIndex = 0;
            this.tvDonVi.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDonVi_AfterSelect);
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTieuDe.Size = new System.Drawing.Size(616, 32);
            this.lblTieuDe.Text = "Chọn một lớp để xem danh sách sinh viên";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.TabIndex = 1;
            this.dgvSinhVien.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellDoubleClick);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.splitChinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmCayDonVi";
            this.Text = "Cây Khoa - Ngành - Lớp";
            this.Load += new System.EventHandler(this.frmCayDonVi_Load);
            this.splitChinh.Panel1.ResumeLayout(false);
            this.splitChinh.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChinh)).EndInit();
            this.splitChinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitChinh;
        private System.Windows.Forms.TreeView tvDonVi;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Label lblTieuDe;
    }
}

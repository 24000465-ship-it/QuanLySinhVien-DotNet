using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    /// <summary>
    /// Xem và in báo cáo bằng Crystal Report (F13, UC05).
    /// Quy trình: BUS lấy DataTable (từ View/Stored Procedure) → nạp vào mẫu .rpt bằng SetDataSource
    /// → gán cho CrystalReportViewer. Từ cửa sổ xem trước có thể in, xuất PDF/Excel.
    /// </summary>
    public partial class frmBaoCao : Form
    {
        // Ba mẫu báo cáo: tên file .rpt trong thư mục CrystalReport và tên bảng dữ liệu mà mẫu dùng
        private const string BaoCaoDanhSachSV = "Danh sách sinh viên theo lớp";
        private const string BaoCaoBangDiemLopMon = "Bảng điểm lớp - môn";
        private const string BaoCaoBangDiemSV = "Bảng điểm cá nhân sinh viên";

        private readonly IThongKeBUS thongKeBus = new ThongKeBUS();
        private readonly IXepMonBUS xepMonBus = new XepMonBUS();
        private readonly IPhanCongBUS phanCongBus = new PhanCongBUS();
        private readonly IDanhMucBUS<HocKy> hocKyBus = new HocKyBUS();
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();

        private ReportDocument baoCaoDangMo;

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            GiaoDien.DinhDangLuoi(dgvXemTruoc);
            NguoiDung nd = PhienDangNhap.NguoiDungHienTai;
            if (nd.LaQuanLyDaoTao)
                cboLoaiBaoCao.Items.AddRange(new object[] { BaoCaoDanhSachSV, BaoCaoBangDiemLopMon, BaoCaoBangDiemSV });
            else
                cboLoaiBaoCao.Items.Add(BaoCaoBangDiemLopMon); // giảng viên: chỉ bảng điểm lớp mình dạy
            try
            {
                GiaoDien.NapHocKy(cboHocKy, hocKyBus.LayDanhSach(""));
                if (nd.LaQuanLyDaoTao)
                {
                    GiaoDien.NapComboBox(cboLop, lopBus.LayDanhSach(""), "TenLop", "MaLop", false);
                }
                cboHocKy.SelectedIndexChanged += (s, ev) => NapLopVaMon();
                cboLop.SelectedIndexChanged += (s, ev) => NapMon();
                cboLoaiBaoCao.SelectedIndex = 0;
                NapLopVaMon();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void NapLopVaMon()
        {
            NguoiDung nd = PhienDangNhap.NguoiDungHienTai;
            if (!nd.LaQuanLyDaoTao)
            {
                DataTable pc = phanCongBus.LayCuaGiangVien(nd.MaGV, GiaoDien.GiaTri(cboHocKy));
                GiaoDien.NapComboBox(cboLop, pc.DefaultView.ToTable(true, "MaLop", "TenLop"), "TenLop", "MaLop", false);
            }
            NapMon();
        }

        private void NapMon()
        {
            string maLop = GiaoDien.GiaTri(cboLop);
            string maHocKy = GiaoDien.GiaTri(cboHocKy);
            if (maLop == "" || maHocKy == "") return;
            GiaoDien.NapComboBox(cboMonHoc, xepMonBus.LayMonDaXep(maLop, maHocKy), "TenMon", "MaMon", false);
        }

        /// <summary>Chỉ hiện các ô điều kiện cần cho loại báo cáo đang chọn.</summary>
        private void cboLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = Convert.ToString(cboLoaiBaoCao.SelectedItem);
            bool canHocKyMon = loai == BaoCaoBangDiemLopMon;
            bool canLop = loai != BaoCaoBangDiemSV;
            lblHocKy.Visible = cboHocKy.Visible = canHocKyMon;
            lblMonHoc.Visible = cboMonHoc.Visible = canHocKyMon;
            lblLop.Visible = cboLop.Visible = canLop;
            lblMaSV.Visible = txtMaSV.Visible = !canLop;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string loai = Convert.ToString(cboLoaiBaoCao.SelectedItem);
            try
            {
                DataTable duLieu;
                string tenFile;
                if (loai == BaoCaoDanhSachSV)
                {
                    duLieu = thongKeBus.BaoCaoDanhSachSinhVien(GiaoDien.GiaTri(cboLop));
                    duLieu.TableName = "SinhVienReport";
                    tenFile = "rptDanhSachSinhVien.rpt";
                }
                else if (loai == BaoCaoBangDiemLopMon)
                {
                    duLieu = thongKeBus.BaoCaoBangDiemLopMon(GiaoDien.GiaTri(cboLop),
                        GiaoDien.GiaTri(cboMonHoc), GiaoDien.GiaTri(cboHocKy));
                    duLieu.TableName = "BangDiemReport";
                    tenFile = "rptBangDiemLopMon.rpt";
                }
                else
                {
                    duLieu = thongKeBus.BaoCaoBangDiemSinhVien(txtMaSV.Text);
                    duLieu.TableName = "BangDiemReport";
                    tenFile = "rptBangDiemSinhVien.rpt";
                }

                if (duLieu.Rows.Count == 0)
                {
                    GiaoDien.BaoLoi("Không có dữ liệu để hiển thị.");
                    return;
                }
                HienBaoCao(tenFile, duLieu);
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tạo được báo cáo: " + ex.Message);
            }
        }

        /// <summary>
        /// Nạp mẫu .rpt và gán dữ liệu. Nếu máy chưa có file mẫu (chưa thiết kế trong Visual Studio)
        /// thì hiện dữ liệu dạng bảng để vẫn xem / xuất Excel được.
        /// </summary>
        private void HienBaoCao(string tenFile, DataTable duLieu)
        {
            // Thư mục chứa file chương trình (QuanLySinhVien.exe) — mẫu .rpt nằm trong CrystalReport bên cạnh
            string thuMucChuongTrinh = Path.GetDirectoryName(typeof(frmBaoCao).Assembly.Location);
            string duongDan = Path.Combine(thuMucChuongTrinh, "CrystalReport", tenFile);
            if (!File.Exists(duongDan))
            {
                crvBaoCao.Visible = false;
                dgvXemTruoc.Visible = true;
                dgvXemTruoc.DataSource = duLieu;
                lblTrangThai.Text = "Chưa có mẫu " + tenFile + " — đang hiển thị dữ liệu dạng bảng.";
                return;
            }
            if (baoCaoDangMo != null)
            {
                baoCaoDangMo.Close();
                baoCaoDangMo.Dispose();
            }
            baoCaoDangMo = new ReportDocument();
            baoCaoDangMo.Load(duongDan);
            baoCaoDangMo.SetDataSource(duLieu);
            crvBaoCao.ReportSource = baoCaoDangMo;
            dgvXemTruoc.Visible = false;
            crvBaoCao.Visible = true;
            crvBaoCao.Zoom(100);
            lblTrangThai.Text = duLieu.Rows.Count + " dòng dữ liệu. Dùng thanh công cụ của báo cáo để in hoặc xuất PDF/Excel.";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvXemTruoc.Visible)
            {
                XuatExcel.TuLuoi(dgvXemTruoc, Convert.ToString(cboLoaiBaoCao.SelectedItem));
            }
            else if (baoCaoDangMo != null)
            {
                crvBaoCao.ExportReport();   // hộp thoại xuất có sẵn của Crystal (PDF, Excel, Word...)
            }
            else
            {
                GiaoDien.BaoLoi("Hãy bấm \"Xem báo cáo\" trước.");
            }
        }

        private void frmBaoCao_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (baoCaoDangMo != null)
            {
                baoCaoDangMo.Close();
                baoCaoDangMo.Dispose();
            }
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmBangDiem : Form
    {
        private readonly IKetQuaBUS ketQuaBus = new KetQuaBUS();
        private readonly IXepMonBUS xepMonBus = new XepMonBUS();
        private readonly IPhanCongBUS phanCongBus = new PhanCongBUS();
        private readonly IDanhMucBUS<HocKy> hocKyBus = new HocKyBUS();
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();

        private bool laGiangVien;

        public frmBangDiem()
        {
            InitializeComponent();
        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            GiaoDien.DinhDangLuoi(dgvLopMon);
            GiaoDien.DinhDangLuoi(dgvSinhVien);
            laGiangVien = PhienDangNhap.NguoiDungHienTai.VaiTro == NguoiDung.VaiTroGiangVien;
            if (laGiangVien)
            {
                tabChinh.TabPages.Remove(tabSinhVien);
            }
            try
            {
                GiaoDien.NapHocKy(cboHocKy, hocKyBus.LayDanhSach(""));
                cboHocKy.SelectedIndexChanged += (s, ev) => NapLop();
                cboLop.SelectedIndexChanged += (s, ev) => NapMon();
                NapLop();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void NapLop()
        {
            if (laGiangVien)
            {
                DataTable pc = phanCongBus.LayCuaGiangVien(PhienDangNhap.NguoiDungHienTai.MaGV, GiaoDien.GiaTri(cboHocKy));
                GiaoDien.NapComboBox(cboLop, pc.DefaultView.ToTable(true, "MaLop", "TenLop"), "TenLop", "MaLop", false);
            }
            else if (cboLop.DataSource == null)
            {
                GiaoDien.NapComboBox(cboLop, lopBus.LayDanhSach(""), "TenLop", "MaLop", false);
            }
            NapMon();
        }

        private void NapMon()
        {
            string maLop = GiaoDien.GiaTri(cboLop);
            string maHocKy = GiaoDien.GiaTri(cboHocKy);
            if (maLop == "" || maHocKy == "")
            {
                cboMonHoc.DataSource = null;
                return;
            }
            DataTable mon = xepMonBus.LayMonDaXep(maLop, maHocKy);
            if (laGiangVien)
            {
                DataTable pc = phanCongBus.LayCuaGiangVien(PhienDangNhap.NguoiDungHienTai.MaGV, maHocKy);
                for (int i = mon.Rows.Count - 1; i >= 0; i--)
                {
                    if (pc.Select("MaLop = '" + maLop + "' AND MaMon = '" + mon.Rows[i]["MaMon"] + "'").Length == 0)
                        mon.Rows.RemoveAt(i);
                }
            }
            GiaoDien.NapComboBox(cboMonHoc, mon, "TenMon", "MaMon", false);
        }

        private void btnXemLopMon_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable bang = ketQuaBus.LayBangDiemLopMon(GiaoDien.GiaTri(cboLop),
                    GiaoDien.GiaTri(cboMonHoc), GiaoDien.GiaTri(cboHocKy));
                dgvLopMon.DataSource = bang;
                GiaoDien.DatTieuDeCot(dgvLopMon, "MaSV", "Mã SV", "HoTen", "Họ tên", "DiemCC", "Chuyên cần",
                    "DiemGK", "Giữa kỳ", "DiemKTHP", "Kết thúc HP", "DiemHP", "Điểm HP",
                    "DiemChu", "Điểm chữ", "DiemHe4", "Thang 4");
                lblTomTatLopMon.Text = TomTat(bang);
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi(ex.Message);
            }
        }

        private static string TomTat(DataTable bang)
        {
            int dat = 0, truot = 0, chuaDu = 0;
            foreach (DataRow d in bang.Rows)
            {
                string chu = Convert.ToString(d["DiemChu"]);
                if (chu == "") chuaDu++;
                else if (chu == "F") truot++;
                else dat++;
            }
            return string.Format("Tổng {0} — Đạt: {1}, Trượt: {2}, Chưa đủ điểm: {3}", bang.Rows.Count, dat, truot, chuaDu);
        }

        private void btnXuatExcelLopMon_Click(object sender, EventArgs e)
        {
            XuatExcel.TuLuoi(dgvLopMon, "Bảng điểm " + cboLop.Text + " - " + cboMonHoc.Text + " - " + cboHocKy.Text);
        }


        private void btnXemSinhVien_Click(object sender, EventArgs e)
        {
            XemBangDiemSinhVien(txtMaSV.Text.Trim().ToUpper(), null);
        }

        private void XemBangDiemSinhVien(string maSV, string hoTen)
        {
            if (maSV == "")
            {
                GiaoDien.BaoLoi("Vui lòng nhập mã sinh viên.");
                return;
            }
            try
            {
                txtMaSV.Text = maSV;
                DataTable bang = ketQuaBus.LayBangDiemSinhVien(maSV);
                dgvSinhVien.DataSource = bang;
                GiaoDien.DatTieuDeCot(dgvSinhVien, "TenHocKy", "Học kỳ", "MaMon", "Mã môn", "TenMon", "Tên môn",
                    "SoTinChi", "Tín chỉ", "DiemCC", "CC", "DiemGK", "GK", "DiemKTHP", "KTHP",
                    "DiemHP", "Điểm HP", "DiemChu", "Điểm chữ", "DiemHe4", "Thang 4");
                lblTomTatSinhVien.Text = (hoTen != null ? hoTen + " — " : "") +
                    (bang.Rows.Count == 0 ? "Không tìm thấy kết quả học tập của sinh viên này." : TomTat(bang));
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi(ex.Message);
            }
        }

        private void btnChonTuCay_Click(object sender, EventArgs e)
        {
            frmCayDonVi cay = new frmCayDonVi();
            cay.SinhVienDuocChon += new ChonSinhVienHandler(XemBangDiemSinhVien);
            cay.StartPosition = FormStartPosition.CenterParent;
            cay.ShowDialog(this);
        }

        private void btnXuatExcelSinhVien_Click(object sender, EventArgs e)
        {
            XuatExcel.TuLuoi(dgvSinhVien, "Bảng điểm sinh viên " + txtMaSV.Text);
        }
    }
}

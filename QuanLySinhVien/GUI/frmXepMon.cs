using System;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmXepMon : Form
    {
        private readonly IXepMonBUS xepMonBus = new XepMonBUS();
        private readonly IDanhMucBUS<HocKy> hocKyBus = new HocKyBUS();
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();
        private readonly IDanhMucBUS<MonHoc> monHocBus = new MonHocBUS();

        public frmXepMon()
        {
            InitializeComponent();
        }

        private void frmXepMon_Load(object sender, EventArgs e)
        {
            GiaoDien.DinhDangLuoi(dgvMonDaXep);
            GiaoDien.DinhDangLuoi(dgvTongTinChi);
            try
            {
                GiaoDien.NapHocKy(cboHocKy, hocKyBus.LayDanhSach(""));
                GiaoDien.NapComboBox(cboLop, lopBus.LayDanhSach(""), "TenLop", "MaLop", false);
                GiaoDien.NapComboBox(cboMonHoc, monHocBus.LayDanhSach(""), "TenMon", "MaMon", false);
                cboHocKy.SelectedIndexChanged += BoLoc_Changed;
                cboLop.SelectedIndexChanged += BoLoc_Changed;
                TaiLai();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void BoLoc_Changed(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void TaiLai()
        {
            string maLop = GiaoDien.GiaTri(cboLop);
            string maHocKy = GiaoDien.GiaTri(cboHocKy);
            if (maLop == "" || maHocKy == "") return;
            try
            {
                dgvMonDaXep.DataSource = xepMonBus.LayMonDaXep(maLop, maHocKy);
                GiaoDien.DatTieuDeCot(dgvMonDaXep, "MaMon", "Mã môn", "TenMon", "Tên môn",
                    "SoTinChi", "Tín chỉ", "SoSinhVien", "Số SV", "GiangVien", "Giảng viên");
                dgvTongTinChi.DataSource = xepMonBus.LayTongTinChi(maLop, maHocKy);
                GiaoDien.DatTieuDeCot(dgvTongTinChi, "MaSV", "Mã SV", "HoTen", "Họ tên", "TongTinChi", "Tổng tín chỉ");
                grpMonDaXep.Text = "Các môn đã xếp (" + dgvMonDaXep.Rows.Count + " môn)";
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi(ex.Message);
            }
        }

        private void btnXepMon_Click(object sender, EventArgs e)
        {
            try
            {
                int soSV = xepMonBus.XepMon(GiaoDien.GiaTri(cboLop), GiaoDien.GiaTri(cboMonHoc), GiaoDien.GiaTri(cboHocKy));
                GiaoDien.ThongBao("Đã xếp môn cho " + soSV + " sinh viên.");
                TaiLai();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không xếp được môn: " + ex.Message);
            }
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmThongKe : Form
    {
        private readonly IThongKeBUS thongKeBus = new ThongKeBUS();
        private readonly IDanhMucBUS<HocKy> hocKyBus = new HocKyBUS();
        private readonly IDanhMucBUS<Lop> lopBus = new LopBUS();

        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            foreach (DataGridView dgv in new[] { dgvXepLoai, dgvTongHop, dgvDiemCao, dgvMonTruot, dgvQuyMo })
                GiaoDien.DinhDangLuoi(dgv);
            try
            {
                GiaoDien.NapComboBox(cboHocKy, hocKyBus.LayDanhSach(""), "TenHocKy", "MaHocKy", false);
                GiaoDien.NapComboBox(cboLop, lopBus.LayDanhSach(""), "TenLop", "MaLop", false);
                cboHocKy.SelectedValue = "20252";
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string maLop = GiaoDien.GiaTri(cboLop);
            string maHocKy = GiaoDien.GiaTri(cboHocKy);
            int soLuong = (int)nudSoLuong.Value;
            try
            {
                dgvXepLoai.DataSource = thongKeBus.XepLoaiSinhVien(maLop, maHocKy);
                GiaoDien.DatTieuDeCot(dgvXepLoai, "MaSV", "Mã SV", "HoTen", "Họ tên",
                    "SoTinChi", "Tín chỉ tính điểm", "DiemTBHe4", "Điểm TB (thang 4)", "XepLoai", "Xếp loại");
                DataTable tongHop = thongKeBus.DemTheoXepLoai(maLop, maHocKy);
                dgvTongHop.DataSource = tongHop;
                GiaoDien.DatTieuDeCot(dgvTongHop, "XepLoai", "Xếp loại", "SoSinhVien", "Số SV", "TiLe", "Tỉ lệ");
                VeBieuDo(tongHop);

                dgvDiemCao.DataSource = thongKeBus.SinhVienDiemCaoNhat(maLop, maHocKy, soLuong);
                GiaoDien.DatTieuDeCot(dgvDiemCao, "MaSV", "Mã SV", "HoTen", "Họ tên",
                    "DiemTBHe4", "Điểm TB (thang 4)", "SoTinChi", "Số tín chỉ");
                dgvMonTruot.DataSource = thongKeBus.MonTiLeTruotCaoNhat(maHocKy, soLuong);
                GiaoDien.DatTieuDeCot(dgvMonTruot, "MaMon", "Mã môn", "TenMon", "Tên môn",
                    "SoDuThi", "Số SV có điểm", "SoTruot", "Số SV trượt", "TiLeTruot", "Tỉ lệ trượt (%)");
                dgvQuyMo.DataSource = thongKeBus.QuyMoTheoKhoa();
                GiaoDien.DatTieuDeCot(dgvQuyMo, "TenKhoa", "Khoa", "SoNganh", "Số ngành", "SoLop", "Số lớp",
                    "SoSinhVien", "Số sinh viên", "SoGiangVien", "Số giảng viên");
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không thống kê được: " + ex.Message);
            }
        }

        private void VeBieuDo(DataTable tongHop)
        {
            System.Windows.Forms.DataVisualization.Charting.Series cot = chartXepLoai.Series["SoSinhVien"];
            cot.Points.Clear();
            foreach (DataRow d in tongHop.Rows)
            {
                cot.Points.AddXY(d["XepLoai"].ToString(), Convert.ToInt32(d["SoSinhVien"]));
            }
            chartXepLoai.Titles[0].Text = "Xếp loại lớp " + GiaoDien.GiaTri(cboLop) + " - " + cboHocKy.Text;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataGridView luoi = dgvXepLoai;
            if (tabChinh.SelectedTab == tabDiemCao) luoi = dgvDiemCao;
            else if (tabChinh.SelectedTab == tabMonTruot) luoi = dgvMonTruot;
            else if (tabChinh.SelectedTab == tabQuyMo) luoi = dgvQuyMo;
            XuatExcel.TuLuoi(luoi, "Thống kê - " + tabChinh.SelectedTab.Text);
        }
    }
}

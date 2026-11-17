using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.BUS.Interface;
using QuanLySinhVien.DAL.Entity;

namespace QuanLySinhVien.GUI
{
    public partial class frmNhapDiem : Form
    {
        private readonly IKetQuaBUS ketQuaBus = new KetQuaBUS();
        private readonly IPhanCongBUS phanCongBus = new PhanCongBUS();
        private readonly IDanhMucBUS<HocKy> hocKyBus = new HocKyBUS();

        private string maLopDangMo;
        private string maMonDangMo;
        private string maHocKyDangMo;

        public frmNhapDiem()
        {
            InitializeComponent();
        }

        private void frmNhapDiem_Load(object sender, EventArgs e)
        {
            try
            {
                GiaoDien.NapHocKy(cboHocKy, hocKyBus.LayDanhSach(""));
                cboHocKy.SelectedIndexChanged += cboHocKy_SelectedIndexChanged;
                NapLopMon();
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được dữ liệu: " + ex.Message);
            }
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            NapLopMon();
        }

        private void NapLopMon()
        {
            DataTable ds = phanCongBus.LayCuaGiangVien(PhienDangNhap.NguoiDungHienTai.MaGV, GiaoDien.GiaTri(cboHocKy));
            cboLopMon.DisplayMember = "HienThi";
            cboLopMon.DataSource = ds;
            lblThongBao.Text = ds.Rows.Count == 0
                ? "Bạn chưa được phân công lớp nào trong học kỳ này."
                : "Bạn được phân công " + ds.Rows.Count + " lớp - môn. Chọn lớp - môn rồi bấm \"Tải danh sách\".";
            dgvDiem.Rows.Clear();
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            DataRowView chon = cboLopMon.SelectedItem as DataRowView;
            if (chon == null)
            {
                GiaoDien.BaoLoi("Bạn chưa được phân công lớp nào trong học kỳ này.");
                return;
            }
            maLopDangMo = chon["MaLop"].ToString();
            maMonDangMo = chon["MaMon"].ToString();
            maHocKyDangMo = GiaoDien.GiaTri(cboHocKy);
            TaiBangDiem();
        }

        private void TaiBangDiem()
        {
            try
            {
                DataTable bang = ketQuaBus.LayBangDiemLopMon(maLopDangMo, maMonDangMo, maHocKyDangMo);
                dgvDiem.Rows.Clear();
                foreach (DataRow d in bang.Rows)
                {
                    int i = dgvDiem.Rows.Add(d["MaSV"], d["HoTen"],
                        HienDiem(d["DiemCC"]), HienDiem(d["DiemGK"]), HienDiem(d["DiemKTHP"]),
                        HienDiem(d["DiemHP"]), d["DiemChu"], HienDiem(d["DiemHe4"]), "");
                    CapNhatKetLuan(dgvDiem.Rows[i]);
                }
                lblThongBao.Text = cboLopMon.Text + ": " + bang.Rows.Count +
                    " sinh viên. Nhập điểm vào 3 cột màu vàng rồi bấm \"Lưu bảng điểm\".";
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không tải được bảng điểm: " + ex.Message);
            }
        }

        private static string HienDiem(object giaTri)
        {
            return giaTri == DBNull.Value ? "" : Convert.ToDecimal(giaTri).ToString("0.0");
        }

        private KetQua DocDong(DataGridViewRow dong)
        {
            KetQua kq = new KetQua();
            kq.MaSV = dong.Cells[colMaSV.Index].Value.ToString();
            kq.DiemCC = TienIch.DocDiem(Convert.ToString(dong.Cells[colDiemCC.Index].Value));
            kq.DiemGK = TienIch.DocDiem(Convert.ToString(dong.Cells[colDiemGK.Index].Value));
            kq.DiemKTHP = TienIch.DocDiem(Convert.ToString(dong.Cells[colDiemKTHP.Index].Value));
            return kq;
        }

        private void dgvDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dong = dgvDiem.Rows[e.RowIndex];
            DataGridViewCell o = dong.Cells[e.ColumnIndex];
            o.ErrorText = "";
            try
            {
                KetQua kq = DocDong(dong);
                ketQuaBus.TinhDiem(kq);
                dong.Cells[colDiemHP.Index].Value = kq.DiemHP.HasValue ? kq.DiemHP.Value.ToString("0.0") : "";
                dong.Cells[colDiemChu.Index].Value = kq.DiemChu;
                dong.Cells[colDiemHe4.Index].Value = kq.DiemHe4.HasValue ? kq.DiemHe4.Value.ToString("0.0") : "";
                CapNhatKetLuan(dong);
            }
            catch (LoiNghiepVu loi)
            {
                o.ErrorText = loi.Message;
                o.Style.BackColor = Color.MistyRose;
                return;
            }
            o.Style.BackColor = Color.Empty;
        }

        private void CapNhatKetLuan(DataGridViewRow dong)
        {
            string chu = Convert.ToString(dong.Cells[colDiemChu.Index].Value);
            DataGridViewCell o = dong.Cells[colKetLuan.Index];
            o.Value = chu == "" ? "Chưa đủ điểm" : (chu == "F" ? "Trượt" : "Đạt");
            o.Style.ForeColor = chu == "F" ? Color.Red : (chu == "" ? Color.Gray : Color.DarkGreen);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (maLopDangMo == null || dgvDiem.Rows.Count == 0)
            {
                GiaoDien.BaoLoi("Hãy tải danh sách sinh viên trước.");
                return;
            }
            dgvDiem.EndEdit();
            List<KetQua> danhSach = new List<KetQua>();
            foreach (DataGridViewRow dong in dgvDiem.Rows)
            {
                try
                {
                    danhSach.Add(DocDong(dong));
                }
                catch (LoiNghiepVu loi)
                {
                    dgvDiem.CurrentCell = dong.Cells[colDiemCC.Index];
                    GiaoDien.BaoLoi(loi.Message + "\nBảng điểm chưa được lưu.");
                    return;
                }
            }
            try
            {
                ketQuaBus.LuuBangDiem(maLopDangMo, maMonDangMo, maHocKyDangMo, danhSach);
                GiaoDien.ThongBao("Đã lưu điểm của " + danhSach.Count + " sinh viên.");
                TaiBangDiem();
            }
            catch (LoiNghiepVu loi)
            {
                GiaoDien.BaoLoi(loi.Message);
            }
            catch (Exception ex)
            {
                GiaoDien.BaoLoi("Không lưu được bảng điểm: " + ex.Message);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatExcel.TuLuoi(dgvDiem, "Bảng điểm " + cboLopMon.Text + " - " + cboHocKy.Text);
        }
    }
}

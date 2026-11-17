using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

internal class SoDo
{
    private const float TiLe = 2f;
    private readonly Bitmap anh;
    private readonly Graphics g;
    private readonly Font chu = new Font("Segoe UI", 10.5f);
    private readonly Font chuDam = new Font("Segoe UI", 10.5f, FontStyle.Bold);
    private readonly Font chuNghieng = new Font("Segoe UI", 10.5f, FontStyle.Italic);
    private readonly Font chuNho = new Font("Segoe UI", 9f, FontStyle.Italic);

    public static readonly Color MauLop = Color.White;
    public static readonly Color MauInterface = Color.White;
    public static readonly Color MauForm = Color.White;
    public static readonly Color MauBang = Color.White;
    public static readonly Color MauVien = Color.Black;

    public SoDo(int rong, int cao)
    {
        anh = new Bitmap((int)(rong * TiLe), (int)(cao * TiLe));
        g = Graphics.FromImage(anh);
        g.ScaleTransform(TiLe, TiLe);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        g.Clear(Color.White);
    }

    public void Luu(string duongDan)
    {
        anh.Save(duongDan, ImageFormat.Png);
        Console.WriteLine("  + " + Path.GetFileName(duongDan));
    }

    public RectangleF Lop(float x, float y, float rong, string khuonMau, string ten, string[] thuocTinh, string[] phuongThuc, Color nen)
    {
        float dong = 17;
        float cao = 8 + (khuonMau != null ? dong : 0) + dong + 6;
        if (thuocTinh != null && thuocTinh.Length > 0) cao += thuocTinh.Length * dong + 6;
        if (phuongThuc != null && phuongThuc.Length > 0) cao += phuongThuc.Length * dong + 6;
        RectangleF r = new RectangleF(x, y, rong, cao);
        using (Brush b = new SolidBrush(nen)) g.FillRectangle(b, r);
        using (Pen p = new Pen(MauVien, 1.2f)) g.DrawRectangle(p, r.X, r.Y, r.Width, r.Height);
        StringFormat giua = new StringFormat { Alignment = StringAlignment.Center };
        float yy = y + 4;
        if (khuonMau != null)
        {
            g.DrawString(khuonMau, chuNho, Brushes.Black, new RectangleF(x, yy, rong, dong), giua);
            yy += dong;
        }
        bool truuTuong = khuonMau != null && khuonMau.Contains("abstract");
        g.DrawString(ten, truuTuong ? new Font(chuDam, FontStyle.Bold | FontStyle.Italic) : chuDam, Brushes.Black, new RectangleF(x, yy, rong, dong), giua);
        yy += dong + 4;
        using (Pen p = new Pen(MauVien, 1f))
        {
            if (thuocTinh != null && thuocTinh.Length > 0)
            {
                g.DrawLine(p, x, yy, x + rong, yy);
                yy += 3;
                foreach (string t in thuocTinh) { g.DrawString(t, chu, Brushes.Black, x + 6, yy); yy += dong; }
                yy += 3;
            }
            if (phuongThuc != null && phuongThuc.Length > 0)
            {
                g.DrawLine(p, x, yy, x + rong, yy);
                yy += 3;
                foreach (string t in phuongThuc) { g.DrawString(t, t.Contains("«abstract»") ? chuNghieng : chu, Brushes.Black, x + 6, yy); yy += dong; }
            }
        }
        return r;
    }

    public RectangleF Bang(float x, float y, float rong, string ten, string[] cot)
    {
        float dong = 17;
        RectangleF r = new RectangleF(x, y, rong, 24 + cot.Length * dong + 6);
        g.FillRectangle(new SolidBrush(MauBang), r);
        g.DrawLine(new Pen(MauVien, 1.2f), x, y + 22, x + rong, y + 22);
        g.DrawRectangle(new Pen(MauVien, 1.2f), r.X, r.Y, r.Width, r.Height);
        g.DrawString(ten, chuDam, Brushes.Black, new RectangleF(x, y + 2, rong, 20), new StringFormat { Alignment = StringAlignment.Center });
        float yy = y + 26;
        foreach (string c in cot)
        {
            Font f = c.StartsWith("PK") ? chuDam : chu;
            g.DrawString(c, f, Brushes.Black, x + 5, yy);
            yy += dong;
        }
        return r;
    }

    public RectangleF Khoi(float x, float y, float rong, float cao, string noiDung, Color nen, bool dam)
    {
        RectangleF r = new RectangleF(x, y, rong, cao);
        using (GraphicsPath gp = BoTron(r, 8))
        {
            g.FillPath(new SolidBrush(nen), gp);
            g.DrawPath(new Pen(MauVien, 1.3f), gp);
        }
        g.DrawString(noiDung, dam ? chuDam : chu, Brushes.Black, r, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        return r;
    }

    public void Chu(float x, float y, string noiDung, bool dam, Color mau)
    {
        g.DrawString(noiDung, dam ? chuDam : chu, new SolidBrush(mau), x, y);
    }

    public void Vung(float x, float y, float rong, float cao, string tieuDe, Color nen)
    {
        g.FillRectangle(new SolidBrush(nen), x, y, rong, cao);
        Pen p = new Pen(Color.Black, 1f) { DashStyle = DashStyle.Dash };
        g.DrawRectangle(p, x, y, rong, cao);
        g.DrawString(tieuDe, chuDam, new SolidBrush(MauVien), x + 8, y + 6);
    }

    public enum KieuNoi { KeThua, HienThuc, LienKet, PhuThuoc, MotNhieu, Duong }

    public void Noi(RectangleF tu, RectangleF den, KieuNoi kieu, string nhan)
    {
        PointF a = Tam(tu), b = Tam(den);
        PointF pa = CatVien(tu, b), pb = CatVien(den, a);
        Noi(pa, pb, kieu, nhan);
    }

    public void Noi(PointF pa, PointF pb, KieuNoi kieu, string nhan)
    {
        Pen p = new Pen(Color.Black, 1.3f);
        if (kieu == KieuNoi.HienThuc || kieu == KieuNoi.PhuThuoc || kieu == KieuNoi.Duong) p.DashStyle = DashStyle.Dash;
        g.DrawLine(p, pa, pb);
        double goc = Math.Atan2(pb.Y - pa.Y, pb.X - pa.X);
        if (kieu == KieuNoi.KeThua || kieu == KieuNoi.HienThuc)
        {
            PointF[] tg = { pb, Xoay(pb, goc, -14, 8), Xoay(pb, goc, -14, -8) };
            g.FillPolygon(Brushes.White, tg);
            g.DrawPolygon(new Pen(Color.Black, 1.3f), tg);
        }
        else if (kieu == KieuNoi.PhuThuoc || kieu == KieuNoi.LienKet)
        {
            Pen mt = new Pen(Color.Black, 1.3f);
            g.DrawLine(mt, pb, Xoay(pb, goc, -11, 6));
            g.DrawLine(mt, pb, Xoay(pb, goc, -11, -6));
        }
        else if (kieu == KieuNoi.MotNhieu)
        {
            g.DrawString("1", chuDam, Brushes.Black, Xoay(pa, goc, 8, -16));
            g.DrawString("n", chuDam, Brushes.Black, Xoay(pb, goc, -18, -18));
        }
        if (!string.IsNullOrEmpty(nhan))
        {
            PointF giua = new PointF((pa.X + pb.X) / 2, (pa.Y + pb.Y) / 2);
            SizeF kt = g.MeasureString(nhan, chuNho);
            g.FillRectangle(Brushes.White, giua.X - kt.Width / 2, giua.Y - kt.Height / 2, kt.Width, kt.Height);
            g.DrawString(nhan, chuNho, Brushes.Black, giua.X - kt.Width / 2, giua.Y - kt.Height / 2);
        }
    }

    public static PointF Tam(RectangleF r) { return new PointF(r.X + r.Width / 2, r.Y + r.Height / 2); }
    public static PointF Tren(RectangleF r) { return new PointF(r.X + r.Width / 2, r.Y); }
    public static PointF Duoi(RectangleF r) { return new PointF(r.X + r.Width / 2, r.Bottom); }

    private static PointF CatVien(RectangleF r, PointF huong)
    {
        PointF c = Tam(r);
        double dx = huong.X - c.X, dy = huong.Y - c.Y;
        if (dx == 0 && dy == 0) return c;
        double tx = dx == 0 ? double.MaxValue : (r.Width / 2) / Math.Abs(dx);
        double ty = dy == 0 ? double.MaxValue : (r.Height / 2) / Math.Abs(dy);
        double t = Math.Min(tx, ty);
        return new PointF((float)(c.X + dx * t), (float)(c.Y + dy * t));
    }

    private static PointF Xoay(PointF goc0, double goc, float doc, float ngang)
    {
        double c = Math.Cos(goc), s = Math.Sin(goc);
        return new PointF((float)(goc0.X + doc * c - ngang * s), (float)(goc0.Y + doc * s + ngang * c));
    }

    private static GraphicsPath BoTron(RectangleF r, float bk)
    {
        GraphicsPath gp = new GraphicsPath();
        gp.AddArc(r.X, r.Y, bk * 2, bk * 2, 180, 90);
        gp.AddArc(r.Right - bk * 2, r.Y, bk * 2, bk * 2, 270, 90);
        gp.AddArc(r.Right - bk * 2, r.Bottom - bk * 2, bk * 2, bk * 2, 0, 90);
        gp.AddArc(r.X, r.Bottom - bk * 2, bk * 2, bk * 2, 90, 90);
        gp.CloseFigure();
        return gp;
    }
}

internal static class VeSoDo
{
    private static string thuMuc;

    private static void Main(string[] args)
    {
        thuMuc = args.Length > 0 ? args[0] : ".";
        Directory.CreateDirectory(thuMuc);
        KienTruc();
        LopThucThe();
        LopBUS();
        KeThuaForm();
        ERD();
        MoHinhVatLy();
        QuanHeForm();
        TuanTuThemSinhVien();
    }

    private static string F(string ten) { return Path.Combine(thuMuc, ten); }

    private static void KienTruc()
    {
        SoDo s = new SoDo(900, 560);
        s.Vung(20, 20, 860, 120, "GUI — Lớp giao diện (namespace QuanLySinhVien.GUI)", SoDo.MauForm);
        s.Khoi(40, 58, 150, 60, "frmDangNhap\nfrmMain", Color.White, false);
        s.Khoi(205, 58, 190, 60, "frmDanhMucBase\n(frmKhoa, frmSinhVien...)", Color.White, false);
        s.Khoi(410, 58, 150, 60, "frmNhapDiem\nfrmBangDiem", Color.White, false);
        s.Khoi(575, 58, 140, 60, "frmThongKe\nfrmBaoCao", Color.White, false);
        s.Khoi(730, 58, 130, 60, "GiaoDien\nXuatExcel", Color.White, false);

        s.Vung(20, 175, 860, 120, "BUS — Lớp xử lý nghiệp vụ (namespace QuanLySinhVien.BUS)", SoDo.MauInterface);
        s.Khoi(40, 213, 160, 60, "Interface\nIDanhMucBUS<T>, ...", Color.White, false);
        s.Khoi(215, 213, 180, 60, "KhoaBUS, SinhVienBUS\nKetQuaBUS, ThongKeBUS...", Color.White, false);
        s.Khoi(410, 213, 150, 60, "TienIch\nQuyTacDiem (static)", Color.White, false);
        s.Khoi(575, 213, 140, 60, "PhienDangNhap\n(static)", Color.White, false);
        s.Khoi(730, 213, 130, 60, "LoiNghiepVu\n(ngoại lệ)", Color.White, false);

        s.Vung(20, 330, 860, 120, "DAL — Lớp truy cập dữ liệu (namespace QuanLySinhVien.DAL)", SoDo.MauLop);
        s.Khoi(40, 368, 200, 60, "DBHelper\n(MySqlConnection, Command,\nDataAdapter, Transaction)", Color.White, false);
        s.Khoi(255, 368, 220, 60, "KhoaDAL, SinhVienDAL,\nKetQuaDAL, ThongKeDAL...", Color.White, false);
        s.Khoi(490, 368, 370, 60, "Entity: Nguoi, SinhVien, GiangVien, NguoiDung,\nKhoa, Nganh, Lop, HocKy, MonHoc, PhanCong, KetQua", Color.White, false);

        s.Khoi(270, 480, 360, 60, "MySQL — CSDL qlsv\n10 bảng · 2 view · ~50 Stored Procedure", Color.White, true);
        s.Noi(new PointF(450, 140), new PointF(450, 175), SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(new PointF(450, 295), new PointF(450, 330), SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(new PointF(450, 450), new PointF(450, 480), SoDo.KieuNoi.PhuThuoc, null);
        s.Chu(470, 146, "gọi phương thức BUS, bắt LoiNghiepVu để báo lỗi", false, Color.Black);
        s.Chu(470, 301, "kiểm tra quy tắc R01–R12 rồi gọi DAL", false, Color.Black);
        s.Chu(470, 455, "gọi Stored Procedure có tham số (ADO.NET)", false, Color.Black);
        s.Luu(F("SoDo_KienTruc.png"));
    }

    private static void LopThucThe()
    {
        SoDo s = new SoDo(1180, 760);
        Color c = SoDo.MauLop;
        RectangleF nguoi = s.Lop(330, 20, 300, "«abstract»", "Nguoi",
            new[] { "- hoTen : string", "- soDienThoai : string", "+ HoTen : string  {kiểm tra, chuẩn hóa}", "+ NgaySinh : DateTime", "+ GioiTinh : string", "+ SoDienThoai : string  {10 chữ số}" },
            new[] { "+ MaDinhDanh : string  «abstract»", "+ VaiTro() : string  «abstract»", "+ Tuoi() : int", "+ ToString() : string  (override)" }, c);
        RectangleF sv = s.Lop(130, 330, 290, null, "SinhVien",
            new[] { "+ SoLuongDaTao : int  {static}", "+ MaSV : string", "+ MaLop : string" },
            new[] { "+ SinhVien()", "+ MaDinhDanh : string  (override)", "+ VaiTro() : string  (override)" }, c);
        RectangleF gv = s.Lop(540, 330, 290, null, "GiangVien",
            new[] { "+ MaGV : string", "+ Email : string", "+ MaKhoa : string", "+ TenDangNhap : string" },
            new[] { "+ MaDinhDanh : string  (override)", "+ VaiTro() : string  (override)" }, c);
        s.Noi(sv, nguoi, SoDo.KieuNoi.KeThua, null);
        s.Noi(gv, nguoi, SoDo.KieuNoi.KeThua, null);

        RectangleF kq = s.Lop(20, 540, 330, null, "KetQua",
            new[] { "+ MaSV, MaMon, MaHocKy : string", "+ DiemCC, DiemGK, DiemKTHP : decimal?  {R01}", "+ DiemHP, DiemHe4 : decimal?", "+ DiemChu : string", "+ DuDiemThanhPhan : bool  {R10}" }, null, c);
        RectangleF nd = s.Lop(870, 20, 290, null, "NguoiDung",
            new[] { "+ TenDangNhap, HoTen : string", "+ VaiTro : string", "+ TrangThai : bool", "+ MaGV : string", "+ LaQuanLyDaoTao : bool" },
            new[] { "+ TenVaiTro(vaiTro) : string  {static}" }, c);
        s.Lop(870, 230, 140, null, "Khoa", new[] { "+ MaKhoa", "+ TenKhoa" }, null, c);
        s.Lop(1020, 230, 140, null, "Nganh", new[] { "+ MaNganh", "+ TenNganh", "+ MaKhoa" }, null, c);
        s.Lop(870, 360, 140, null, "Lop", new[] { "+ MaLop", "+ TenLop", "+ MaNganh", "+ KhoaHoc" }, null, c);
        s.Lop(1020, 360, 140, null, "HocKy", new[] { "+ MaHocKy", "+ TenHocKy" }, null, c);
        s.Lop(870, 500, 140, null, "MonHoc", new[] { "+ MaMon", "+ TenMon", "+ SoTinChi" }, null, c);
        s.Lop(1020, 500, 140, null, "PhanCong", new[] { "+ MaLop", "+ MaMon", "+ MaHocKy", "+ MaGV" }, null, c);
        RectangleF ex = s.Lop(420, 560, 210, null, "ApplicationException", null, null, Color.White);
        RectangleF loi = s.Lop(420, 660, 210, null, "LoiNghiepVu", new[] { "+ TenTruong : string" }, null, SoDo.MauInterface);
        s.Noi(loi, ex, SoDo.KieuNoi.KeThua, null);
        s.Chu(650, 680, "(BUS) ngoại lệ do vi phạm quy tắc nghiệp vụ", false, Color.Black);
        s.Chu(20, 730, "Namespace QuanLySinhVien.DAL.Entity — lớp thực thể nằm ở lớp DAL theo mẫu báo cáo", false, Color.Black);
        s.Luu(F("SoDo_LopThucThe.png"));
    }

    private static void LopBUS()
    {
        SoDo s = new SoDo(1220, 680);
        Color i = SoDo.MauInterface, c = SoDo.MauLop;
        RectangleF iDm = s.Lop(170, 20, 280, "«interface»", "IDanhMucBUS<T>", null,
            new[] { "LayDanhSach(tuKhoa) : DataTable", "Them(T)", "Sua(T)", "Xoa(ma)" }, i);
        string[] danhMuc = { "KhoaBUS", "NganhBUS", "LopBUS", "HocKyBUS", "MonHocBUS" };
        for (int k = 0; k < danhMuc.Length; k++)
        {
            RectangleF b = s.Lop(20 + k * 118, 230, 108, null, danhMuc[k], null, null, c);
            s.Noi(SoDo.Tren(b), new PointF(iDm.X + 40 + k * 50, iDm.Bottom), SoDo.KieuNoi.HienThuc, null);
        }
        RectangleF iNd = s.Lop(640, 20, 270, "«interface»", "INguoiDungBUS", null,
            new[] { "DangNhap(ten, matKhau) : NguoiDung", "DoiMatKhau(cu, moi, xacNhan)", "Them / Sua / KhoaHoacMoKhoa", "CapLaiMatKhau(ten) : string" }, i);
        RectangleF iSv = s.Lop(930, 20, 270, "«interface»", "ISinhVienBUS", null,
            new[] { "LayDanhSach(tuKhoa, maLop)", "Them(SinhVien) : string", "Sua(SinhVien)", "Xoa(maSV)" }, i);
        RectangleF bNd = s.Lop(665, 230, 220, null, "NguoiDungBUS", new[] { "MatKhauMacDinh = \"123456\"" }, null, c);
        RectangleF bSv = s.Lop(970, 230, 190, null, "SinhVienBUS", null, null, c);
        s.Noi(bNd, iNd, SoDo.KieuNoi.HienThuc, null);
        s.Noi(bSv, iSv, SoDo.KieuNoi.HienThuc, null);

        RectangleF iKq = s.Lop(20, 330, 290, "«interface»", "IKetQuaBUS", null,
            new[] { "LayBangDiemLopMon(lop, mon, hk)", "LayBangDiemSinhVien(maSV)", "TinhDiem(KetQua)", "LuuBangDiem(lop, mon, hk, ds)" }, i);
        RectangleF bKq = s.Lop(40, 540, 250, null, "KetQuaBUS", null, new[] { "KiemTraQuyenXem(...)  {R07}" }, c);
        s.Noi(bKq, iKq, SoDo.KieuNoi.HienThuc, null);
        string[] ten = { "GiangVien", "XepMon", "PhanCong", "ThongKe" };
        for (int k = 0; k < ten.Length; k++)
        {
            RectangleF ii = s.Lop(340 + k * 220, 360, 205, "«interface»", "I" + ten[k] + "BUS", null, null, i);
            RectangleF bb = s.Lop(340 + k * 220, 470, 205, null, ten[k] + "BUS", null, null, c);
            s.Noi(bb, ii, SoDo.KieuNoi.HienThuc, null);
        }
        s.Lop(340, 560, 420, "«static»", "TienIch + QuyTacDiem + PhienDangNhap", null,
            new[] { "BamMatKhau, LaSoDienThoaiHopLe, ChuanHoaHoTen, ...", "TinhDiemHocPhan, QuyDoiDiemChu, QuyDoiHe4, XepLoaiHocKy" }, Color.White);
        s.Chu(790, 600, "Nét đứt + tam giác rỗng: lớp cài đặt (hiện thực) interface", false, Color.Black);
        s.Luu(F("SoDo_LopBUS.png"));
    }

    private static void KeThuaForm()
    {
        SoDo s = new SoDo(1180, 470);
        RectangleF form = s.Lop(480, 15, 220, null, "System.Windows.Forms.Form", null, null, Color.White);
        RectangleF bas = s.Lop(420, 110, 340, null, "frmDanhMucBase",
            new[] { "# cheDoHienTai : CheDo (Xem/Them/Sua)", "# dgvDanhSach, pnlNhapLieu, errorProvider" },
            new[] { "# KhoiTao(), TaiDuLieu(tuKhoa)  «virtual»", "# HienThiDong(), XoaTrang(), ChoPhepNhap()", "# LuuThem(), LuuSua(), XoaBanGhi()  «virtual»", "# NapLai(), ChuyenCheDo()" }, SoDo.MauForm);
        s.Noi(bas, form, SoDo.KieuNoi.KeThua, null);
        string[] con = { "frmKhoa", "frmNganh", "frmLop", "frmHocKy", "frmMonHoc", "frmGiangVien", "frmSinhVien", "frmNguoiDung" };
        for (int k = 0; k < con.Length; k++)
        {
            RectangleF r = s.Lop(20 + k * 145, 360, 130, null, con[k], null, new[] { "override ..." }, SoDo.MauForm);
            s.Noi(r, bas, SoDo.KieuNoi.KeThua, null);
        }
        string[] khac = { "frmDangNhap, frmMain", "frmDoiMatKhau, frmCayDonVi", "frmXepMon, frmPhanCong", "frmNhapDiem, frmBangDiem", "frmThongKe, frmBaoCao" };
        for (int k = 0; k < khac.Length; k++)
        {
            RectangleF r = s.Khoi(900, 10 + k * 50, 260, 38, khac[k], Color.White, false);
            s.Noi(new PointF(r.X, r.Y + r.Height / 2), new PointF(form.Right, form.Y + form.Height / 2), SoDo.KieuNoi.KeThua, null);
        }
        s.Chu(20, 20, "8 form kế thừa frmDanhMucBase; mọi form kế thừa lớp Form của .NET", false, Color.Black);
        s.Luu(F("SoDo_KeThuaForm.png"));
    }

    private static void ERD()
    {
        SoDo s = new SoDo(1120, 640);
        Color c = SoDo.MauLop;
        RectangleF khoa = s.Lop(40, 40, 160, null, "KHOA", new[] { "MaKhoa (khóa)", "TenKhoa" }, null, c);
        RectangleF nganh = s.Lop(300, 40, 170, null, "NGÀNH", new[] { "MaNganh (khóa)", "TenNganh" }, null, c);
        RectangleF lop = s.Lop(580, 40, 170, null, "LỚP", new[] { "MaLop (khóa)", "TenLop", "KhoaHoc" }, null, c);
        RectangleF sv = s.Lop(890, 40, 200, null, "SINH VIÊN", new[] { "MaSV (khóa)", "HoTen, NgaySinh", "GioiTinh, SoDienThoai" }, null, c);
        RectangleF gv = s.Lop(40, 270, 200, null, "GIẢNG VIÊN", new[] { "MaGV (khóa)", "HoTen, NgaySinh, GioiTinh", "SoDienThoai, Email" }, null, c);
        RectangleF nd = s.Lop(40, 480, 200, null, "NGƯỜI DÙNG", new[] { "TenDangNhap (khóa)", "MatKhau (SHA-256)", "HoTen, VaiTro, TrangThai" }, null, c);
        RectangleF pc = s.Lop(400, 280, 230, null, "PHÂN CÔNG", new[] { "(MaLop, MaMon, MaHocKy) khóa", "MaGV" }, null, SoDo.MauInterface);
        RectangleF mh = s.Lop(330, 490, 180, null, "MÔN HỌC", new[] { "MaMon (khóa)", "TenMon, SoTinChi" }, null, c);
        RectangleF hk = s.Lop(600, 490, 170, null, "HỌC KỲ", new[] { "MaHocKy (khóa)", "TenHocKy" }, null, c);
        RectangleF kq = s.Lop(860, 280, 230, null, "KẾT QUẢ", new[] { "(MaSV, MaMon, MaHocKy) khóa", "DiemCC, DiemGK, DiemKTHP", "DiemHP, DiemChu, DiemHe4" }, null, SoDo.MauInterface);

        s.Noi(khoa, nganh, SoDo.KieuNoi.MotNhieu, "gồm");
        s.Noi(nganh, lop, SoDo.KieuNoi.MotNhieu, "mở");
        s.Noi(lop, sv, SoDo.KieuNoi.MotNhieu, "có");
        s.Noi(khoa, gv, SoDo.KieuNoi.MotNhieu, "thuộc");
        s.Noi(nd, gv, SoDo.KieuNoi.LienKet, "1 - 0..1");
        s.Noi(gv, pc, SoDo.KieuNoi.MotNhieu, "dạy");
        s.Noi(lop, pc, SoDo.KieuNoi.MotNhieu, null);
        s.Noi(mh, pc, SoDo.KieuNoi.MotNhieu, null);
        s.Noi(hk, pc, SoDo.KieuNoi.MotNhieu, null);
        s.Noi(sv, kq, SoDo.KieuNoi.MotNhieu, "học");
        s.Noi(mh, kq, SoDo.KieuNoi.MotNhieu, null);
        s.Noi(hk, kq, SoDo.KieuNoi.MotNhieu, null);
        s.Chu(40, 610, "Ký hiệu: 1 — n là quan hệ một - nhiều; PHÂN CÔNG và KẾT QUẢ là thực thể liên kết (khóa gồm 3 thuộc tính)", false, Color.Black);
        s.Luu(F("SoDo_ERD.png"));
    }

    private static void MoHinhVatLy()
    {
        SoDo s = new SoDo(1200, 760);
        RectangleF khoa = s.Bang(20, 20, 220, "Khoa", new[] { "PK MaKhoa  VARCHAR(10)", "    TenKhoa  VARCHAR(100) UQ" });
        RectangleF nganh = s.Bang(290, 20, 230, "Nganh", new[] { "PK MaNganh  CHAR(2)", "    TenNganh  VARCHAR(100) UQ", "FK MaKhoa  VARCHAR(10)" });
        RectangleF lop = s.Bang(570, 20, 230, "Lop", new[] { "PK MaLop  VARCHAR(15)", "    TenLop  VARCHAR(100)", "FK MaNganh  CHAR(2)", "    KhoaHoc  SMALLINT" });
        RectangleF sv = s.Bang(880, 20, 300, "SinhVien", new[] { "PK MaSV  CHAR(9)", "    HoTen  VARCHAR(50)", "    NgaySinh  DATE", "    GioiTinh  VARCHAR(3)", "    SoDienThoai  CHAR(10)", "FK MaLop  VARCHAR(15)" });
        RectangleF gv = s.Bang(20, 230, 260, "GiangVien", new[] { "PK MaGV  VARCHAR(10)", "    HoTen  VARCHAR(50)", "    NgaySinh  DATE", "    GioiTinh  VARCHAR(3)", "    SoDienThoai  CHAR(10)", "    Email  VARCHAR(100)", "FK MaKhoa  VARCHAR(10)", "FK TenDangNhap  VARCHAR(30) UQ" });
        RectangleF nd = s.Bang(20, 520, 260, "NguoiDung", new[] { "PK TenDangNhap  VARCHAR(30)", "    MatKhau  CHAR(64)", "    HoTen  VARCHAR(50)", "    VaiTro  VARCHAR(20)", "    TrangThai  TINYINT(1)" });
        RectangleF pc = s.Bang(380, 280, 230, "PhanCong", new[] { "PK,FK MaLop  VARCHAR(15)", "PK,FK MaMon  VARCHAR(10)", "PK,FK MaHocKy  CHAR(5)", "FK MaGV  VARCHAR(10)" });
        RectangleF mh = s.Bang(380, 530, 230, "MonHoc", new[] { "PK MaMon  VARCHAR(10)", "    TenMon  VARCHAR(100)", "    SoTinChi  TINYINT" });
        RectangleF hk = s.Bang(660, 560, 210, "HocKy", new[] { "PK MaHocKy  CHAR(5)", "    TenHocKy  VARCHAR(50)" });
        RectangleF kq = s.Bang(900, 330, 280, "KetQua", new[] { "PK,FK MaSV  CHAR(9)", "PK,FK MaMon  VARCHAR(10)", "PK,FK MaHocKy  CHAR(5)", "    DiemCC  DECIMAL(3,1)", "    DiemGK  DECIMAL(3,1)", "    DiemKTHP  DECIMAL(3,1)", "    DiemHP  DECIMAL(3,1)", "    DiemChu  CHAR(1)", "    DiemHe4  DECIMAL(2,1)" });
        s.Noi(nganh, khoa, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(lop, nganh, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(sv, lop, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(new PointF(130, gv.Y), new PointF(130, khoa.Bottom), SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(new PointF(150, gv.Bottom), new PointF(150, nd.Y), SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(pc, lop, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(pc, mh, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(pc, hk, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(pc, gv, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(kq, sv, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(kq, mh, SoDo.KieuNoi.PhuThuoc, null);
        s.Noi(kq, hk, SoDo.KieuNoi.PhuThuoc, null);
        s.Chu(20, 730, "PK: khóa chính · FK: khóa ngoại (mũi tên chỉ tới bảng được tham chiếu) · UQ: không trùng · CHECK: điểm 0-10, SĐT 10 số, mã ngành 2 số, mã học kỳ NNNNK", false, Color.Black);
        s.Luu(F("SoDo_MoHinhVatLy.png"));
    }

    private static void QuanHeForm()
    {
        SoDo s = new SoDo(1100, 560);
        RectangleF prog = s.Khoi(20, 215, 130, 50, "Program.Main()", Color.White, true);
        RectangleF dn = s.Khoi(200, 215, 150, 50, "frmDangNhap\n(ShowDialog)", SoDo.MauForm, true);
        RectangleF main = s.Khoi(420, 210, 190, 60, "frmMain\n(MDI, menu theo vai trò)", SoDo.MauForm, true);
        s.Noi(prog, dn, SoDo.KieuNoi.LienKet, null);
        s.Noi(dn, main, SoDo.KieuNoi.LienKet, null);
        s.Chu(352, 190, "đăng nhập OK", false, Color.Black);
        string[] con = { "frmNguoiDung (chỉ Admin)", "frmKhoa, frmNganh, frmLop", "frmHocKy, frmMonHoc", "frmGiangVien", "frmSinhVien", "frmXepMon, frmPhanCong", "frmNhapDiem (chỉ giảng viên)", "frmBangDiem", "frmCayDonVi", "frmThongKe", "frmBaoCao" };
        RectangleF cay = RectangleF.Empty, bd = RectangleF.Empty;
        PointF goc = new PointF(main.Right, main.Y + main.Height / 2);
        for (int k = 0; k < con.Length; k++)
        {
            RectangleF r = s.Khoi(760, 10 + k * 44, 260, 34, con[k], Color.White, false);
            s.Noi(goc, new PointF(r.X, r.Y + r.Height / 2), SoDo.KieuNoi.LienKet, null);
            if (con[k] == "frmCayDonVi") cay = r;
            if (con[k] == "frmBangDiem") bd = r;
        }
        float xp = cay.Right + 35;
        s.Noi(new PointF(bd.Right, bd.Y + bd.Height / 2), new PointF(xp, bd.Y + bd.Height / 2), SoDo.KieuNoi.Duong, null);
        s.Noi(new PointF(xp, bd.Y + bd.Height / 2), new PointF(xp, cay.Y + cay.Height / 2), SoDo.KieuNoi.Duong, null);
        s.Noi(new PointF(xp, cay.Y + cay.Height / 2), new PointF(cay.Right, cay.Y + cay.Height / 2), SoDo.KieuNoi.PhuThuoc, null);
        s.Chu(xp - 25, cay.Bottom + 6, "delegate", false, Color.Black);
        RectangleF dmk = s.Khoi(420, 390, 190, 50, "frmDoiMatKhau\n(ShowDialog)", Color.White, false);
        s.Noi(main, dmk, SoDo.KieuNoi.LienKet, null);
        RectangleF ss = s.Khoi(160, 390, 220, 60, "PhienDangNhap (static)\nngười dùng đang đăng nhập", SoDo.MauInterface, false);
        s.Noi(dn, ss, SoDo.KieuNoi.PhuThuoc, "BatDau()");
        s.Chu(20, 515, "Mũi tên liền: form mở form; nét đứt: truyền dữ liệu (lớp static PhienDangNhap, delegate/event ChonSinhVienHandler)", false, Color.Black);
        s.Luu(F("SoDo_QuanHeForm.png"));
    }

    private static void TuanTuThemSinhVien()
    {
        SoDo s = new SoDo(1100, 600);
        string[] doiTuong = { "Cán bộ đào tạo", "frmSinhVien\n(GUI)", "SinhVienBUS\n(BUS)", "SinhVienDAL\n(DAL)", "DBHelper\n(DAL)", "MySQL\n(sp_...)" };
        float[] x = new float[doiTuong.Length];
        for (int k = 0; k < doiTuong.Length; k++)
        {
            x[k] = 40 + k * 180;
            s.Khoi(x[k], 15, 150, 46, doiTuong[k], k == 0 ? Color.White : SoDo.MauLop, true);
            s.Noi(new PointF(x[k] + 75, 61), new PointF(x[k] + 75, 590), SoDo.KieuNoi.HienThuc, null);
        }
        string[][] buoc = {
            new[] { "0", "1", "Nhập họ tên, ngày sinh, SĐT, chọn lớp; bấm Lưu" },
            new[] { "1", "2", "DocForm() → Them(SinhVien)  (HoTen, SĐT tự kiểm tra)" },
            new[] { "2", "3", "SinhMa(maLop)  — R05" },
            new[] { "3", "4", "LayGiaTri(\"sp_SinhVien_SinhMa\")" },
            new[] { "4", "5", "CALL sp_SinhVien_SinhMa(@p_MaLop)" },
            new[] { "5", "4", "trả về \"BM2601011\"" },
            new[] { "2", "3", "Them(sv)" },
            new[] { "3", "4", "ThucThi(\"sp_SinhVien_Them\", tham số)" },
            new[] { "4", "5", "INSERT INTO SinhVien ..." },
            new[] { "2", "1", "trả về mã SV mới" },
            new[] { "1", "0", "\"Lưu thành công\", nạp lại danh sách" } };
        float y = 90;
        foreach (string[] b in buoc)
        {
            int tu = int.Parse(b[0]), den = int.Parse(b[1]);
            bool tra = den < tu;
            s.Noi(new PointF(x[tu] + 75, y), new PointF(x[den] + 75, y), tra ? SoDo.KieuNoi.PhuThuoc : SoDo.KieuNoi.LienKet, null);
            s.Chu(Math.Min(x[tu], x[den]) + 85, y - 19, b[2], false, Color.Black);
            y += 45;
        }
        s.Luu(F("SoDo_TuanTuThemSV.png"));
    }
}

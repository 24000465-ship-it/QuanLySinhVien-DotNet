// =============================================================================
// Công cụ tạo 3 mẫu Crystal Report (.rpt) bằng code, dùng thư viện RAS (Report Application Server)
// có sẵn trong Crystal Reports runtime — dùng khi máy chưa cài công cụ thiết kế kéo thả
// "SAP Crystal Reports for Visual Studio". Cấu trúc cột lấy trực tiếp từ lớp BUS của phần mềm,
// nên mẫu báo cáo luôn khớp với dữ liệu chương trình nạp vào lúc chạy (SetDataSource).
// Cách chạy: CongCu\TaoMauBaoCao.bat (cần MySQL đang chạy và CSDL qlsv đã tạo).
// Sau này nếu cài công cụ thiết kế thì có thể mở các file .rpt này trong Visual Studio để sửa giao diện.
// =============================================================================
using System;
using System.Data;
using System.IO;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.ReportAppServer.Controllers;
using CrystalDecisions.ReportAppServer.DataDefModel;
using CrystalDecisions.ReportAppServer.DataSetConversion;
using CrystalDecisions.ReportAppServer.ReportDefModel;
using QuanLySinhVien.BUS;

internal static class TaoMauBaoCao
{
    private const int TwipMoiCm = 567;               // Crystal đo kích thước bằng twip (1 cm = 567 twip)
    private const uint MauXanh = 0x935400;           // màu BGR: xanh đậm (0, 84, 147)
    private const uint MauDen = 0x000000;

    private static void Main(string[] args)
    {
        string thuMucRa = args.Length > 0 ? args[0] : Path.Combine(Environment.CurrentDirectory, "CrystalReport");
        Directory.CreateDirectory(thuMucRa);

        // Đăng nhập Admin để lớp BUS cho phép lấy dữ liệu báo cáo
        new NguoiDungBUS().DangNhap("admin", "123456");
        ThongKeBUS tk = new ThongKeBUS();

        DataTable dsSV = tk.BaoCaoDanhSachSinhVien("DH2501");
        dsSV.TableName = "SinhVienReport";
        Tao(thuMucRa, "rptDanhSachSinhVien.rpt", dsSV,
            "DANH SÁCH SINH VIÊN THEO LỚP",
            new[] { "Lớp: ", "TenLop", "     Ngành: ", "TenNganh" },
            new[] { "Mã SV", "Họ và tên", "Ngày sinh", "Giới tính", "Điện thoại" },
            new[] { "MaSV", "HoTen", "NgaySinhText", "GioiTinh", "SoDienThoai" },
            new[] { 2.4, 5.6, 2.6, 2.0, 3.0 });

        DataTable bdLop = tk.BaoCaoBangDiemLopMon("DH2501", "GD05", "20252");
        bdLop.TableName = "BangDiemReport";
        Tao(thuMucRa, "rptBangDiemLopMon.rpt", bdLop,
            "BẢNG ĐIỂM HỌC PHẦN",
            new[] { "Lớp: ", "TenLop", "     Môn: ", "TenMon", "     ", "TenHocKy" },
            new[] { "Mã SV", "Họ và tên", "CC", "GK", "KTHP", "Điểm HP", "Chữ", "Thang 4" },
            new[] { "MaSV", "HoTen", "DiemCC", "DiemGK", "DiemKTHP", "DiemHP", "DiemChu", "DiemHe4" },
            new[] { 2.4, 5.0, 1.4, 1.4, 1.6, 1.8, 1.2, 1.6 });

        DataTable bdSV = tk.BaoCaoBangDiemSinhVien("BM2501001");
        bdSV.TableName = "BangDiemReport";
        Tao(thuMucRa, "rptBangDiemSinhVien.rpt", bdSV,
            "BẢNG ĐIỂM CÁ NHÂN SINH VIÊN",
            new[] { "Sinh viên: ", "HoTen", "     Mã SV: ", "MaSV", "     Lớp: ", "TenLop" },
            new[] { "Học kỳ", "Mã môn", "Tên môn", "TC", "Điểm HP", "Chữ", "Thang 4" },
            new[] { "MaHocKy", "MaMon", "TenMon", "SoTinChi", "DiemHP", "DiemChu", "DiemHe4" },
            new[] { 1.6, 1.8, 6.0, 1.0, 1.8, 1.2, 1.6 });

        Console.WriteLine("Da tao xong 3 mau bao cao trong: " + thuMucRa);
    }

    /// <summary>
    /// Tạo một mẫu báo cáo: tiêu đề + dòng thông tin chung (Report Header), tiêu đề cột (Page Header),
    /// dữ liệu từng dòng (Details), chữ ký người lập (Report Footer).
    /// </summary>
    private static void Tao(string thuMuc, string tenFile, DataTable mau, string tieuDe,
        string[] dongThongTin, string[] tieuDeCot, string[] tenCot, double[] doRongCm)
    {
        System.Data.DataSet ds = new System.Data.DataSet("dsBaoCao");
        ds.Tables.Add(mau.Copy());

        // RAS chạy trong tiến trình: mở mẫu trống bằng ReportDocument rồi lấy ReportClientDocument
        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        rd.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MauTrong.rpt"));
        ISCDReportClientDocument rcd = rd.ReportClientDocument;
        rcd.DatabaseController.AddDataSource(DataSetConverter.Convert(ds));
        Table bang = (Table)rcd.Database.Tables[0];

        ReportDefinition dinhNghia = rcd.ReportDefController.ReportDefinition;
        Section rh = dinhNghia.ReportHeaderArea.Sections[0];
        Section ph = dinhNghia.PageHeaderArea.Sections[0];
        Section de = dinhNghia.DetailArea.Sections[0];
        Section rf = dinhNghia.ReportFooterArea.Sections[0];
        DatChieuCao(rcd, rh, 1700);
        DatChieuCao(rcd, ph, 450);
        DatChieuCao(rcd, de, 330);
        DatChieuCao(rcd, rf, 1400);

        // Report Header: tên trường, tiêu đề báo cáo, dòng thông tin (lớp, môn...)
        ThemChu(rcd, rh, "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á - PHÒNG ĐÀO TẠO", 0, 0, 10000, 280, 9, true, MauDen, CrAlignmentEnum.crAlignmentLeft);
        ThemChu(rcd, rh, tieuDe, 0, 450, 10500, 420, 15, true, MauXanh, CrAlignmentEnum.crAlignmentHorizontalCenter);
        int x = 0;
        for (int i = 0; i + 1 < dongThongTin.Length; i += 2)
        {
            int rongNhan = Math.Max(500, dongThongTin[i].Length * 110);
            ThemChu(rcd, rh, dongThongTin[i], x, 1100, rongNhan, 300, 10, false, MauDen, CrAlignmentEnum.crAlignmentLeft);
            x += rongNhan;
            int rongTruong = 2900;
            ThemTruong(rcd, rh, bang, dongThongTin[i + 1], x, 1100, rongTruong, true, -1);
            x += rongTruong;
        }

        // Page Header: tiêu đề cột; Details: các trường dữ liệu.
        // Cột số căn giữa (cả tiêu đề), điểm 1 chữ số thập phân, số tín chỉ / mã học kỳ là số nguyên.
        int trai = 0;
        for (int i = 0; i < tenCot.Length; i++)
        {
            int rong = (int)(doRongCm[i] * TwipMoiCm);
            Type kieu = mau.Columns[tenCot[i]].DataType;
            bool laSo = kieu != typeof(string) && kieu != typeof(DateTime);
            int soLe = !laSo ? -1 : (tenCot[i].StartsWith("Diem") ? 1 : 0);
            CrAlignmentEnum canLe = laSo ? CrAlignmentEnum.crAlignmentHorizontalCenter : CrAlignmentEnum.crAlignmentLeft;
            ThemChu(rcd, ph, tieuDeCot[i], trai, 80, rong, 300, 10, true, MauXanh, canLe);
            ThemTruong(rcd, de, bang, tenCot[i], trai, 0, rong, false, soLe);
            trai += rong;
        }
        ThemDuongKe(rcd, ph, 0, 420, trai);

        // Report Footer: ngày lập và chữ ký
        ThemDuongKe(rcd, rf, 0, 60, trai);
        ThemChu(rcd, rf, "Bắc Ninh, ngày ...... tháng ...... năm 20......", trai - 5200, 250, 5200, 300, 10, false, MauDen, CrAlignmentEnum.crAlignmentHorizontalCenter);
        ThemChu(rcd, rf, "NGƯỜI LẬP BIỂU", trai - 5200, 600, 5200, 300, 10, true, MauDen, CrAlignmentEnum.crAlignmentHorizontalCenter);
        ThemChu(rcd, rf, "(Ký, ghi rõ họ tên)", trai - 5200, 900, 5200, 300, 9, false, MauDen, CrAlignmentEnum.crAlignmentHorizontalCenter);

        object duongDan = thuMuc;
        rcd.SaveAs(tenFile, ref duongDan, (int)CdReportClientDocumentSaveAsOptionsEnum.cdReportClientDocumentSaveAsOverwriteExisting);
        rd.Close();
        rd.Dispose();
        Console.WriteLine("  + " + tenFile);
    }

    private static void DatChieuCao(ISCDReportClientDocument rcd, Section vung, int chieuCao)
    {
        rcd.ReportDefController.ReportSectionController.SetProperty(vung, CrReportSectionPropertyEnum.crReportSectionPropertyHeight, chieuCao);
    }

    private static FontColor TaoFont(decimal coChu, bool dam, uint mau)
    {
        FontColor fc = new FontColorClass();
        Font f = new FontClass();
        f.Name = "Times New Roman";
        f.Size = coChu;
        f.Bold = dam;
        fc.Font = f;
        fc.Color = mau;
        return fc;
    }

    private static void ThemChu(ISCDReportClientDocument rcd, Section vung, string noiDung, int trai, int tren,
        int rong, int cao, decimal coChu, bool dam, uint mau, CrAlignmentEnum canLe)
    {
        ParagraphTextElement chu = new ParagraphTextElementClass();
        chu.Text = noiDung;
        chu.Kind = CrParagraphElementKindEnum.crParagraphElementKindText;
        chu.FontColor = TaoFont(coChu, dam, mau);

        Paragraph doan = new ParagraphClass();
        doan.Alignment = canLe;
        doan.ParagraphElements = new ParagraphElementsClass();
        doan.ParagraphElements.Add(chu);

        TextObject o = new TextObjectClass();
        o.Paragraphs = new ParagraphsClass();
        o.Paragraphs.Add(doan);
        o.Left = Math.Max(0, trai);
        o.Top = tren;
        o.Width = rong;
        o.Height = cao;
        o.FontColor = TaoFont(coChu, dam, mau);
        rcd.ReportDefController.ReportObjectController.Add(o, vung, -1);
    }

    private static void ThemTruong(ISCDReportClientDocument rcd, Section vung, Table bang, string tenCot,
        int trai, int tren, int rong, bool dam, int soLe)
    {
        Field truong = null;
        foreach (Field f in bang.DataFields)
        {
            if (f.Name == tenCot) { truong = f; break; }
        }
        if (truong == null) throw new Exception("Khong tim thay cot " + tenCot);

        FieldObject o = new FieldObjectClass();
        o.DataSourceName = truong.FormulaForm;
        o.FieldValueType = truong.Type;
        o.Left = trai;
        o.Top = tren;
        o.Width = rong;
        o.Height = 300;
        o.FontColor = TaoFont(10, dam, MauDen);
        if (soLe >= 0)
        {
            // Trường số: căn giữa, số chữ số thập phân cố định, dấu phẩy thập phân kiểu Việt Nam
            ObjectFormat dinhDang = new ObjectFormatClass();
            dinhDang.HorizontalAlignment = CrAlignmentEnum.crAlignmentHorizontalCenter;
            o.Format = dinhDang;
            NumericFieldFormat so = new NumericFieldFormatClass();
            so.NDecimalPlaces = soLe;
            so.RoundingFormat = soLe == 1 ? CrRoundingTypeEnum.crRoundingTypeRoundToTenth : CrRoundingTypeEnum.crRoundingTypeRoundToUnit;
            so.EnableUseLeadZero = true;
            so.NegativeFormat = CrNegativeTypeEnum.crNegativeTypeLeadingMinus;
            so.ThousandsSeparator = false;
            so.EnableSuppressIfZero = false;                 // điểm 0 (môn F) vẫn phải hiện "0,0"
            so.ZeroValueString = soLe == 1 ? "0,0" : "0";
            so.DecimalSymbol = ",";
            FieldFormat ff = new FieldFormatClass();
            CommonFieldFormat chung = new CommonFieldFormatClass();
            chung.EnableSystemDefault = false;   // không dùng định dạng số mặc định của Windows
            ff.CommonFormat = chung;
            ff.NumericFormat = so;
            o.FieldFormat = ff;
        }
        rcd.ReportDefController.ReportObjectController.Add(o, vung, -1);
    }

    private static void ThemDuongKe(ISCDReportClientDocument rcd, Section vung, int trai, int tren, int rong)
    {
        LineObject ke = new LineObjectClass();
        ke.Left = trai;
        ke.Top = tren;
        ke.Right = trai + rong;
        ke.Bottom = tren;
        ke.LineStyle = CrLineStyleEnum.crLineStyleSingle;
        ke.LineThickness = 15;
        ke.SectionName = vung.Name;
        ke.EndSectionName = vung.Name;
        rcd.ReportDefController.ReportObjectController.Add(ke, vung, -1);
    }
}

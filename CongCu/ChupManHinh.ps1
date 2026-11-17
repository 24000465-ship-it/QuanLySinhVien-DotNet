$ErrorActionPreference = "Stop"
$goc = Split-Path -Parent $PSScriptRoot
$bin = Join-Path $goc "QuanLySinhVien\bin\Debug"
$raAnh = Join-Path $goc "TaiLieu\HinhAnh"
New-Item -ItemType Directory -Force $raAnh | Out-Null

[System.AppDomain]::CurrentDomain.SetData("APP_CONFIG_FILE", "$bin\QuanLySinhVien.exe.config")
Add-Type -AssemblyName System.Configuration
$cm = [System.Configuration.ConfigurationManager]
$cm.GetField("s_initState", "NonPublic,Static").SetValue($null, 0)
$cm.GetField("s_configSystem", "NonPublic,Static").SetValue($null, $null)
$cm.Assembly.GetTypes() | Where-Object { $_.FullName -eq "System.Configuration.ClientConfigPaths" } | ForEach-Object { $_.GetField("s_current", "NonPublic,Static").SetValue($null, $null) }
Add-Type -AssemblyName System.Windows.Forms, System.Drawing
Get-ChildItem $bin -Filter *.dll | ForEach-Object { try { [void][System.Reflection.Assembly]::LoadFrom($_.FullName) } catch {} }
$asm = [System.Reflection.Assembly]::LoadFrom("$bin\QuanLySinhVien.exe")
[System.Windows.Forms.Application]::EnableVisualStyles()
[System.Windows.Forms.Application]::SetUnhandledExceptionMode([System.Windows.Forms.UnhandledExceptionMode]::CatchException)
$flags = [System.Reflection.BindingFlags]"NonPublic,Instance,Public"

function G($f, $ten) { $t = $f.GetType(); while ($t) { $fi = $t.GetField($ten, $flags); if ($fi) { return $fi.GetValue($f) }; $t = $t.BaseType } }
function Cho() { for ($i = 0; $i -lt 5; $i++) { [System.Windows.Forms.Application]::DoEvents(); Start-Sleep -Milliseconds 80 } }
function Chup($tenForm, $tenAnh, $rong, $cao, [scriptblock]$thaoTac) {
    $f = [Activator]::CreateInstance($asm.GetType("QuanLySinhVien.GUI.$tenForm"))
    $f.StartPosition = "Manual"; $f.Location = New-Object System.Drawing.Point(-4000, 0)
    if ($rong -gt 0) { $f.WindowState = "Normal"; $f.Size = New-Object System.Drawing.Size($rong, $cao) }
    $f.Show(); Cho
    if ($thaoTac) { & $thaoTac $f; Cho }
    $bmp = New-Object System.Drawing.Bitmap($f.Width, $f.Height)
    $f.DrawToBitmap($bmp, (New-Object System.Drawing.Rectangle(0, 0, $f.Width, $f.Height)))
    $bmp.Save((Join-Path $raAnh "$tenAnh.png"), [System.Drawing.Imaging.ImageFormat]::Png)
    $bmp.Dispose(); $f.Close(); $f.Dispose()
    Write-Host "  da chup $tenAnh"
}

$nd = New-Object QuanLySinhVien.BUS.NguoiDungBUS
Chup "frmDangNhap" "01_DangNhap" 0 0 { param($f) (G $f "txtTenDangNhap").Text = "admin"; (G $f "txtMatKhau").Text = "123456" }

[void]$nd.DangNhap("admin", "123456")
Chup "frmMain" "02_FormChinh" 1100 650 $null
Chup "frmNguoiDung" "03_TaiKhoan" 1100 650 $null
Chup "frmKhoa" "04_Khoa" 1100 600 $null
Chup "frmNganh" "05_Nganh" 1100 650 $null
Chup "frmLop" "06_Lop" 1100 650 $null
Chup "frmHocKy" "07_HocKy" 1100 600 $null
Chup "frmMonHoc" "08_MonHoc" 1100 650 $null
Chup "frmGiangVien" "09_GiangVien" 1200 650 { param($f) (G $f "cboLocKhoa").SelectedValue = "CNTT"; $f.GetType().GetMethod("NapLai", $flags).Invoke($f, $null) }
Chup "frmSinhVien" "10_SinhVien" 1100 650 { param($f) (G $f "cboLocLop").SelectedValue = "DH2601"; $f.GetType().GetMethod("NapLai", $flags).Invoke($f, $null) }
Chup "frmCayDonVi" "11_CayDonVi" 1100 600 { param($f)
    $tv = G $f "tvDonVi"; $khoa = $tv.Nodes | Where-Object { $_.Text -like "*Công nghệ thông tin*" } | Select-Object -First 1
    $khoa.Expand(); $nganh = $khoa.Nodes[0]; $nganh.Expand(); $tv.SelectedNode = $nganh.Nodes[1] }
Chup "frmXepMon" "12_XepMon" 1100 600 $null
Chup "frmPhanCong" "13_PhanCong" 1100 600 $null
Chup "frmBangDiem" "14_BangDiemLopMon" 1150 600 { param($f)
    (G $f "cboHocKy").SelectedValue = "20252"; Cho; (G $f "cboLop").SelectedValue = "DH2401"; Cho
    (G $f "btnXemLopMon").PerformClick() }
Chup "frmBangDiem" "15_BangDiemSinhVien" 1150 600 { param($f)
    $tab = G $f "tabChinh"; $tab.SelectedIndex = 1; (G $f "txtMaSV").Text = "BM2401003"; (G $f "btnXemSinhVien").PerformClick() }
foreach ($i in 0..3) {
    Chup "frmThongKe" ("16_ThongKe_" + $i) 1150 620 { param($f)
        (G $f "cboLop").SelectedValue = "DH2501"; (G $f "btnThongKe").PerformClick(); Cho; (G $f "tabChinh").SelectedIndex = $i }
}
Chup "frmBaoCao" "17_BaoCao_DanhSach" 1100 750 { param($f) (G $f "cboLoaiBaoCao").SelectedIndex = 0; Cho; (G $f "cboLop").SelectedValue = "DH2401"; (G $f "btnXem").PerformClick() }
Chup "frmBaoCao" "18_BaoCao_BangDiem" 1100 750 { param($f)
    (G $f "cboLoaiBaoCao").SelectedIndex = 1; (G $f "cboHocKy").SelectedValue = "20252"; Cho
    (G $f "cboLop").SelectedValue = "DH2401"; Cho; (G $f "btnXem").PerformClick() }

[void]$nd.DangNhap("gv016", "123456")
Chup "frmNhapDiem" "19_NhapDiem" 1150 600 { param($f)
    $c = G $f "cboLopMon"; for ($i = 0; $i -lt $c.Items.Count; $i++) { if ($c.Items[$i]["MaLop"] -eq "DH2601") { $c.SelectedIndex = $i; break } }
    (G $f "btnTai").PerformClick(); Cho
    $dgv = G $f "dgvDiem"; $diem = @(@(9,7,6),@(8,8.5,7),@(10,9,9.5),@(7,5,3))
    for ($r = 0; $r -lt 4; $r++) { for ($c2 = 0; $c2 -lt 3; $c2++) { $dgv.Rows[$r].Cells[2 + $c2].Value = [string]$diem[$r][$c2] }
        $f.GetType().GetMethod("dgvDiem_CellEndEdit", $flags).Invoke($f, [object[]]@($dgv, [System.Windows.Forms.DataGridViewCellEventArgs]::new(4, $r))) }
    $dgv.Rows[4].Cells[2].Value = "11"; $f.GetType().GetMethod("dgvDiem_CellEndEdit", $flags).Invoke($f, [object[]]@($dgv, [System.Windows.Forms.DataGridViewCellEventArgs]::new(2, 4))) }
Write-Host "Xong. Anh luu trong $raAnh"

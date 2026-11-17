$ErrorActionPreference = "Stop"
$goc = Split-Path -Parent $PSScriptRoot
$msbuild = "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
$phienBan = "QuanLySinhVien_v1.0"
$dich = Join-Path $goc "BanPhatHanh\$phienBan"

Write-Host "1. Build ban Release..."
& $msbuild (Join-Path $goc "QuanLySinhVien.sln") -restore -p:Configuration=Release -v:minimal -nologo
if ($LASTEXITCODE -ne 0) { throw "Build that bai" }

Write-Host "2. Gom file vao $dich"
if (Test-Path $dich) { Remove-Item $dich -Recurse -Force }
New-Item -ItemType Directory -Force (Join-Path $dich "ChuongTrinh") | Out-Null
$release = Join-Path $goc "QuanLySinhVien\bin\Release"
Copy-Item "$release\*" (Join-Path $dich "ChuongTrinh") -Recurse -Exclude "*.pdb","*.xml"
New-Item -ItemType Directory -Force (Join-Path $dich "Database") | Out-Null
Copy-Item (Join-Path $goc "Database\QLSV.sql") (Join-Path $dich "Database")
Copy-Item (Join-Path $PSScriptRoot "CaiDat.bat") $dich
Copy-Item (Join-Path $goc "HUONG_DAN_CAI_DAT.md") $dich

Write-Host "3. Nen thanh file zip"
$zip = Join-Path $goc "BanPhatHanh\$phienBan.zip"
if (Test-Path $zip) { Remove-Item $zip -Force }
Compress-Archive -Path "$dich\*" -DestinationPath $zip
Write-Host "Xong: $zip"

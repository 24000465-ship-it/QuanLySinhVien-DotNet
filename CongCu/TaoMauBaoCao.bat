@echo off
chcp 65001 >nul
setlocal
set GAC64=C:\Windows\Microsoft.NET\assembly\GAC_64
set V=v4.0_13.0.4000.0__692fbea5521e1304
set BIN=%~dp0..\QuanLySinhVien\bin\Debug
set CSC=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe

"%CSC%" /nologo /platform:x64 /out:"%BIN%\TaoMauBaoCao.exe" ^
  /r:"%BIN%\QuanLySinhVien.exe" /r:System.Data.dll ^
  /r:"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\CrystalDecisions.CrystalReports.Engine\%V%\CrystalDecisions.CrystalReports.Engine.dll" ^
  /r:"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\CrystalDecisions.Shared\%V%\CrystalDecisions.Shared.dll" ^
  /r:"%GAC64%\CrystalDecisions.ReportAppServer.ClientDoc\%V%\CrystalDecisions.ReportAppServer.ClientDoc.dll" ^
  /r:"%GAC64%\CrystalDecisions.ReportAppServer.Controllers\%V%\CrystalDecisions.ReportAppServer.Controllers.dll" ^
  /r:"%GAC64%\CrystalDecisions.ReportAppServer.DataDefModel\%V%\CrystalDecisions.ReportAppServer.DataDefModel.dll" ^
  /r:"%GAC64%\CrystalDecisions.ReportAppServer.ReportDefModel\%V%\CrystalDecisions.ReportAppServer.ReportDefModel.dll" ^
  /r:"%GAC64%\CrystalDecisions.ReportAppServer.DataSetConversion\%V%\CrystalDecisions.ReportAppServer.DataSetConversion.dll" ^
  /r:"%GAC64%\CrystalDecisions.ReportAppServer.CommonObjectModel\%V%\CrystalDecisions.ReportAppServer.CommonObjectModel.dll" ^
  "%~dp0TaoMauBaoCao.cs"
if errorlevel 1 exit /b 1

copy /y "%~dp0MauTrong.rpt" "%BIN%\MauTrong.rpt" >nul
copy /y "%BIN%\QuanLySinhVien.exe.config" "%BIN%\TaoMauBaoCao.exe.config" >nul
"%BIN%\TaoMauBaoCao.exe" "%~dp0..\QuanLySinhVien\CrystalReport"

@echo off
chcp 65001 >nul
set DICH=%LOCALAPPDATA%\QuanLySinhVien
echo Dang cai dat vao %DICH% ...
if not exist "%DICH%" mkdir "%DICH%"
xcopy /e /y /q "%~dp0ChuongTrinh\*" "%DICH%\" >nul
powershell -NoProfile -Command "$s=(New-Object -ComObject WScript.Shell).CreateShortcut([Environment]::GetFolderPath('Desktop')+'\Quan ly sinh vien.lnk'); $s.TargetPath='%DICH%\QuanLySinhVien.exe'; $s.WorkingDirectory='%DICH%'; $s.Save()"
echo.
echo Da cai dat xong. Lan dau su dung, hay chay file Database\QLSV.sql bang MySQL Workbench (tai khoan root).
echo Mo phan mem bang loi tat "Quan ly sinh vien" tren Desktop.
pause

# Phần mềm Quản lý Sinh viên

Bài tập lớn học phần **Lập trình .NET (IT3212)** – Trường Đại học Công nghệ Đông Á.
Đề tài 1: **Xây dựng phần mềm quản lý sinh viên bằng công nghệ .NET**.

Ứng dụng Windows Forms viết bằng C# (.NET Framework 4.8), cơ sở dữ liệu MySQL 8.0, theo mô hình 3 lớp GUI – BUS – DAL, kết nối bằng ADO.NET qua Stored Procedure, báo cáo bằng Crystal Reports.

## Chức năng

| Mã | Chức năng |
|---|---|
| F01 | Đăng nhập, đăng xuất, đổi mật khẩu |
| F02 | Quản lý tài khoản |
| F03 | Quản lý sinh viên |
| F04 | Quản lý khoa, ngành, lớp, học kỳ, giảng viên |
| F05 | Quản lý môn học |
| F06 | Xếp môn theo lớp |
| F07 | Phân công giảng viên |
| F08 | Nhập điểm |
| F09 | Tính điểm, quy đổi, xếp loại |
| F10 | Xem bảng điểm |
| F11 | Thống kê |
| F12 | Xuất Excel |
| F13 | Xem, in báo cáo (Crystal Report) |

## Cấu trúc thư mục

```
QuanLySinhVien.sln          Solution Visual Studio
QuanLySinhVien/
  GUI/                      19 form giao diện
  BUS/                      Lớp nghiệp vụ, Interface/, tiện ích
  DAL/                      DBHelper, lớp truy cập dữ liệu, Entity/ (lớp thực thể)
  CrystalReport/            3 mẫu báo cáo .rpt
  App.config                Chuỗi kết nối MySQL
Database/QLSV.sql           Script tạo CSDL, thủ tục và dữ liệu mẫu
CongCu/                     Công cụ đóng gói, tạo mẫu báo cáo, vẽ sơ đồ
TaiLieu/                    Báo cáo, slide, phân công, câu hỏi vấn đáp
HUONG_DAN_CAI_DAT.md        Hướng dẫn cài đặt chi tiết
```

## Cách chạy

1. Mở **MySQL Workbench**, chạy file `Database/QLSV.sql` (tạo CSDL `qlsv` và tài khoản MySQL `qlsv_app` cho phần mềm).
2. Mở `QuanLySinhVien.sln` bằng **Visual Studio 2022**, bấm **F5**.
3. Đăng nhập bằng một trong các tài khoản dưới đây.

Chức năng báo cáo cần cài **SAP Crystal Reports runtime 13 (64-bit)**. Xem thêm [HUONG_DAN_CAI_DAT.md](HUONG_DAN_CAI_DAT.md).

## Tài khoản dùng thử (mật khẩu `123456`)

| Tài khoản | Vai trò |
|---|---|
| `admin` | Quản trị |
| `cbdt01` | Cán bộ đào tạo |
| `gv016` | Giảng viên (nhập điểm các lớp được phân công) |
| `cbdt04` | Tài khoản bị khóa |

# Phần mềm Quản lý Sinh viên — Hướng dẫn cài đặt và chạy

Đề tài: **Xây dựng phần mềm quản lý sinh viên bằng công nghệ .NET** — Học phần Lập trình .NET (IT3212).

## 1. Yêu cầu máy

| Thành phần | Phiên bản |
|---|---|
| Windows | 10 / 11 (64-bit) |
| .NET Framework | 4.8 (Windows 10/11 có sẵn) |
| MySQL Server | 8.0 trở lên (kèm MySQL Workbench) |
| SAP Crystal Reports runtime | 13.0 (64-bit) — chỉ cần cho chức năng Báo cáo |
| Microsoft Excel | Không bắt buộc (không có Excel thì xuất ra file CSV) |

## 2. Tạo cơ sở dữ liệu (làm một lần)

1. Mở **MySQL Workbench**, kết nối bằng tài khoản **root**.
2. **File → Open SQL Script…** → chọn `Database\QLSV.sql`.
3. Bấm biểu tượng **tia sét** (Execute). Khi chạy xong, cuối kết quả có bảng đếm số bản ghi của 10 bảng.

Script tạo CSDL `qlsv`, các bảng, view, thủ tục, dữ liệu mẫu, và tài khoản MySQL riêng `qlsv_app` cho phần mềm.
Chạy lại script sẽ xóa và tạo lại toàn bộ dữ liệu mẫu.

## 3. Cài và chạy phần mềm

- **Từ bản phát hành:** giải nén `QuanLySinhVien_v1.0.zip`, chạy `CaiDat.bat`, mở lối tắt **Quan ly sinh vien** trên Desktop.
- **Từ mã nguồn:** mở `QuanLySinhVien.sln` bằng Visual Studio 2022, bấm **F5**.

Đổi máy chủ MySQL hoặc mật khẩu: sửa chuỗi kết nối `QLSV` trong file `QuanLySinhVien.exe.config` (hoặc `App.config` khi chạy từ mã nguồn).

## 4. Tài khoản dùng thử (mật khẩu đều là `123456`)

| Tài khoản | Vai trò | Dùng để thử |
|---|---|---|
| `admin` | Quản trị | Mọi chức năng, quản lý tài khoản |
| `cbdt01` | Cán bộ đào tạo | Danh mục, sinh viên, xếp môn, phân công, thống kê, báo cáo |
| `cbdt04` | Cán bộ đào tạo | Tài khoản **bị khóa** — thử thông báo khóa tài khoản |
| `gv016` | Giảng viên khoa CNTT | Nhập điểm các lớp ngành CNTT được phân công |

Gợi ý demo nhập điểm: đăng nhập `gv016` → Điểm → Nhập điểm → học kỳ 1 năm 2026-2027 → chọn lớp `DH2601…` (lớp K26 chưa có điểm thi) → nhập điểm → Lưu.

## 5. Cấu trúc thư mục mã nguồn

```
BTL_QuanLySinhVien
├── QuanLySinhVien.sln
├── Database\QLSV.sql            CSDL, thủ tục, dữ liệu mẫu
├── QuanLySinhVien\
│   ├── GUI\                      các form (giao diện)
│   ├── BUS\                      xử lý nghiệp vụ (+ Interface\)
│   ├── DAL\                      truy cập dữ liệu (+ Entity\ lớp thực thể)
│   └── CrystalReport\            3 mẫu báo cáo .rpt
└── CongCu\
    ├── TaoMauBaoCao.bat          tạo lại 3 mẫu báo cáo bằng code (Crystal RAS)
    ├── DongGoi.ps1               đóng gói bản phát hành .zip
    └── CaiDat.bat                cài đặt trên máy người dùng
```

## 6. Lỗi thường gặp

| Hiện tượng | Cách xử lý |
|---|---|
| "Không kết nối được cơ sở dữ liệu MySQL" khi mở | Kiểm tra dịch vụ MySQL80 đang chạy (services.msc) và đã chạy `QLSV.sql` |
| Báo cáo hiện dạng bảng thay vì Crystal Report | Thiếu file trong thư mục `CrystalReport` cạnh file .exe — chạy `CongCu\TaoMauBaoCao.bat` |
| Lỗi khi mở báo cáo trên máy khác | Cài *SAP Crystal Reports runtime engine for .NET Framework (64-bit)* |

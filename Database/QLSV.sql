
DROP DATABASE IF EXISTS qlsv;
CREATE DATABASE qlsv CHARACTER SET utf8mb4 COLLATE utf8mb4_vi_0900_ai_ci;
USE qlsv;
SET NAMES utf8mb4 COLLATE utf8mb4_vi_0900_ai_ci;

CREATE USER IF NOT EXISTS 'qlsv_app'@'localhost' IDENTIFIED BY 'Qlsv@2026';
GRANT ALL PRIVILEGES ON qlsv.* TO 'qlsv_app'@'localhost';
FLUSH PRIVILEGES;


CREATE TABLE NguoiDung (
    TenDangNhap VARCHAR(30)  NOT NULL PRIMARY KEY,
    MatKhau     CHAR(64)     NOT NULL,
    HoTen       VARCHAR(50)  NOT NULL,
    VaiTro      VARCHAR(20)  NOT NULL,
    TrangThai   TINYINT(1)   NOT NULL DEFAULT 1,
    CONSTRAINT CK_NguoiDung_VaiTro CHECK (VaiTro IN ('Admin', 'CanBoDaoTao', 'GiangVien'))
);

CREATE TABLE Khoa (
    MaKhoa  VARCHAR(10)  NOT NULL PRIMARY KEY,
    TenKhoa VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Nganh (
    MaNganh  CHAR(2)      NOT NULL PRIMARY KEY,
    TenNganh VARCHAR(100) NOT NULL UNIQUE,
    MaKhoa   VARCHAR(10)  NOT NULL,
    CONSTRAINT FK_Nganh_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa (MaKhoa),
    CONSTRAINT CK_Nganh_Ma CHECK (MaNganh REGEXP '^[0-9]{2}$')
);

CREATE TABLE GiangVien (
    MaGV        VARCHAR(10)  NOT NULL PRIMARY KEY,
    HoTen       VARCHAR(50)  NOT NULL,
    NgaySinh    DATE         NULL,
    GioiTinh    VARCHAR(3)   NOT NULL,
    SoDienThoai CHAR(10)     NOT NULL,
    Email       VARCHAR(100) NULL,
    MaKhoa      VARCHAR(10)  NOT NULL,
    TenDangNhap VARCHAR(30)  NULL UNIQUE,
    CONSTRAINT FK_GiangVien_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa (MaKhoa),
    CONSTRAINT FK_GiangVien_NguoiDung FOREIGN KEY (TenDangNhap) REFERENCES NguoiDung (TenDangNhap),
    CONSTRAINT CK_GiangVien_GioiTinh CHECK (GioiTinh IN ('Nam', 'Nữ')),
    CONSTRAINT CK_GiangVien_SDT CHECK (SoDienThoai REGEXP '^[0-9]{10}$')
);

CREATE TABLE Lop (
    MaLop   VARCHAR(15)  NOT NULL PRIMARY KEY,
    TenLop  VARCHAR(100) NOT NULL,
    MaNganh CHAR(2)      NOT NULL,
    KhoaHoc SMALLINT     NOT NULL,
    CONSTRAINT FK_Lop_Nganh FOREIGN KEY (MaNganh) REFERENCES Nganh (MaNganh),
    CONSTRAINT CK_Lop_KhoaHoc CHECK (KhoaHoc BETWEEN 2000 AND 2099)
);

CREATE TABLE SinhVien (
    MaSV        CHAR(9)     NOT NULL PRIMARY KEY,
    HoTen       VARCHAR(50) NOT NULL,
    NgaySinh    DATE        NOT NULL,
    GioiTinh    VARCHAR(3)  NOT NULL,
    SoDienThoai CHAR(10)    NOT NULL,
    MaLop       VARCHAR(15) NOT NULL,
    CONSTRAINT FK_SinhVien_Lop FOREIGN KEY (MaLop) REFERENCES Lop (MaLop),
    CONSTRAINT CK_SinhVien_GioiTinh CHECK (GioiTinh IN ('Nam', 'Nữ')),
    CONSTRAINT CK_SinhVien_SDT CHECK (SoDienThoai REGEXP '^[0-9]{10}$')
);

CREATE TABLE HocKy (
    MaHocKy  CHAR(5)     NOT NULL PRIMARY KEY,
    TenHocKy VARCHAR(50) NOT NULL,
    CONSTRAINT CK_HocKy_Ma CHECK (MaHocKy REGEXP '^[0-9]{4}[1-3]$')
);

CREATE TABLE MonHoc (
    MaMon    VARCHAR(10)  NOT NULL PRIMARY KEY,
    TenMon   VARCHAR(100) NOT NULL,
    SoTinChi TINYINT      NOT NULL,
    CONSTRAINT CK_MonHoc_TinChi CHECK (SoTinChi BETWEEN 1 AND 10)
);

CREATE TABLE PhanCong (
    MaLop   VARCHAR(15) NOT NULL,
    MaMon   VARCHAR(10) NOT NULL,
    MaHocKy CHAR(5)     NOT NULL,
    MaGV    VARCHAR(10) NOT NULL,
    PRIMARY KEY (MaLop, MaMon, MaHocKy),
    CONSTRAINT FK_PhanCong_Lop FOREIGN KEY (MaLop) REFERENCES Lop (MaLop),
    CONSTRAINT FK_PhanCong_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc (MaMon),
    CONSTRAINT FK_PhanCong_HocKy FOREIGN KEY (MaHocKy) REFERENCES HocKy (MaHocKy),
    CONSTRAINT FK_PhanCong_GiangVien FOREIGN KEY (MaGV) REFERENCES GiangVien (MaGV)
);

CREATE TABLE KetQua (
    MaSV     CHAR(9)      NOT NULL,
    MaMon    VARCHAR(10)  NOT NULL,
    MaHocKy  CHAR(5)      NOT NULL,
    DiemCC   DECIMAL(3,1) NULL,
    DiemGK   DECIMAL(3,1) NULL,
    DiemKTHP DECIMAL(3,1) NULL,
    DiemHP   DECIMAL(3,1) NULL,
    DiemChu  CHAR(1)      NULL,
    DiemHe4  DECIMAL(2,1) NULL,
    PRIMARY KEY (MaSV, MaMon, MaHocKy),
    CONSTRAINT FK_KetQua_SinhVien FOREIGN KEY (MaSV) REFERENCES SinhVien (MaSV),
    CONSTRAINT FK_KetQua_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc (MaMon),
    CONSTRAINT FK_KetQua_HocKy FOREIGN KEY (MaHocKy) REFERENCES HocKy (MaHocKy),
    CONSTRAINT CK_KetQua_DiemCC CHECK (DiemCC BETWEEN 0 AND 10),
    CONSTRAINT CK_KetQua_DiemGK CHECK (DiemGK BETWEEN 0 AND 10),
    CONSTRAINT CK_KetQua_DiemKTHP CHECK (DiemKTHP BETWEEN 0 AND 10)
);


CREATE VIEW v_SinhVienReport AS
SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.SoDienThoai,
       l.MaLop, l.TenLop, n.TenNganh, k.TenKhoa
FROM SinhVien sv
JOIN Lop l   ON l.MaLop = sv.MaLop
JOIN Nganh n ON n.MaNganh = l.MaNganh
JOIN Khoa k  ON k.MaKhoa = n.MaKhoa;

CREATE VIEW v_BangDiemReport AS
SELECT kq.MaHocKy, hk.TenHocKy, sv.MaLop, l.TenLop, kq.MaMon, mh.TenMon, mh.SoTinChi,
       kq.MaSV, sv.HoTen, kq.DiemCC, kq.DiemGK, kq.DiemKTHP, kq.DiemHP, kq.DiemChu, kq.DiemHe4,
       gv.HoTen AS GiangVienDay
FROM KetQua kq
JOIN SinhVien sv ON sv.MaSV = kq.MaSV
JOIN Lop l       ON l.MaLop = sv.MaLop
JOIN MonHoc mh   ON mh.MaMon = kq.MaMon
JOIN HocKy hk    ON hk.MaHocKy = kq.MaHocKy
LEFT JOIN PhanCong pc ON pc.MaLop = sv.MaLop AND pc.MaMon = kq.MaMon AND pc.MaHocKy = kq.MaHocKy
LEFT JOIN GiangVien gv ON gv.MaGV = pc.MaGV;


DELIMITER $$

CREATE PROCEDURE sp_NguoiDung_DangNhap(IN p_TenDangNhap VARCHAR(30), IN p_MatKhau CHAR(64))
BEGIN
    SELECT nd.TenDangNhap, nd.HoTen, nd.VaiTro, nd.TrangThai, gv.MaGV
    FROM NguoiDung nd
    LEFT JOIN GiangVien gv ON gv.TenDangNhap = nd.TenDangNhap
    WHERE nd.TenDangNhap = p_TenDangNhap AND nd.MatKhau = p_MatKhau;
END$$

CREATE PROCEDURE sp_NguoiDung_DoiMatKhau(IN p_TenDangNhap VARCHAR(30), IN p_MatKhauCu CHAR(64), IN p_MatKhauMoi CHAR(64))
BEGIN
    UPDATE NguoiDung SET MatKhau = p_MatKhauMoi
    WHERE TenDangNhap = p_TenDangNhap AND MatKhau = p_MatKhauCu;
    SELECT ROW_COUNT() AS SoDong;
END$$

CREATE PROCEDURE sp_NguoiDung_LayDanhSach(IN p_TuKhoa VARCHAR(50))
BEGIN
    SELECT TenDangNhap, HoTen, VaiTro, TrangThai
    FROM NguoiDung
    WHERE p_TuKhoa = '' OR TenDangNhap LIKE CONCAT('%', p_TuKhoa, '%') OR HoTen LIKE CONCAT('%', p_TuKhoa, '%')
    ORDER BY VaiTro, TenDangNhap;
END$$

CREATE PROCEDURE sp_NguoiDung_Them(IN p_TenDangNhap VARCHAR(30), IN p_MatKhau CHAR(64), IN p_HoTen VARCHAR(50), IN p_VaiTro VARCHAR(20))
BEGIN
    INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai)
    VALUES (p_TenDangNhap, p_MatKhau, p_HoTen, p_VaiTro, 1);
END$$

CREATE PROCEDURE sp_NguoiDung_Sua(IN p_TenDangNhap VARCHAR(30), IN p_HoTen VARCHAR(50), IN p_VaiTro VARCHAR(20))
BEGIN
    UPDATE NguoiDung SET HoTen = p_HoTen, VaiTro = p_VaiTro WHERE TenDangNhap = p_TenDangNhap;
END$$

CREATE PROCEDURE sp_NguoiDung_DatTrangThai(IN p_TenDangNhap VARCHAR(30), IN p_TrangThai TINYINT)
BEGIN
    UPDATE NguoiDung SET TrangThai = p_TrangThai WHERE TenDangNhap = p_TenDangNhap;
END$$

CREATE PROCEDURE sp_NguoiDung_CapLaiMatKhau(IN p_TenDangNhap VARCHAR(30), IN p_MatKhau CHAR(64))
BEGIN
    UPDATE NguoiDung SET MatKhau = p_MatKhau WHERE TenDangNhap = p_TenDangNhap;
END$$

CREATE PROCEDURE sp_NguoiDung_DemTheoTen(IN p_TenDangNhap VARCHAR(30))
BEGIN
    SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = p_TenDangNhap;
END$$

CREATE PROCEDURE sp_Khoa_LayDanhSach(IN p_TuKhoa VARCHAR(100))
BEGIN
    SELECT MaKhoa, TenKhoa FROM Khoa
    WHERE p_TuKhoa = '' OR MaKhoa LIKE CONCAT('%', p_TuKhoa, '%') OR TenKhoa LIKE CONCAT('%', p_TuKhoa, '%')
    ORDER BY MaKhoa;
END$$

CREATE PROCEDURE sp_Khoa_Them(IN p_MaKhoa VARCHAR(10), IN p_TenKhoa VARCHAR(100))
BEGIN
    INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES (p_MaKhoa, p_TenKhoa);
END$$

CREATE PROCEDURE sp_Khoa_Sua(IN p_MaKhoa VARCHAR(10), IN p_TenKhoa VARCHAR(100))
BEGIN
    UPDATE Khoa SET TenKhoa = p_TenKhoa WHERE MaKhoa = p_MaKhoa;
END$$

CREATE PROCEDURE sp_Khoa_Xoa(IN p_MaKhoa VARCHAR(10))
BEGIN
    DELETE FROM Khoa WHERE MaKhoa = p_MaKhoa;
END$$

CREATE PROCEDURE sp_Khoa_DemPhuThuoc(IN p_MaKhoa VARCHAR(10))
BEGIN
    SELECT (SELECT COUNT(*) FROM Nganh WHERE MaKhoa = p_MaKhoa)
         + (SELECT COUNT(*) FROM GiangVien WHERE MaKhoa = p_MaKhoa);
END$$

CREATE PROCEDURE sp_Nganh_LayDanhSach(IN p_TuKhoa VARCHAR(100))
BEGIN
    SELECT n.MaNganh, n.TenNganh, n.MaKhoa, k.TenKhoa
    FROM Nganh n JOIN Khoa k ON k.MaKhoa = n.MaKhoa
    WHERE p_TuKhoa = '' OR n.MaNganh LIKE CONCAT('%', p_TuKhoa, '%') OR n.TenNganh LIKE CONCAT('%', p_TuKhoa, '%')
    ORDER BY n.MaNganh;
END$$

CREATE PROCEDURE sp_Nganh_Them(IN p_MaNganh CHAR(2), IN p_TenNganh VARCHAR(100), IN p_MaKhoa VARCHAR(10))
BEGIN
    INSERT INTO Nganh (MaNganh, TenNganh, MaKhoa) VALUES (p_MaNganh, p_TenNganh, p_MaKhoa);
END$$

CREATE PROCEDURE sp_Nganh_Sua(IN p_MaNganh CHAR(2), IN p_TenNganh VARCHAR(100), IN p_MaKhoa VARCHAR(10))
BEGIN
    UPDATE Nganh SET TenNganh = p_TenNganh, MaKhoa = p_MaKhoa WHERE MaNganh = p_MaNganh;
END$$

CREATE PROCEDURE sp_Nganh_Xoa(IN p_MaNganh CHAR(2))
BEGIN
    DELETE FROM Nganh WHERE MaNganh = p_MaNganh;
END$$

CREATE PROCEDURE sp_Nganh_DemPhuThuoc(IN p_MaNganh CHAR(2))
BEGIN
    SELECT COUNT(*) FROM Lop WHERE MaNganh = p_MaNganh;
END$$

CREATE PROCEDURE sp_Lop_LayDanhSach(IN p_TuKhoa VARCHAR(100))
BEGIN
    SELECT l.MaLop, l.TenLop, l.MaNganh, n.TenNganh, l.KhoaHoc,
           (SELECT COUNT(*) FROM SinhVien sv WHERE sv.MaLop = l.MaLop) AS SiSo
    FROM Lop l JOIN Nganh n ON n.MaNganh = l.MaNganh
    WHERE p_TuKhoa = '' OR l.MaLop LIKE CONCAT('%', p_TuKhoa, '%') OR l.TenLop LIKE CONCAT('%', p_TuKhoa, '%')
    ORDER BY l.KhoaHoc DESC, l.MaLop;
END$$

CREATE PROCEDURE sp_Lop_Them(IN p_MaLop VARCHAR(15), IN p_TenLop VARCHAR(100), IN p_MaNganh CHAR(2), IN p_KhoaHoc SMALLINT)
BEGIN
    INSERT INTO Lop (MaLop, TenLop, MaNganh, KhoaHoc) VALUES (p_MaLop, p_TenLop, p_MaNganh, p_KhoaHoc);
END$$

CREATE PROCEDURE sp_Lop_Sua(IN p_MaLop VARCHAR(15), IN p_TenLop VARCHAR(100), IN p_MaNganh CHAR(2), IN p_KhoaHoc SMALLINT)
BEGIN
    UPDATE Lop SET TenLop = p_TenLop, MaNganh = p_MaNganh, KhoaHoc = p_KhoaHoc WHERE MaLop = p_MaLop;
END$$

CREATE PROCEDURE sp_Lop_Xoa(IN p_MaLop VARCHAR(15))
BEGIN
    DELETE FROM Lop WHERE MaLop = p_MaLop;
END$$

CREATE PROCEDURE sp_Lop_DemPhuThuoc(IN p_MaLop VARCHAR(15))
BEGIN
    SELECT (SELECT COUNT(*) FROM SinhVien WHERE MaLop = p_MaLop)
         + (SELECT COUNT(*) FROM PhanCong WHERE MaLop = p_MaLop);
END$$

CREATE PROCEDURE sp_HocKy_LayDanhSach(IN p_TuKhoa VARCHAR(50))
BEGIN
    SELECT MaHocKy, TenHocKy FROM HocKy
    WHERE p_TuKhoa = '' OR MaHocKy LIKE CONCAT('%', p_TuKhoa, '%') OR TenHocKy LIKE CONCAT('%', p_TuKhoa, '%')
    ORDER BY MaHocKy DESC;
END$$

CREATE PROCEDURE sp_HocKy_Them(IN p_MaHocKy CHAR(5), IN p_TenHocKy VARCHAR(50))
BEGIN
    INSERT INTO HocKy (MaHocKy, TenHocKy) VALUES (p_MaHocKy, p_TenHocKy);
END$$

CREATE PROCEDURE sp_HocKy_Sua(IN p_MaHocKy CHAR(5), IN p_TenHocKy VARCHAR(50))
BEGIN
    UPDATE HocKy SET TenHocKy = p_TenHocKy WHERE MaHocKy = p_MaHocKy;
END$$

CREATE PROCEDURE sp_HocKy_Xoa(IN p_MaHocKy CHAR(5))
BEGIN
    DELETE FROM HocKy WHERE MaHocKy = p_MaHocKy;
END$$

CREATE PROCEDURE sp_HocKy_DemPhuThuoc(IN p_MaHocKy CHAR(5))
BEGIN
    SELECT (SELECT COUNT(*) FROM PhanCong WHERE MaHocKy = p_MaHocKy)
         + (SELECT COUNT(*) FROM KetQua WHERE MaHocKy = p_MaHocKy);
END$$

CREATE PROCEDURE sp_MonHoc_LayDanhSach(IN p_TuKhoa VARCHAR(100))
BEGIN
    SELECT MaMon, TenMon, SoTinChi FROM MonHoc
    WHERE p_TuKhoa = '' OR MaMon LIKE CONCAT('%', p_TuKhoa, '%') OR TenMon LIKE CONCAT('%', p_TuKhoa, '%')
    ORDER BY MaMon;
END$$

CREATE PROCEDURE sp_MonHoc_Them(IN p_MaMon VARCHAR(10), IN p_TenMon VARCHAR(100), IN p_SoTinChi TINYINT)
BEGIN
    INSERT INTO MonHoc (MaMon, TenMon, SoTinChi) VALUES (p_MaMon, p_TenMon, p_SoTinChi);
END$$

CREATE PROCEDURE sp_MonHoc_Sua(IN p_MaMon VARCHAR(10), IN p_TenMon VARCHAR(100), IN p_SoTinChi TINYINT)
BEGIN
    UPDATE MonHoc SET TenMon = p_TenMon, SoTinChi = p_SoTinChi WHERE MaMon = p_MaMon;
END$$

CREATE PROCEDURE sp_MonHoc_Xoa(IN p_MaMon VARCHAR(10))
BEGIN
    DELETE FROM MonHoc WHERE MaMon = p_MaMon;
END$$

CREATE PROCEDURE sp_MonHoc_DemPhuThuoc(IN p_MaMon VARCHAR(10))
BEGIN
    SELECT (SELECT COUNT(*) FROM KetQua WHERE MaMon = p_MaMon)
         + (SELECT COUNT(*) FROM PhanCong WHERE MaMon = p_MaMon);
END$$

CREATE PROCEDURE sp_GiangVien_LayDanhSach(IN p_TuKhoa VARCHAR(100), IN p_MaKhoa VARCHAR(10))
BEGIN
    SELECT gv.MaGV, gv.HoTen, gv.NgaySinh, gv.GioiTinh, gv.SoDienThoai, gv.Email,
           gv.MaKhoa, k.TenKhoa, gv.TenDangNhap
    FROM GiangVien gv JOIN Khoa k ON k.MaKhoa = gv.MaKhoa
    WHERE (p_MaKhoa = '' OR gv.MaKhoa = p_MaKhoa)
      AND (p_TuKhoa = '' OR gv.MaGV LIKE CONCAT('%', p_TuKhoa, '%') OR gv.HoTen LIKE CONCAT('%', p_TuKhoa, '%'))
    ORDER BY gv.MaGV;
END$$

CREATE PROCEDURE sp_GiangVien_Them(IN p_MaGV VARCHAR(10), IN p_HoTen VARCHAR(50), IN p_NgaySinh DATE,
    IN p_GioiTinh VARCHAR(3), IN p_SoDienThoai CHAR(10), IN p_Email VARCHAR(100), IN p_MaKhoa VARCHAR(10),
    IN p_TenDangNhap VARCHAR(30))
BEGIN
    INSERT INTO GiangVien (MaGV, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, MaKhoa, TenDangNhap)
    VALUES (p_MaGV, p_HoTen, p_NgaySinh, p_GioiTinh, p_SoDienThoai, p_Email, p_MaKhoa, NULLIF(p_TenDangNhap, ''));
END$$

CREATE PROCEDURE sp_GiangVien_Sua(IN p_MaGV VARCHAR(10), IN p_HoTen VARCHAR(50), IN p_NgaySinh DATE,
    IN p_GioiTinh VARCHAR(3), IN p_SoDienThoai CHAR(10), IN p_Email VARCHAR(100), IN p_MaKhoa VARCHAR(10),
    IN p_TenDangNhap VARCHAR(30))
BEGIN
    UPDATE GiangVien
    SET HoTen = p_HoTen, NgaySinh = p_NgaySinh, GioiTinh = p_GioiTinh, SoDienThoai = p_SoDienThoai,
        Email = p_Email, MaKhoa = p_MaKhoa, TenDangNhap = NULLIF(p_TenDangNhap, '')
    WHERE MaGV = p_MaGV;
END$$

CREATE PROCEDURE sp_GiangVien_Xoa(IN p_MaGV VARCHAR(10))
BEGIN
    DELETE FROM GiangVien WHERE MaGV = p_MaGV;
END$$

CREATE PROCEDURE sp_GiangVien_DemPhuThuoc(IN p_MaGV VARCHAR(10))
BEGIN
    SELECT COUNT(*) FROM PhanCong WHERE MaGV = p_MaGV;
END$$

CREATE PROCEDURE sp_SinhVien_LayDanhSach(IN p_TuKhoa VARCHAR(100), IN p_MaLop VARCHAR(15))
BEGIN
    SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.SoDienThoai, sv.MaLop, l.TenLop
    FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop
    WHERE (p_MaLop = '' OR sv.MaLop = p_MaLop)
      AND (p_TuKhoa = '' OR sv.MaSV LIKE CONCAT('%', p_TuKhoa, '%') OR sv.HoTen LIKE CONCAT('%', p_TuKhoa, '%'))
    ORDER BY sv.MaSV;
END$$

CREATE PROCEDURE sp_SinhVien_SinhMa(IN p_MaLop VARCHAR(15))
BEGIN
    DECLARE v_TienTo CHAR(6);
    DECLARE v_SoCuoi INT;
    SELECT CONCAT('BM', RIGHT(KhoaHoc, 2), MaNganh) INTO v_TienTo FROM Lop WHERE MaLop = p_MaLop;
    SELECT IFNULL(MAX(CAST(RIGHT(MaSV, 3) AS UNSIGNED)), 0) INTO v_SoCuoi
    FROM SinhVien WHERE MaSV LIKE CONCAT(v_TienTo, '%');
    SELECT CONCAT(v_TienTo, LPAD(v_SoCuoi + 1, 3, '0')) AS MaSV;
END$$

CREATE PROCEDURE sp_SinhVien_Them(IN p_MaSV CHAR(9), IN p_HoTen VARCHAR(50), IN p_NgaySinh DATE,
    IN p_GioiTinh VARCHAR(3), IN p_SoDienThoai CHAR(10), IN p_MaLop VARCHAR(15))
BEGIN
    INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, SoDienThoai, MaLop)
    VALUES (p_MaSV, p_HoTen, p_NgaySinh, p_GioiTinh, p_SoDienThoai, p_MaLop);
END$$

CREATE PROCEDURE sp_SinhVien_Sua(IN p_MaSV CHAR(9), IN p_HoTen VARCHAR(50), IN p_NgaySinh DATE,
    IN p_GioiTinh VARCHAR(3), IN p_SoDienThoai CHAR(10), IN p_MaLop VARCHAR(15))
BEGIN
    UPDATE SinhVien
    SET HoTen = p_HoTen, NgaySinh = p_NgaySinh, GioiTinh = p_GioiTinh, SoDienThoai = p_SoDienThoai, MaLop = p_MaLop
    WHERE MaSV = p_MaSV;
END$$

CREATE PROCEDURE sp_SinhVien_Xoa(IN p_MaSV CHAR(9))
BEGIN
    DELETE FROM KetQua WHERE MaSV = p_MaSV AND DiemCC IS NULL AND DiemGK IS NULL AND DiemKTHP IS NULL;
    DELETE FROM SinhVien WHERE MaSV = p_MaSV;
END$$

CREATE PROCEDURE sp_SinhVien_DemDiem(IN p_MaSV CHAR(9))
BEGIN
    SELECT COUNT(*) FROM KetQua
    WHERE MaSV = p_MaSV AND (DiemCC IS NOT NULL OR DiemGK IS NOT NULL OR DiemKTHP IS NOT NULL);
END$$

CREATE PROCEDURE sp_SinhVien_LayMaLop(IN p_MaSV CHAR(9))
BEGIN
    SELECT MaLop FROM SinhVien WHERE MaSV = p_MaSV;
END$$

CREATE PROCEDURE sp_XepMon_TheoLop(IN p_MaLop VARCHAR(15), IN p_MaMon VARCHAR(10), IN p_MaHocKy CHAR(5))
BEGIN
    INSERT INTO KetQua (MaSV, MaMon, MaHocKy)
    SELECT sv.MaSV, p_MaMon, p_MaHocKy
    FROM SinhVien sv
    WHERE sv.MaLop = p_MaLop
      AND NOT EXISTS (SELECT 1 FROM KetQua kq
                      WHERE kq.MaSV = sv.MaSV AND kq.MaMon = p_MaMon AND kq.MaHocKy = p_MaHocKy);
    SELECT ROW_COUNT() AS SoDongThem;
END$$

CREATE PROCEDURE sp_XepMon_LayDanhSach(IN p_MaLop VARCHAR(15), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT mh.MaMon, mh.TenMon, mh.SoTinChi, COUNT(*) AS SoSinhVien, gv.HoTen AS GiangVien
    FROM KetQua kq
    JOIN SinhVien sv ON sv.MaSV = kq.MaSV
    JOIN MonHoc mh ON mh.MaMon = kq.MaMon
    LEFT JOIN PhanCong pc ON pc.MaLop = sv.MaLop AND pc.MaMon = kq.MaMon AND pc.MaHocKy = kq.MaHocKy
    LEFT JOIN GiangVien gv ON gv.MaGV = pc.MaGV
    WHERE sv.MaLop = p_MaLop AND kq.MaHocKy = p_MaHocKy
    GROUP BY mh.MaMon, mh.TenMon, mh.SoTinChi, gv.HoTen
    ORDER BY mh.MaMon;
END$$

CREATE PROCEDURE sp_XepMon_TongTinChi(IN p_MaLop VARCHAR(15), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT sv.MaSV, sv.HoTen, IFNULL(SUM(mh.SoTinChi), 0) AS TongTinChi
    FROM SinhVien sv
    LEFT JOIN KetQua kq ON kq.MaSV = sv.MaSV AND kq.MaHocKy = p_MaHocKy
    LEFT JOIN MonHoc mh ON mh.MaMon = kq.MaMon
    WHERE sv.MaLop = p_MaLop
    GROUP BY sv.MaSV, sv.HoTen
    ORDER BY sv.MaSV;
END$$

CREATE PROCEDURE sp_PhanCong_LayDanhSach(IN p_MaLop VARCHAR(15), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT pc.MaLop, pc.MaMon, mh.TenMon, pc.MaHocKy, pc.MaGV, gv.HoTen AS TenGiangVien
    FROM PhanCong pc
    JOIN MonHoc mh ON mh.MaMon = pc.MaMon
    JOIN GiangVien gv ON gv.MaGV = pc.MaGV
    WHERE pc.MaLop = p_MaLop AND pc.MaHocKy = p_MaHocKy
    ORDER BY pc.MaMon;
END$$

CREATE PROCEDURE sp_PhanCong_DemDaXepMon(IN p_MaLop VARCHAR(15), IN p_MaMon VARCHAR(10), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT COUNT(*) FROM KetQua kq JOIN SinhVien sv ON sv.MaSV = kq.MaSV
    WHERE sv.MaLop = p_MaLop AND kq.MaMon = p_MaMon AND kq.MaHocKy = p_MaHocKy;
END$$

CREATE PROCEDURE sp_PhanCong_Luu(IN p_MaLop VARCHAR(15), IN p_MaMon VARCHAR(10), IN p_MaHocKy CHAR(5), IN p_MaGV VARCHAR(10))
BEGIN
    INSERT INTO PhanCong (MaLop, MaMon, MaHocKy, MaGV)
    VALUES (p_MaLop, p_MaMon, p_MaHocKy, p_MaGV)
    ON DUPLICATE KEY UPDATE MaGV = p_MaGV;
END$$

CREATE PROCEDURE sp_PhanCong_LayCuaGiangVien(IN p_MaGV VARCHAR(10), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT pc.MaLop, l.TenLop, pc.MaMon, mh.TenMon, pc.MaHocKy,
           CONCAT(pc.MaLop, ' - ', mh.TenMon) AS HienThi
    FROM PhanCong pc
    JOIN Lop l ON l.MaLop = pc.MaLop
    JOIN MonHoc mh ON mh.MaMon = pc.MaMon
    WHERE pc.MaGV = p_MaGV AND pc.MaHocKy = p_MaHocKy
    ORDER BY pc.MaLop, pc.MaMon;
END$$

CREATE PROCEDURE sp_KetQua_LayTheoLopMon(IN p_MaLop VARCHAR(15), IN p_MaMon VARCHAR(10), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT kq.MaSV, sv.HoTen, kq.DiemCC, kq.DiemGK, kq.DiemKTHP, kq.DiemHP, kq.DiemChu, kq.DiemHe4
    FROM KetQua kq JOIN SinhVien sv ON sv.MaSV = kq.MaSV
    WHERE sv.MaLop = p_MaLop AND kq.MaMon = p_MaMon AND kq.MaHocKy = p_MaHocKy
    ORDER BY kq.MaSV;
END$$

CREATE PROCEDURE sp_KetQua_CapNhat(IN p_MaSV CHAR(9), IN p_MaMon VARCHAR(10), IN p_MaHocKy CHAR(5),
    IN p_DiemCC DECIMAL(3,1), IN p_DiemGK DECIMAL(3,1), IN p_DiemKTHP DECIMAL(3,1),
    IN p_DiemHP DECIMAL(3,1), IN p_DiemChu CHAR(1), IN p_DiemHe4 DECIMAL(2,1))
BEGIN
    UPDATE KetQua
    SET DiemCC = p_DiemCC, DiemGK = p_DiemGK, DiemKTHP = p_DiemKTHP,
        DiemHP = p_DiemHP, DiemChu = p_DiemChu, DiemHe4 = p_DiemHe4
    WHERE MaSV = p_MaSV AND MaMon = p_MaMon AND MaHocKy = p_MaHocKy;
END$$

CREATE PROCEDURE sp_KetQua_LayTheoSinhVien(IN p_MaSV CHAR(9))
BEGIN
    SELECT kq.MaHocKy, hk.TenHocKy, kq.MaMon, mh.TenMon, mh.SoTinChi,
           kq.DiemCC, kq.DiemGK, kq.DiemKTHP, kq.DiemHP, kq.DiemChu, kq.DiemHe4
    FROM KetQua kq
    JOIN MonHoc mh ON mh.MaMon = kq.MaMon
    JOIN HocKy hk ON hk.MaHocKy = kq.MaHocKy
    WHERE kq.MaSV = p_MaSV
    ORDER BY kq.MaHocKy, kq.MaMon;
END$$

CREATE PROCEDURE sp_KetQua_LayTheoLopHocKy(IN p_MaLop VARCHAR(15), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT sv.MaSV, sv.HoTen, mh.SoTinChi, kq.DiemHe4
    FROM SinhVien sv
    JOIN KetQua kq ON kq.MaSV = sv.MaSV AND kq.MaHocKy = p_MaHocKy
    JOIN MonHoc mh ON mh.MaMon = kq.MaMon
    WHERE sv.MaLop = p_MaLop
    ORDER BY sv.MaSV;
END$$

CREATE PROCEDURE sp_TK_SinhVienDiemCaoNhat(IN p_MaLop VARCHAR(15), IN p_MaHocKy CHAR(5), IN p_SoLuong INT)
BEGIN
    SELECT sv.MaSV, sv.HoTen,
           ROUND(SUM(kq.DiemHe4 * mh.SoTinChi) / SUM(mh.SoTinChi), 2) AS DiemTBHe4,
           SUM(mh.SoTinChi) AS SoTinChi
    FROM SinhVien sv
    JOIN KetQua kq ON kq.MaSV = sv.MaSV AND kq.MaHocKy = p_MaHocKy AND kq.DiemHe4 IS NOT NULL
    JOIN MonHoc mh ON mh.MaMon = kq.MaMon
    WHERE sv.MaLop = p_MaLop
    GROUP BY sv.MaSV, sv.HoTen
    ORDER BY DiemTBHe4 DESC, sv.MaSV
    LIMIT p_SoLuong;
END$$

CREATE PROCEDURE sp_TK_MonTiLeTruotCaoNhat(IN p_MaHocKy CHAR(5), IN p_SoLuong INT)
BEGIN
    SELECT mh.MaMon, mh.TenMon,
           COUNT(*) AS SoDuThi,
           SUM(kq.DiemChu = 'F') AS SoTruot,
           ROUND(100 * SUM(kq.DiemChu = 'F') / COUNT(*), 1) AS TiLeTruot
    FROM KetQua kq JOIN MonHoc mh ON mh.MaMon = kq.MaMon
    WHERE kq.MaHocKy = p_MaHocKy AND kq.DiemChu IS NOT NULL
    GROUP BY mh.MaMon, mh.TenMon
    ORDER BY TiLeTruot DESC, mh.MaMon
    LIMIT p_SoLuong;
END$$

CREATE PROCEDURE sp_TK_QuyMoTheoKhoa()
BEGIN
    SELECT k.MaKhoa, k.TenKhoa,
           (SELECT COUNT(*) FROM Nganh n WHERE n.MaKhoa = k.MaKhoa) AS SoNganh,
           (SELECT COUNT(*) FROM Lop l JOIN Nganh n ON n.MaNganh = l.MaNganh WHERE n.MaKhoa = k.MaKhoa) AS SoLop,
           (SELECT COUNT(*) FROM SinhVien sv JOIN Lop l ON l.MaLop = sv.MaLop
                JOIN Nganh n ON n.MaNganh = l.MaNganh WHERE n.MaKhoa = k.MaKhoa) AS SoSinhVien,
           (SELECT COUNT(*) FROM GiangVien gv WHERE gv.MaKhoa = k.MaKhoa) AS SoGiangVien
    FROM Khoa k
    ORDER BY k.MaKhoa;
END$$

CREATE PROCEDURE sp_BaoCao_DanhSachSinhVien(IN p_MaLop VARCHAR(15))
BEGIN
    SELECT * FROM v_SinhVienReport WHERE MaLop = p_MaLop ORDER BY MaSV;
END$$

CREATE PROCEDURE sp_BaoCao_BangDiemLopMon(IN p_MaLop VARCHAR(15), IN p_MaMon VARCHAR(10), IN p_MaHocKy CHAR(5))
BEGIN
    SELECT * FROM v_BangDiemReport
    WHERE MaLop = p_MaLop AND MaMon = p_MaMon AND MaHocKy = p_MaHocKy
    ORDER BY MaSV;
END$$

CREATE PROCEDURE sp_BaoCao_BangDiemSinhVien(IN p_MaSV CHAR(9))
BEGIN
    SELECT * FROM v_BangDiemReport WHERE MaSV = p_MaSV ORDER BY MaHocKy, MaMon;
END$$

DELIMITER ;


SET SESSION cte_max_recursion_depth = 5000;

INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES
('CNTT', 'Khoa Công nghệ thông tin'),
('KT',   'Khoa Kinh tế'),
('CK',   'Khoa Cơ khí - Ô tô'),
('DDT',  'Khoa Điện - Điện tử'),
('XD',   'Khoa Xây dựng'),
('NN',   'Khoa Ngoại ngữ'),
('YD',   'Khoa Y dược'),
('DL',   'Khoa Du lịch');

INSERT INTO Nganh (MaNganh, TenNganh, MaKhoa) VALUES
('01', 'Công nghệ thông tin', 'CNTT'),
('02', 'Khoa học máy tính', 'CNTT'),
('03', 'Hệ thống thông tin', 'CNTT'),
('04', 'Kỹ thuật phần mềm', 'CNTT'),
('05', 'Kế toán', 'KT'),
('06', 'Quản trị kinh doanh', 'KT'),
('07', 'Tài chính - Ngân hàng', 'KT'),
('08', 'Marketing', 'KT'),
('09', 'Công nghệ kỹ thuật cơ khí', 'CK'),
('10', 'Công nghệ kỹ thuật ô tô', 'CK'),
('11', 'Công nghệ kỹ thuật điện, điện tử', 'DDT'),
('12', 'Công nghệ kỹ thuật điều khiển và tự động hóa', 'DDT'),
('13', 'Kỹ thuật xây dựng', 'XD'),
('14', 'Kiến trúc', 'XD'),
('15', 'Ngôn ngữ Anh', 'NN'),
('16', 'Ngôn ngữ Trung Quốc', 'NN'),
('17', 'Dược học', 'YD'),
('18', 'Điều dưỡng', 'YD'),
('19', 'Quản trị dịch vụ du lịch và lữ hành', 'DL'),
('20', 'Quản trị khách sạn', 'DL');

INSERT INTO HocKy (MaHocKy, TenHocKy)
WITH RECURSIVE Nam (N) AS (SELECT 2022 UNION ALL SELECT N + 1 FROM Nam WHERE N < 2026)
SELECT CONCAT(N, k.Ky), CONCAT('Học kỳ ', k.Ky, ' năm học ', N, '-', N + 1)
FROM Nam CROSS JOIN (SELECT 1 AS Ky UNION ALL SELECT 2) k;

INSERT INTO MonHoc (MaMon, TenMon, SoTinChi) VALUES
('GD01', 'Triết học Mác - Lênin', 3),
('GD02', 'Kinh tế chính trị Mác - Lênin', 2),
('GD03', 'Chủ nghĩa xã hội khoa học', 2),
('GD04', 'Tư tưởng Hồ Chí Minh', 2),
('GD05', 'Pháp luật đại cương', 2),
('GD06', 'Toán cao cấp', 3),
('GD07', 'Xác suất thống kê', 3),
('GD08', 'Tiếng Anh 1', 3),
('GD09', 'Tiếng Anh 2', 3),
('GD10', 'Tin học đại cương', 3),
('IT2201', 'Lập trình hướng đối tượng', 3),
('IT2202', 'Cơ sở dữ liệu', 3),
('IT2203', 'Cấu trúc dữ liệu và giải thuật', 3),
('IT2204', 'Mạng máy tính', 3),
('IT2205', 'Hệ điều hành', 3),
('IT3210', 'Phân tích thiết kế hệ thống', 3),
('IT3211', 'Lập trình Web', 3),
('IT3212', 'Lập trình .NET', 4),
('IT3213', 'Kiểm thử phần mềm', 3),
('IT3214', 'Trí tuệ nhân tạo', 3);

INSERT INTO MonHoc (MaMon, TenMon, SoTinChi)
SELECT CONCAT('CN', n.MaNganh, m.So),
       CONCAT(m.TienTo, ' ', n.TenNganh, m.HauTo),
       m.TinChi
FROM Nganh n
CROSS JOIN (SELECT '1' AS So, 'Nhập môn' AS TienTo, '' AS HauTo, 2 AS TinChi
            UNION ALL SELECT '2', 'Cơ sở', '', 3
            UNION ALL SELECT '3', 'Chuyên đề', ' 1', 3
            UNION ALL SELECT '4', 'Chuyên đề', ' 2', 3
            UNION ALL SELECT '5', 'Thực tập', '', 4) m;

INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai) VALUES
('admin',  SHA2('123456', 256), 'Quản trị hệ thống', 'Admin', 1),
('cbdt01', SHA2('123456', 256), 'Nguyễn Thị Hương', 'CanBoDaoTao', 1),
('cbdt02', SHA2('123456', 256), 'Trần Văn Nam', 'CanBoDaoTao', 1),
('cbdt03', SHA2('123456', 256), 'Lê Thị Mai', 'CanBoDaoTao', 1),
('cbdt04', SHA2('123456', 256), 'Phạm Minh Đức', 'CanBoDaoTao', 0);

CREATE TEMPORARY TABLE tmpHo (i INT PRIMARY KEY, Ho VARCHAR(20));
INSERT INTO tmpHo VALUES (0,'Nguyễn'),(1,'Trần'),(2,'Lê'),(3,'Phạm'),(4,'Hoàng'),(5,'Huỳnh'),(6,'Phan'),
  (7,'Vũ'),(8,'Võ'),(9,'Đặng'),(10,'Bùi'),(11,'Đỗ'),(12,'Hồ'),(13,'Ngô'),(14,'Dương');

CREATE TEMPORARY TABLE tmpTenNam (i INT PRIMARY KEY, Dem VARCHAR(20), Ten VARCHAR(20));
INSERT INTO tmpTenNam VALUES (0,'Văn','An'),(1,'Minh','Bình'),(2,'Đức','Cường'),(3,'Quang','Dũng'),
  (4,'Hữu','Đạt'),(5,'Tuấn','Hải'),(6,'Thành','Hiếu'),(7,'Gia','Huy'),(8,'Anh','Khoa'),(9,'Trung','Kiên'),
  (10,'Hoàng','Long'),(11,'Văn','Mạnh'),(12,'Đình','Nam'),(13,'Minh','Phúc'),(14,'Xuân','Quân');

CREATE TEMPORARY TABLE tmpTenNu (i INT PRIMARY KEY, Dem VARCHAR(20), Ten VARCHAR(20));
INSERT INTO tmpTenNu VALUES (0,'Thị','Anh'),(1,'Ngọc','Ánh'),(2,'Thu','Hà'),(3,'Thị','Hằng'),
  (4,'Thanh','Hương'),(5,'Khánh','Linh'),(6,'Thị','Lan'),(7,'Phương','Mai'),(8,'Bảo','Ngọc'),(9,'Hồng','Nhung'),
  (10,'Minh','Phương'),(11,'Thu','Thảo'),(12,'Thanh','Thủy'),(13,'Huyền','Trang'),(14,'Hải','Yến');

CREATE TEMPORARY TABLE tmpGV AS
WITH RECURSIVE So (N) AS (SELECT 0 UNION ALL SELECT N + 1 FROM So WHERE N < 14),
DsKhoa AS (SELECT MaKhoa, ROW_NUMBER() OVER (ORDER BY MaKhoa) - 1 AS STT FROM Khoa)
SELECT CONCAT('GV', LPAD(k.STT * 15 + s.N + 1, 3, '0')) AS MaGV,
       k.MaKhoa, k.STT * 15 + s.N AS ChiSo
FROM DsKhoa k CROSS JOIN So s;

INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai)
SELECT LOWER(g.MaGV), SHA2('123456', 256),
       CASE WHEN g.ChiSo % 2 = 0
            THEN CONCAT(h.Ho, ' ', nam.Dem, ' ', nam.Ten)
            ELSE CONCAT(h.Ho, ' ', nu.Dem, ' ', nu.Ten) END,
       'GiangVien', 1
FROM tmpGV g
JOIN tmpHo h ON h.i = (g.ChiSo * 7) % 15
JOIN tmpTenNam nam ON nam.i = (g.ChiSo * 4 + 3) % 15
JOIN tmpTenNu nu ON nu.i = (g.ChiSo * 4 + 3) % 15;

INSERT INTO GiangVien (MaGV, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, MaKhoa, TenDangNhap)
SELECT g.MaGV, nd.HoTen,
       DATE_ADD('1970-01-01', INTERVAL (g.ChiSo * 97) % 9000 DAY),
       CASE WHEN g.ChiSo % 2 = 0 THEN 'Nam' ELSE 'Nữ' END,
       CONCAT('098', LPAD(1000000 + g.ChiSo * 3571, 7, '0')),
       CONCAT(LOWER(g.MaGV), '@eaut.edu.vn'),
       g.MaKhoa, LOWER(g.MaGV)
FROM tmpGV g JOIN NguoiDung nd ON nd.TenDangNhap = LOWER(g.MaGV);

INSERT INTO Lop (MaLop, TenLop, MaNganh, KhoaHoc)
WITH RECURSIVE Nam (N) AS (SELECT 2022 UNION ALL SELECT N + 1 FROM Nam WHERE N < 2026)
SELECT CONCAT('DH', RIGHT(Nam.N, 2), n.MaNganh), CONCAT(n.TenNganh, ' K', RIGHT(Nam.N, 2)), n.MaNganh, Nam.N
FROM Nganh n CROSS JOIN Nam;

INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, SoDienThoai, MaLop)
WITH RECURSIVE So (N) AS (SELECT 1 UNION ALL SELECT N + 1 FROM So WHERE N < 10),
DsLop AS (SELECT MaLop, MaNganh, KhoaHoc, ROW_NUMBER() OVER (ORDER BY MaLop) - 1 AS STT FROM Lop),
Nguon AS (SELECT l.MaLop, l.MaNganh, l.KhoaHoc, s.N, l.STT * 10 + s.N AS ChiSo FROM DsLop l CROSS JOIN So s)
SELECT CONCAT('BM', RIGHT(x.KhoaHoc, 2), x.MaNganh, LPAD(x.N, 3, '0')),
       CASE WHEN x.ChiSo % 2 = 0
            THEN CONCAT(h.Ho, ' ', nam.Dem, ' ', nam.Ten)
            ELSE CONCAT(h.Ho, ' ', nu.Dem, ' ', nu.Ten) END,
       DATE_ADD(CONCAT(x.KhoaHoc - 18, '-01-01'), INTERVAL (x.ChiSo * 37) % 365 DAY),
       CASE WHEN x.ChiSo % 2 = 0 THEN 'Nam' ELSE 'Nữ' END,
       CONCAT('03', LPAD(10000000 + x.ChiSo * 7919, 8, '0')),
       x.MaLop
FROM Nguon x
JOIN tmpHo h ON h.i = (x.ChiSo * 11) % 15
JOIN tmpTenNam nam ON nam.i = (x.ChiSo * 13 + 5) % 15
JOIN tmpTenNu nu ON nu.i = (x.ChiSo * 13 + 5) % 15;

CREATE TEMPORARY TABLE tmpMonCuaNganh (MaNganh CHAR(2), ViTri INT, MaMon VARCHAR(10), PRIMARY KEY (MaNganh, ViTri));
INSERT INTO tmpMonCuaNganh
SELECT n.MaNganh, CAST(RIGHT(m.MaMon, 2) AS UNSIGNED) - 1, m.MaMon
FROM Nganh n CROSS JOIN MonHoc m WHERE m.MaMon LIKE 'GD%';
INSERT INTO tmpMonCuaNganh
SELECT n.MaNganh, 9 + CAST(RIGHT(m.MaMon, 1) AS UNSIGNED), m.MaMon
FROM Nganh n JOIN MonHoc m ON m.MaMon LIKE CONCAT('CN', n.MaNganh, '_')
WHERE n.MaNganh <> '01';
INSERT INTO tmpMonCuaNganh VALUES
('01', 10, 'IT2202'), ('01', 11, 'IT3212'), ('01', 12, 'IT2201'), ('01', 13, 'IT3211'), ('01', 14, 'IT3210');

CREATE TEMPORARY TABLE tmpLopHocKy AS
SELECT l.MaLop, l.MaNganh, hk.MaHocKy,
       CASE hk.MaHocKy WHEN '20251' THEN 0 WHEN '20252' THEN 1 ELSE 2 END AS ThuTu,
       ROW_NUMBER() OVER (PARTITION BY hk.MaHocKy ORDER BY l.MaLop) AS STTLop
FROM Lop l JOIN HocKy hk ON hk.MaHocKy IN ('20251', '20252', '20261')
WHERE l.KhoaHoc <= 2025 OR hk.MaHocKy = '20261';

CREATE TEMPORARY TABLE tmpLopMon AS
SELECT lh.MaLop, lh.MaNganh, lh.MaHocKy, lh.STTLop, mc.MaMon, j.J
FROM tmpLopHocKy lh
CROSS JOIN (SELECT 0 AS J UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3) j
JOIN tmpMonCuaNganh mc ON mc.MaNganh = lh.MaNganh AND mc.ViTri = lh.ThuTu * 4 + j.J;

INSERT INTO PhanCong (MaLop, MaMon, MaHocKy, MaGV)
SELECT lm.MaLop, lm.MaMon, lm.MaHocKy,
       (SELECT g.MaGV FROM tmpGV g JOIN Nganh n ON n.MaKhoa = g.MaKhoa
        WHERE n.MaNganh = lm.MaNganh
        ORDER BY g.MaGV LIMIT 1 OFFSET 0) AS MaGV
FROM tmpLopMon lm WHERE lm.J = 0;

INSERT INTO PhanCong (MaLop, MaMon, MaHocKy, MaGV)
SELECT lm.MaLop, lm.MaMon, lm.MaHocKy,
       CONCAT('GV', LPAD(k.STTKhoa * 15 + 1 + (lm.STTLop + lm.J) % 15, 3, '0'))
FROM tmpLopMon lm
JOIN Nganh n ON n.MaNganh = lm.MaNganh
JOIN (SELECT MaKhoa, ROW_NUMBER() OVER (ORDER BY MaKhoa) - 1 AS STTKhoa FROM Khoa) k ON k.MaKhoa = n.MaKhoa
WHERE lm.J > 0;

INSERT INTO KetQua (MaSV, MaMon, MaHocKy, DiemCC, DiemGK, DiemKTHP)
SELECT sv.MaSV, lm.MaMon, lm.MaHocKy,
       LEAST(10, 6 + (CRC32(CONCAT(sv.MaSV, lm.MaMon)) % 31) / 10 + (CRC32(sv.MaSV) % 11) / 10),
       LEAST(10, 3.5 + ((CRC32(CONCAT(sv.MaSV, lm.MaMon)) DIV 7) % 46) / 10 + (CRC32(sv.MaSV) % 31) / 10),
       CASE WHEN lm.MaHocKy = '20261' AND sv.MaLop LIKE 'DH26%' THEN NULL
            ELSE LEAST(10, 2 + ((CRC32(CONCAT(sv.MaSV, lm.MaMon)) DIV 13) % 56) / 10 + (CRC32(sv.MaSV) % 31) / 10) END
FROM tmpLopMon lm JOIN SinhVien sv ON sv.MaLop = lm.MaLop;

UPDATE KetQua
SET DiemHP = ROUND(DiemCC * 0.1 + DiemGK * 0.3 + DiemKTHP * 0.6, 1)
WHERE DiemCC IS NOT NULL AND DiemGK IS NOT NULL AND DiemKTHP IS NOT NULL;

UPDATE KetQua
SET DiemChu = CASE WHEN DiemHP >= 8.5 THEN 'A' WHEN DiemHP >= 7.0 THEN 'B'
                   WHEN DiemHP >= 5.5 THEN 'C' WHEN DiemHP >= 4.0 THEN 'D' ELSE 'F' END,
    DiemHe4 = CASE WHEN DiemHP >= 8.5 THEN 4 WHEN DiemHP >= 7.0 THEN 3
                   WHEN DiemHP >= 5.5 THEN 2 WHEN DiemHP >= 4.0 THEN 1 ELSE 0 END
WHERE DiemHP IS NOT NULL;

DROP TEMPORARY TABLE tmpHo, tmpTenNam, tmpTenNu, tmpGV, tmpMonCuaNganh, tmpLopHocKy, tmpLopMon;

SELECT 'NguoiDung' AS Bang, COUNT(*) AS SoBanGhi FROM NguoiDung
UNION ALL SELECT 'Khoa', COUNT(*) FROM Khoa
UNION ALL SELECT 'Nganh', COUNT(*) FROM Nganh
UNION ALL SELECT 'GiangVien', COUNT(*) FROM GiangVien
UNION ALL SELECT 'Lop', COUNT(*) FROM Lop
UNION ALL SELECT 'SinhVien', COUNT(*) FROM SinhVien
UNION ALL SELECT 'HocKy', COUNT(*) FROM HocKy
UNION ALL SELECT 'MonHoc', COUNT(*) FROM MonHoc
UNION ALL SELECT 'PhanCong', COUNT(*) FROM PhanCong
UNION ALL SELECT 'KetQua', COUNT(*) FROM KetQua;

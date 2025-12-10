--================================================================================
-- FILE 1: 01_Tables_Schema.sql
-- [BÁO CÁO CUỐI KỲ] HỆ THỐNG QUẢN LÝ RESORT - SCHEMA (BẢNG VÀ RÀNG BUỘC)
-- Mục đích: Tạo database và tất cả các bảng với constraints (PK, FK, CHECK)
-- Lưu ý: Chạy file này ĐẦU TIÊN
--================================================================================

--================================================================================
-- [BÁO CÁO CUỐI KỲ] HỆ THỐNG QUẢN LÝ RESORT - DATABASE SCHEMA VÀ CÁC RÀNG BUỘC
-- Mục đích: Thiết lập nền tảng database cho ứng dụng WinForms QLResort
-- Ghi chú: Sử dụng Soft Delete (IsActive) cho hầu hết các bảng.
-- Thứ tự đã được tối ưu để chạy liền mạch (F5)
--================================================================================
GO

-- 1. XÓA DATABASE CŨ (Cho môi trường phát triển/test)
CREATE DATABASE QLR;
GO
USE QLR;
GO

set dateformat dmy
go

--- 3. BƯỚC 1: KHỞI TẠO TẤT CẢ CÁC BẢNG (Entities) VÀ KHÓA CHÍNH (PK)
-- Việc tạo PK ngay trong lệnh CREATE TABLE giúp code sạch và dễ đọc hơn.
-----------------------------------------------------------------------------------------------------------------------

CREATE TABLE LoaiNhanVien (
    MaLoaiNV NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenLoaiNV NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    UpdatedBy NVARCHAR(20) NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE ChiNhanh (
    MaCN NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenCN NVARCHAR(200) NULL,
    DiaChi NVARCHAR(300) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    MaQuanLy NVARCHAR(20) NULL, -- Mã NV quản lý chi nhánh (FK sẽ gán sau)
    UpdatedBy NVARCHAR(20) NULL,
    IsActive BIT NOT NULL DEFAULT 1 -- Cột Soft Delete
);
GO

CREATE TABLE LoaiKhachHang (
    MaLKH NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenLKH NVARCHAR(100) NOT NULL,
    GiamGiaPercent DECIMAL(5,2) NOT NULL DEFAULT 0,
    DiemToiThieu INT NOT NULL DEFAULT 0, -- Điều kiện để đạt loại này
    MoTa NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    UpdatedBy NVARCHAR(20) NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
GO

-- Bảng NhanVien phải được tạo trước để các bảng khác có thể tham chiếu
CREATE TABLE NhanVien (
    MaNV NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaCN NVARCHAR(20) NOT NULL,
    CCCD NVARCHAR(20) NOT NULL UNIQUE, -- Đặt UNIQUE ở đây
    GioiTinh NVARCHAR(10) NULL,
    HoTen NVARCHAR(200) NULL,
    ChucVu NVARCHAR(100) NULL,
    SDT NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL,
    MaLoaiNV NVARCHAR(20) NULL,
    DuongDanAnh NVARCHAR(500) NULL, -- Đường dẫn ảnh nhân viên
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    UpdatedBy NVARCHAR(20) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_NhanVien_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN),
    CONSTRAINT FK_NhanVien_LoaiNV FOREIGN KEY (MaLoaiNV) REFERENCES LoaiNhanVien(MaLoaiNV)
);
GO

CREATE TABLE LoaiPhong (
    MaLP NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenLP NVARCHAR(100),
    MoTa NVARCHAR(500),
    IsNhaNguyenCan BIT DEFAULT 0, -- Check xem là Phòng thường (0) hay Nhà nguyên căn (1)
    SoPhongTrongNha INT,
    GiaTheoGio DECIMAL(18,2),
    GiaTheoNgay DECIMAL(18,2),
    GiaTheoThang DECIMAL(18,2),
    SucChuaToiDa INT,
    IsActive BIT DEFAULT 1,
    CreatedBy NVARCHAR(20),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(20),
    UpdatedAt DATETIME2
);
GO

CREATE TABLE Phong (
    MaPhong NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaCN NVARCHAR(20) NOT NULL,
    MaLP NVARCHAR(20) NOT NULL,
    SoPhong NVARCHAR(50), -- Số hoặc tên phòng (A101, B205,...)
    ViTri NVARCHAR(100),
    TrangThai NVARCHAR(20) DEFAULT N'Trống',
    GhiChu NVARCHAR(500),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20),
    UpdatedBy NVARCHAR(20),
    UpdatedAt DATETIME2,
    IsActive BIT DEFAULT 1,
    CONSTRAINT UQ_Phong_SoPhong UNIQUE (MaCN, SoPhong),
    CONSTRAINT FK_Phong_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN),
    CONSTRAINT FK_Phong_LP FOREIGN KEY (MaLP) REFERENCES LoaiPhong(MaLP)
);
GO

CREATE TABLE KhachHang (
    MaKH NVARCHAR(20) NOT NULL PRIMARY KEY,
    HoTen NVARCHAR(200) NULL,
    GioiTinh NVARCHAR(10) NULL,
    NgaySinh DATE NULL,
    SDT NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL,
    IDType NVARCHAR(20) NOT NULL DEFAULT N'CCCD',
    IDNumber NVARCHAR(50) NOT NULL UNIQUE, -- Số CCCD/Passport (Đặt UNIQUE ở đây)
    DiaChi NVARCHAR(300) NULL,
    MaLKH NVARCHAR(20) NOT NULL, -- Khóa ngoại đến LoaiKhachHang
    CreatedBy NVARCHAR(20) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_KhachHang_LoaiKH FOREIGN KEY (MaLKH) REFERENCES LoaiKhachHang(MaLKH)
);
GO

CREATE TABLE TaiKhoan (
    MaTK NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaNV NVARCHAR(20) NOT NULL UNIQUE, -- Liên kết 1-1 với nhân viên (Đặt UNIQUE ở đây)
    TenDangNhap NVARCHAR(100) NOT NULL UNIQUE, -- Đặt UNIQUE ở đây
    MatKhau NVARCHAR(100) NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT N'NhanVien', -- NhanVien, QuanLy, Admin
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_TaiKhoan_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT CK_TaiKhoan_Role CHECK (Role IN (N'NhanVien', N'Admin', N'QuanLy'))
);
GO

CREATE TABLE DichVu (
    MaDV NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenDV NVARCHAR(200) NULL,
    LoaiDV NVARCHAR(50) NULL,
    MoTa NVARCHAR(500) NULL,
    Gia DECIMAL(10,2) NULL,
    ChoPhepDoiDiem BIT NOT NULL DEFAULT 0, -- Có thể dùng điểm thưởng để thanh toán không
    GiaTriDoiDiem INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE KhuyenMai (
    MaKM NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenKM NVARCHAR(200) NULL,
    IsPhanTram BIT NOT NULL DEFAULT 1, -- Giảm theo % (1) hay tiền mặt (0)
    GiaTri DECIMAL(12,2) NULL,
    MaLKH NVARCHAR(20) NULL, -- Áp dụng cho loại KH nào
    MaCN NVARCHAR(20) NULL,   -- Áp dụng cho CN nào
    MaLP NVARCHAR(20) NULL,   -- Áp dụng cho loại phòng nào
    MaPhong NVARCHAR(20) NULL, -- Áp dụng cho phòng cụ thể nào
    CouponCode NVARCHAR(100) NULL UNIQUE, -- Đặt UNIQUE ở đây
    NgayBD DATETIME2 NULL,
    NgayKT DATETIME2 NULL,
    DieuKien NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_KhuyenMai_MaLKH FOREIGN KEY (MaLKH) REFERENCES LoaiKhachHang(MaLKH),
    CONSTRAINT FK_KhuyenMai_MaCN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN),
    CONSTRAINT FK_KhuyenMai_MaLP FOREIGN KEY (MaLP) REFERENCES LoaiPhong(MaLP),
    CONSTRAINT FK_KhuyenMai_MaPhong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);
GO

CREATE TABLE DatPhong (
    MaDP NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaKH NVARCHAR(20) NOT NULL,
    MaNV NVARCHAR(20) NOT NULL, -- NV tiếp nhận/tạo phiếu đặt phòng
    TrangThai NVARCHAR(50) NULL,
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_DatPhong_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_DatPhong_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

CREATE TABLE CTDatPhong (
    MaCTDP NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaDP NVARCHAR(20) NOT NULL,
    TrangThai NVARCHAR(50) NULL,
    NgayDen DATETIME2 NULL,
    NgayDi DATETIME2 NULL,
    NgayCheckIn DATETIME2 NULL, -- Ngày check-in thực tế
    NgayCheckOut DATETIME2 NULL, -- Ngày check-out thực tế
    NguoiLon INT NULL,
    TreEm INT NULL,
    MaPhong NVARCHAR(20) NOT NULL,
    MaCN NVARCHAR(20) NULL, -- Chi nhánh
    MaNV NVARCHAR(20) NULL, -- Nhân viên xử lý
    MaCTDV NVARCHAR(20) NULL, -- Lưu ý: cột này có thể dư thừa nếu CTDichVu tham chiếu ngược lại CTDatPhong
    LoaiThue NVARCHAR(20) NULL DEFAULT N'Ngày', -- 'Giờ', 'Ngày', 'Tháng'
    GiaPhong DECIMAL(10,2) NULL,
    ThanhTien DECIMAL(12,2) NULL,
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CTDatPhong_DP FOREIGN KEY (MaDP) REFERENCES DatPhong(MaDP),
    CONSTRAINT FK_CTDatPhong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_CTDatPhong_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN),
    CONSTRAINT FK_CTDatPhong_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT CHK_CTDatPhong_LoaiThue CHECK (LoaiThue IN (N'Giờ', N'Ngày', N'Tháng'))
);
GO

CREATE TABLE CTDichVu (
    MaCTDV NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaCTDP NVARCHAR(20) NOT NULL, -- Chi tiết đặt phòng nào
    MaDV NVARCHAR(20) NOT NULL,
    SoLuong INT NULL,
    Gia DECIMAL(10,2) NULL,
    ThanhTien DECIMAL(12,2) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CTDichVu_CTDP FOREIGN KEY (MaCTDP) REFERENCES CTDatPhong(MaCTDP),
    CONSTRAINT FK_CTDichVu_DichVu FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);
GO

CREATE TABLE HoaDon (
    MaHD NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaDP NVARCHAR(20) NULL, -- NULL nếu là hóa đơn sự kiện
    MaCTSK NVARCHAR(20) NULL, -- NULL nếu là hóa đơn đặt phòng (FK được thêm sau bằng ALTER TABLE)
    LoaiHoaDon NVARCHAR(20) DEFAULT N'DatPhong', -- 'DatPhong' hoặc 'SuKien'
    MaKH NVARCHAR(20) NOT NULL,
    MaNV NVARCHAR(20) NOT NULL, -- NV tạo/xử lý hóa đơn
    MaKM NVARCHAR(20) NULL,
    MaCN NVARCHAR(20) NOT NULL,
    TrangThai NVARCHAR(50) NULL,
    NgayLap DATETIME2 NULL,
    TongTruocKM DECIMAL(12,2) NULL,
    TongTien DECIMAL(12,2) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_HoaDon_DP FOREIGN KEY (MaDP) REFERENCES DatPhong(MaDP),
    CONSTRAINT FK_HoaDon_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_HoaDon_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HoaDon_KM FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM),
    CONSTRAINT FK_HoaDon_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
GO

CREATE TABLE CTHoaDon (
    MaCTHD NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaHD NVARCHAR(20) NOT NULL,
    MoTa NVARCHAR(500) NULL,
    SoLuong INT NULL,
    DonGia DECIMAL(10,2) NULL,
    ThanhTien DECIMAL(12,2) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CTHoaDon_HD FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD)
);
GO

CREATE TABLE LoaiThanhToan (
    MaLTT NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenLTT NVARCHAR(100) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE ThanhToan (
    MaTT NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaHD NVARCHAR(20) NOT NULL,
    SoTien DECIMAL(12,2) NULL,
    MaLTT NVARCHAR(20) NOT NULL,
    NgayTT DATETIME2 NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_ThanhToan_HD FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    CONSTRAINT FK_ThanhToan_LoaiTT FOREIGN KEY (MaLTT) REFERENCES LoaiThanhToan(MaLTT)
);
GO

CREATE TABLE HinhAnhPhong (
    MaAnh NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaPhong NVARCHAR(20) NOT NULL,
    DuongDan NVARCHAR(500) NULL,
    GhiChu NVARCHAR(300) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_HinhAnhPhong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);
GO

CREATE TABLE KhachHangDiem (
    MaKH NVARCHAR(20) NOT NULL PRIMARY KEY,
    DiemHienTai INT NOT NULL DEFAULT 0,
    CapNhatLuc DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_KhachHangDiem_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO

CREATE TABLE KhachHangLichSuDiem (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- ID tự tăng & PK
    MaKH NVARCHAR(20) NOT NULL,
    Ngay DATETIME2 NOT NULL DEFAULT GETDATE(),
    LoaiThaoTac NVARCHAR(10) NOT NULL, -- CONG, TRU, DIEUCHINH
    Diem INT NOT NULL,
    GhiChu NVARCHAR(500) NULL,
    NguoiThucHien NVARCHAR(50) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_KhachHangLSDiem_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO

CREATE TABLE SuKien (
    MaSK NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenSK NVARCHAR(200) NOT NULL,
    LoaiSuKien NVARCHAR(100) NOT NULL,
    MaCN NVARCHAR(20) NOT NULL,
    DiaDiem NVARCHAR(300) NULL,
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    TongChiPhi DECIMAL(12,2) NULL,
    CONSTRAINT FK_SuKien_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
GO

CREATE TABLE CTSuKien (
    MaCTSK NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaSK NVARCHAR(20) NOT NULL,
    MaKH NVARCHAR(20) NOT NULL,
    MaCTDV NVARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL DEFAULT 1,
    DonGia DECIMAL(12,2) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED, -- Cột tự tính
    GhiChu NVARCHAR(300) NULL,
    DaThanhToan DECIMAL(12,2) NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Lên kế hoạch',
    NgayBD DATETIME2 NOT NULL,
    NgayKT DATETIME2 NOT NULL,
    TongKhach INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CTSuKien_SK FOREIGN KEY (MaSK) REFERENCES SuKien(MaSK),
    CONSTRAINT FK_CTSuKien_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_CTSuKien_CTDV FOREIGN KEY (MaCTDV) REFERENCES CTDichVu(MaCTDV) -- LƯU Ý: FK này trỏ đến CTDichVu có thể gây lỗi vòng lặp/trùng lặp dữ liệu, nhưng giữ lại theo bản gốc của bạn.
);
GO

-- Thêm FK và CHECK constraint cho HoaDon sau khi CTSuKien đã được tạo
ALTER TABLE HoaDon ADD CONSTRAINT FK_HoaDon_CTSK FOREIGN KEY (MaCTSK) REFERENCES CTSuKien(MaCTSK);
GO

ALTER TABLE HoaDon ADD CONSTRAINT CHK_HoaDon_Loai CHECK (
    (LoaiHoaDon = N'DatPhong' AND MaDP IS NOT NULL AND MaCTSK IS NULL) OR
    (LoaiHoaDon = N'SuKien' AND MaDP IS NULL AND MaCTSK IS NOT NULL)
);
GO

CREATE TABLE GoiSuKien (
    MaGoiSK NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenGoiSK NVARCHAR(200) NOT NULL,
    LoaiSuKien NVARCHAR(100) NOT NULL, -- Cưới, Hội nghị, Team building, ...
    MoTa NVARCHAR(500) NULL,
    GiaCoBan DECIMAL(12,2) NOT NULL DEFAULT 0,
    SoKhachToiThieu INT NOT NULL DEFAULT 10,
    SoKhachToiDa INT NULL,
    ThoiGianToiThieu INT NULL, -- Số giờ tối thiểu
    ThoiGianToiDa INT NULL, -- Số giờ tối đa
    DichVuKemTheo NVARCHAR(500) NULL, -- Mô tả dịch vụ kèm theo
    IsGoiMacDinh BIT NOT NULL DEFAULT 0, -- 1 = Gói mặc định, 0 = Gói custom
    MaCN NVARCHAR(20) NULL, -- NULL = áp dụng cho tất cả chi nhánh
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_GoiSuKien_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
GO

CREATE TABLE DatCoc (
    MaDatCoc NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaDP NVARCHAR(20) NULL,
    MaCTSK NVARCHAR(20) NULL,
    MaKH NVARCHAR(20) NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL,
    NgayCoc DATETIME2 NOT NULL DEFAULT GETDATE(),
    HinhThucThanhToan NVARCHAR(50) NULL,
    LoaiCoc NVARCHAR(50) NOT NULL DEFAULT N'Đặt phòng',
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'ĐÃ NHẬN',
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_DatCoc_DP FOREIGN KEY (MaDP) REFERENCES DatPhong(MaDP),
    CONSTRAINT FK_DatCoc_CTSK FOREIGN KEY (MaCTSK) REFERENCES CTSuKien(MaCTSK),
    CONSTRAINT FK_DatCoc_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO

CREATE TABLE HoanCoc (
    MaPhieuHoan NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaDatCoc NVARCHAR(20) NOT NULL,
    MaCN NVARCHAR(20) NOT NULL, -- Chi nhánh thực hiện hoàn cọc
    SoTienHoan DECIMAL(18,2) NOT NULL,
    NgayHoan DATETIME2 NOT NULL DEFAULT GETDATE(),
    HinhThucHoan NVARCHAR(50) NULL,
    CreatedBy NVARCHAR(20) NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'ĐÃ HOÀN',
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_HoanCoc_DatCoc FOREIGN KEY (MaDatCoc) REFERENCES DatCoc(MaDatCoc),
    CONSTRAINT FK_HoanCoc_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
GO

CREATE TABLE LostFound (
    MaLF NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaKH NVARCHAR(20) NULL,
    MaNV NVARCHAR(20) NOT NULL, -- NV tìm thấy đồ
    MaCN NVARCHAR(20) NOT NULL,
    TenDo NVARCHAR(200) NOT NULL,
    NgayTimThay DATETIME2 NOT NULL,
    DiaDiemTim NVARCHAR(300) NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Chưa trả',
    NgayTra DATETIME2 NULL,
    NguoiNhan NVARCHAR(200) NULL,
    GhiChu NVARCHAR(300) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_LostFound_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_LostFound_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN),
    CONSTRAINT FK_LostFound_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO

CREATE TABLE Complaint (
    MaKN NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaKH NVARCHAR(20) NOT NULL,
    MaNV NVARCHAR(20) NULL, -- NV xử lý khiếu nại
    MaCN NVARCHAR(20) NOT NULL,
    NgayGhi DATETIME2 NOT NULL DEFAULT GETDATE(),
    NoiDung NVARCHAR(500) NOT NULL,
    MucDo NVARCHAR(50) NOT NULL DEFAULT N'Thường',
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Chưa xử lý',
    KetQua NVARCHAR(300) NULL,
    SoTienBoiThuong DECIMAL(12,2) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(300) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    
    CONSTRAINT FK_Complaint_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_Complaint_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_Complaint_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
GO

CREATE TABLE Voucher (
    MaVoucher NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenVoucher NVARCHAR(200) NULL,
    CouponCode NVARCHAR(100) NULL UNIQUE,
    IsPhanTram BIT NOT NULL DEFAULT 1,
    GiaTri DECIMAL(12,2) NULL,
    SoLuong INT NULL,
    SoLuongDaDung INT NOT NULL DEFAULT 0,
    MaLKH NVARCHAR(20) NULL,
    MaCN NVARCHAR(20) NULL,
    MaLP NVARCHAR(20) NULL,
    MaPhong NVARCHAR(20) NULL,
    NgayBD DATETIME2 NULL,
    NgayKT DATETIME2 NULL,
    DieuKien NVARCHAR(500) NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Active',
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Voucher_MaLKH FOREIGN KEY (MaLKH) REFERENCES LoaiKhachHang(MaLKH),
    CONSTRAINT FK_Voucher_MaCN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN),
    CONSTRAINT FK_Voucher_MaLP FOREIGN KEY (MaLP) REFERENCES LoaiPhong(MaLP),
    CONSTRAINT FK_Voucher_MaPhong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);
GO

CREATE TABLE VoucherUsage (
    MaSuDung NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaVoucher NVARCHAR(20) NOT NULL,
    MaKH NVARCHAR(20) NULL,
    MaHD NVARCHAR(20) NULL,
    MaDP NVARCHAR(20) NULL,
    NgaySuDung DATETIME2 NOT NULL DEFAULT GETDATE(),
    GiaTriApDung DECIMAL(12,2) NULL,
    GhiChu NVARCHAR(500) NULL,
    CreatedBy NVARCHAR(20) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_VoucherUsage_Voucher FOREIGN KEY (MaVoucher) REFERENCES Voucher(MaVoucher),
    CONSTRAINT FK_VoucherUsage_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_VoucherUsage_HoaDon FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    CONSTRAINT FK_VoucherUsage_DatPhong FOREIGN KEY (MaDP) REFERENCES DatPhong(MaDP)
);
GO

--- 4. GÁN RÀNG BUỘC KHÓA NGOẠI THIẾU (VÍ DỤ: CỘT MAQUANLY VÀ AUDIT COLUMNS)
-----------------------------------------------------------------------------------------------------------------------

-- Gán FK MaQuanLy sau khi NhanVien đã tồn tại
ALTER TABLE ChiNhanh ADD CONSTRAINT FK_Resort_QuanLy FOREIGN KEY (MaQuanLy) REFERENCES NhanVien(MaNV);
GO

-- Liên kết các trường Audit (CreatedBy, UpdatedBy) với NhanVien
-- NhanVien phải được tạo trước khi thêm các FK này.
ALTER TABLE LoaiPhong ADD CONSTRAINT FK_LoaiPhong_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LoaiPhong ADD CONSTRAINT FK_LoaiPhong_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LoaiNhanVien ADD CONSTRAINT FK_LoaiNhanVien_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LoaiNhanVien ADD CONSTRAINT FK_LoaiNhanVien_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Phong ADD CONSTRAINT FK_Phong_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Phong ADD CONSTRAINT FK_Phong_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LoaiKhachHang ADD CONSTRAINT FK_LoaiKhachHang_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LoaiKhachHang ADD CONSTRAINT FK_LoaiKhachHang_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhachHang ADD CONSTRAINT FK_KhachHang_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhachHang ADD CONSTRAINT FK_KhachHang_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE TaiKhoan ADD CONSTRAINT FK_TaiKhoan_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE TaiKhoan ADD CONSTRAINT FK_TaiKhoan_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE DichVu ADD CONSTRAINT FK_DichVu_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE DichVu ADD CONSTRAINT FK_DichVu_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhuyenMai ADD CONSTRAINT FK_KhuyenMai_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhuyenMai ADD CONSTRAINT FK_KhuyenMai_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE DatPhong ADD CONSTRAINT FK_DatPhong_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE DatPhong ADD CONSTRAINT FK_DatPhong_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTDatPhong ADD CONSTRAINT FK_CTDatPhong_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTDatPhong ADD CONSTRAINT FK_CTDatPhong_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTDichVu ADD CONSTRAINT FK_CTDichVu_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTDichVu ADD CONSTRAINT FK_CTDichVu_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE HoaDon ADD CONSTRAINT FK_HoaDon_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE HoaDon ADD CONSTRAINT FK_HoaDon_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTHoaDon ADD CONSTRAINT FK_CTHoaDon_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTHoaDon ADD CONSTRAINT FK_CTHoaDon_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LoaiThanhToan ADD CONSTRAINT FK_LoaiThanhToan_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LoaiThanhToan ADD CONSTRAINT FK_LoaiThanhToan_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE ThanhToan ADD CONSTRAINT FK_ThanhToan_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE ThanhToan ADD CONSTRAINT FK_ThanhToan_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE HinhAnhPhong ADD CONSTRAINT FK_HinhAnhPhong_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE HinhAnhPhong ADD CONSTRAINT FK_HinhAnhPhong_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhachHangDiem ADD CONSTRAINT FK_KhachHangDiem_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhachHangDiem ADD CONSTRAINT FK_KhachHangDiem_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhachHangLichSuDiem ADD CONSTRAINT FK_KhachHangLSDiem_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE KhachHangLichSuDiem ADD CONSTRAINT FK_KhachHangLSDiem_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE DatCoc ADD CONSTRAINT FK_DatCoc_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE DatCoc ADD CONSTRAINT FK_DatCoc_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE HoanCoc ADD CONSTRAINT FK_HoanCoc_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE HoanCoc ADD CONSTRAINT FK_HoanCoc_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE SuKien ADD CONSTRAINT FK_SuKien_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE SuKien ADD CONSTRAINT FK_SuKien_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTSuKien ADD CONSTRAINT FK_CTSuKien_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTSuKien ADD CONSTRAINT FK_CTSuKien_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE GoiSuKien ADD CONSTRAINT FK_GoiSuKien_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE GoiSuKien ADD CONSTRAINT FK_GoiSuKien_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LostFound ADD CONSTRAINT FK_LostFound_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Complaint ADD CONSTRAINT FK_Complaint_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Voucher ADD CONSTRAINT FK_Voucher_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Voucher ADD CONSTRAINT FK_Voucher_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE VoucherUsage ADD CONSTRAINT FK_VoucherUsage_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE VoucherUsage ADD CONSTRAINT FK_VoucherUsage_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
GO

--- 5. RÀNG BUỘC DỮ LIỆU (CHECK CONSTRAINTS)
-- Giữ nguyên các ràng buộc CHECK và thêm vào sau khi các bảng đã tồn tại
-----------------------------------------------------------------------------------------------------------------------

ALTER TABLE LoaiPhong
ADD CONSTRAINT CK_LoaiPhong_SoPhongTrongNha CHECK (SoPhongTrongNha >= 0 OR SoPhongTrongNha IS NULL);
ALTER TABLE LoaiPhong ADD CONSTRAINT CK_LoaiPhong_GiaTheoGio CHECK (GiaTheoGio >= 0 OR GiaTheoGio IS NULL);
ALTER TABLE LoaiPhong ADD CONSTRAINT CK_LoaiPhong_GiaTheoNgay CHECK (GiaTheoNgay >= 0);
ALTER TABLE LoaiPhong ADD CONSTRAINT CK_LoaiPhong_GiaTheoThang CHECK (GiaTheoThang >= 0 OR GiaTheoThang IS NULL);
ALTER TABLE LoaiPhong ADD CONSTRAINT CK_LoaiPhong_SucChuaToiDa CHECK (SucChuaToiDa > 0);
GO
ALTER TABLE DichVu ADD CONSTRAINT CK_DichVu_Gia CHECK (Gia IS NULL OR Gia >= 0);
GO
ALTER TABLE CTDatPhong ADD CONSTRAINT CK_CTDatPhong_Tien CHECK (GiaPhong IS NULL OR GiaPhong >= 0);
ALTER TABLE CTDichVu ADD CONSTRAINT CK_CTDichVu_TIEN CHECK ((SoLuong IS NULL OR SoLuong > 0) AND (Gia IS NULL OR Gia >= 0) AND (ThanhTien IS NULL OR ThanhTien >= 0));
GO
ALTER TABLE KhuyenMai ADD CONSTRAINT CK_KhuyenMai_GiaTri CHECK (GiaTri IS NULL OR GiaTri >= 0);
ALTER TABLE KhuyenMai ADD CONSTRAINT CK_KhuyenMai_Ngay CHECK ((NgayBD IS NULL OR NgayKT IS NULL OR NgayKT >= NgayBD));
GO
ALTER TABLE ThanhToan ADD CONSTRAINT CK_ThanhToan_SoTien CHECK (SoTien IS NULL OR SoTien >= 0);
ALTER TABLE HoaDon ADD CONSTRAINT CK_HoaDon_TongTruocKM CHECK (TongTruocKM IS NULL OR TongTruocKM >= 0);
GO
ALTER TABLE CTDatPhong ADD CONSTRAINT CK_CTDatPhong_Ngay CHECK ((NgayDen IS NULL OR NgayDi IS NULL OR NgayDi > NgayDen));
ALTER TABLE CTDatPhong ADD CONSTRAINT CK_CTDatPhong_TrangThai CHECK (TrangThai IS NULL OR TrangThai IN (N'Đặt', N'Đang sử dụng', N'Nhận phòng', N'Trả phòng', N'Hủy', N'Hoàn tất'));
ALTER TABLE DatPhong ADD CONSTRAINT CK_DatPhong_TrangThai CHECK (TrangThai IS NULL OR TrangThai IN (N'Đặt', N'Đang sử dụng', N'Nhận phòng', N'Trả phòng', N'Hủy'));
ALTER TABLE HoaDon ADD CONSTRAINT CK_HoaDon_TrangThai CHECK (TrangThai IS NULL OR TrangThai IN (N'Chưa TT', N'Đã TT', N'Hủy'));
ALTER TABLE Phong ADD CONSTRAINT CK_Phong_TrangThai CHECK (TrangThai IN (N'Trống', N'Đã đặt', N'Bảo trì', N'Ngưng hoạt động', N'Đang Dọn', N'Đang Sử Dụng')); -- Bổ sung thêm trạng thái đang dọn/sử dụng
ALTER TABLE KhachHangDiem ADD CONSTRAINT CK_KhachHangDiem_NonNeg CHECK (DiemHienTai >= 0);
GO
ALTER TABLE DatCoc ADD CONSTRAINT CK_DatCoc_TrangThai CHECK (TrangThai IN (N'ĐÃ NHẬN', N'ĐÃ HOÀN', N'GIỮ LẠI'));
ALTER TABLE DatCoc ADD CONSTRAINT CK_DatCoc_Loai CHECK (LoaiCoc IN (N'Đặt phòng', N'Sự kiện'));
ALTER TABLE DatCoc ADD CONSTRAINT CK_DatCoc_LienKet CHECK ((MaDP IS NOT NULL AND MaCTSK IS NULL) OR (MaDP IS NULL AND MaCTSK IS NOT NULL));
ALTER TABLE DatCoc ADD CONSTRAINT CK_DatCoc_SoTien CHECK (SoTien > 0);
GO
ALTER TABLE HoanCoc ADD CONSTRAINT CK_HoanCoc_SoTienHoan CHECK (SoTienHoan >= 0);
ALTER TABLE HoanCoc ADD CONSTRAINT CK_HoanCoc_TrangThai CHECK (TrangThai IN (N'ĐÃ HOÀN', N'CHỜ DUYỆT', N'HUỶ'));
GO
ALTER TABLE SuKien ADD CONSTRAINT CK_SuKien_Loai CHECK (LoaiSuKien IN (N'Cưới', N'Team building', N'Hội nghị', N'Khác'));
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_TrangThai CHECK (TrangThai IN (N'Lên kế hoạch', N'Đang diễn ra', N'Đã kết thúc', N'Hủy'));
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_Ngay CHECK (NgayKT >= NgayBD);
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_SoLuong CHECK (SoLuong > 0);
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_DonGia CHECK (DonGia >= 0);
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_DaThanhToan CHECK (DaThanhToan >= 0);
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_TongKhach CHECK (TongKhach IS NULL OR TongKhach >= 0);
GO
ALTER TABLE LostFound ADD CONSTRAINT CK_LostFound_TrangThai CHECK (TrangThai IN (N'Chưa trả', N'Đã trả', N'Hủy'));
ALTER TABLE Complaint ADD CONSTRAINT CK_Complaint_TrangThai CHECK (TrangThai IN (N'Chưa xử lý', N'Đang xử lý', N'Đã xong', N'Hủy'));
GO
ALTER TABLE KhachHangLichSuDiem ADD CONSTRAINT CK_KhachHangLSDiem_Diem CHECK (Diem <> 0);
ALTER TABLE KhachHangLichSuDiem ADD CONSTRAINT CK_KhachHangLSDiem_Loai CHECK (LoaiThaoTac IN (N'CONG', N'TRU', N'DIEUCHINH'));
GO
ALTER TABLE Voucher ADD CONSTRAINT CK_Voucher_SoLuong CHECK (SoLuong IS NULL OR SoLuong >= 0);
ALTER TABLE Voucher ADD CONSTRAINT CK_Voucher_SoLuongDaDung CHECK (SoLuongDaDung >= 0 AND (SoLuong IS NULL OR SoLuongDaDung <= SoLuong));
ALTER TABLE Voucher ADD CONSTRAINT CK_Voucher_GiaTri CHECK (GiaTri IS NULL OR GiaTri >= 0);
ALTER TABLE Voucher ADD CONSTRAINT CK_Voucher_Ngay CHECK ((NgayBD IS NULL OR NgayKT IS NULL OR NgayKT >= NgayBD));
ALTER TABLE Voucher ADD CONSTRAINT CK_Voucher_TrangThai CHECK (TrangThai IN (N'Active', N'Inactive', N'Expired'));
ALTER TABLE VoucherUsage ADD CONSTRAINT CK_VoucherUsage_GiaTriApDung CHECK (GiaTriApDung IS NULL OR GiaTriApDung >= 0);
GO


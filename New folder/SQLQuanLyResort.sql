

-- 1. XÓA DATABASE CŨ (Cho môi trường phát triển/test)
IF DB_ID(N'QLR') IS NOT NULL
BEGIN
    ALTER DATABASE QLR SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLR;
END
GO
IF DB_ID(N'QLR') IS NULL
BEGIN
    CREATE DATABASE QLR;
END
GO
USE QLR;
GO

set dateformat dmy
go


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
    MaQuanLy NVARCHAR(20) NULL, -- Mã NV quản lý chi nhánh 
    UpdatedBy NVARCHAR(20) NULL,
    IsActive BIT NOT NULL DEFAULT 1
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

CREATE TABLE NhanVien (
    MaNV NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaCN NVARCHAR(20) NOT NULL,
    CCCD NVARCHAR(20) NOT NULL UNIQUE, 
    GioiTinh NVARCHAR(10) NULL,
    HoTen NVARCHAR(200) NULL,
    ChucVu NVARCHAR(100) NULL,
    SDT NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL,
    MaLoaiNV NVARCHAR(20) NULL,
    DuongDanAnh NVARCHAR(500) NULL,
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
    IDNumber NVARCHAR(50) NOT NULL UNIQUE, 
    DiaChi NVARCHAR(300) NULL,
    MaLKH NVARCHAR(20) NOT NULL, 
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
    MaNV NVARCHAR(20) NOT NULL UNIQUE, 
    TenDangNhap NVARCHAR(100) NOT NULL UNIQUE, 
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
    ChoPhepDoiDiem BIT NOT NULL DEFAULT 0,
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
    NgayDen DATETIME2 NULL,
    NgayDi DATETIME2 NULL,
    NguoiLon INT NULL DEFAULT 2,
    TreEm INT NULL DEFAULT 0,
    TongTien DECIMAL(12,2) NULL,
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
    NguoiLon INT NULL,
    TreEm INT NULL,
    MaPhong NVARCHAR(20) NOT NULL,
    MaCTDV NVARCHAR(20) NULL,
    LoaiDat NVARCHAR(20) NULL DEFAULT N'Theo ngày', -- Theo giờ, Theo ngày, Theo tháng
    SoLuongThue INT NULL DEFAULT 1, -- Số giờ/ngày/tháng thuê
    GiaPhong DECIMAL(10,2) NULL,
    ThanhTien DECIMAL(12,2) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CTDatPhong_DP FOREIGN KEY (MaDP) REFERENCES DatPhong(MaDP),
    CONSTRAINT FK_CTDatPhong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
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

CREATE TABLE SuKien (
    MaSK NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenSK NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE GoiSuKien (
    MaGoiSK NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaSK NVARCHAR(20) NOT NULL, 
    TenGoiSK NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(500) NULL,
    GiaGoi DECIMAL(12,2) NOT NULL, 
    SoKhachToiThieu INT NOT NULL DEFAULT 10,
    SoKhachToiDa INT NULL,
    ThoiGianToiThieu INT NULL, 
    ThoiGianToiDa INT NULL,
    DichVuKemTheo NVARCHAR(1000) NULL,
    MaCN NVARCHAR(20) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_GoiSuKien_SuKien FOREIGN KEY (MaSK) REFERENCES SuKien(MaSK),
    CONSTRAINT FK_GoiSuKien_ChiNhanh FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
GO

CREATE TABLE CTSuKien (
    MaCTSK NVARCHAR(20) NOT NULL PRIMARY KEY, 
    MaGoiSK NVARCHAR(20) NOT NULL, 
    MaKH NVARCHAR(20) NOT NULL,
    NgayToChuc DATETIME2 NOT NULL, 
    SoLuongKhach INT NOT NULL DEFAULT 1,
    YeuCauThem NVARCHAR(1000) NULL,
    ChiPhiGoi DECIMAL(12,2) NOT NULL,
    ChiPhiPhatSinh DECIMAL(12,2) NOT NULL DEFAULT 0, 
    ThanhTien AS (ChiPhiGoi + ChiPhiPhatSinh) PERSISTED, 
    DaThanhToan DECIMAL(12,2) NOT NULL DEFAULT 0, 
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Lên kế hoạch', 
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CTSuKien_GoiSK FOREIGN KEY (MaGoiSK) REFERENCES GoiSuKien(MaGoiSK),
    CONSTRAINT FK_CTSuKien_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT UQ_CTSuKien_GoiKH UNIQUE (MaGoiSK, MaKH, NgayToChuc)
);
GO

CREATE TABLE HoaDon (
    MaHD NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaDP NVARCHAR(20) NULL, 
    MaCTSK NVARCHAR(20) NULL, 
    MaKH NVARCHAR(20) NOT NULL,
    MaNV NVARCHAR(20) NOT NULL, 
    MaKM NVARCHAR(20) NULL,
    MaCN NVARCHAR(20) NOT NULL,
    TrangThai NVARCHAR(50) NULL DEFAULT N'Chưa TT',
    NgayLap DATETIME2 NULL,
    TongTruocKM DECIMAL(12,2) NULL,
    TongTien DECIMAL(12,2) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_HoaDon_DP FOREIGN KEY (MaDP) REFERENCES DatPhong(MaDP),
    CONSTRAINT FK_HoaDon_CTSK FOREIGN KEY (MaCTSK) REFERENCES CTSuKien(MaCTSK),
    CONSTRAINT FK_HoaDon_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_HoaDon_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HoaDon_KM FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM),
    CONSTRAINT FK_HoaDon_CN FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN),
    CONSTRAINT CK_HoaDon_Type CHECK (
        (MaDP IS NOT NULL AND MaCTSK IS NULL) OR 
        (MaDP IS NULL AND MaCTSK IS NOT NULL)
    )
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
    SoTienHoan DECIMAL(18,2) NOT NULL,
    NgayHoan DATETIME2 NOT NULL DEFAULT GETDATE(),
    HinhThucHoan NVARCHAR(50) NULL,
    CreatedBy NVARCHAR(20) NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'ĐÃ HOÀN',
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_HoanCoc_DatCoc FOREIGN KEY (MaDatCoc) REFERENCES DatCoc(MaDatCoc)
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

-----------------------------------------------------------------------------------------------------------------------

ALTER TABLE ChiNhanh ADD CONSTRAINT FK_Resort_QuanLy FOREIGN KEY (MaQuanLy) REFERENCES NhanVien(MaNV);
GO
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
ALTER TABLE GoiSuKien ADD CONSTRAINT FK_GoiSuKien_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE GoiSuKien ADD CONSTRAINT FK_GoiSuKien_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTSuKien ADD CONSTRAINT FK_CTSuKien_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE CTSuKien ADD CONSTRAINT FK_CTSuKien_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE LostFound ADD CONSTRAINT FK_LostFound_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Complaint ADD CONSTRAINT FK_Complaint_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Voucher ADD CONSTRAINT FK_Voucher_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE Voucher ADD CONSTRAINT FK_Voucher_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE VoucherUsage ADD CONSTRAINT FK_VoucherUsage_CreatedBy_NV FOREIGN KEY (CreatedBy) REFERENCES NhanVien(MaNV);
ALTER TABLE VoucherUsage ADD CONSTRAINT FK_VoucherUsage_UpdatedBy_NV FOREIGN KEY (UpdatedBy) REFERENCES NhanVien(MaNV);
GO

--- 5. RÀNG BUỘC DỮ LIỆU (CHECK CONSTRAINTS)
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
-- CHECK constraints cho bảng GoiSuKien
ALTER TABLE GoiSuKien ADD CONSTRAINT CK_GoiSuKien_GiaGoi CHECK (GiaGoi >= 0);
ALTER TABLE GoiSuKien ADD CONSTRAINT CK_GoiSuKien_SoKhach CHECK (
    (SoKhachToiThieu IS NULL OR SoKhachToiThieu >= 0) AND
    (SoKhachToiDa IS NULL OR SoKhachToiDa >= SoKhachToiThieu)
);
GO
-- CHECK constraints cho bảng CTSuKien (Event Detail)
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_TrangThai CHECK (TrangThai IN (N'Lên kế hoạch', N'Đang diễn ra', N'Đã kết thúc', N'Hủy'));
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_SoLuongKhach CHECK (SoLuongKhach > 0);
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_ChiPhi CHECK (ChiPhiGoi >= 0 AND ChiPhiPhatSinh >= 0);
ALTER TABLE CTSuKien ADD CONSTRAINT CK_CTSuKien_DaThanhToan CHECK (DaThanhToan >= 0);
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




--- 7. KHỐI LỆNH TẠO STORED PROCEDURES (PROC)
-- Giữ nguyên các PROC của bạn
-----------------------------------------------------------------------------------------------------------------------

-- [PROC - LOẠI NHÂN VIÊN] Lấy danh sách
CREATE OR ALTER PROC sp_GetLoaiNV @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLoaiNV, TenLoaiNV, MoTa, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM LoaiNhanVien
    WHERE @IsActive IS NULL OR IsActive = @IsActive;
END
GO

-- [PROC - LOẠI NHÂN VIÊN] Lấy danh sách cho Hóa đơn (alias)
CREATE OR ALTER PROC sp_GetAllLoaiNhanVienHD
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLoaiNV, TenLoaiNV, MoTa, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM LoaiNhanVien
    WHERE IsActive = 1;
END
GO

-- [PROC - LOẠI NHÂN VIÊN] Thêm mới
CREATE OR ALTER PROC sp_InsertLoaiNhanVien
    @MaLoaiNV NVARCHAR(20), @TenLoaiNV NVARCHAR(200), @MoTa NVARCHAR(500), @CreatedBy NVARCHAR(20), @IsActive bit
AS
BEGIN
    INSERT INTO LoaiNhanVien (MaLoaiNV, TenLoaiNV, MoTa, CreatedAt, CreatedBy, IsActive)
    VALUES (@MaLoaiNV, @TenLoaiNV, @MoTa, GETDATE(), @CreatedBy, @IsActive);
END
GO

-- [PROC - LOẠI NHÂN VIÊN] Cập nhật
CREATE OR ALTER PROC sp_UpdateLoaiNhanVien
    @MaLoaiNV NVARCHAR(20), @TenLoaiNV NVARCHAR(200), @MoTa NVARCHAR(500), @UpdatedBy NVARCHAR(20), @IsActive BIT
AS
BEGIN
    UPDATE LoaiNhanVien
    SET TenLoaiNV = @TenLoaiNV, MoTa = @MoTa, UpdatedAt = GETDATE(), UpdatedBy = @UpdatedBy, IsActive = @IsActive
    WHERE MaLoaiNV = @MaLoaiNV;
END
GO

-- [PROC - LOẠI NHÂN VIÊN] Xóa cứng
CREATE OR ALTER PROC sp_DeleteLoaiNhanVien_Hard
    @MaLoaiNV NVARCHAR(20)
AS
BEGIN
    DELETE FROM LoaiNhanVien
    WHERE MaLoaiNV = @MaLoaiNV AND MaLoaiNV != 'LNV00';
END
GO

-- [PROC - NHÂN VIÊN] Thêm mới
CREATE OR ALTER PROC sp_InsertNhanVien
    @MaNV NVARCHAR(20), @MaCN NVARCHAR(20), @CCCD NVARCHAR(20), @GioiTinh NVARCHAR(10), @HoTen NVARCHAR(200),
    @ChucVu NVARCHAR(100), @SDT NVARCHAR(30), @Email NVARCHAR(100), @MaLoaiNV NVARCHAR(20),
    @DuongDanAnh NVARCHAR(500) = NULL, @CreatedBy NVARCHAR(20), @IsActive bit
AS
BEGIN
    INSERT INTO NhanVien (MaNV, MaCN, CCCD, GioiTinh, HoTen, ChucVu, SDT, Email, MaLoaiNV, DuongDanAnh, CreatedBy,IsActive)
    VALUES (@MaNV, @MaCN, @CCCD, @GioiTinh, @HoTen, @ChucVu, @SDT, @Email, @MaLoaiNV, @DuongDanAnh, @CreatedBy,@IsActive);
END
GO

-- [PROC - NHÂN VIÊN] Cập nhật
CREATE OR ALTER PROC sp_UpdateNhanVien
    @MaNV NVARCHAR(20), @MaCN NVARCHAR(20), @CCCD NVARCHAR(20), @GioiTinh NVARCHAR(10), @HoTen NVARCHAR(200),
    @ChucVu NVARCHAR(100), @SDT NVARCHAR(30), @Email NVARCHAR(100), @MaLoaiNV NVARCHAR(20),
    @DuongDanAnh NVARCHAR(500) = NULL, @UpdatedBy NVARCHAR(20), @IsActive BIT
AS
BEGIN
    UPDATE NhanVien
    SET MaCN = @MaCN, CCCD = @CCCD, GioiTinh = @GioiTinh, HoTen = @HoTen, ChucVu = @ChucVu, SDT = @SDT, Email = @Email,
        MaLoaiNV = @MaLoaiNV, DuongDanAnh = @DuongDanAnh, UpdatedAt = GETDATE(), UpdatedBy = @UpdatedBy, IsActive = @IsActive
    WHERE MaNV = @MaNV;
END
GO

-- [PROC - NHÂN VIÊN] Xóa cứng
CREATE OR ALTER PROC sp_DeleteNhanVien @MaNV NVARCHAR(20)
AS
BEGIN
    DELETE FROM NhanVien WHERE MaNV = @MaNV AND MaNV != 'NV01'
END
GO
-- [PROC - NHÂN VIÊN] Xem danh sách chi nhánh (Đã tối ưu SELECT)
CREATE OR ALTER PROC sp_GetNhanVien
    @CCCD NVARCHAR(20) = NULL, @MaCN NVARCHAR(20) = NULL, @MaLoaiNV NVARCHAR(20) = NULL,
    @GioiTinh NVARCHAR(10) = NULL, @ChucVu NVARCHAR(100) = NULL, @IsActive BIT = NULL, @MaNV NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        NV.MaNV, NV.MaCN, NV.CCCD, NV.GioiTinh, NV.HoTen, NV.ChucVu, NV.SDT, NV.Email, NV.MaLoaiNV, NV.DuongDanAnh,
        NV.CreatedAt, NV.CreatedBy, NV.UpdatedAt, NV.UpdatedBy, NV.IsActive, CN.TenCN, LNV.TenLoaiNV
    FROM NhanVien NV
    INNER JOIN ChiNhanh CN ON NV.MaCN = CN.MaCN
    INNER JOIN LoaiNhanVien LNV ON NV.MaLoaiNV = LNV.MaLoaiNV
    WHERE
        (@MaCN IS NULL OR NV.MaCN = @MaCN) AND (@MaLoaiNV IS NULL OR NV.MaLoaiNV = @MaLoaiNV)
        AND (@GioiTinh IS NULL OR NV.GioiTinh = @GioiTinh) AND (@ChucVu IS NULL OR NV.ChucVu = @ChucVu)
        AND (@IsActive IS NULL OR NV.IsActive = @IsActive) AND (@CCCD IS NULL OR NV.CCCD = @CCCD)
        AND (@MaNV IS NULL OR NV.MaNV = @MaNV)
    ORDER BY NV.HoTen;
END
GO

-- [PROC - CHI NHÁNH] Thêm mới
CREATE OR ALTER PROC sp_AddChiNhanh
    @MaCN NVARCHAR(20), @TenCN NVARCHAR(200), @MaQuanLy NVARCHAR(20) = null,
    @DiaChi NVARCHAR(300), @CreatedBy NVARCHAR(20), @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChiNhanh (MaCN, TenCN, DiaChi, CreatedAt, CreatedBy, IsActive,MaQuanLy)
    VALUES (@MaCN, @TenCN, @DiaChi, GETDATE(), @CreatedBy, @IsActive,@MaQuanLy);
END
GO

-- [PROC - CHI NHÁNH] Cập nhật
CREATE OR ALTER PROC sp_UpdateChiNhanh
    @MaCN NVARCHAR(20), @TenCN NVARCHAR(200), @DiaChi NVARCHAR(300),
    @UpdatedBy NVARCHAR(20), @IsActive BIT, @MaNQL NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ChiNhanh
    SET TenCN = @TenCN, DiaChi = @DiaChi, UpdatedAt = GETDATE(), UpdatedBy = @UpdatedBy,
        IsActive = @IsActive, MaQuanLy = @MaNQL
    WHERE MaCN = @MaCN;
END
GO

-- [PROC - CHI NHÁNH] Xóa cứng
CREATE OR ALTER PROC sp_DeleteChiNhanh_Hard
    @MaCN NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM ChiNhanh WHERE MaCN = @MaCN;
END
GO

-- [PROC - CHI NHÁNH] Xem chi tiết / Danh sách (Đã tối ưu SELECT)
CREATE OR ALTER PROC sp_GetChiNhanh
    @MaCN NVARCHAR(20) = NULL, @IsActive BIT = NULL, @TenCN NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaCN, TenCN, DiaChi, MaQuanLy, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM ChiNhanh
    WHERE
        (@MaCN IS NULL OR MaCN = @MaCN) AND (@IsActive IS NULL OR IsActive = @IsActive)
        AND (@TenCN IS NULL OR TenCN = @TenCN)
    ORDER BY TenCN;
END
GO

-- [PROC - CHI NHÁNH] Xóa cứng (thêm điều kiện an toàn)
CREATE OR ALTER PROC sp_DeleteChiNhanh @MaCN NVARCHAR(20)
AS
BEGIN
    DELETE FROM ChiNhanh
    WHERE MaCN = @MaCN AND MaCN != 'CN01'
END
GO

-- [PROC - KHÁCH HÀNG] Xem danh sách/Chi tiết
CREATE OR ALTER PROC sp_GetKhachHang
    @MaKH NVARCHAR(20) = NULL, @HoTen NVARCHAR(200) = NULL, @GioiTinh NVARCHAR(10) = NULL,
    @SDT NVARCHAR(30) = NULL, @IDNumber NVARCHAR(50) = NULL, @MaLKH NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        MaKH, HoTen, GioiTinh, NgaySinh, SDT, Email, IDType, IDNumber, DiaChi, MaLKH,
        CreatedBy, CreatedAt, UpdatedAt, UpdatedBy, IsActive
    FROM KhachHang
    WHERE
        (@MaKH IS NULL OR MaKH = @MaKH) AND (@HoTen IS NULL OR HoTen LIKE N'%' + @HoTen + N'%')
        AND (@GioiTinh IS NULL OR GioiTinh = @GioiTinh) AND (@SDT IS NULL OR SDT LIKE N'%' + @SDT + N'%')
        AND (@IDNumber IS NULL OR IDNumber = @IDNumber) AND (@MaLKH IS NULL OR MaLKH = @MaLKH)
        AND (@IsActive IS NULL OR IsActive = @IsActive)
END;
GO

-- [PROC - KHÁCH HÀNG] Thêm mới
CREATE OR ALTER PROCEDURE sp_AddKhachHang
    @MaKH NVARCHAR(20), @HoTen NVARCHAR(200), @GioiTinh NVARCHAR(10), @NgaySinh DATE, @SDT NVARCHAR(30),
    @Email NVARCHAR(100), @IDType NVARCHAR(20) = N'CCCD', @IDNumber NVARCHAR(50), @DiaChi NVARCHAR(300),
    @MaLKH NVARCHAR(20), @CreateBy NVARCHAR(20), @IsActive bit
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO KhachHang(MaKH,HoTen,GioiTinh,NgaySinh, SDT, Email,IDType,IDNumber,DiaChi,MaLKH,CreatedBy,CreatedAt,IsActive)
    VALUES (
        @MaKH, @HoTen, @GioiTinh, @NgaySinh, @SDT, @Email, @IDType, @IDNumber, @DiaChi, @MaLKH, @CreateBy, GETDATE(), @IsActive
    );
END;
GO

-- [PROC - KHÁCH HÀNG] Cập nhật
CREATE OR ALTER PROCEDURE sp_UpdateKhachHang
    @MaKH NVARCHAR(20), @HoTen NVARCHAR(200) = NULL, @GioiTinh NVARCHAR(10) = NULL, @NgaySinh DATE = NULL,
    @SDT NVARCHAR(30) = NULL, @Email NVARCHAR(100) = NULL, @IDType NVARCHAR(20) = N'CCCD', @IDNumber NVARCHAR(50) = NULL,
    @DiaChi NVARCHAR(300) = NULL, @MaLKH NVARCHAR(20) = NULL, @IsActive BIT = 1, @UpdatedBy NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE KhachHang
    SET
        HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SDT = @SDT, Email = @Email, IDType = @IDType,
        IDNumber = @IDNumber, DiaChi = @DiaChi, MaLKH = @MaLKH, IsActive = @IsActive, UpdatedBy = @UpdatedBy, UpdatedAt = GETDATE()
    WHERE MaKH = @MaKH;
END;
GO

-- [PROC - KHÁCH HÀNG] Xóa cứng
CREATE OR ALTER PROCEDURE sp_DeleteKhachHang
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM KhachHang WHERE MaKH = @MaKH;
END;
GO

-- [PROC - LOẠI KHÁCH HÀNG] Xem chi tiết / Danh sách (Đã tối ưu SELECT)
CREATE OR ALTER PROCEDURE sp_GetLoaiKhachHang
    @MaLKH NVARCHAR(20) = NULL, @IsActive BIT = NULL
AS
BEGIN
    SELECT MaLKH, TenLKH, GiamGiaPercent, DiemToiThieu, MoTa, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM LoaiKhachHang
    WHERE (@MaLKH IS NULL OR MaLKH = @MaLKH) AND (@IsActive IS NULL OR IsActive = @IsActive)
    ORDER BY MaLKH;
END
GO

CREATE OR ALTER PROCEDURE sp_GetLoaiKhachHangForKH
AS
BEGIN
    SELECT MaLKH, TenLKH
    FROM LoaiKhachHang
    WHERE IsActive = 1
    ORDER BY MaLKH;
END
GO

-- [PROC - LOẠI KHÁCH HÀNG] Lấy Mã và Tên (Dùng cho ComboBox)
CREATE OR ALTER PROCEDURE sp_GetLoaiKhachHang_Key_Value
AS
BEGIN
    SELECT MaLKH, TenLKH
    FROM LoaiKhachHang
    WHERE IsActive = 1;
END
GO

-- [PROC - LOẠI KHÁCH HÀNG] Thêm mới
CREATE OR ALTER PROCEDURE sp_InsertLoaiKhachHang
    @MaLKH NVARCHAR(20), @TenLKH NVARCHAR(100), @GiamGiaPercent DECIMAL(5,2), @DiemToiThieu INT,
    @MoTa NVARCHAR(500) = NULL, @CreatedBy NVARCHAR(20), @IsActive BIT
AS
BEGIN
    INSERT INTO LoaiKhachHang (MaLKH, TenLKH, GiamGiaPercent, DiemToiThieu, MoTa, CreatedBy,CreatedAt, IsActive)
    VALUES (@MaLKH, @TenLKH, @GiamGiaPercent, @DiemToiThieu, @MoTa, @CreatedBy,GETDATE(), @IsActive);
END
GO

-- [PROC - LOẠI KHÁCH HÀNG] Xóa cứng
CREATE OR ALTER PROCEDURE sp_DeleteLoaiKhachHang
    @MaLKH NVARCHAR(20)
AS
BEGIN
    DELETE FROM LoaiKhachHang
    WHERE MaLKH = @MaLKH;
END
GO

-- [PROC - LOẠI KHÁCH HÀNG] Cập nhật
CREATE OR ALTER PROCEDURE sp_UpdateLoaiKhachHang
    @MaLKH NVARCHAR(20), @TenLKH NVARCHAR(100), @GiamGiaPercent DECIMAL(5,2), @DiemToiThieu INT,
    @MoTa NVARCHAR(500) = NULL, @UpdatedBy NVARCHAR(20), @IsActive BIT
AS
BEGIN
    UPDATE LoaiKhachHang
    SET
        TenLKH = @TenLKH, GiamGiaPercent = @GiamGiaPercent, DiemToiThieu = @DiemToiThieu, MoTa = @MoTa,
        UpdatedAt = GETDATE(), UpdatedBy = @UpdatedBy, IsActive = @IsActive
    WHERE MaLKH = @MaLKH;
END
GO

-- [PROC - PHÒNG] Lấy danh sách
CREATE OR ALTER PROC sp_GetPhong
    @MaPhong NVARCHAR(20) = NULL, 
    @MaCN NVARCHAR(20) = NULL, 
    @MaLP NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(20) = NULL, 
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        P.MaPhong, P.MaCN, P.MaLP, P.SoPhong, P.ViTri, P.TrangThai, P.GhiChu, 
        P.CreatedAt, P.CreatedBy, P.UpdatedAt, P.UpdatedBy, P.IsActive,
        
        -- CÁC CỘT ĐƯỢC LẤY TỪ BẢNG LOAIPHONG (ROOMTYPE)
        LP.TenLP AS TenLoaiPhong,
        LP.SucChuaToiDa,
        LP.GiaTheoNgay,
        LP.GiaTheoGio,
        LP.GiaTheoThang
    FROM 
        Phong P
    INNER JOIN 
        LoaiPhong LP ON P.MaLP = LP.MaLP -- Thực hiện JOIN trên khóa ngoại MaLP
    WHERE 
        (@MaPhong IS NULL OR P.MaPhong = @MaPhong) 
        AND (@MaCN IS NULL OR P.MaCN = @MaCN)
        AND (@MaLP IS NULL OR P.MaLP = @MaLP) 
        AND (@TrangThai IS NULL OR P.TrangThai = @TrangThai)
        AND (@IsActive IS NULL OR P.IsActive = @IsActive);
END
GO

-- [PROC - PHÒNG] Thêm mới
CREATE OR ALTER PROC sp_InsertPhong
    @MaPhong NVARCHAR(20), @MaCN NVARCHAR(20), @MaLP NVARCHAR(20), @SoPhong NVARCHAR(50), @ViTri NVARCHAR(100),
    @TrangThai NVARCHAR(20), @GhiChu NVARCHAR(500), @CreatedBy NVARCHAR(20), @IsActive BIT
AS
BEGIN
    INSERT INTO Phong (MaPhong, MaCN, MaLP, SoPhong, ViTri, TrangThai, GhiChu, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaPhong, @MaCN, @MaLP, @SoPhong, @ViTri, @TrangThai, @GhiChu, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - PHÒNG] Cập nhật
CREATE OR ALTER PROC sp_UpdatePhong
    @MaPhong NVARCHAR(20), @MaCN NVARCHAR(20), @MaLP NVARCHAR(20), @SoPhong NVARCHAR(50), @ViTri NVARCHAR(100),
    @TrangThai NVARCHAR(20), @GhiChu NVARCHAR(500), @UpdatedBy NVARCHAR(20), @IsActive BIT
AS
BEGIN
    UPDATE Phong
    SET MaCN = @MaCN, MaLP = @MaLP, SoPhong = @SoPhong, ViTri = @ViTri, TrangThai = @TrangThai, GhiChu = @GhiChu,
        UpdatedBy = @UpdatedBy, UpdatedAt = GETDATE(), IsActive = @IsActive
    WHERE MaPhong = @MaPhong;
END
GO

-- [PROC - PHÒNG] Xóa
CREATE OR ALTER PROC sp_DeletePhong
    @MaPhong NVARCHAR(20)
AS
BEGIN
    DELETE FROM Phong WHERE MaPhong = @MaPhong;
END
GO

-- [PROC - HÌNH ẢNH PHÒNG] Lấy danh sách
CREATE OR ALTER PROC sp_GetHinhAnhPhong
    @MaAnh NVARCHAR(20) = NULL, @MaPhong NVARCHAR(20) = NULL, @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM HinhAnhPhong
    WHERE (@MaAnh IS NULL OR MaAnh = @MaAnh) AND (@MaPhong IS NULL OR MaPhong = @MaPhong)
      AND (@IsActive IS NULL OR IsActive = @IsActive);
END
GO

-- [PROC - HÌNH ẢNH PHÒNG] Thêm mới
CREATE OR ALTER PROC sp_InsertHinhAnhPhong
    @MaAnh NVARCHAR(20), @MaPhong NVARCHAR(20), @DuongDan NVARCHAR(500), @GhiChu NVARCHAR(300) = NULL,
    @CreatedBy NVARCHAR(20), @IsActive BIT = 1
AS
BEGIN
    INSERT INTO HinhAnhPhong (MaAnh, MaPhong, DuongDan, GhiChu, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaAnh, @MaPhong, @DuongDan, @GhiChu, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - HÌNH ẢNH PHÒNG] Cập nhật
CREATE OR ALTER PROC sp_UpdateHinhAnhPhong
    @MaAnh NVARCHAR(20), @DuongDan NVARCHAR(500), @GhiChu NVARCHAR(300) = NULL,
    @UpdatedBy NVARCHAR(20), @IsActive BIT = 1
AS
BEGIN
    UPDATE HinhAnhPhong
    SET DuongDan = @DuongDan, GhiChu = @GhiChu, UpdatedBy = @UpdatedBy, UpdatedAt = GETDATE(), IsActive = @IsActive
    WHERE MaAnh = @MaAnh;
END
GO

-- [PROC - HÌNH ẢNH PHÒNG] Xóa
CREATE OR ALTER PROC sp_DeleteHinhAnhPhong
    @MaAnh NVARCHAR(20)
AS
BEGIN
    DELETE FROM HinhAnhPhong WHERE MaAnh = @MaAnh;
END
GO

-- ==========================================
-- STORED PROCEDURES CHO ĐẶT PHÒNG
-- ==========================================

-- [PROC - ĐẶT PHÒNG] Lấy danh sách

-- [PROC - CHI TIẾT ĐẶT PHÒNG] Lấy danh sách
CREATE OR ALTER PROC sp_GetCTDatPhong
    @MaCTDP NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @MaPhong NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CTDP.MaCTDP, CTDP.MaDP, CTDP.TrangThai, CTDP.NgayDen, CTDP.NgayDi,
           CTDP.NguoiLon, CTDP.TreEm, CTDP.MaPhong, CTDP.GiaPhong, CTDP.ThanhTien,
           CTDP.CreatedAt, CTDP.CreatedBy, CTDP.UpdatedAt, CTDP.UpdatedBy, CTDP.IsActive,
           P.SoPhong, P.ViTri, LP.TenLP, LP.GiaTheoNgay
    FROM CTDatPhong CTDP
    LEFT JOIN Phong P ON CTDP.MaPhong = P.MaPhong
    LEFT JOIN LoaiPhong LP ON P.MaLP = LP.MaLP
    WHERE (@MaCTDP IS NULL OR CTDP.MaCTDP = @MaCTDP)
      AND (@MaDP IS NULL OR CTDP.MaDP = @MaDP)
      AND (@MaPhong IS NULL OR CTDP.MaPhong = @MaPhong)
      AND (@TrangThai IS NULL OR CTDP.TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR CTDP.IsActive = @IsActive)
    ORDER BY CTDP.NgayDen DESC;
END
GO

-- [PROC - CHI TIẾT ĐẶT PHÒNG] Thêm mới
-- Update sp_InsertCTDatPhong
CREATE OR ALTER PROC sp_InsertCTDatPhong
    @MaCTDP NVARCHAR(20),
    @MaDP NVARCHAR(20),
    @TrangThai NVARCHAR(50) = N'Đặt',
    @NgayDen DATETIME2 = NULL,
    @NgayDi DATETIME2 = NULL,
    @NguoiLon INT = NULL,
    @TreEm INT = NULL,
    @MaPhong NVARCHAR(20) = NULL,
    @MaCTDV NVARCHAR(20) = NULL,
    @LoaiDat NVARCHAR(20) = N'Theo ngày',  -- NEW
    @SoLuongThue INT = 1,                   -- NEW
    @GiaPhong DECIMAL(10,2) = NULL,
    @ThanhTien DECIMAL(12,2) = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CTDatPhong (MaCTDP, MaDP, TrangThai, NgayDen, NgayDi, NguoiLon, TreEm,
                           MaPhong, MaCTDV, LoaiDat, SoLuongThue, GiaPhong, ThanhTien, 
                           CreatedBy, CreatedAt, IsActive)
    VALUES (@MaCTDP, @MaDP, @TrangThai, @NgayDen, @NgayDi, @NguoiLon, @TreEm,
            @MaPhong, @MaCTDV, @LoaiDat, @SoLuongThue, @GiaPhong, @ThanhTien, 
            @CreatedBy, GETDATE(), @IsActive);
END
GO


-- [PROC - CHI TIẾT ĐẶT PHÒNG] Cập nhật
CREATE OR ALTER PROC sp_UpdateCTDatPhong
    @MaCTDP NVARCHAR(20),
    @TrangThai NVARCHAR(50) = NULL,
    @NgayDen DATETIME2 = NULL,
    @NgayDi DATETIME2 = NULL,
    @NguoiLon INT = NULL,
    @TreEm INT = NULL,
    @LoaiDat NVARCHAR(50) = NULL,  -- ✅ NEW: Support booking type (Theo giờ/ngày/tháng)
    @SoLuongThue INT = NULL,        -- ✅ NEW: Support quantity (hours, days, months)
    @GiaPhong DECIMAL(10,2) = NULL,
    @ThanhTien DECIMAL(12,2) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CTDatPhong
    SET TrangThai = ISNULL(@TrangThai, TrangThai),
        NgayDen = ISNULL(@NgayDen, NgayDen),
        NgayDi = ISNULL(@NgayDi, NgayDi),
        NguoiLon = ISNULL(@NguoiLon, NguoiLon),
        TreEm = ISNULL(@TreEm, TreEm),
        LoaiDat = ISNULL(@LoaiDat, LoaiDat),          -- ✅ NEW
        SoLuongThue = ISNULL(@SoLuongThue, SoLuongThue),  -- ✅ NEW
        GiaPhong = ISNULL(@GiaPhong, GiaPhong),
        ThanhTien = ISNULL(@ThanhTien, ThanhTien),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaCTDP = @MaCTDP;
END
GO

-- [PROC - CHI TIẾT DỊCH VỤ] Lấy danh sách
CREATE OR ALTER PROC sp_GetCTDichVu
    @MaCTDV NVARCHAR(20) = NULL,
    @MaCTDP NVARCHAR(20) = NULL,
    @MaDV NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CTDV.MaCTDV, CTDV.MaCTDP, CTDV.MaDV, CTDV.SoLuong, CTDV.Gia, CTDV.ThanhTien,
           CTDV.CreatedAt, CTDV.CreatedBy, CTDV.UpdatedAt, CTDV.UpdatedBy, CTDV.IsActive,
           DV.TenDV, DV.LoaiDV, DV.ChoPhepDoiDiem, DV.GiaTriDoiDiem
    FROM CTDichVu CTDV
    LEFT JOIN DichVu DV ON CTDV.MaDV = DV.MaDV
    WHERE (@MaCTDV IS NULL OR CTDV.MaCTDV = @MaCTDV)
      AND (@MaCTDP IS NULL OR CTDV.MaCTDP = @MaCTDP)
      AND (@MaDV IS NULL OR CTDV.MaDV = @MaDV)
      AND (@IsActive IS NULL OR CTDV.IsActive = @IsActive)
    ORDER BY CTDV.CreatedAt DESC;
END
GO

-- [PROC - CHI TIẾT DỊCH VỤ] Thêm mới
CREATE OR ALTER PROC sp_InsertCTDichVu
    @MaCTDV NVARCHAR(20),
    @MaCTDP NVARCHAR(20),
    @MaDV NVARCHAR(20),
    @SoLuong INT,
    @Gia DECIMAL(10,2),
    @ThanhTien DECIMAL(12,2),
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CTDichVu (MaCTDV, MaCTDP, MaDV, SoLuong, Gia, ThanhTien, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaCTDV, @MaCTDP, @MaDV, @SoLuong, @Gia, @ThanhTien, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - CHI TIẾT DỊCH VỤ] Cập nhật
CREATE OR ALTER PROC sp_UpdateCTDichVu
    @MaCTDV NVARCHAR(20),
    @SoLuong INT = NULL,
    @Gia DECIMAL(10,2) = NULL,
    @ThanhTien DECIMAL(12,2) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CTDichVu
    SET SoLuong = ISNULL(@SoLuong, SoLuong),
        Gia = ISNULL(@Gia, Gia),
        ThanhTien = ISNULL(@ThanhTien, ThanhTien),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaCTDV = @MaCTDV;
END
GO

-- [PROC - CHI TIẾT DỊCH VỤ] Xóa
CREATE OR ALTER PROC sp_DeleteCTDichVu
    @MaCTDV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CTDichVu SET IsActive = 0 WHERE MaCTDV = @MaCTDV;
END
GO

-----------------------------------------------------------------------------------------------------------------------
-- 5.7 STORED PROCEDURES - ĐẶT PHÒNG (DatPhong)
-----------------------------------------------------------------------------------------------------------------------
-- [PROC - ĐẶT PHÒNG] Lấy danh sách
CREATE OR ALTER PROC sp_GetDatPhong
    @MaDP NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @MaNV NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        DP.MaDP, DP.MaKH, DP.MaNV, DP.NgayDen, DP.NgayDi, DP.NguoiLon, DP.TreEm, 
        DP.TongTien, DP.TrangThai, DP.GhiChu,
        DP.CreatedAt, DP.CreatedBy, DP.UpdatedAt, DP.UpdatedBy, DP.IsActive,
        KH.HoTen AS TenKH, KH.SDT AS SDTKH, KH.Email AS EmailKH,
        NV.HoTen AS TenNV
    FROM DatPhong DP
    LEFT JOIN KhachHang KH ON DP.MaKH = KH.MaKH
    LEFT JOIN NhanVien NV ON DP.MaNV = NV.MaNV
    WHERE (@MaDP IS NULL OR DP.MaDP = @MaDP)
      AND (@MaKH IS NULL OR DP.MaKH = @MaKH)
      AND (@MaNV IS NULL OR DP.MaNV = @MaNV)
      AND (@TrangThai IS NULL OR DP.TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR DP.IsActive = @IsActive)
    ORDER BY DP.CreatedAt DESC;
END
GO

-- [PROC - ĐẶT PHÒNG] Thêm mới
CREATE OR ALTER PROC sp_InsertDatPhong
    @MaDP NVARCHAR(20),
    @MaKH NVARCHAR(20),
    @MaNV NVARCHAR(20),
    @NgayDen DATETIME2 = NULL,
    @NgayDi DATETIME2 = NULL,
    @NguoiLon INT = 2,
    @TreEm INT = 0,
    @TongTien DECIMAL(12,2) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DatPhong (MaDP, MaKH, MaNV, NgayDen, NgayDi, NguoiLon, TreEm, TongTien, 
                          TrangThai, GhiChu, CreatedAt, CreatedBy, IsActive)
    VALUES (@MaDP, @MaKH, @MaNV, @NgayDen, @NgayDi, @NguoiLon, @TreEm, @TongTien,
            @TrangThai, @GhiChu, GETDATE(), @CreatedBy, @IsActive);
END
GO

-- [PROC - ĐẶT PHÒNG] Cập nhật
CREATE OR ALTER PROC sp_UpdateDatPhong
    @MaDP NVARCHAR(20),
    @NgayDen DATETIME2 = NULL,
    @NgayDi DATETIME2 = NULL,
    @NguoiLon INT = NULL,
    @TreEm INT = NULL,
    @TongTien DECIMAL(12,2) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DatPhong
    SET NgayDen = ISNULL(@NgayDen, NgayDen),
        NgayDi = ISNULL(@NgayDi, NgayDi),
        NguoiLon = ISNULL(@NguoiLon, NguoiLon),
        TreEm = ISNULL(@TreEm, TreEm),
        TongTien = ISNULL(@TongTien, TongTien),
        TrangThai = ISNULL(@TrangThai, TrangThai),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaDP = @MaDP;
END
GO

-- [PROC - ĐẶT PHÒNG] Xóa mềm
CREATE OR ALTER PROC sp_DeleteDatPhong
    @MaDP NVARCHAR(20),
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DatPhong 
    SET IsActive = 0, UpdatedBy = @UpdatedBy, UpdatedAt = GETDATE()
    WHERE MaDP = @MaDP;
END
GO

-----------------------------------------------------------------------------------------------------------------------
-- 5.8 STORED PROCEDURES - ĐẶT CỌC (DatCoc)
-----------------------------------------------------------------------------------------------------------------------
-- [PROC - ĐẶT CỌC] Lấy danh sách
CREATE OR ALTER PROC sp_GetDatCoc
    @MaDatCoc NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @LoaiCoc NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        DC.MaDatCoc, DC.MaDP, DC.MaCTSK, DC.MaKH, DC.SoTien, DC.NgayCoc,
        DC.HinhThucThanhToan, DC.LoaiCoc, DC.TrangThai, DC.GhiChu,
        DC.CreatedAt, DC.CreatedBy, DC.UpdatedAt, DC.UpdatedBy,
        KH.HoTen AS TenKH, KH.SDT AS SDTKH
    FROM DatCoc DC
    LEFT JOIN KhachHang KH ON DC.MaKH = KH.MaKH
    WHERE (@MaDatCoc IS NULL OR DC.MaDatCoc = @MaDatCoc)
      AND (@MaDP IS NULL OR DC.MaDP = @MaDP)
      AND (@MaKH IS NULL OR DC.MaKH = @MaKH)
      AND (@LoaiCoc IS NULL OR DC.LoaiCoc = @LoaiCoc)
      AND (@TrangThai IS NULL OR DC.TrangThai = @TrangThai)
    ORDER BY DC.CreatedAt DESC;
END
GO

-- [PROC - ĐẶT CỌC] Thêm mới
CREATE OR ALTER PROC sp_InsertDatCoc
    @MaDatCoc NVARCHAR(20),
    @MaDP NVARCHAR(20) = NULL,
    @MaCTSK NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20),
    @SoTien DECIMAL(18,2),
    @HinhThucThanhToan NVARCHAR(50) = NULL,
    @LoaiCoc NVARCHAR(50) = N'Đặt phòng',
    @TrangThai NVARCHAR(50) = N'ĐÃ NHẬN',
    @GhiChu NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DatCoc (MaDatCoc, MaDP, MaCTSK, MaKH, SoTien, NgayCoc, HinhThucThanhToan,
                        LoaiCoc, TrangThai, GhiChu, CreatedAt, CreatedBy)
    VALUES (@MaDatCoc, @MaDP, @MaCTSK, @MaKH, @SoTien, GETDATE(), @HinhThucThanhToan,
            @LoaiCoc, @TrangThai, @GhiChu, GETDATE(), @CreatedBy);
END
GO

-- [PROC - ĐẶT CỌC] Cập nhật
CREATE OR ALTER PROC sp_UpdateDatCoc
    @MaDatCoc NVARCHAR(20),
    @SoTien DECIMAL(18,2) = NULL,
    @HinhThucThanhToan NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DatCoc
    SET SoTien = ISNULL(@SoTien, SoTien),
        HinhThucThanhToan = ISNULL(@HinhThucThanhToan, HinhThucThanhToan),
        TrangThai = ISNULL(@TrangThai, TrangThai),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaDatCoc = @MaDatCoc;
END
GO

-----------------------------------------------------------------------------------------------------------------------
-- 5.9 STORED PROCEDURES - HOÀN CỌC (HoanCoc)
-----------------------------------------------------------------------------------------------------------------------
-- [PROC - HOÀN CỌC] Lấy danh sách
CREATE OR ALTER PROC sp_GetHoanCoc
    @MaPhieuHoan NVARCHAR(20) = NULL,
    @MaDatCoc NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        HC.MaPhieuHoan, HC.MaDatCoc, HC.SoTienHoan, HC.NgayHoan, HC.HinhThucHoan,
        HC.TrangThai, HC.GhiChu, HC.CreatedAt, HC.CreatedBy, HC.UpdatedAt, HC.UpdatedBy,
        DC.MaDP, DC.MaKH, DC.SoTien AS SoTienGoc
    FROM HoanCoc HC
    LEFT JOIN DatCoc DC ON HC.MaDatCoc = DC.MaDatCoc
    WHERE (@MaPhieuHoan IS NULL OR HC.MaPhieuHoan = @MaPhieuHoan)
      AND (@MaDatCoc IS NULL OR HC.MaDatCoc = @MaDatCoc)
      AND (@TrangThai IS NULL OR HC.TrangThai = @TrangThai)
    ORDER BY HC.CreatedAt DESC;
END
GO

-- [PROC - HOÀN CỌC] Thêm mới
CREATE OR ALTER PROC sp_InsertHoanCoc
    @MaPhieuHoan NVARCHAR(20),
    @MaDatCoc NVARCHAR(20),
    @SoTienHoan DECIMAL(18,2),
    @HinhThucHoan NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(50) = N'ĐÃ HOÀN',
    @GhiChu NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO HoanCoc (MaPhieuHoan, MaDatCoc, SoTienHoan, NgayHoan, HinhThucHoan,
                         TrangThai, GhiChu, CreatedAt, CreatedBy)
    VALUES (@MaPhieuHoan, @MaDatCoc, @SoTienHoan, GETDATE(), @HinhThucHoan,
            @TrangThai, @GhiChu, GETDATE(), @CreatedBy);
END
GO



-- [PROC - ĐIỂM KHÁCH HÀNG] Lấy điểm hiện tại
CREATE OR ALTER PROC sp_GetKhachHangDiem
    @MaKH NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaKH, DiemHienTai, CapNhatLuc, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
    FROM KhachHangDiem
    WHERE MaKH = @MaKH;
END
GO

-- [PROC - ĐIỂM KHÁCH HÀNG] Cập nhật điểm (trừ điểm khi thanh toán)
CREATE OR ALTER PROC sp_UpdateKhachHangDiem
    @MaKH NVARCHAR(20),
    @DiemTru INT,
    @GhiChu NVARCHAR(500) = NULL,
    @NguoiThucHien NVARCHAR(50) = NULL,
    @CreatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Cập nhật điểm hiện tại
        UPDATE KhachHangDiem
        SET DiemHienTai = DiemHienTai - @DiemTru,
            CapNhatLuc = GETDATE(),
            UpdatedBy = @CreatedBy,
            UpdatedAt = GETDATE()
        WHERE MaKH = @MaKH;
        
        -- Ghi lịch sử
        INSERT INTO KhachHangLichSuDiem (MaKH, Ngay, LoaiThaoTac, Diem, GhiChu, NguoiThucHien, CreatedBy, CreatedAt)
        VALUES (@MaKH, GETDATE(), N'TRU', @DiemTru, @GhiChu, @NguoiThucHien, @CreatedBy, GETDATE());
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

----Loại phòng
CREATE OR ALTER PROC sp_GetLoaiPhong
    @MaLP NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MaLP, TenLP, MoTa, IsNhaNguyenCan, SoPhongTrongNha, 
        GiaTheoGio, GiaTheoNgay, GiaTheoThang, SucChuaToiDa, 
        IsActive, CreatedBy, CreatedAt, UpdatedAt, UpdatedBy
    FROM 
        LoaiPhong
    WHERE 
        (@MaLP IS NULL OR MaLP = @MaLP)
        AND (@IsActive IS NULL OR IsActive = @IsActive);
END
GO

-- [PROC - DỊCH VỤ] Lấy danh sách
CREATE OR ALTER PROC sp_GetDichVu
    @MaDV NVARCHAR(20) = NULL,
    @LoaiDV NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaDV, TenDV, LoaiDV, MoTa, Gia, ChoPhepDoiDiem, GiaTriDoiDiem,
           CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM DichVu
    WHERE (@MaDV IS NULL OR MaDV = @MaDV)
      AND (@LoaiDV IS NULL OR LoaiDV = @LoaiDV)
      AND (@IsActive IS NULL OR IsActive = @IsActive)
    ORDER BY TenDV;
END
GO

-- [PROC - DỊCH VỤ] Thêm mới
CREATE OR ALTER PROC sp_InsertDichVu
    @MaDV NVARCHAR(20),
    @TenDV NVARCHAR(200),
    @LoaiDV NVARCHAR(50) = NULL,
    @MoTa NVARCHAR(500) = NULL,
    @Gia DECIMAL(10,2),
    @ChoPhepDoiDiem BIT = 0,
    @GiaTriDoiDiem INT = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DichVu (MaDV, TenDV, LoaiDV, MoTa, Gia, ChoPhepDoiDiem, GiaTriDoiDiem, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaDV, @TenDV, @LoaiDV, @MoTa, @Gia, @ChoPhepDoiDiem, @GiaTriDoiDiem, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - DỊCH VỤ] Cập nhật
CREATE OR ALTER PROC sp_UpdateDichVu
    @MaDV NVARCHAR(20),
    @TenDV NVARCHAR(200) = NULL,
    @LoaiDV NVARCHAR(50) = NULL,
    @MoTa NVARCHAR(500) = NULL,
    @Gia DECIMAL(10,2) = NULL,
    @ChoPhepDoiDiem BIT = NULL,
    @GiaTriDoiDiem INT = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DichVu
    SET TenDV = ISNULL(@TenDV, TenDV),
        LoaiDV = ISNULL(@LoaiDV, LoaiDV),
        MoTa = ISNULL(@MoTa, MoTa),
        Gia = ISNULL(@Gia, Gia),
        ChoPhepDoiDiem = ISNULL(@ChoPhepDoiDiem, ChoPhepDoiDiem),
        GiaTriDoiDiem = ISNULL(@GiaTriDoiDiem, GiaTriDoiDiem),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaDV = @MaDV;
END
GO

-- [PROC - DỊCH VỤ] Xóa
CREATE OR ALTER PROC sp_DeleteDichVu
    @MaDV NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DichVu SET IsActive = 0 WHERE MaDV = @MaDV;
END
GO
-- [PROC - LOẠI PHÒNG] Thêm mới
CREATE OR ALTER PROC sp_InsertLoaiPhong
    @MaLP NVARCHAR(20),
    @TenLP NVARCHAR(100),
    @MoTa NVARCHAR(500) = NULL,
    @IsNhaNguyenCan BIT = 0,
    @SoPhongTrongNha INT = NULL,
    @GiaTheoGio DECIMAL(18,2) = NULL,
    @GiaTheoNgay DECIMAL(18,2),
    @GiaTheoThang DECIMAL(18,2) = NULL,
    @SucChuaToiDa INT,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LoaiPhong (MaLP, TenLP, MoTa, IsNhaNguyenCan, SoPhongTrongNha, 
                          GiaTheoGio, GiaTheoNgay, GiaTheoThang, SucChuaToiDa, 
                          CreatedBy, CreatedAt, IsActive)
    VALUES (@MaLP, @TenLP, @MoTa, @IsNhaNguyenCan, @SoPhongTrongNha,
            @GiaTheoGio, @GiaTheoNgay, @GiaTheoThang, @SucChuaToiDa,
            @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - LOẠI PHÒNG] Cập nhật
CREATE OR ALTER PROC sp_UpdateLoaiPhong
    @MaLP NVARCHAR(20),
    @TenLP NVARCHAR(100) = NULL,
    @MoTa NVARCHAR(500) = NULL,
    @IsNhaNguyenCan BIT = NULL,
    @SoPhongTrongNha INT = NULL,
    @GiaTheoGio DECIMAL(18,2) = NULL,
    @GiaTheoNgay DECIMAL(18,2) = NULL,
    @GiaTheoThang DECIMAL(18,2) = NULL,
    @SucChuaToiDa INT = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LoaiPhong
    SET TenLP = ISNULL(@TenLP, TenLP),
        MoTa = ISNULL(@MoTa, MoTa),
        IsNhaNguyenCan = ISNULL(@IsNhaNguyenCan, IsNhaNguyenCan),
        SoPhongTrongNha = ISNULL(@SoPhongTrongNha, SoPhongTrongNha),
        GiaTheoGio = ISNULL(@GiaTheoGio, GiaTheoGio),
        GiaTheoNgay = ISNULL(@GiaTheoNgay, GiaTheoNgay),
        GiaTheoThang = ISNULL(@GiaTheoThang, GiaTheoThang),
        SucChuaToiDa = ISNULL(@SucChuaToiDa, SucChuaToiDa),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaLP = @MaLP;
END
GO

-- [PROC - LOẠI PHÒNG] Xóa
CREATE OR ALTER PROC sp_DeleteLoaiPhong
    @MaLP NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LoaiPhong SET IsActive = 0 WHERE MaLP = @MaLP;
END
GO
-- [PROC - LOẠI THANH TOÁN] Lấy danh sách
CREATE OR ALTER PROC sp_GetLoaiThanhToan
    @MaLTT NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLTT, TenLTT, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM LoaiThanhToan
    WHERE (@MaLTT IS NULL OR MaLTT = @MaLTT)
      AND (@IsActive IS NULL OR IsActive = @IsActive)
    ORDER BY TenLTT;
END
GO

-- [PROC - LOẠI THANH TOÁN] Thêm mới
CREATE OR ALTER PROC sp_InsertLoaiThanhToan
    @MaLTT NVARCHAR(20),
    @TenLTT NVARCHAR(100),
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LoaiThanhToan (MaLTT, TenLTT, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaLTT, @TenLTT, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - LOẠI THANH TOÁN] Cập nhật
CREATE OR ALTER PROC sp_UpdateLoaiThanhToan
    @MaLTT NVARCHAR(20),
    @TenLTT NVARCHAR(100) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LoaiThanhToan
    SET TenLTT = ISNULL(@TenLTT, TenLTT),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaLTT = @MaLTT;
END
GO

-- [PROC - LOẠI THANH TOÁN] Xóa
CREATE OR ALTER PROC sp_DeleteLoaiThanhToan
    @MaLTT NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LoaiThanhToan SET IsActive = 0 WHERE MaLTT = @MaLTT;
END
GO
-- [PROC - KHUYẾN MÃI] Lấy danh sách
CREATE OR ALTER PROC sp_GetKhuyenMai
    @MaKM NVARCHAR(20) = NULL,
    @IsActive BIT = NULL,
    @NgayHienTai DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT KM.MaKM, KM.TenKM, KM.IsPhanTram, KM.GiaTri, KM.MaLKH, KM.MaCN, 
           KM.MaLP, KM.MaPhong, KM.CouponCode, KM.NgayBD, KM.NgayKT, 
           KM.DieuKien, KM.CreatedAt, KM.CreatedBy, KM.UpdatedAt, 
           KM.UpdatedBy, KM.IsActive,
           LKH.TenLKH, CN.TenCN, LP.TenLP, P.SoPhong
    FROM KhuyenMai KM
    LEFT JOIN LoaiKhachHang LKH ON KM.MaLKH = LKH.MaLKH
    LEFT JOIN ChiNhanh CN ON KM.MaCN = CN.MaCN
    LEFT JOIN LoaiPhong LP ON KM.MaLP = LP.MaLP
    LEFT JOIN Phong P ON KM.MaPhong = P.MaPhong
    WHERE (@MaKM IS NULL OR KM.MaKM = @MaKM)
      AND (@IsActive IS NULL OR KM.IsActive = @IsActive)
      AND (@NgayHienTai IS NULL OR (@NgayHienTai BETWEEN KM.NgayBD AND KM.NgayKT))
    ORDER BY KM.CreatedAt DESC;
END
GO

-- [PROC - KHUYẾN MÃI] Thêm mới
CREATE OR ALTER PROC sp_InsertKhuyenMai
    @MaKM NVARCHAR(20),
    @TenKM NVARCHAR(200),
    @IsPhanTram BIT = 1,
    @GiaTri DECIMAL(12,2),
    @MaLKH NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @MaLP NVARCHAR(20) = NULL,
    @MaPhong NVARCHAR(20) = NULL,
    @CouponCode NVARCHAR(100) = NULL,
    @NgayBD DATETIME2,
    @NgayKT DATETIME2,
    @DieuKien NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO KhuyenMai (MaKM, TenKM, IsPhanTram, GiaTri, MaLKH, MaCN, MaLP, MaPhong,
                          CouponCode, NgayBD, NgayKT, DieuKien, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaKM, @TenKM, @IsPhanTram, @GiaTri, @MaLKH, @MaCN, @MaLP, @MaPhong,
            @CouponCode, @NgayBD, @NgayKT, @DieuKien, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - KHUYẾN MÃI] Cập nhật
CREATE OR ALTER PROC sp_UpdateKhuyenMai
    @MaKM NVARCHAR(20),
    @TenKM NVARCHAR(200) = NULL,
    @IsPhanTram BIT = NULL,
    @GiaTri DECIMAL(12,2) = NULL,
    @MaLKH NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @MaLP NVARCHAR(20) = NULL,
    @MaPhong NVARCHAR(20) = NULL,
    @CouponCode NVARCHAR(100) = NULL,
    @NgayBD DATETIME2 = NULL,
    @NgayKT DATETIME2 = NULL,
    @DieuKien NVARCHAR(500) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE KhuyenMai
    SET TenKM = ISNULL(@TenKM, TenKM),
        IsPhanTram = ISNULL(@IsPhanTram, IsPhanTram),
        GiaTri = ISNULL(@GiaTri, GiaTri),
        MaLKH = ISNULL(@MaLKH, MaLKH),
        MaCN = ISNULL(@MaCN, MaCN),
        MaLP = ISNULL(@MaLP, MaLP),
        MaPhong = ISNULL(@MaPhong, MaPhong),
        CouponCode = ISNULL(@CouponCode, CouponCode),
        NgayBD = ISNULL(@NgayBD, NgayBD),
        NgayKT = ISNULL(@NgayKT, NgayKT),
        DieuKien = ISNULL(@DieuKien, DieuKien),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaKM = @MaKM;
END
GO

-- [PROC - KHUYẾN MÃI] Xóa
CREATE OR ALTER PROC sp_DeleteKhuyenMai
    @MaKM NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE KhuyenMai SET IsActive = 0 WHERE MaKM = @MaKM;
END
GO
-- [PROC - HÓA ĐƠN] Lấy danh sách
CREATE OR ALTER PROC sp_GetHoaDon
    @MaHD NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT HD.MaHD, HD.MaDP, HD.MaKH, HD.MaNV, HD.MaKM, HD.MaCN, HD.TrangThai,
           HD.NgayLap, HD.TongTruocKM, HD.TongTien, HD.CreatedAt, HD.CreatedBy,
           HD.UpdatedAt, HD.UpdatedBy, HD.IsActive,
           KH.HoTen AS TenKH, NV.HoTen AS TenNV, CN.TenCN, KM.TenKM
    FROM HoaDon HD
    LEFT JOIN KhachHang KH ON HD.MaKH = KH.MaKH
    LEFT JOIN NhanVien NV ON HD.MaNV = NV.MaNV
    LEFT JOIN ChiNhanh CN ON HD.MaCN = CN.MaCN
    LEFT JOIN KhuyenMai KM ON HD.MaKM = KM.MaKM
    WHERE (@MaHD IS NULL OR HD.MaHD = @MaHD)
      AND (@MaDP IS NULL OR HD.MaDP = @MaDP)
      AND (@MaKH IS NULL OR HD.MaKH = @MaKH)
      AND (@MaCN IS NULL OR HD.MaCN = @MaCN)
      AND (@TrangThai IS NULL OR HD.TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR HD.IsActive = @IsActive)
    ORDER BY HD.NgayLap DESC;
END
GO

-- [PROC - HÓA ĐƠN] Thêm mới
CREATE OR ALTER PROC sp_InsertHoaDon
    @MaHD NVARCHAR(20),
    @MaDP NVARCHAR(20),
    @MaKH NVARCHAR(20),
    @MaNV NVARCHAR(20),
    @MaKM NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20),
    @TrangThai NVARCHAR(50) = N'Chưa TT',
    @NgayLap DATETIME2 = NULL,
    @TongTruocKM DECIMAL(12,2) = 0,
    @TongTien DECIMAL(12,2) = 0,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO HoaDon (MaHD, MaDP, MaKH, MaNV, MaKM, MaCN, TrangThai, NgayLap,
                       TongTruocKM, TongTien, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaHD, @MaDP, @MaKH, @MaNV, @MaKM, @MaCN, @TrangThai, 
            ISNULL(@NgayLap, GETDATE()), @TongTruocKM, @TongTien, 
            @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - HÓA ĐƠN] Cập nhật
CREATE OR ALTER PROC sp_UpdateHoaDon
    @MaHD NVARCHAR(20),
    @TrangThai NVARCHAR(50) = NULL,
    @TongTruocKM DECIMAL(12,2) = NULL,
    @TongTien DECIMAL(12,2) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE HoaDon
    SET TrangThai = ISNULL(@TrangThai, TrangThai),
        TongTruocKM = ISNULL(@TongTruocKM, TongTruocKM),
        TongTien = ISNULL(@TongTien, TongTien),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaHD = @MaHD;
END
GO

-- [PROC - CHI TIẾT HÓA ĐƠN] Lấy danh sách
CREATE OR ALTER PROC sp_GetCTHoaDon
    @MaCTHD NVARCHAR(20) = NULL,
    @MaHD NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaCTHD, MaHD, MoTa, SoLuong, DonGia, ThanhTien,
           CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM CTHoaDon
    WHERE (@MaCTHD IS NULL OR MaCTHD = @MaCTHD)
      AND (@MaHD IS NULL OR MaHD = @MaHD)
      AND (@IsActive IS NULL OR IsActive = @IsActive)
    ORDER BY CreatedAt;
END
GO

-- [PROC - CHI TIẾT HÓA ĐƠN] Thêm mới
CREATE OR ALTER PROC sp_InsertCTHoaDon
    @MaCTHD NVARCHAR(20),
    @MaHD NVARCHAR(20),
    @MoTa NVARCHAR(500) = NULL,
    @SoLuong INT,
    @DonGia DECIMAL(10,2),
    @ThanhTien DECIMAL(12,2),
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CTHoaDon (MaCTHD, MaHD, MoTa, SoLuong, DonGia, ThanhTien, 
                         CreatedBy, CreatedAt, IsActive)
    VALUES (@MaCTHD, @MaHD, @MoTa, @SoLuong, @DonGia, @ThanhTien,
            @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - THANH TOÁN] Lấy danh sách
CREATE OR ALTER PROC sp_GetThanhToan
    @MaTT NVARCHAR(20) = NULL,
    @MaHD NVARCHAR(20) = NULL,
    @MaLTT NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TT.MaTT, TT.MaHD, TT.SoTien, TT.MaLTT, TT.NgayTT,
           TT.CreatedAt, TT.CreatedBy, TT.UpdatedAt, TT.UpdatedBy, TT.IsActive,
           LTT.TenLTT, HD.MaKH, HD.TongTien
    FROM ThanhToan TT
    LEFT JOIN LoaiThanhToan LTT ON TT.MaLTT = LTT.MaLTT
    LEFT JOIN HoaDon HD ON TT.MaHD = HD.MaHD
    WHERE (@MaTT IS NULL OR TT.MaTT = @MaTT)
      AND (@MaHD IS NULL OR TT.MaHD = @MaHD)
      AND (@MaLTT IS NULL OR TT.MaLTT = @MaLTT)
      AND (@IsActive IS NULL OR TT.IsActive = @IsActive)
    ORDER BY TT.NgayTT DESC;
END
GO

-- [PROC - THANH TOÁN] Thêm mới
CREATE OR ALTER PROC sp_InsertThanhToan
    @MaTT NVARCHAR(20),
    @MaHD NVARCHAR(20),
    @SoTien DECIMAL(12,2),
    @MaLTT NVARCHAR(20),
    @NgayTT DATETIME2 = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ThanhToan (MaTT, MaHD, SoTien, MaLTT, NgayTT, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaTT, @MaHD, @SoTien, @MaLTT, ISNULL(@NgayTT, GETDATE()), @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - THANH TOÁN] Cập nhật
CREATE OR ALTER PROC sp_UpdateThanhToan
    @MaTT NVARCHAR(20),
    @SoTien DECIMAL(12,2) = NULL,
    @MaLTT NVARCHAR(20) = NULL,
    @NgayTT DATETIME2 = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ThanhToan
    SET SoTien = ISNULL(@SoTien, SoTien),
        MaLTT = ISNULL(@MaLTT, MaLTT),
        NgayTT = ISNULL(@NgayTT, NgayTT),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaTT = @MaTT;
END
GO

-- [PROC - THANH TOÁN] Xóa
CREATE OR ALTER PROC sp_DeleteThanhToan
    @MaTT NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ThanhToan SET IsActive = 0 WHERE MaTT = @MaTT;
END
GO

-- ==========================================
-- STORED PROCEDURES CHO ĐỒ THẤT LẠC (LOST FOUND)
-- ==========================================

-- [PROC - LOST FOUND] Lấy danh sách
CREATE OR ALTER PROC sp_GetLostFound
    @MaLF NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @MaNV NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT LF.MaLF, LF.MaKH, LF.MaNV, LF.MaCN, LF.TenDo, LF.NgayTimThay, 
           LF.DiaDiemTim, LF.TrangThai, LF.NgayTra, LF.NguoiNhan, LF.GhiChu,
           LF.CreatedAt, LF.UpdatedBy, LF.UpdatedAt,
           KH.HoTen AS TenKH, NV.HoTen AS TenNV, CN.TenCN AS TenCN
    FROM LostFound LF
    LEFT JOIN KhachHang KH ON LF.MaKH = KH.MaKH
    LEFT JOIN NhanVien NV ON LF.MaNV = NV.MaNV
    LEFT JOIN ChiNhanh CN ON LF.MaCN = CN.MaCN
    WHERE (@MaLF IS NULL OR LF.MaLF = @MaLF)
      AND (@MaKH IS NULL OR LF.MaKH = @MaKH)
      AND (@MaNV IS NULL OR LF.MaNV = @MaNV)
      AND (@MaCN IS NULL OR LF.MaCN = @MaCN)
      AND (@TrangThai IS NULL OR LF.TrangThai = @TrangThai)
    ORDER BY LF.NgayTimThay DESC;
END
GO

-- [PROC - LOST FOUND] Thêm mới
CREATE OR ALTER PROC sp_InsertLostFound
    @MaLF NVARCHAR(20),
    @MaKH NVARCHAR(20) = NULL,
    @MaNV NVARCHAR(20),
    @MaCN NVARCHAR(20),
    @TenDo NVARCHAR(200),
    @NgayTimThay DATETIME2,
    @DiaDiemTim NVARCHAR(300) = NULL,
    @TrangThai NVARCHAR(50) = N'Chưa trả',
    @GhiChu NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO LostFound (MaLF, MaKH, MaNV, MaCN, TenDo, NgayTimThay, DiaDiemTim, TrangThai, GhiChu, CreatedAt)
    VALUES (@MaLF, @MaKH, @MaNV, @MaCN, @TenDo, @NgayTimThay, @DiaDiemTim, @TrangThai, @GhiChu, GETDATE());
END
GO

-- [PROC - LOST FOUND] Cập nhật
CREATE OR ALTER PROC sp_UpdateLostFound
    @MaLF NVARCHAR(20),
    @MaKH NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @NgayTra DATETIME2 = NULL,
    @NguoiNhan NVARCHAR(200) = NULL,
    @GhiChu NVARCHAR(300) = NULL,
    @UpdatedBy NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LostFound
    SET MaKH = ISNULL(@MaKH, MaKH),
        TrangThai = ISNULL(@TrangThai, TrangThai),
        NgayTra = ISNULL(@NgayTra, NgayTra),
        NguoiNhan = ISNULL(@NguoiNhan, NguoiNhan),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaLF = @MaLF;
END
GO

CREATE OR ALTER PROC sp_GetAllEvents
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaSK, TenSK, MoTa, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM SuKien
    WHERE @IsActive IS NULL OR IsActive = @IsActive
    ORDER BY TenSK;
END
GO

CREATE OR ALTER PROC sp_GetEventByID
    @MaSK NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaSK, TenSK, MoTa, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM SuKien
    WHERE MaSK = @MaSK;
END
GO

CREATE OR ALTER PROC sp_InsertEvent
    @MaSK NVARCHAR(20),
    @TenSK NVARCHAR(200),
    @MoTa NVARCHAR(500),
    @CreatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SuKien (MaSK, TenSK, MoTa, CreatedBy, IsActive)
    VALUES (@MaSK, @TenSK, @MoTa, @CreatedBy, 1);
END
GO

CREATE OR ALTER PROC sp_UpdateEvent
    @MaSK NVARCHAR(20),
    @TenSK NVARCHAR(200),
    @MoTa NVARCHAR(500),
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SuKien
    SET TenSK = @TenSK,
        MoTa = @MoTa,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaSK = @MaSK;
END
GO

CREATE OR ALTER PROC sp_DeleteEvent
    @MaSK NVARCHAR(20),
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SuKien
    SET IsActive = 0,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaSK = @MaSK;
END
GO

GO

-- ==========================================
-- STORED PROCEDURES CHO KHIẾU NẠI (COMPLAINT)
-- ==========================================

-- [PROC - KHIẾU NẠI] Lấy danh sách
CREATE OR ALTER PROC sp_GetComplaint
    @MaKN NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @MaNV NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @MucDo NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT C.MaKN, C.MaKH, C.MaNV, C.MaCN, C.NgayGhi, C.NoiDung, C.MucDo,
           C.TrangThai, C.KetQua, C.SoTienBoiThuong, C.GhiChu,
           C.CreatedAt, C.UpdatedBy, C.UpdatedAt,
           KH.HoTen AS TenKH, NV.HoTen AS TenNV, CN.TenCN AS TenCN
    FROM Complaint C
    LEFT JOIN KhachHang KH ON C.MaKH = KH.MaKH
    LEFT JOIN NhanVien NV ON C.MaNV = NV.MaNV
    LEFT JOIN ChiNhanh CN ON C.MaCN = CN.MaCN
    WHERE (@MaKN IS NULL OR C.MaKN = @MaKN)
      AND (@MaKH IS NULL OR C.MaKH = @MaKH)
      AND (@MaNV IS NULL OR C.MaNV = @MaNV)
      AND (@MaCN IS NULL OR C.MaCN = @MaCN)
      AND (@TrangThai IS NULL OR C.TrangThai = @TrangThai)
      AND (@MucDo IS NULL OR C.MucDo = @MucDo)
    ORDER BY C.NgayGhi DESC;
END
GO

-- [PROC - KHIẾU NẠI] Thêm mới
CREATE OR ALTER PROC sp_InsertComplaint
    @MaKN NVARCHAR(20),
    @MaKH NVARCHAR(20),
    @MaCN NVARCHAR(20),
    @NoiDung NVARCHAR(500),
    @MucDo NVARCHAR(50) = N'Thường',
    @TrangThai NVARCHAR(50) = N'Chưa xử lý',
    @GhiChu NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Complaint (MaKN, MaKH, MaCN, NgayGhi, NoiDung, MucDo, TrangThai, GhiChu, CreatedAt)
    VALUES (@MaKN, @MaKH, @MaCN, GETDATE(), @NoiDung, @MucDo, @TrangThai, @GhiChu, GETDATE());
END
GO

-- [PROC - KHIẾU NẠI] Cập nhật
CREATE OR ALTER PROC sp_UpdateComplaint
    @MaKN NVARCHAR(20),
    @MaNV NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @KetQua NVARCHAR(300) = NULL,
    @SoTienBoiThuong DECIMAL(12,2) = NULL,
    @GhiChu NVARCHAR(300) = NULL,
    @UpdatedBy NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Complaint
    SET MaNV = ISNULL(@MaNV, MaNV),
        TrangThai = ISNULL(@TrangThai, TrangThai),
        KetQua = ISNULL(@KetQua, KetQua),
        SoTienBoiThuong = ISNULL(@SoTienBoiThuong, SoTienBoiThuong),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaKN = @MaKN;
END
GO

-- ==========================================
-- STORED PROCEDURES CHO VOUCHER
-- ==========================================

-- [PROC - VOUCHER] Lấy danh sách
CREATE OR ALTER PROC sp_GetVoucher
    @MaVoucher NVARCHAR(20) = NULL,
    @CouponCode NVARCHAR(100) = NULL,
    @MaLKH NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT V.MaVoucher, V.TenVoucher, V.CouponCode, V.IsPhanTram, V.GiaTri,
           V.SoLuong, V.SoLuongDaDung, V.MaLKH, V.MaCN, V.MaLP, V.MaPhong,
           V.NgayBD, V.NgayKT, V.DieuKien, V.TrangThai,
           V.CreatedAt, V.CreatedBy, V.UpdatedAt, V.UpdatedBy, V.IsActive,
           LKH.TenLKH, CN.TenCN, LP.TenLP, P.SoPhong
    FROM Voucher V
    LEFT JOIN LoaiKhachHang LKH ON V.MaLKH = LKH.MaLKH
    LEFT JOIN ChiNhanh CN ON V.MaCN = CN.MaCN
    LEFT JOIN LoaiPhong LP ON V.MaLP = LP.MaLP
    LEFT JOIN Phong P ON V.MaPhong = P.MaPhong
    WHERE (@MaVoucher IS NULL OR V.MaVoucher = @MaVoucher)
      AND (@CouponCode IS NULL OR V.CouponCode = @CouponCode)
      AND (@MaLKH IS NULL OR V.MaLKH = @MaLKH)
      AND (@MaCN IS NULL OR V.MaCN = @MaCN)
      AND (@TrangThai IS NULL OR V.TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR V.IsActive = @IsActive)
    ORDER BY V.CreatedAt DESC;
END
GO

-- [PROC - VOUCHER] Thêm mới
CREATE OR ALTER PROC sp_InsertVoucher
    @MaVoucher NVARCHAR(20),
    @TenVoucher NVARCHAR(200),
    @CouponCode NVARCHAR(100) = NULL,
    @IsPhanTram BIT = 1,
    @GiaTri DECIMAL(12,2) = NULL,
    @SoLuong INT = NULL,
    @MaLKH NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @MaLP NVARCHAR(20) = NULL,
    @MaPhong NVARCHAR(20) = NULL,
    @NgayBD DATETIME2 = NULL,
    @NgayKT DATETIME2 = NULL,
    @DieuKien NVARCHAR(500) = NULL,
    @TrangThai NVARCHAR(50) = N'Active',
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Voucher (MaVoucher, TenVoucher, CouponCode, IsPhanTram, GiaTri, SoLuong, 
                        SoLuongDaDung, MaLKH, MaCN, MaLP, MaPhong, NgayBD, NgayKT, 
                        DieuKien, TrangThai, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaVoucher, @TenVoucher, @CouponCode, @IsPhanTram, @GiaTri, @SoLuong, 0,
            @MaLKH, @MaCN, @MaLP, @MaPhong, @NgayBD, @NgayKT, @DieuKien, @TrangThai,
            @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - VOUCHER] Cập nhật
CREATE OR ALTER PROC sp_UpdateVoucher
    @MaVoucher NVARCHAR(20),
    @TenVoucher NVARCHAR(200) = NULL,
    @IsPhanTram BIT = NULL,
    @GiaTri DECIMAL(12,2) = NULL,
    @SoLuong INT = NULL,
    @NgayBD DATETIME2 = NULL,
    @NgayKT DATETIME2 = NULL,
    @DieuKien NVARCHAR(500) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Voucher
    SET TenVoucher = ISNULL(@TenVoucher, TenVoucher),
        IsPhanTram = ISNULL(@IsPhanTram, IsPhanTram),
        GiaTri = ISNULL(@GiaTri, GiaTri),
        SoLuong = ISNULL(@SoLuong, SoLuong),
        NgayBD = ISNULL(@NgayBD, NgayBD),
        NgayKT = ISNULL(@NgayKT, NgayKT),
        DieuKien = ISNULL(@DieuKien, DieuKien),
        TrangThai = ISNULL(@TrangThai, TrangThai),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaVoucher = @MaVoucher;
END
GO

-- [PROC - VOUCHER USAGE] Lấy danh sách
CREATE OR ALTER PROC sp_GetVoucherUsage
    @MaSuDung NVARCHAR(20) = NULL,
    @MaVoucher NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @MaHD NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT VU.MaSuDung, VU.MaVoucher, VU.MaKH, VU.MaHD, VU.MaDP, VU.NgaySuDung,
           VU.GiaTriApDung, VU.GhiChu, VU.CreatedBy, VU.CreatedAt,
           V.TenVoucher, KH.HoTen AS TenKH
    FROM VoucherUsage VU
    LEFT JOIN Voucher V ON VU.MaVoucher = V.MaVoucher
    LEFT JOIN KhachHang KH ON VU.MaKH = KH.MaKH
    WHERE (@MaSuDung IS NULL OR VU.MaSuDung = @MaSuDung)
      AND (@MaVoucher IS NULL OR VU.MaVoucher = @MaVoucher)
      AND (@MaKH IS NULL OR VU.MaKH = @MaKH)
      AND (@MaHD IS NULL OR VU.MaHD = @MaHD)
    ORDER BY VU.NgaySuDung DESC;
END
GO

-- [PROC - VOUCHER USAGE] Thêm mới
CREATE OR ALTER PROC sp_InsertVoucherUsage
    @MaSuDung NVARCHAR(20),
    @MaVoucher NVARCHAR(20),
    @MaKH NVARCHAR(20) = NULL,
    @MaHD NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @GiaTriApDung DECIMAL(12,2) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Thêm bản ghi sử dụng
        INSERT INTO VoucherUsage (MaSuDung, MaVoucher, MaKH, MaHD, MaDP, NgaySuDung,
                                 GiaTriApDung, GhiChu, CreatedBy, CreatedAt)
        VALUES (@MaSuDung, @MaVoucher, @MaKH, @MaHD, @MaDP, GETDATE(),
                @GiaTriApDung, @GhiChu, @CreatedBy, GETDATE());
        
        -- Tăng số lượng đã dùng
        UPDATE Voucher
        SET SoLuongDaDung = SoLuongDaDung + 1
        WHERE MaVoucher = @MaVoucher;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
--------------------------------
GO

-- Tạo bảng GoiSuKien (Event Package)

-- [PROC - THỐNG KÊ] Doanh thu
CREATE OR ALTER PROC sp_GetDoanhThu
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(TongTien), 0) as DoanhThu
    FROM HoaDon
    WHERE IsActive = 1 AND TrangThai = N'Đã TT'
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayLap) = @Year)
      AND (@Month IS NULL OR MONTH(NgayLap) = @Month);
END
GO

-- [PROC - THỐNG KÊ] Chi phí
CREATE OR ALTER PROC sp_GetChiPhi
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(SoTienBoiThuong), 0) as ChiPhi
    FROM Complaint
    WHERE TrangThai = N'Đã xử lý' AND SoTienBoiThuong > 0
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayGhi) = @Year)
      AND (@Month IS NULL OR MONTH(NgayGhi) = @Month);
END
GO

-- [PROC - THỐNG KÊ] Tổng đặt cọc
CREATE OR ALTER PROC sp_GetTongDatCoc
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(SoTien), 0) as DatCoc
    FROM DatCoc
    WHERE TrangThai = N'ĐÃ NHẬN'
      AND (@Year IS NULL OR YEAR(NgayCoc) = @Year)
      AND (@Month IS NULL OR MONTH(NgayCoc) = @Month)
      AND (
          @MaCN IS NULL OR 
          MaDP IN (
              SELECT DP.MaDP 
              FROM DatPhong DP
              INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
              INNER JOIN Phong P ON CTDP.MaPhong = P.MaPhong
              WHERE P.MaCN = @MaCN
          ) OR
          MaCTSK IN (
              SELECT ct.MaCTSK 
              FROM CTSuKien ct
              INNER JOIN GoiSuKien g ON ct.MaGoiSK = g.MaGoiSK
              WHERE g.MaCN = @MaCN
          )
      );
END
GO

-- [PROC - THỐNG KÊ] Hoàn tiền
CREATE OR ALTER PROC sp_GetHoanTien
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(SoTien), 0) as HoanTien
    FROM Refund
    WHERE IsActive = 1
      AND (@Year IS NULL OR YEAR(NgayHoan) = @Year)
      AND (@Month IS NULL OR MONTH(NgayHoan) = @Month)
      AND (
          @MaCN IS NULL OR 
          MaDP IN (SELECT MaDP FROM DatPhong WHERE MaCN = @MaCN) OR
          MaCTSK IN (SELECT MaCTSK FROM CTSuKien WHERE MaSK IN (SELECT MaSK FROM SuKien WHERE MaCN = @MaCN))
      );
END
GO

-- [PROC - THỐNG KÊ] Tổng đặt phòng
CREATE OR ALTER PROC sp_GetTongDatPhong
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(DISTINCT DP.MaDP) as TongDP
    FROM DatPhong DP
    INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    INNER JOIN Phong P ON CTDP.MaPhong = P.MaPhong
    WHERE DP.IsActive = 1
      AND (@MaCN IS NULL OR P.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(CTDP.NgayDen) = @Year)
      AND (@Month IS NULL OR MONTH(CTDP.NgayDen) = @Month);
END
GO

-- [PROC - THỐNG KÊ] Đặt phòng theo trạng thái
CREATE OR ALTER PROC sp_GetDatPhongTheoTrangThai
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50),
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(DISTINCT DP.MaDP) as TongDP
    FROM DatPhong DP
    INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    INNER JOIN Phong P ON CTDP.MaPhong = P.MaPhong
    WHERE DP.IsActive = 1 AND CTDP.TrangThai = @TrangThai
      AND (@MaCN IS NULL OR P.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(CTDP.NgayDen) = @Year)
      AND (@Month IS NULL OR MONTH(CTDP.NgayDen) = @Month);
END
GO

-- [PROC - THỐNG KÊ] Tổng sự kiện
CREATE OR ALTER PROC sp_GetTongSuKien
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) as TongSK
    FROM CTSuKien ct
    INNER JOIN GoiSuKien g ON ct.MaGoiSK = g.MaGoiSK
    WHERE ct.IsActive = 1
      AND (@Year IS NULL OR YEAR(ct.NgayToChuc) = @Year)
      AND (@Month IS NULL OR MONTH(ct.NgayToChuc) = @Month)
      AND (@MaCN IS NULL OR g.MaCN = @MaCN);
END
GO

-- [PROC - THỐNG KÊ] Doanh thu sự kiện
CREATE OR ALTER PROC sp_GetDoanhThuSuKien
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(ct.ThanhTien), 0) as DoanhThu
    FROM CTSuKien ct
    INNER JOIN GoiSuKien g ON ct.MaGoiSK = g.MaGoiSK
    WHERE ct.IsActive = 1 
      AND ct.TrangThai IN (N'Hoàn thành', N'Đã thanh toán')
      AND (@Year IS NULL OR YEAR(ct.NgayToChuc) = @Year)
      AND (@Month IS NULL OR MONTH(ct.NgayToChuc) = @Month)
      AND (@MaCN IS NULL OR g.MaCN = @MaCN);
END
GO

-- [PROC - THỐNG KÊ] Tổng khách hàng
CREATE OR ALTER PROC sp_GetTongKhachHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) as TongKH
    FROM KhachHang
    WHERE IsActive = 1;
END
GO

-- [PROC - THỐNG KÊ] Khách hàng mới
CREATE OR ALTER PROC sp_GetKhachHangMoi
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) as TongKH
    FROM KhachHang
    WHERE IsActive = 1
      AND (@Year IS NULL OR YEAR(CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(CreatedAt) = @Month);
END
GO

-- [PROC - THỐNG KÊ] Doanh thu dịch vụ
CREATE OR ALTER PROC sp_GetDoanhThuDichVu
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(CTDV.ThanhTien), 0) as DoanhThu
    FROM CTDichVu CTDV
    INNER JOIN CTDatPhong CTDP ON CTDV.MaCTDP = CTDP.MaCTDP
    INNER JOIN Phong P ON CTDP.MaPhong = P.MaPhong
    WHERE CTDV.IsActive = 1
      AND (@MaCN IS NULL OR P.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(CTDV.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(CTDV.CreatedAt) = @Month);
END

GO

-- ============ STORED PROCEDURES CHO VOUCHER ============

-- Lấy danh sách voucher
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetVouchers')
    DROP PROC sp_GetVouchers;
GO

CREATE PROC sp_GetVouchers
    @MaVoucher NVARCHAR(20) = NULL,
    @CouponCode NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SELECT 
        MaVoucher, TenVoucher, CouponCode, IsPhanTram, GiaTri,
        SoLuong, SoLuongDaDung, MaLKH, MaCN, MaLP, MaPhong,
        NgayBD, NgayKT, DieuKien, TrangThai,
        CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM Voucher
    WHERE (@MaVoucher IS NULL OR MaVoucher = @MaVoucher)
      AND (@CouponCode IS NULL OR CouponCode = @CouponCode)
      AND (@TrangThai IS NULL OR TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR IsActive = @IsActive);
END
GO

-- Cập nhật số lượng đã dùng voucher
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_UseVoucher')
    DROP PROC sp_UseVoucher;
GO

CREATE PROC sp_UseVoucher
    @CouponCode NVARCHAR(50)
AS
BEGIN
    UPDATE Voucher
    SET SoLuongDaDung = SoLuongDaDung + 1,
        UpdatedAt = GETDATE()
    WHERE CouponCode = @CouponCode
      AND IsActive = 1;
      
    -- Return success status
    IF @@ROWCOUNT > 0
        SELECT 1 AS Success;
    ELSE
        SELECT 0 AS Success;
END
GO

-- Insert voucher
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_InsertVoucher')
    DROP PROC sp_InsertVoucher;
GO


-- ==============================================================================
-- Fix sp_InsertCTSuKien: Allow MaCTDV to be NULL
-- Fix sp_InsertCTDatPhong: Add LoaiDat and SoLuongThue parameters
-- ==============================================================================


-- 1. Fix sp_InsertCTSuKien - Allow MaCTDV NULL
-- ==============================================================================
-- COMPLETE FIX: Add Columns + Update Stored Procedures
-- ==============================================================================
-- Part 1: Add missing columns to CTDatPhong table
-- Part 2: Fix sp_InsertCTSuKien (allow MaCTDV NULL)
-- Part 3: Update sp_InsertCTDatPhong and sp_UpdateCTDatPhong
-- ==============================================================================





-----------------------------------------------------------------------------------------------------------------------
-- [PROC - GÓI SỰ KIỆN/ EVENT PACKAGES] Lấy danh sách gói sự kiện
-----------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROC sp_GetAllEventPackages
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        g.MaGoiSK, g.MaSK, g.TenGoiSK, g.MoTa, g.GiaGoi,
        g.SoKhachToiThieu, g.SoKhachToiDa, 
        g.ThoiGianToiThieu, g.ThoiGianToiDa,
        g.DichVuKemTheo, g.MaCN,
        g.CreatedAt, g.CreatedBy, g.UpdatedAt, g.UpdatedBy, g.IsActive,
        s.TenSK,
        cn.TenCN
    FROM GoiSuKien g
    JOIN SuKien s ON g.MaSK = s.MaSK
    LEFT JOIN ChiNhanh cn ON g.MaCN = cn.MaCN
    WHERE @IsActive IS NULL OR g.IsActive = @IsActive
    ORDER BY s.TenSK, g.GiaGoi;
END
GO

CREATE OR ALTER PROC sp_GetEventPackagesByEventType
    @MaSK NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        g.MaGoiSK, g.MaSK, g.TenGoiSK, g.MoTa, g.GiaGoi,
        g.SoKhachToiThieu, g.SoKhachToiDa,
        g.ThoiGianToiThieu, g.ThoiGianToiDa,
        g.DichVuKemTheo, g.MaCN,
        g.CreatedAt, g.CreatedBy, g.UpdatedAt, g.UpdatedBy, g.IsActive,
        s.TenSK,
        cn.TenCN
    FROM GoiSuKien g
    JOIN SuKien s ON g.MaSK = s.MaSK
    LEFT JOIN ChiNhanh cn ON g.MaCN = cn.MaCN
    WHERE g.MaSK = @MaSK 
      AND (@IsActive IS NULL OR g.IsActive = @IsActive)
    ORDER BY g.GiaGoi;
END
GO

CREATE OR ALTER PROC sp_GetEventPackageByID
    @MaGoiSK NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        g.MaGoiSK, g.MaSK, g.TenGoiSK, g.MoTa, g.GiaGoi,
        g.SoKhachToiThieu, g.SoKhachToiDa,
        g.ThoiGianToiThieu, g.ThoiGianToiDa,
        g.DichVuKemTheo, g.MaCN,
        g.CreatedAt, g.CreatedBy, g.UpdatedAt, g.UpdatedBy, g.IsActive,
        s.TenSK,
        cn.TenCN
    FROM GoiSuKien g
    JOIN SuKien s ON g.MaSK = s.MaSK
    LEFT JOIN ChiNhanh cn ON g.MaCN = cn.MaCN
    WHERE g.MaGoiSK = @MaGoiSK;
END
GO
select * from GoiSuKien
exec sp_GetEventPackageByID 'SK05'

CREATE OR ALTER PROC sp_InsertEventPackage
    @MaGoiSK NVARCHAR(20),
    @MaSK NVARCHAR(20),
    @TenGoiSK NVARCHAR(200),
    @MoTa NVARCHAR(500),
    @GiaGoi DECIMAL(12,2),
    @SoKhachToiThieu INT,
    @SoKhachToiDa INT,
    @ThoiGianToiThieu INT,
    @ThoiGianToiDa INT,
    @DichVuKemTheo NVARCHAR(1000),
    @MaCN NVARCHAR(20),
    @CreatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO GoiSuKien (
        MaGoiSK, MaSK, TenGoiSK, MoTa, GiaGoi, 
        SoKhachToiThieu, SoKhachToiDa, 
        ThoiGianToiThieu, ThoiGianToiDa,
        DichVuKemTheo, MaCN,
        CreatedBy, IsActive
    )
    VALUES (
        @MaGoiSK, @MaSK, @TenGoiSK, @MoTa, @GiaGoi,
        @SoKhachToiThieu, @SoKhachToiDa,
        @ThoiGianToiThieu, @ThoiGianToiDa,
        @DichVuKemTheo, @MaCN,
        @CreatedBy, 1
    );
END
GO

CREATE OR ALTER PROC sp_UpdateEventPackage
    @MaGoiSK NVARCHAR(20),
    @MaSK NVARCHAR(20),
    @TenGoiSK NVARCHAR(200),
    @MoTa NVARCHAR(500),
    @GiaGoi DECIMAL(12,2),
    @SoKhachToiThieu INT,
    @SoKhachToiDa INT,
    @ThoiGianToiThieu INT,
    @ThoiGianToiDa INT,
    @DichVuKemTheo NVARCHAR(1000),
    @MaCN NVARCHAR(20),
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE GoiSuKien
    SET MaSK = @MaSK,
        TenGoiSK = @TenGoiSK,
        MoTa = @MoTa,
        GiaGoi = @GiaGoi,
        SoKhachToiThieu = @SoKhachToiThieu,
        SoKhachToiDa = @SoKhachToiDa,
        ThoiGianToiThieu = @ThoiGianToiThieu,
        ThoiGianToiDa = @ThoiGianToiDa,
        DichVuKemTheo = @DichVuKemTheo,
        MaCN = @MaCN,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaGoiSK = @MaGoiSK;
END
GO

CREATE OR ALTER PROC sp_DeleteEventPackage
    @MaGoiSK NVARCHAR(20),
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE GoiSuKien
    SET IsActive = 0,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaGoiSK = @MaGoiSK;
END
GO

-----------------------------------------------------------------------------------------------------------------------
-- [EVENT DETAILS/BOOKINGS] Stored Procedures
-----------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROC sp_GetAllEventDetails
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ct.MaCTSK, ct.MaGoiSK, ct.MaKH, ct.NgayToChuc, ct.SoLuongKhach,
        ct.YeuCauThem, ct.ChiPhiGoi, ct.ChiPhiPhatSinh, ct.ThanhTien, ct.DaThanhToan,
        ct.TrangThai, ct.GhiChu,
        ct.CreatedAt, ct.CreatedBy, ct.UpdatedAt, ct.UpdatedBy, ct.IsActive,
        g.TenGoiSK,
        s.TenSK,
        k.HoTen AS HoTenKH
    FROM CTSuKien ct
    JOIN GoiSuKien g ON ct.MaGoiSK = g.MaGoiSK
    JOIN SuKien s ON g.MaSK = s.MaSK
    JOIN KhachHang k ON ct.MaKH = k.MaKH
    WHERE @IsActive IS NULL OR ct.IsActive = @IsActive
    ORDER BY ct.NgayToChuc DESC;
END
GO

CREATE OR ALTER PROC sp_GetEventDetailByID
    @MaCTSK NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ct.MaCTSK, ct.MaGoiSK, ct.MaKH, ct.NgayToChuc, ct.SoLuongKhach,
        ct.YeuCauThem, ct.ChiPhiGoi, ct.ChiPhiPhatSinh, ct.ThanhTien, ct.DaThanhToan,
        ct.TrangThai, ct.GhiChu,
        ct.CreatedAt, ct.CreatedBy, ct.UpdatedAt, ct.UpdatedBy, ct.IsActive,
        g.TenGoiSK,
        s.TenSK,
        k.HoTen AS HoTenKH
    FROM CTSuKien ct
    JOIN GoiSuKien g ON ct.MaGoiSK = g.MaGoiSK
    JOIN SuKien s ON g.MaSK = s.MaSK
    JOIN KhachHang k ON ct.MaKH = k.MaKH
    WHERE ct.MaCTSK = @MaCTSK;
END
GO

CREATE OR ALTER PROC sp_GetEventDetailsByCustomer
    @MaKH NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ct.MaCTSK, ct.MaGoiSK, ct.MaKH, ct.NgayToChuc, ct.SoLuongKhach,
        ct.YeuCauThem, ct.ChiPhiGoi, ct.ChiPhiPhatSinh, ct.ThanhTien, ct.DaThanhToan,
        ct.TrangThai, ct.GhiChu,
        ct.CreatedAt, ct.CreatedBy, ct.UpdatedAt, ct.UpdatedBy, ct.IsActive,
        g.TenGoiSK,
        s.TenSK,
        k.HoTen AS HoTenKH
    FROM CTSuKien ct
    JOIN GoiSuKien g ON ct.MaGoiSK = g.MaGoiSK
    JOIN SuKien s ON g.MaSK = s.MaSK
    JOIN KhachHang k ON ct.MaKH = k.MaKH
    WHERE ct.MaKH = @MaKH
      AND (@IsActive IS NULL OR ct.IsActive = @IsActive)
    ORDER BY ct.NgayToChuc DESC;
END
GO

CREATE OR ALTER PROC sp_GetEventDetailsByDateRange
    @NgayBatDau DATETIME2,
    @NgayKetThuc DATETIME2,
    @TrangThai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ct.MaCTSK, ct.MaGoiSK, ct.MaKH, ct.NgayToChuc, ct.SoLuongKhach,
        ct.YeuCauThem, ct.ChiPhiGoi, ct.ChiPhiPhatSinh, ct.ThanhTien, ct.DaThanhToan,
        ct.TrangThai, ct.GhiChu,
        ct.CreatedAt, ct.CreatedBy, ct.UpdatedAt, ct.UpdatedBy, ct.IsActive,
        g.TenGoiSK,
        s.TenSK,
        k.HoTen AS HoTenKH
    FROM CTSuKien ct
    JOIN GoiSuKien g ON ct.MaGoiSK = g.MaGoiSK
    JOIN SuKien s ON g.MaSK = s.MaSK
    JOIN KhachHang k ON ct.MaKH = k.MaKH
    WHERE ct.NgayToChuc BETWEEN @NgayBatDau AND @NgayKetThuc
      AND (@TrangThai IS NULL OR ct.TrangThai = @TrangThai)
    ORDER BY ct.NgayToChuc;
END
GO

CREATE OR ALTER PROC sp_InsertEventDetail
    @MaCTSK NVARCHAR(20),
    @MaGoiSK NVARCHAR(20),
    @MaKH NVARCHAR(20),
    @NgayToChuc DATETIME2,
    @SoLuongKhach INT,
    @YeuCauThem NVARCHAR(1000),
    @ChiPhiGoi DECIMAL(12,2),
    @ChiPhiPhatSinh DECIMAL(12,2),
    @DaThanhToan DECIMAL(12,2),
    @TrangThai NVARCHAR(50),
    @GhiChu NVARCHAR(500),
    @CreatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CTSuKien (
        MaCTSK, MaGoiSK, MaKH, NgayToChuc, SoLuongKhach,
        YeuCauThem, ChiPhiGoi, ChiPhiPhatSinh, DaThanhToan,
        TrangThai, GhiChu, CreatedBy, IsActive
    )
    VALUES (
        @MaCTSK, @MaGoiSK, @MaKH, @NgayToChuc, @SoLuongKhach,
        @YeuCauThem, @ChiPhiGoi, @ChiPhiPhatSinh, @DaThanhToan,
        @TrangThai, @GhiChu, @CreatedBy, 1
    );
END
GO

CREATE OR ALTER PROC sp_UpdateEventDetail
    @MaCTSK NVARCHAR(20),
    @NgayToChuc DATETIME2,
    @SoLuongKhach INT,
    @YeuCauThem NVARCHAR(1000),
    @ChiPhiPhatSinh DECIMAL(12,2),
    @DaThanhToan DECIMAL(12,2),
    @TrangThai NVARCHAR(50),
    @GhiChu NVARCHAR(500),
    @UpdatedBy NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CTSuKien
    SET NgayToChuc = @NgayToChuc,
        SoLuongKhach = @SoLuongKhach,
        YeuCauThem = @YeuCauThem,
        ChiPhiPhatSinh = @ChiPhiPhatSinh,
        DaThanhToan = @DaThanhToan,
        TrangThai = @TrangThai,
        GhiChu = @GhiChu,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaCTSK = @MaCTSK;
END
GO

CREATE OR ALTER PROC sp_UpdateEventDetailStatus
    @MaCTSK NVARCHAR(20),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CTSuKien
    SET TrangThai = @TrangThai,
        UpdatedAt = GETDATE()
    WHERE MaCTSK = @MaCTSK;
END
GO

CREATE OR ALTER PROC sp_UpdateEventDetailPayment
    @MaCTSK NVARCHAR(20),
    @SoTienTra DECIMAL(12,2),
    @UpdatedBy NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CTSuKien
    SET DaThanhToan = DaThanhToan + @SoTienTra,
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE()
    WHERE MaCTSK = @MaCTSK;
END
GO

CREATE OR ALTER PROC sp_DeleteEventDetail
    @MaCTSK NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE CTSuKien
    SET IsActive = 0,
        TrangThai = N'Hủy',
        UpdatedAt = GETDATE()
    WHERE MaCTSK = @MaCTSK;
END
GO


-- =====================================================
-- INVOICE (HÓA ĐƠN) STORED PROCEDURES
-- Hỗ trợ cả đặt phòng (MaDP) VÀ sự kiện (MaCTSK)
-- =====================================================

CREATE OR ALTER PROC sp_GetHoaDon
    @MaHD NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @MaCTSK NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM HoaDon
    WHERE (@MaHD IS NULL OR MaHD = @MaHD)
      AND (@MaDP IS NULL OR MaDP = @MaDP)
      AND (@MaCTSK IS NULL OR MaCTSK = @MaCTSK)
      AND (@MaKH IS NULL OR MaKH = @MaKH)
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@TrangThai IS NULL OR TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR IsActive = @IsActive);
END
GO

CREATE OR ALTER PROC sp_InsertHoaDon
    @MaHD NVARCHAR(20),
    @MaDP NVARCHAR(20) = NULL,
    @MaCTSK NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20),
    @MaNV NVARCHAR(20),
    @MaKM NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20),
    @TrangThai NVARCHAR(50) = N'Chưa TT',
    @NgayLap DATETIME2 = NULL,
    @TongTruocKM DECIMAL(12,2) = NULL,
    @TongTien DECIMAL(12,2) = NULL,
    @CreatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validate: Must have either MaDP OR MaCTSK
    IF (@MaDP IS NULL AND @MaCTSK IS NULL)
    BEGIN
        RAISERROR(N'Hóa đơn phải có MaDP (đặt phòng) HOẶC MaCTSK (sự kiện)!', 16, 1);
        RETURN;
    END
    
    IF (@MaDP IS NOT NULL AND @MaCTSK IS NOT NULL)
    BEGIN
        RAISERROR(N'Hóa đơn không thể có cả MaDP VÀ MaCTSK!', 16, 1);
        RETURN;
    END
    
    INSERT INTO HoaDon (
        MaHD, MaDP, MaCTSK, MaKH, MaNV, MaKM, MaCN, 
        TrangThai, NgayLap, TongTruocKM, TongTien, 
        CreatedBy, CreatedAt, IsActive
    )
    VALUES (
        @MaHD, @MaDP, @MaCTSK, @MaKH, @MaNV, @MaKM, @MaCN,
        @TrangThai, ISNULL(@NgayLap, GETDATE()), @TongTruocKM, @TongTien,
        @CreatedBy, GETDATE(), @IsActive
    );
END
GO

CREATE OR ALTER PROC sp_UpdateHoaDon
    @MaHD NVARCHAR(20),
    @TrangThai NVARCHAR(50),
    @TongTruocKM DECIMAL(12,2) = NULL,
    @TongTien DECIMAL(12,2) = NULL,
    @UpdatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE HoaDon
    SET TrangThai = @TrangThai,
        TongTruocKM = ISNULL(@TongTruocKM, TongTruocKM),
        TongTien = ISNULL(@TongTien, TongTien),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaHD = @MaHD;
END
GO

CREATE OR ALTER PROC sp_GetCTHoaDon
    @MaCTHD NVARCHAR(20) = NULL,
    @MaHD NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM CTHoaDon
    WHERE (@MaCTHD IS NULL OR MaCTHD = @MaCTHD)
      AND (@MaHD IS NULL OR MaHD = @MaHD)
      AND (@IsActive IS NULL OR IsActive = @IsActive);
END
GO

CREATE OR ALTER PROC sp_InsertCTHoaDon
    @MaCTHD NVARCHAR(20),
    @MaHD NVARCHAR(20),
    @MoTa NVARCHAR(500) = NULL,
    @SoLuong INT = NULL,
    @DonGia DECIMAL(10,2) = NULL,
    @ThanhTien DECIMAL(12,2) = NULL,
    @CreatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CTHoaDon (
        MaCTHD, MaHD, MoTa, SoLuong, DonGia, ThanhTien,
        CreatedBy, CreatedAt, IsActive
    )
    VALUES (
        @MaCTHD, @MaHD, @MoTa, @SoLuong, @DonGia, @ThanhTien,
        @CreatedBy, GETDATE(), @IsActive
    );
END
GO

PRINT N'✅ Đã tạo Invoice Stored Procedures (hỗ trợ cả Room & Event)!';

-- =====================================================
-- MIGRATE EXISTING INVOICE CODES: HD### → HD-DP-###
-- =====================================================
UPDATE HoaDon
SET MaHD = 'HD-DP-' + RIGHT('000' + SUBSTRING(MaHD, 3, LEN(MaHD) - 2), 3)
WHERE MaHD LIKE 'HD[0-9]%' AND MaHD NOT LIKE 'HD-DP-%' AND MaHD NOT LIKE 'HD-SK-%';
GO
PRINT '✅ Migrated invoice codes: HD### → HD-DP-###';
GO

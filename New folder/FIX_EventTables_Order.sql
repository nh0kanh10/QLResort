-- =====================================================
-- FIX: TABLE CREATION ORDER FOR EVENT INVOICING
-- Move Event tables BEFORE HoaDon to fix FK dependencies
-- =====================================================

-- DELETE OLD EVENT TABLES (if any exist later in script)
-- Execute manually: DROP TABLE IF EXISTS CTSuKien, GoiSuKien, SuKien;

-- INSERT THESE TABLES AFTER CTDichVu (around line 261) and BEFORE HoaDon (currently line 263)

-- Bảng Sự kiện - Đây là bảng cha chứa LOẠI/DANH MỤC sự kiện
-- Ví dụ: Cưới, Hội nghị, Team building, Tiệc cá nhân, Wellness, Sự kiện mùa...
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

-- Bảng Gói Sự kiện - Các gói thuộc từng loại sự kiện
-- Mỗi loại sự kiện có nhiều gói (Basic, Standard, Premium...)
CREATE TABLE GoiSuKien (
    MaGoiSK NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaSK NVARCHAR(20) NOT NULL, -- FK → Loại sự kiện
    TenGoiSK NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(500) NULL,
    GiaGoi DECIMAL(12,2) NOT NULL, -- Giá gói sự kiện
    SoKhachToiThieu INT NOT NULL DEFAULT 10,
    SoKhachToiDa INT NULL,
    ThoiGianToiThieu INT NULL, -- Thời gian tối thiểu (giờ)
    ThoiGianToiDa INT NULL, -- Thời gian tối đa (giờ)
    DichVuKemTheo NVARCHAR(1000) NULL, -- Dịch vụ đi kèm
    MaCN NVARCHAR(20) NULL, -- FK → Chi nhánh (có thể null nếu áp dụng cho tất cả chi nhánh)
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_GoiSuKien_SuKien FOREIGN KEY (MaSK) REFERENCES SuKien(MaSK),
    CONSTRAINT FK_GoiSuKien_ChiNhanh FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
GO

-- Bảng Chi tiết Sự kiện - Lưu thông tin đặt gói sự kiện của khách hàng
-- Đây là bảng giao dịch lưu lần đặt sự kiện
CREATE TABLE CTSuKien (
    MaCTSK NVARCHAR(20) NOT NULL PRIMARY KEY, -- Khóa chính riêng để dễ dùng với ADO.NET
    MaGoiSK NVARCHAR(20) NOT NULL, -- FK → Gói sự kiện
    MaKH NVARCHAR(20) NOT NULL, -- FK → Khách hàng
    NgayToChuc DATETIME2 NOT NULL, -- Ngày tổ chức sự kiện
    SoLuongKhach INT NOT NULL DEFAULT 1, -- Số lượng khách dự kiến
    YeuCauThem NVARCHAR(1000) NULL, -- Yêu cầu đặc biệt từ khách hàng
    ChiPhiGoi DECIMAL(12,2) NOT NULL, -- Chi phí gói (copy từ GoiSuKien lúc đặt)
    ChiPhiPhatSinh DECIMAL(12,2) NOT NULL DEFAULT 0, -- Phí phát sinh thêm
    ThanhTien AS (ChiPhiGoi + ChiPhiPhatSinh) PERSISTED, -- Tổng chi phí
    DaThanhToan DECIMAL(12,2) NOT NULL DEFAULT 0, -- Số tiền đã thanh toán
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Lên kế hoạch', -- Trạng thái sự kiện
    GhiChu NVARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(20) NULL,
    UpdatedBy NVARCHAR(20) NULL,
    UpdatedAt DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CTSuKien_GoiSK FOREIGN KEY (MaGoiSK) REFERENCES GoiSuKien(MaGoiSK),
    CONSTRAINT FK_CTSuKien_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    -- Unique constraint: Một khách hàng không thể đặt cùng gói sự kiện 2 lần (có thể bỏ nếu cho phép đặt lại)
    CONSTRAINT UQ_CTSuKien_GoiKH UNIQUE (MaGoiSK, MaKH, NgayToChuc)
);
GO

-- =====================================================
-- IMPORTANT NOTES:
-- 1. These 3 tables MUST be created BEFORE HoaDon table
-- 2. Delete any duplicate definitions later in the script
-- 3. HoaDon line 281 has FK to CTSuKien - it will fail if CTSuKien doesn't exist yet
-- =====================================================

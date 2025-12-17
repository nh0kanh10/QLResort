--================================================================================
-- FILE 2: 02_StoredProcedures.sql
-- HỆ THỐNG QUẢN LÝ RESORT - STORED PROCEDURES
-- Mục đích: Tạo tất cả các stored procedures cho hệ thống
-- Lưu ý: Chạy file này SAU KHI chạy 01_Tables_Schema.sql và TRƯỚC 03_Data.sql (nếu cần)
--================================================================================

USE QLR;
GO

--- 7. KHỐI LỆNH TẠO STORED PROCEDURES (PROC)
-- Giữ nguyên các PROC của bạn
-----------------------------------------------------------------------------------------------------------------------

-- [PROC - LOẠI NHÂN VIÊN] Lấy danh sách
CREATE OR ALTER PROC sp_GetLoaiNV @IsActive BIT = NULL
AS
BEGIN
 
    SELECT MaLoaiNV, TenLoaiNV, MoTa, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM LoaiNhanVien
    WHERE @IsActive IS NULL OR IsActive = @IsActive;
END
GO

-- [PROC - LOẠI NHÂN VIÊN] Lấy danh sách cho Hóa đơn (alias)
CREATE OR ALTER PROC sp_GetAllLoaiNhanVienHD
AS
BEGIN
 
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
CREATE OR ALTER PROC sp_GetDatPhong
    @MaDP NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @MaNV NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    SELECT DP.MaDP, DP.MaKH, DP.MaNV, DP.TrangThai, DP.GhiChu,
           DP.CreatedAt, DP.CreatedBy, DP.UpdatedAt, DP.UpdatedBy, DP.IsActive,
           KH.HoTen AS TenKH, NV.HoTen AS TenNV
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
    @TrangThai NVARCHAR(50) = N'Đặt',
    @GhiChu NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
 
    INSERT INTO DatPhong (MaDP, MaKH, MaNV, TrangThai, GhiChu, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaDP, @MaKH, @MaNV, @TrangThai, @GhiChu, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - ĐẶT PHÒNG] Cập nhật
CREATE OR ALTER PROC sp_UpdateDatPhong
    @MaDP NVARCHAR(20),
    @TrangThai NVARCHAR(50) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
 
    UPDATE DatPhong
    SET TrangThai = ISNULL(@TrangThai, TrangThai),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaDP = @MaDP;
END
GO

-- [PROC - CHI TIẾT ĐẶT PHÒNG] Lấy danh sách
CREATE OR ALTER PROC sp_GetCTDatPhong
    @MaCTDP NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @MaPhong NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    SELECT CTDP.MaCTDP, CTDP.MaDP, CTDP.TrangThai, CTDP.NgayDen, CTDP.NgayDi,
           CTDP.NguoiLon, CTDP.TreEm, CTDP.MaPhong, CTDP.GiaPhong, CTDP.ThanhTien,
           CTDP.CreatedAt, CTDP.CreatedBy, CTDP.UpdatedAt, CTDP.UpdatedBy, CTDP.IsActive,
           P.SoPhong, P.ViTri, LP.TenLP, LP.GiaTheoNgay
    FROM CTDatPhong CTDP
    INNER JOIN DatPhong DP ON CTDP.MaDP = DP.MaDP
    LEFT JOIN Phong P ON CTDP.MaPhong = P.MaPhong
    LEFT JOIN LoaiPhong LP ON P.MaLP = LP.MaLP
    WHERE (@MaCTDP IS NULL OR CTDP.MaCTDP = @MaCTDP)
      AND (@MaDP IS NULL OR CTDP.MaDP = @MaDP)
      AND (@MaPhong IS NULL OR CTDP.MaPhong = @MaPhong)
      AND (@TrangThai IS NULL OR CTDP.TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR CTDP.IsActive = @IsActive)
      AND (@IsActive IS NULL OR @IsActive = 0 OR DP.IsActive = 1)
    ORDER BY CTDP.NgayDen DESC;
END
GO

-- [PROC - CHI TIẾT ĐẶT PHÒNG] Thêm mới
CREATE OR ALTER PROC sp_InsertCTDatPhong
    @MaCTDP NVARCHAR(20),
    @MaDP NVARCHAR(20),
    @MaPhong NVARCHAR(20),
    @TrangThai NVARCHAR(50) = N'Đặt',
    @NgayDen DATETIME2,
    @NgayDi DATETIME2,
    @NguoiLon INT = NULL,
    @TreEm INT = NULL,
    @GiaPhong DECIMAL(10,2) = NULL,
    @ThanhTien DECIMAL(12,2) = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1,
    @LoaiThue NVARCHAR(20) = N'Ngày'
AS
BEGIN
 
    INSERT INTO CTDatPhong (MaCTDP, MaDP, TrangThai, NgayDen, NgayDi, NguoiLon, TreEm,
                           MaPhong, GiaPhong, ThanhTien, CreatedBy, CreatedAt, IsActive, LoaiThue)
    VALUES (@MaCTDP, @MaDP, @TrangThai, @NgayDen, @NgayDi, @NguoiLon, @TreEm,
            @MaPhong, @GiaPhong, @ThanhTien, @CreatedBy, GETDATE(), @IsActive, @LoaiThue);
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
    @GiaPhong DECIMAL(10,2) = NULL,
    @ThanhTien DECIMAL(12,2) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL,
    @LoaiThue NVARCHAR(20) = NULL
AS
BEGIN
 
    UPDATE CTDatPhong
    SET TrangThai = ISNULL(@TrangThai, TrangThai),
        NgayDen = ISNULL(@NgayDen, NgayDen),
        NgayDi = ISNULL(@NgayDi, NgayDi),
        NguoiLon = ISNULL(@NguoiLon, NguoiLon),
        TreEm = ISNULL(@TreEm, TreEm),
        GiaPhong = ISNULL(@GiaPhong, GiaPhong),
        ThanhTien = ISNULL(@ThanhTien, ThanhTien),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive),
        LoaiThue = ISNULL(@LoaiThue, LoaiThue)
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
 
    UPDATE CTDichVu SET IsActive = 0 WHERE MaCTDV = @MaCTDV;
END
GO

-- [PROC - ĐIỂM KHÁCH HÀNG] Lấy điểm hiện tại
CREATE OR ALTER PROC sp_GetKhachHangDiem
    @MaKH NVARCHAR(20)
AS
BEGIN
 
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


-- [PROC - ĐIỂM KHÁCH HÀNG] Cộng điểm (tích điểm khi thanh toán)
CREATE OR ALTER PROC sp_AddKhachHangDiem
    @MaKH NVARCHAR(20),
    @DiemCong INT,
    @GhiChu NVARCHAR(500) = NULL,
    @NguoiThucHien NVARCHAR(50) = NULL,
    @CreatedBy NVARCHAR(20)
AS
BEGIN
 

    -- 1. Nếu chưa có điểm thì tạo mới (0 điểm)
    IF NOT EXISTS (SELECT 1 FROM KhachHangDiem WHERE MaKH = @MaKH)
    BEGIN
        INSERT INTO KhachHangDiem (MaKH, DiemHienTai, CapNhatLuc, CreatedBy, CreatedAt)
        VALUES (@MaKH, 0, GETDATE(), @CreatedBy, GETDATE());
    END

    -- 2. Cập nhật cộng điểm
    UPDATE KhachHangDiem
    SET DiemHienTai = DiemHienTai + @DiemCong,
        CapNhatLuc = GETDATE(),
        UpdatedBy = @CreatedBy,
        UpdatedAt = GETDATE()
    WHERE MaKH = @MaKH;
    
    -- 3. Ghi lịch sử
    INSERT INTO KhachHangLichSuDiem (MaKH, Ngay, LoaiThaoTac, Diem, GhiChu, NguoiThucHien, CreatedBy, CreatedAt)
    VALUES (@MaKH, GETDATE(), N'CONG', @DiemCong, @GhiChu, @NguoiThucHien, @CreatedBy, GETDATE());
END
GO

----Loại phòng
CREATE OR ALTER PROC sp_GetLoaiPhong
    @MaLP NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    
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
-- [PROC - LOẠI PHÒNG] Xóa
CREATE OR ALTER PROC sp_DeleteLoaiPhong
    @MaLP NVARCHAR(20)
AS
BEGIN
 
    DELETE FROM LoaiPhong WHERE MaLP = @MaLP;
END
GO
-- [PROC - LOẠI THANH TOÁN] Lấy danh sách
CREATE OR ALTER PROC sp_GetLoaiThanhToan
    @MaLTT NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
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
 
    UPDATE KhuyenMai SET IsActive = 0 WHERE MaKM = @MaKM;
END
GO
-- [PROC - HÓA ĐƠN] Lấy danh sách
CREATE OR ALTER PROC sp_GetHoaDon
    @MaHD NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @MaCTSK NVARCHAR(20) = NULL,
    @LoaiHoaDon NVARCHAR(20) = NULL, -- 'DatPhong', 'SuKien', hoặc NULL để lấy tất cả
    @MaKH NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    SELECT HD.MaHD, HD.MaDP, HD.MaCTSK, HD.LoaiHoaDon, HD.MaKH, HD.MaNV, HD.MaKM, HD.MaCN, HD.TrangThai,
           HD.NgayLap, HD.TongTruocKM, HD.TongTien, HD.CreatedAt, HD.CreatedBy,
           HD.UpdatedAt, HD.UpdatedBy, HD.IsActive,
           KH.HoTen AS TenKH, NV.HoTen AS TenNV, CN.TenCN, KM.TenKM,
           -- Thêm tên sự kiện nếu là hóa đơn sự kiện
           SK.TenSK AS TenSuKien
    FROM HoaDon HD
    LEFT JOIN KhachHang KH ON HD.MaKH = KH.MaKH
    LEFT JOIN NhanVien NV ON HD.MaNV = NV.MaNV
    LEFT JOIN ChiNhanh CN ON HD.MaCN = CN.MaCN
    LEFT JOIN KhuyenMai KM ON HD.MaKM = KM.MaKM
    LEFT JOIN CTSuKien CTSK ON HD.MaCTSK = CTSK.MaCTSK
    LEFT JOIN SuKien SK ON CTSK.MaSK = SK.MaSK
    WHERE (@MaHD IS NULL OR HD.MaHD = @MaHD)
      AND (@MaDP IS NULL OR HD.MaDP = @MaDP)
      AND (@MaCTSK IS NULL OR HD.MaCTSK = @MaCTSK)
      AND (@LoaiHoaDon IS NULL OR HD.LoaiHoaDon = @LoaiHoaDon)
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
    @MaDP NVARCHAR(20) = NULL, -- NULL nếu là hóa đơn sự kiện
    @MaCTSK NVARCHAR(20) = NULL, -- NULL nếu là hóa đơn đặt phòng
    @LoaiHoaDon NVARCHAR(20) = N'DatPhong', -- 'DatPhong' hoặc 'SuKien'
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
    INSERT INTO HoaDon (MaHD, MaDP, MaCTSK, LoaiHoaDon, MaKH, MaNV, MaKM, MaCN, TrangThai, NgayLap,
                       TongTruocKM, TongTien, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaHD, @MaDP, @MaCTSK, @LoaiHoaDon, @MaKH, @MaNV, @MaKM, @MaCN, @TrangThai, 
            ISNULL(@NgayLap, GETDATE()), @TongTruocKM, @TongTien, 
            @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - HÓA ĐƠN] Cập nhật
CREATE OR ALTER PROC sp_UpdateHoaDon
    @MaHD NVARCHAR(20),
    @MaKM NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @TongTruocKM DECIMAL(12,2) = NULL,
    @TongTien DECIMAL(12,2) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
 
    UPDATE HoaDon
    SET TrangThai = ISNULL(@TrangThai, TrangThai),
        MaKM = ISNULL(@MaKM, MaKM),
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
 
    
    -- Kiểm tra nếu Mã HD được cung cấp
    IF @MaHD IS NOT NULL
    BEGIN
        DECLARE @LoaiHoaDon NVARCHAR(20);
        DECLARE @MaCTSK NVARCHAR(20);
        
        SELECT @LoaiHoaDon = LoaiHoaDon, @MaCTSK = MaCTSK 
        FROM HoaDon WHERE MaHD = @MaHD;
        
        -- Nếu là hóa đơn sự kiện và không có chi tiết trong CTHoaDon, tự động lấy từ CTSuKien
        IF @LoaiHoaDon = 'SuKien' AND NOT EXISTS (SELECT 1 FROM CTHoaDon WHERE MaHD = @MaHD)
        BEGIN
            -- Lấy thông tin từ CTSuKien và GoiSuKien
            SELECT 
                'AUTO_' + CTSK.MaCTSK AS MaCTHD,
                @MaHD AS MaHD,
                ISNULL(GSK.TenGoiSK, SK.TenSK) + N' (Sự kiện: ' + SK.TenSK + N')' AS MoTa,
                1 AS SoLuong,
                CTSK.DonGia AS DonGia, -- Đây có thể là giá gói hoặc tổng tiền dự kiến
                CTSK.ThanhTien AS ThanhTien,
                CTSK.CreatedAt,
                CTSK.CreatedBy,
                CTSK.UpdatedAt,
                CTSK.UpdatedBy,
                CTSK.IsActive
            FROM CTSuKien CTSK
            LEFT JOIN SuKien SK ON CTSK.MaSK = SK.MaSK
            LEFT JOIN GoiSuKien GSK ON GSK.MaSK = SK.MaSK -- Lưu ý: Logic này giả định lấy gói đầu tiên hoặc cần logic chính xác hơn nếu lưu gói
            WHERE CTSK.MaCTSK = @MaCTSK;
            RETURN;
        END
    END

    -- Trường hợp mặc định: lấy từ CTHoaDon
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

-- ==========================================
-- STORED PROCEDURES CHO SỰ KIỆN (EVENT)
-- ==========================================

-- [PROC - SỰ KIỆN] Lấy danh sách
CREATE OR ALTER PROC sp_GetSuKien
    @MaSK NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @LoaiSuKien NVARCHAR(100) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    SELECT SK.MaSK, SK.TenSK, SK.LoaiSuKien, SK.MaCN, SK.DiaDiem, SK.GhiChu,
           SK.TongChiPhi, SK.CreatedAt, SK.CreatedBy, SK.UpdatedAt, SK.UpdatedBy, SK.IsActive,
           CN.TenCN AS TenCN
    FROM SuKien SK
    LEFT JOIN ChiNhanh CN ON SK.MaCN = CN.MaCN
    WHERE (@MaSK IS NULL OR SK.MaSK = @MaSK)
      AND (@MaCN IS NULL OR SK.MaCN = @MaCN)
      AND (@LoaiSuKien IS NULL OR SK.LoaiSuKien = @LoaiSuKien)
      AND (@IsActive IS NULL OR SK.IsActive = @IsActive)
    ORDER BY SK.CreatedAt DESC;
END
GO

-- [PROC - SỰ KIỆN] Thêm mới
CREATE OR ALTER PROC sp_InsertSuKien
    @MaSK NVARCHAR(20),
    @TenSK NVARCHAR(200),
    @LoaiSuKien NVARCHAR(100),
    @MaCN NVARCHAR(20),
    @DiaDiem NVARCHAR(300) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @TongChiPhi DECIMAL(12,2) = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
 
    INSERT INTO SuKien (MaSK, TenSK, LoaiSuKien, MaCN, DiaDiem, GhiChu, TongChiPhi, CreatedBy, CreatedAt, IsActive)
    VALUES (@MaSK, @TenSK, @LoaiSuKien, @MaCN, @DiaDiem, @GhiChu, @TongChiPhi, @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - SỰ KIỆN] Cập nhật
CREATE OR ALTER PROC sp_UpdateSuKien
    @MaSK NVARCHAR(20),
    @TenSK NVARCHAR(200) = NULL,
    @LoaiSuKien NVARCHAR(100) = NULL,
    @DiaDiem NVARCHAR(300) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @TongChiPhi DECIMAL(12,2) = NULL,
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT = NULL
AS
BEGIN
 
    UPDATE SuKien
    SET TenSK = ISNULL(@TenSK, TenSK),
        LoaiSuKien = ISNULL(@LoaiSuKien, LoaiSuKien),
        DiaDiem = ISNULL(@DiaDiem, DiaDiem),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        TongChiPhi = ISNULL(@TongChiPhi, TongChiPhi),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaSK = @MaSK;
END
GO

-- [PROC - CHI TIẾT SỰ KIỆN] Lấy danh sách
CREATE OR ALTER PROC sp_GetCTSuKien
    @MaCTSK NVARCHAR(20) = NULL,
    @MaSK NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    SELECT CTSK.MaCTSK, CTSK.MaSK, CTSK.MaKH, CTSK.SoLuong, CTSK.DonGia, 
           CTSK.ThanhTien, CTSK.GhiChu, CTSK.DaThanhToan, CTSK.TrangThai, 
           CTSK.NgayBD, CTSK.NgayKT, CTSK.TongKhach,
           CTSK.CreatedAt, CTSK.CreatedBy, CTSK.UpdatedAt, CTSK.UpdatedBy, CTSK.IsActive,
           SK.TenSK, KH.HoTen AS TenKH
    FROM CTSuKien CTSK
    LEFT JOIN SuKien SK ON CTSK.MaSK = SK.MaSK
    LEFT JOIN KhachHang KH ON CTSK.MaKH = KH.MaKH
    WHERE (@MaCTSK IS NULL OR CTSK.MaCTSK = @MaCTSK)
      AND (@MaSK IS NULL OR CTSK.MaSK = @MaSK)
      AND (@MaKH IS NULL OR CTSK.MaKH = @MaKH)
      AND (@TrangThai IS NULL OR CTSK.TrangThai = @TrangThai)
      AND (@IsActive IS NULL OR CTSK.IsActive = @IsActive)
    ORDER BY CTSK.NgayBD DESC;
END
GO

-- [PROC - CHI TIẾT SỰ KIỆN] Thêm mới (FIX: MaCTDV allows NULL)
CREATE OR ALTER PROC sp_InsertCTSuKien
    @MaCTSK NVARCHAR(20),
    @MaSK NVARCHAR(20),
    @MaKH NVARCHAR(20),
    @SoLuong INT,
    @DonGia DECIMAL(12,2),
    @GhiChu NVARCHAR(300) = NULL,
    @DaThanhToan DECIMAL(12,2) = 0,
    @TrangThai NVARCHAR(50) = N'Lên kế hoạch',
    @NgayBD DATETIME2,
    @NgayKT DATETIME2,
    @TongKhach INT = NULL,
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
 
    INSERT INTO CTSuKien (MaCTSK, MaSK, MaKH, SoLuong, DonGia, GhiChu, 
                         DaThanhToan, TrangThai, NgayBD, NgayKT, TongKhach, 
                         CreatedBy, CreatedAt, IsActive)
    VALUES (@MaCTSK, @MaSK, @MaKH, @SoLuong, @DonGia, @GhiChu,
            @DaThanhToan, @TrangThai, @NgayBD, @NgayKT, @TongKhach,
            @CreatedBy, GETDATE(), @IsActive);
END
GO

-- [PROC - CHI TIẾT SỰ KIỆN] Cập nhật
CREATE OR ALTER PROC sp_UpdateCTSuKien
    @MaCTSK NVARCHAR(20),
    @TrangThai NVARCHAR(50) = NULL,
    @DaThanhToan DECIMAL(12,2) = NULL,
    @GhiChu NVARCHAR(300) = NULL,
    @TongKhach INT = NULL,
    @UpdatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    UPDATE CTSuKien
    SET TrangThai = ISNULL(@TrangThai, TrangThai),
        DaThanhToan = ISNULL(@DaThanhToan, DaThanhToan),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        TongKhach = ISNULL(@TongKhach, TongKhach),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaCTSK = @MaCTSK;
END
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

-- LƯU Ý: Bảng GoiSuKien đã được tạo trong 01_Tables_Schema.sql
-- Không tạo lại ở đây để tránh lỗi

-- ============================================
-- STORED PROCEDURES CHO GÓI SỰ KIỆN
-- ============================================

-- Lấy danh sách gói sự kiện
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetGoiSuKien')
    DROP PROC sp_GetGoiSuKien;
GO

CREATE PROC sp_GetGoiSuKien
    @MaGoiSK NVARCHAR(20) = NULL,
    @MaSK NVARCHAR(20) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @IsGoiMacDinh BIT = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SELECT 
        GSK.MaGoiSK,
        GSK.TenGoiSK,
        GSK.MaSK,
        SK.TenSK,
        SK.LoaiSuKien,
        GSK.MoTa,
        GSK.GiaCoBan,
        GSK.SoKhachToiThieu,
        GSK.SoKhachToiDa,
        GSK.ThoiGianToiThieu,
        GSK.ThoiGianToiDa,
        GSK.DichVuKemTheo,
        GSK.IsGoiMacDinh,
        GSK.MaCN,
        CN.TenCN,
        GSK.CreatedAt,
        GSK.CreatedBy,
        GSK.UpdatedAt,
        GSK.UpdatedBy,
        GSK.IsActive
    FROM GoiSuKien GSK
    LEFT JOIN ChiNhanh CN ON GSK.MaCN = CN.MaCN
    LEFT JOIN SuKien SK ON GSK.MaSK = SK.MaSK
    WHERE (@MaGoiSK IS NULL OR GSK.MaGoiSK = @MaGoiSK)
      AND (@MaSK IS NULL OR GSK.MaSK = @MaSK)
      AND (@MaCN IS NULL OR GSK.MaCN IS NULL OR GSK.MaCN = @MaCN)
      AND (@IsGoiMacDinh IS NULL OR GSK.IsGoiMacDinh = @IsGoiMacDinh)
      AND (@IsActive IS NULL OR GSK.IsActive = @IsActive)
    ORDER BY SK.LoaiSuKien, GSK.GiaCoBan;
END
GO

-- Thêm gói sự kiện
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_InsertGoiSuKien')
    DROP PROC sp_InsertGoiSuKien;
GO

CREATE PROC sp_InsertGoiSuKien
    @MaGoiSK NVARCHAR(20),
    @TenGoiSK NVARCHAR(200),
    @MaSK NVARCHAR(20),
    @MoTa NVARCHAR(500) = NULL,
    @GiaCoBan DECIMAL(12,2),
    @SoKhachToiThieu INT = 10,
    @SoKhachToiDa INT = NULL,
    @ThoiGianToiThieu INT = NULL,
    @ThoiGianToiDa INT = NULL,
    @DichVuKemTheo NVARCHAR(500) = NULL,
    @IsGoiMacDinh BIT = 0,
    @MaCN NVARCHAR(20) = NULL,
    @CreatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = 1
AS
BEGIN
    INSERT INTO GoiSuKien (MaGoiSK, TenGoiSK, MaSK, MoTa, GiaCoBan, SoKhachToiThieu, 
                          SoKhachToiDa, ThoiGianToiThieu, ThoiGianToiDa, DichVuKemTheo, 
                          IsGoiMacDinh, MaCN, CreatedBy, IsActive, CreatedAt)
    VALUES (@MaGoiSK, @TenGoiSK, @MaSK, @MoTa, @GiaCoBan, @SoKhachToiThieu, 
            @SoKhachToiDa, @ThoiGianToiThieu, @ThoiGianToiDa, @DichVuKemTheo, 
            @IsGoiMacDinh, @MaCN, @CreatedBy, @IsActive, GETDATE());
END
GO

-- Cập nhật gói sự kiện
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_UpdateGoiSuKien')
    DROP PROC sp_UpdateGoiSuKien;
GO

CREATE PROC sp_UpdateGoiSuKien
    @MaGoiSK NVARCHAR(20),
    @TenGoiSK NVARCHAR(200) = NULL,
    @MaSK NVARCHAR(20) = NULL,
    @MoTa NVARCHAR(500) = NULL,
    @GiaCoBan DECIMAL(12,2) = NULL,
    @SoKhachToiThieu INT = NULL,
    @SoKhachToiDa INT = NULL,
    @ThoiGianToiThieu INT = NULL,
    @ThoiGianToiDa INT = NULL,
    @DichVuKemTheo NVARCHAR(500) = NULL,
    @MaCN NVARCHAR(20) = NULL,
    @UpdatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    UPDATE GoiSuKien
    SET TenGoiSK = ISNULL(@TenGoiSK, TenGoiSK),
        MaSK = ISNULL(@MaSK, MaSK),
        MoTa = ISNULL(@MoTa, MoTa),
        GiaCoBan = ISNULL(@GiaCoBan, GiaCoBan),
        SoKhachToiThieu = ISNULL(@SoKhachToiThieu, SoKhachToiThieu),
        SoKhachToiDa = ISNULL(@SoKhachToiDa, SoKhachToiDa),
        ThoiGianToiThieu = ISNULL(@ThoiGianToiThieu, ThoiGianToiThieu),
        ThoiGianToiDa = ISNULL(@ThoiGianToiDa, ThoiGianToiDa),
        DichVuKemTheo = ISNULL(@DichVuKemTheo, DichVuKemTheo),
        MaCN = ISNULL(@MaCN, MaCN),
        UpdatedBy = @UpdatedBy,
        UpdatedAt = GETDATE(),
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaGoiSK = @MaGoiSK;
END
GO




-- ==============================================================================
-- STORED PROCEDURES CHO THỐNG KÊ
-- ==============================================================================

-- [PROC - THỐNG KÊ] Doanh thu
CREATE OR ALTER PROC sp_GetDoanhThu
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
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
 
    SELECT ISNULL(SUM(SoTienBoiThuong), 0) as ChiPhi
    FROM Complaint
    WHERE TrangThai = N'Đã xử lý' AND SoTienBoiThuong > 0
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayGhi) = @Year)
      AND (@Month IS NULL OR MONTH(NgayGhi) = @Month);
END
GO

-- [PROC - THỐNG KÊ] Đặt cọc
CREATE OR ALTER PROC sp_GetDatCoc
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
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
          MaCTSK IN (SELECT MaCTSK FROM CTSuKien WHERE MaSK IN (SELECT MaSK FROM SuKien WHERE MaCN = @MaCN))
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
 
    SELECT ISNULL(SUM(SoTienHoan), 0) as HoanTien
    FROM HoanCoc
    WHERE (@Year IS NULL OR YEAR(NgayHoan) = @Year)
      AND (@Month IS NULL OR MONTH(NgayHoan) = @Month)
      AND (
          @MaCN IS NULL OR 
          MaDatCoc IN (
              SELECT MaDatCoc FROM DatCoc 
              WHERE MaDP IN (SELECT MaDP FROM DatPhong WHERE MaCN = @MaCN)
                 OR MaCTSK IN (SELECT MaCTSK FROM CTSuKien WHERE MaSK IN (SELECT MaSK FROM SuKien WHERE MaCN = @MaCN))
          )
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
 
    SELECT COUNT(*) as TongSK
    FROM CTSuKien
    WHERE IsActive = 1
      AND (@Year IS NULL OR YEAR(NgayBD) = @Year)
      AND (@Month IS NULL OR MONTH(NgayBD) = @Month)
      AND (
          @MaCN IS NULL OR 
          MaSK IN (SELECT MaSK FROM SuKien WHERE MaCN = @MaCN)
      );
END
GO

-- [PROC - THỐNG KÊ] Doanh thu sự kiện
CREATE OR ALTER PROC sp_GetDoanhThuSuKien
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT ISNULL(SUM(ThanhTien), 0) as DoanhThu
    FROM CTSuKien
    WHERE IsActive = 1 AND TrangThai = N'Đã thanh toán đủ'
      AND (@Year IS NULL OR YEAR(NgayBD) = @Year)
      AND (@Month IS NULL OR MONTH(NgayBD) = @Month)
      AND (
          @MaCN IS NULL OR 
          MaSK IN (SELECT MaSK FROM SuKien WHERE MaCN = @MaCN)
      );
END
GO

-- [PROC - THỐNG KÊ] Tổng khách hàng
CREATE OR ALTER PROC sp_GetTongKhachHang
AS
BEGIN
 
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

-- ✅ FIX 4: Stored Procedure đơn giản để lấy active booking theo phòng
-- [PROC - ĐƠN GIẢN] Lấy active booking detail theo phòng (dùng cho TryGetActiveBooking)
CREATE OR ALTER PROC sp_GetActiveBookingByRoom
    @MaPhong NVARCHAR(20)
AS
BEGIN
 
    -- Lấy booking detail đang active (trạng thái "Đặt" hoặc "Đang sử dụng")
    -- Ưu tiên "Đang sử dụng" trước
    SELECT TOP 1
        CTDP.MaCTDP, CTDP.MaDP, CTDP.TrangThai, CTDP.NgayDen, CTDP.NgayDi,
        CTDP.NguoiLon, CTDP.TreEm, CTDP.MaPhong, CTDP.GiaPhong, CTDP.ThanhTien,
        CTDP.CreatedAt, CTDP.CreatedBy, CTDP.UpdatedAt, CTDP.UpdatedBy, CTDP.IsActive,
        DP.MaKH, DP.MaNV, DP.TrangThai AS TrangThaiBooking,
        P.SoPhong, P.ViTri, LP.TenLP, LP.GiaTheoNgay
    FROM CTDatPhong CTDP
    INNER JOIN DatPhong DP ON CTDP.MaDP = DP.MaDP
    LEFT JOIN Phong P ON CTDP.MaPhong = P.MaPhong
    LEFT JOIN LoaiPhong LP ON P.MaLP = LP.MaLP
    WHERE CTDP.MaPhong = @MaPhong
      AND CTDP.IsActive = 1
      AND (CTDP.TrangThai = N'Đặt' OR CTDP.TrangThai = N'Đang sử dụng' OR CTDP.TrangThai = N'Đang Sử Dụng')
      AND (CTDP.NgayDi IS NULL OR CTDP.NgayDi >= CAST(GETDATE() AS DATE))
    ORDER BY 
        CASE WHEN CTDP.TrangThai = N'Đang sử dụng' OR CTDP.TrangThai = N'Đang Sử Dụng' THEN 1 ELSE 2 END,
        CTDP.NgayDen DESC;
END
GO

-- ==========================================
-- STORED PROCEDURES CHO TÀI KHOẢN (ACCOUNT/TAIKHOAN)
-- ==========================================

-- [PROC - TÀI KHOẢN] Lấy danh sách
CREATE OR ALTER PROC sp_GetTaiKhoan
    @MaTK NVARCHAR(20) = NULL,
    @MaNV NVARCHAR(20) = NULL,
    @TenDangNhap NVARCHAR(100) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    SELECT MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM TaiKhoan
    WHERE (@MaTK IS NULL OR MaTK = @MaTK)
      AND (@MaNV IS NULL OR MaNV = @MaNV)
      AND (@TenDangNhap IS NULL OR TenDangNhap = @TenDangNhap)
      AND (@IsActive IS NULL OR IsActive = @IsActive);
END
GO

-- [PROC - TÀI KHOẢN] Thêm mới
CREATE OR ALTER PROC sp_InsertTaiKhoan
    @MaTK NVARCHAR(20),
    @MaNV NVARCHAR(20),
    @TenDangNhap NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @Role NVARCHAR(20) = N'NhanVien',
    @CreatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = 1
AS
BEGIN
 
    INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
    VALUES (@MaTK, @MaNV, @TenDangNhap, @MatKhau, @Role, GETDATE(), @CreatedBy, @IsActive);
END
GO

-- [PROC - TÀI KHOẢN] Cập nhật
CREATE OR ALTER PROC sp_UpdateTaiKhoan
    @MaTK NVARCHAR(20),
    @TenDangNhap NVARCHAR(100) = NULL,
    @MatKhau NVARCHAR(100) = NULL,
    @Role NVARCHAR(20) = NULL,
    @UpdatedBy NVARCHAR(20) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    UPDATE TaiKhoan
    SET TenDangNhap = ISNULL(@TenDangNhap, TenDangNhap),
        MatKhau = ISNULL(@MatKhau, MatKhau),
        Role = ISNULL(@Role, Role),
        UpdatedAt = GETDATE(),
        UpdatedBy = @UpdatedBy,
        IsActive = ISNULL(@IsActive, IsActive)
    WHERE MaTK = @MaTK;
END
GO

-- ==========================================
-- STORED PROCEDURES CHO ĐẶT CỌC (DEPOSIT/DATCOC)
-- ==========================================

-- [PROC - ĐẶT CỌC] Lấy danh sách (khác với sp_GetDatCoc cho thống kê)
CREATE OR ALTER PROC sp_GetDatCocList
    @MaDatCoc NVARCHAR(20) = NULL,
    @MaDP NVARCHAR(20) = NULL,
    @MaKH NVARCHAR(20) = NULL,
    @LoaiCoc NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(50) = NULL
AS
BEGIN
 
    SELECT DC.MaDatCoc, DC.MaDP, DC.MaCTSK, DC.MaKH, DC.SoTien, DC.NgayCoc,
           DC.HinhThucThanhToan, DC.LoaiCoc, DC.TrangThai, DC.GhiChu,
           DC.CreatedAt, DC.CreatedBy, DC.UpdatedAt, DC.UpdatedBy,
           KH.HoTen AS TenKH
    FROM DatCoc DC
    LEFT JOIN KhachHang KH ON DC.MaKH = KH.MaKH
    WHERE (@MaDatCoc IS NULL OR DC.MaDatCoc = @MaDatCoc)
      AND (@MaDP IS NULL OR DC.MaDP = @MaDP)
      AND (@MaKH IS NULL OR DC.MaKH = @MaKH)
      AND (@LoaiCoc IS NULL OR DC.LoaiCoc = @LoaiCoc)
      AND (@TrangThai IS NULL OR DC.TrangThai = @TrangThai)
    ORDER BY DC.NgayCoc DESC;
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
    @CreatedBy NVARCHAR(20) = NULL
AS
BEGIN
 
    INSERT INTO DatCoc (MaDatCoc, MaDP, MaCTSK, MaKH, SoTien, NgayCoc, HinhThucThanhToan, LoaiCoc, TrangThai, GhiChu, CreatedAt, CreatedBy)
    VALUES (@MaDatCoc, @MaDP, @MaCTSK, @MaKH, @SoTien, GETDATE(), @HinhThucThanhToan, @LoaiCoc, @TrangThai, @GhiChu, GETDATE(), @CreatedBy);
END
GO

-- [PROC - ĐẶT CỌC] Cập nhật
CREATE OR ALTER PROC sp_UpdateDatCoc
    @MaDatCoc NVARCHAR(20),
    @SoTien DECIMAL(18,2) = NULL,
    @HinhThucThanhToan NVARCHAR(50) = NULL,
    @TrangThai NVARCHAR(50) = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @UpdatedBy NVARCHAR(20) = NULL
AS
BEGIN
 
    UPDATE DatCoc
    SET SoTien = ISNULL(@SoTien, SoTien),
        HinhThucThanhToan = ISNULL(@HinhThucThanhToan, HinhThucThanhToan),
        TrangThai = ISNULL(@TrangThai, TrangThai),
        GhiChu = ISNULL(@GhiChu, GhiChu),
        UpdatedAt = GETDATE(),
        UpdatedBy = @UpdatedBy
    WHERE MaDatCoc = @MaDatCoc;
END
GO

-- [PROC - ĐẶT CỌC] Tạo mã mới
CREATE OR ALTER PROC sp_GenerateMaDatCoc
AS
BEGIN
 
    DECLARE @MaxNumber INT = 0;
    DECLARE @LastCode NVARCHAR(20);
    
    SELECT TOP 1 @LastCode = MaDatCoc
    FROM DatCoc
    ORDER BY MaDatCoc DESC;
    
    IF @LastCode IS NOT NULL AND LEN(@LastCode) >= 3
    BEGIN
        DECLARE @NumberPart NVARCHAR(10) = SUBSTRING(@LastCode, 3, LEN(@LastCode));
        IF ISNUMERIC(@NumberPart) = 1
            SET @MaxNumber = CAST(@NumberPart AS INT);
    END
    
    SELECT 'DC' + RIGHT('000' + CAST(@MaxNumber + 1 AS NVARCHAR), 3) AS MaDatCocMoi;
END
GO

-- ============================================
-- STORED PROCEDURES THỐNG KÊ (Statistics)
-- ============================================

-- [STAT] Doanh thu tổng (từ HoaDon đã thanh toán)
CREATE OR ALTER PROC sp_GetDoanhThu
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT ISNULL(SUM(TongTien), 0) AS DoanhThu
    FROM HoaDon
    WHERE TrangThai = N'Đã TT'
      AND IsActive = 1
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayLap) = @Year)
      AND (@Month IS NULL OR MONTH(NgayLap) = @Month);
END
GO

-- [STAT] Doanh thu sự kiện (từ HoaDon có LoaiHoaDon = 'SuKien')
CREATE OR ALTER PROC sp_GetDoanhThuSuKien
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT ISNULL(SUM(TongTien), 0) AS DoanhThu
    FROM HoaDon
    WHERE TrangThai = N'Đã TT'
      AND LoaiHoaDon = N'SuKien'
      AND IsActive = 1
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayLap) = @Year)
      AND (@Month IS NULL OR MONTH(NgayLap) = @Month);
END
GO

-- [STAT] Tổng đặt phòng
CREATE OR ALTER PROC sp_GetTongDatPhong
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT COUNT(*) AS TongDatPhong
    FROM DatPhong DP
    INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    WHERE DP.IsActive = 1
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(DP.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(DP.CreatedAt) = @Month);
END
GO

-- [STAT] Đặt phòng theo trạng thái
CREATE OR ALTER PROC sp_GetDatPhongTheoTrangThai
    @MaCN NVARCHAR(20) = NULL,
    @TrangThai NVARCHAR(50),
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT COUNT(*) AS SoLuong
    FROM DatPhong DP
    INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    WHERE DP.TrangThai = @TrangThai
      AND DP.IsActive = 1
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(DP.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(DP.CreatedAt) = @Month);
END
GO

-- [STAT] Tổng sự kiện
CREATE OR ALTER PROC sp_GetTongSuKien
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT COUNT(*) AS TongSuKien
    FROM CTSuKien CTSK
    INNER JOIN SuKien SK ON CTSK.MaSK = SK.MaSK
    WHERE CTSK.IsActive = 1
      AND (@MaCN IS NULL OR SK.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(CTSK.NgayBD) = @Year)
      AND (@Month IS NULL OR MONTH(CTSK.NgayBD) = @Month);
END
GO

-- [STAT] Tổng khách hàng
CREATE OR ALTER PROC sp_GetTongKhachHang
AS
BEGIN
 
    SELECT COUNT(*) AS TongKhachHang
    FROM KhachHang
    WHERE IsActive = 1;
END
GO

-- [STAT] Khách hàng mới
CREATE OR ALTER PROC sp_GetKhachHangMoi
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT COUNT(*) AS KhachHangMoi
    FROM KhachHang
    WHERE IsActive = 1
      AND (@Year IS NULL OR YEAR(CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(CreatedAt) = @Month);
END
GO

-- [STAT] Doanh thu dịch vụ
CREATE OR ALTER PROC sp_GetDoanhThuDichVu
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT ISNULL(SUM(CTDV.ThanhTien), 0) AS DoanhThu
    FROM CTDichVu CTDV
    INNER JOIN CTDatPhong CTDP ON CTDV.MaCTDP = CTDP.MaCTDP
    WHERE CTDV.IsActive = 1
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(CTDV.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(CTDV.CreatedAt) = @Month);
END
GO

-- [STAT] Tổng đặt cọc
CREATE OR ALTER PROC sp_GetDatCoc
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    -- Lấy tổng đặt cọc từ bảng DatCoc (join với DatPhong hoặc CTSuKien để lấy MaCN)
    SELECT ISNULL(SUM(DC.SoTien), 0) AS DatCoc
    FROM DatCoc DC
    LEFT JOIN DatPhong DP ON DC.MaDP = DP.MaDP
    LEFT JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    LEFT JOIN CTSuKien CTSK ON DC.MaCTSK = CTSK.MaCTSK
    LEFT JOIN SuKien SK ON CTSK.MaSK = SK.MaSK
    WHERE DC.TrangThai = N'ĐÃ NHẬN'
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN OR SK.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(DC.NgayCoc) = @Year)
      AND (@Month IS NULL OR MONTH(DC.NgayCoc) = @Month);
END
GO

-- [STAT] Tổng hoàn tiền
CREATE OR ALTER PROC sp_GetHoanTien
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    SELECT ISNULL(SUM(SoTienHoan), 0) AS HoanTien
    FROM HoanCoc
    WHERE TrangThai = N'ĐÃ HOÀN'
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayHoan) = @Year)
      AND (@Month IS NULL OR MONTH(NgayHoan) = @Month);
END
GO

-- [STAT] Tổng chi phí (placeholder - hiện chưa có bảng chi phí)
CREATE OR ALTER PROC sp_GetChiPhi
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 
    -- Hiện tại chưa có bảng chi phí, trả về 0
    SELECT 0 AS ChiPhi;
END
GO

-- [PROC - TÀI KHOẢN] Xem danh sách/Chi tiết
CREATE OR ALTER PROC sp_GetTaiKhoan
    @MaTK NVARCHAR(20) = NULL,
    @MaNV NVARCHAR(20) = NULL,
    @TenDangNhap NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
 
    SELECT MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    FROM TaiKhoan
    WHERE (@MaTK IS NULL OR MaTK = @MaTK)
      AND (@MaNV IS NULL OR MaNV = @MaNV)
      AND (@TenDangNhap IS NULL OR TenDangNhap = @TenDangNhap)
      AND (@IsActive IS NULL OR IsActive = @IsActive)
    ORDER BY MaTK;
END
GO

-- [PROC - TÀI KHOẢN] Thêm mới
CREATE OR ALTER PROC sp_InsertTaiKhoan
    @MaTK NVARCHAR(20),
    @MaNV NVARCHAR(20),
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(100),
    @Role NVARCHAR(20),
    @CreatedBy NVARCHAR(20),
    @IsActive BIT = 1
AS
BEGIN
 
    INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
    VALUES (@MaTK, @MaNV, @TenDangNhap, @MatKhau, @Role, GETDATE(), @CreatedBy, @IsActive);
END
GO

-- [PROC - TÀI KHOẢN] Cập nhật
CREATE OR ALTER PROC sp_UpdateTaiKhoan
    @MaTK NVARCHAR(20),
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(100),
    @Role NVARCHAR(20),
    @UpdatedBy NVARCHAR(20),
    @IsActive BIT
AS
BEGIN
 
    UPDATE TaiKhoan
    SET TenDangNhap = @TenDangNhap,
        MatKhau = @MatKhau,
        Role = @Role,
        UpdatedAt = GETDATE(),
        UpdatedBy = @UpdatedBy,
        IsActive = @IsActive
    WHERE MaTK = @MaTK;
END
GO

-- [PROC - TÀI KHOẢN] Xóa (Soft Delete)
CREATE OR ALTER PROC sp_DeleteTaiKhoan
    @MaTK NVARCHAR(20)
AS
BEGIN
 
    UPDATE TaiKhoan SET IsActive = 0 WHERE MaTK = @MaTK;
END
GO
USE QLR;
GO

-- [STAT] Tổng hợp thống kê Resort (Dùng cho Crystal Report direct SQL)
CREATE OR ALTER PROC sp_GetResortStatistics
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
 

    -- Biến lưu trữ kết quả thống kê
    DECLARE @TongPhong INT = 0;
    DECLARE @PhongTrong INT = 0;
    DECLARE @PhongDangSuDung INT = 0;
    DECLARE @PhongBaoTri INT = 0;
    DECLARE @PhongNgung INT = 0;
    
    DECLARE @DoanhThu DECIMAL(18,2) = 0;
    DECLARE @DoanhThuSuKien DECIMAL(18,2) = 0;
    DECLARE @DoanhThuDichVu DECIMAL(18,2) = 0;
    DECLARE @ChiPhi DECIMAL(18,2) = 0;
    DECLARE @DatCoc DECIMAL(18,2) = 0;
    DECLARE @HoanTien DECIMAL(18,2) = 0;
    
    DECLARE @TongDatPhong INT = 0;
    DECLARE @DatPhongHoanTat INT = 0;
    DECLARE @DatPhongHuy INT = 0;
    
    DECLARE @TongSuKien INT = 0;
    DECLARE @TongKhachHang INT = 0;
    DECLARE @KhachHangMoi INT = 0;
    DECLARE @TongNhanVien INT = 0;
    DECLARE @TongDichVu INT = 0;

    -- 1. Thống kê thông tin PHÒNG (Hiện tại - không theo thời gian)
    -- Chỉ tính theo MaCN, bỏ qua Year/Month vì trạng thái phòng là realtime
    SELECT @TongPhong = COUNT(*) FROM Phong WHERE IsActive = 1 AND (@MaCN IS NULL OR MaCN = @MaCN);
    SELECT @PhongTrong = COUNT(*) FROM Phong WHERE TrangThai = N'Trống' AND IsActive = 1 AND (@MaCN IS NULL OR MaCN = @MaCN);
    SELECT @PhongDangSuDung = COUNT(*) FROM Phong WHERE (TrangThai = N'Đã đặt' OR TrangThai = N'Đang Sử Dụng' OR TrangThai = N'Đang Dọn') AND IsActive = 1 AND (@MaCN IS NULL OR MaCN = @MaCN);
    SELECT @PhongBaoTri = COUNT(*) FROM Phong WHERE TrangThai = N'Bảo trì' AND IsActive = 1 AND (@MaCN IS NULL OR MaCN = @MaCN);
    SELECT @PhongNgung = COUNT(*) FROM Phong WHERE TrangThai = N'Ngưng hoạt động' AND IsActive = 1 AND (@MaCN IS NULL OR MaCN = @MaCN);

    -- 2. Thống kê NHÂN VIÊN (Hiện tại)
    SELECT @TongNhanVien = COUNT(*) FROM NhanVien WHERE IsActive = 1 AND (@MaCN IS NULL OR MaCN = @MaCN);

    -- 3. Thống kê DỊCH VỤ (Hiện tại)
    -- Dịch vụ là chung toàn hệ thống, không lọc theo MaCN
    SELECT @TongDichVu = COUNT(*) FROM DichVu WHERE IsActive = 1;

    -- 4. Thống kê TÀI CHÍNH (Theo thời gian)
    -- 4.1 Doanh thu
    SELECT @DoanhThu = ISNULL(SUM(TongTien), 0)
    FROM HoaDon
    WHERE TrangThai = N'Đã TT' AND IsActive = 1
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayLap) = @Year)
      AND (@Month IS NULL OR MONTH(NgayLap) = @Month);

    -- 4.2 Doanh thu Sự kiện
    SELECT @DoanhThuSuKien = ISNULL(SUM(TongTien), 0)
    FROM HoaDon
    WHERE TrangThai = N'Đã TT' AND LoaiHoaDon = N'SuKien' AND IsActive = 1
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayLap) = @Year)
      AND (@Month IS NULL OR MONTH(NgayLap) = @Month);
      
    -- 4.3 Doanh thu Dịch vụ (Tính từ chi tiết)
    SELECT @DoanhThuDichVu = ISNULL(SUM(CTDV.ThanhTien), 0)
    FROM CTDichVu CTDV
    INNER JOIN CTDatPhong CTDP ON CTDV.MaCTDP = CTDP.MaCTDP
    WHERE CTDV.IsActive = 1
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(CTDV.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(CTDV.CreatedAt) = @Month);

    -- 4.4 Đặt cọc
    SELECT @DatCoc = ISNULL(SUM(DC.SoTien), 0)
    FROM DatCoc DC
    LEFT JOIN DatPhong DP ON DC.MaDP = DP.MaDP
    LEFT JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    LEFT JOIN CTSuKien CTSK ON DC.MaCTSK = CTSK.MaCTSK
    LEFT JOIN SuKien SK ON CTSK.MaSK = SK.MaSK
    WHERE DC.TrangThai = N'ĐÃ NHẬN'
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN OR SK.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(DC.NgayCoc) = @Year)
      AND (@Month IS NULL OR MONTH(DC.NgayCoc) = @Month);

    -- 4.5 Hoàn tiền
    SELECT @HoanTien = ISNULL(SUM(SoTienHoan), 0)
    FROM HoanCoc
    WHERE TrangThai = N'ĐÃ HOÀN'
      AND (@MaCN IS NULL OR MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(NgayHoan) = @Year)
      AND (@Month IS NULL OR MONTH(NgayHoan) = @Month);

    -- 5. Thống kê ĐẶT PHÒNG
    -- 5.1 Tổng đặt phòng
    SELECT @TongDatPhong = COUNT(*)
    FROM DatPhong DP
    INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    WHERE DP.IsActive = 1
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(DP.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(DP.CreatedAt) = @Month);

    -- 5.2 Đặt phòng hoàn tất
    SELECT @DatPhongHoanTat = COUNT(*)
    FROM DatPhong DP
    INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    WHERE DP.TrangThai = N'Hoàn tất' AND DP.IsActive = 1
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(DP.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(DP.CreatedAt) = @Month);

    -- 5.3 Đặt phòng hủy
    SELECT @DatPhongHuy = COUNT(*)
    FROM DatPhong DP
    INNER JOIN CTDatPhong CTDP ON DP.MaDP = CTDP.MaDP
    WHERE DP.TrangThai = N'Hủy' AND DP.IsActive = 1
      AND (@MaCN IS NULL OR CTDP.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(DP.CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(DP.CreatedAt) = @Month);

    -- 6. Thống kê SỰ KIỆN
    SELECT @TongSuKien = COUNT(*)
    FROM CTSuKien CTSK
    INNER JOIN SuKien SK ON CTSK.MaSK = SK.MaSK
    WHERE CTSK.IsActive = 1
      AND (@MaCN IS NULL OR SK.MaCN = @MaCN)
      AND (@Year IS NULL OR YEAR(CTSK.NgayBD) = @Year)
      AND (@Month IS NULL OR MONTH(CTSK.NgayBD) = @Month);

    -- 7. Thống kê KHÁCH HÀNG
    SELECT @TongKhachHang = COUNT(*) FROM KhachHang WHERE IsActive = 1;
    
    SELECT @KhachHangMoi = COUNT(*) 
    FROM KhachHang 
    WHERE IsActive = 1
      AND (@Year IS NULL OR YEAR(CreatedAt) = @Year)
      AND (@Month IS NULL OR MONTH(CreatedAt) = @Month);

    -- RETURN RESULT SET
    SELECT 
        @MaCN AS MaCN,
        CONCAT(N'Tháng ', ISNULL(CAST(@Month AS NVARCHAR), 'All'), '/', ISNULL(CAST(@Year AS NVARCHAR), 'All')) AS ThoiGian,
        
        @TongPhong AS TongPhong,
        @PhongTrong AS PhongTrong,
        @PhongDangSuDung AS PhongDangSuDung,
        @PhongBaoTri AS PhongBaoTri,
        @PhongNgung AS PhongNgung,
        
        @DoanhThu AS DoanhThu,
        @ChiPhi AS ChiPhi,
        (@DoanhThu - @ChiPhi) AS LoiNhuan,
        @DatCoc AS DatCoc,
        @HoanTien AS HoanTien,
        
        @TongDatPhong AS TongDatPhong,
        @DatPhongHoanTat AS DatPhongHoanTat,
        @DatPhongHuy AS DatPhongHuy,
        CASE WHEN @TongDatPhong > 0 THEN CAST((@DatPhongHoanTat * 100.0 / @TongDatPhong) AS FLOAT) ELSE 0 END AS TiLeThanhCong,
        
        @TongSuKien AS TongSuKien,
        @DoanhThuSuKien AS DoanhThuSuKien,
        
        @TongKhachHang AS TongKhachHang,
        @KhachHangMoi AS KhachHangMoi,
        @TongNhanVien AS TongNhanVien,
        
        @TongDichVu AS TongDichVu,
        @DoanhThuDichVu AS DoanhThuDichVu;
END
GO

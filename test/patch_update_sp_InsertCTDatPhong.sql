
-- 1. Add LoaiThue column
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CTDatPhong' AND COLUMN_NAME = 'LoaiThue')
BEGIN
    ALTER TABLE CTDatPhong ADD LoaiThue NVARCHAR(20) DEFAULT N'Ngày' WITH VALUES;
END
GO

-- 2. Add Constraint
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE name = 'CHK_CTDatPhong_LoaiThue')
BEGIN
    ALTER TABLE CTDatPhong ADD CONSTRAINT CHK_CTDatPhong_LoaiThue CHECK (LoaiThue IN (N'Giờ', N'Ngày', N'Tháng'));
END
GO

-- 3. Update Stored Procedure
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
    @LoaiThue NVARCHAR(20) = N'Ngày' -- Added parameter
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO CTDatPhong (MaCTDP, MaDP, TrangThai, NgayDen, NgayDi, NguoiLon, TreEm,
                           MaPhong, GiaPhong, ThanhTien, CreatedBy, CreatedAt, IsActive, LoaiThue)
    VALUES (@MaCTDP, @MaDP, @TrangThai, @NgayDen, @NgayDi, @NguoiLon, @TreEm,
            @MaPhong, @GiaPhong, @ThanhTien, @CreatedBy, GETDATE(), @IsActive, @LoaiThue);
END
GO

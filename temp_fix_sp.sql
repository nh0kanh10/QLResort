USE QLR;
GO

CREATE OR ALTER PROC sp_GetGoiSuKien
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

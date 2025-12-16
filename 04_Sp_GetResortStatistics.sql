USE QLR;
GO

-- [STAT] Tổng hợp thống kê Resort (Dùng cho Crystal Report direct SQL)
CREATE OR ALTER PROC sp_GetResortStatistics
    @MaCN NVARCHAR(20) = NULL,
    @Year INT = NULL,
    @Month INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

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

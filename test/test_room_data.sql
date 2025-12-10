-- ==================================================
-- TEST SCRIPT: Kiểm tra dữ liệu phòng trong database
-- ==================================================

USE QLR;
GO

PRINT N'====================================================';
PRINT N'1. KIỂM TRA SỐ LƯỢNG BẢN GHI TRONG CÁC BẢNG LIÊN QUAN';
PRINT N'====================================================';

-- Kiểm tra bảng Phong
SELECT COUNT(*) as TotalRooms, 
       SUM(CASE WHEN IsActive = 1 THEN 1 ELSE 0 END) as ActiveRooms,
       SUM(CASE WHEN IsActive = 0 THEN 1 ELSE 0 END) as InactiveRooms
FROM Phong;

-- Kiểm tra bảng LoaiPhong
SELECT COUNT(*) as TotalRoomTypes,
       SUM(CASE WHEN IsActive = 1 THEN 1 ELSE 0 END) as ActiveRoomTypes
FROM LoaiPhong;

-- Kiểm tra bảng ChiNhanh
SELECT COUNT(*) as TotalBranches,
       SUM(CASE WHEN IsActive = 1 THEN 1 ELSE 0 END) as ActiveBranches
FROM ChiNhanh;

PRINT N'';
PRINT N'====================================================';
PRINT N'2. XEM MẪU DỮ LIỆU PHÒNG (5 PHÒNG ĐẦU TIÊN)';
PRINT N'====================================================';

SELECT TOP 5 
    MaPhong, MaCN, MaLP, SoPhong, ViTri, TrangThai, IsActive
FROM Phong
ORDER BY MaPhong;

PRINT N'';
PRINT N'====================================================';
PRINT N'3. TEST STORED PROCEDURE sp_GetPhong - TẤT CẢ PHÒNG ACTIVE';
PRINT N'====================================================';

EXEC sp_GetPhong @IsActive = 1;

PRINT N'';
PRINT N'====================================================';
PRINT N'4. TEST STORED PROCEDURE sp_GetPhong - KHÔNG CÓ FILTER';
PRINT N'====================================================';

EXEC sp_GetPhong;

PRINT N'';
PRINT N'====================================================';
PRINT N'5. KIỂM TRA DỮ LIỆU PHÒNG THEO TRẠNG THÁI';
PRINT N'====================================================';

SELECT 
    TrangThai,
    COUNT(*) as SoLuong
FROM Phong
GROUP BY TrangThai
ORDER BY COUNT(*) DESC;

PRINT N'';
PRINT N'====================================================';
PRINT N'6. KIỂM TRA DỮ LIỆU PHÒNG THEO CHI NHÁNH';
PRINT N'====================================================';

SELECT 
    P.MaCN,
    CN.TenCN,
    COUNT(*) as SoLuongPhong
FROM Phong P
LEFT JOIN ChiNhanh CN ON P.MaCN = CN.MaCN
GROUP BY P.MaCN, CN.TenCN
ORDER BY COUNT(*) DESC;

PRINT N'';
PRINT N'====================================================';
PRINT N'7. TEST JOIN PHÒNG VỚI LOẠI PHÒNG (GIỐNG NHƯ STORED PROCEDURE)';
PRINT N'====================================================';

SELECT 
    P.MaPhong, P.MaCN, P.MaLP, P.SoPhong, P.ViTri, P.TrangThai, P.GhiChu, 
    P.CreatedAt, P.CreatedBy, P.UpdatedAt, P.UpdatedBy, P.IsActive,
    LP.TenLP AS TenLoaiPhong,
    LP.SucChuaToiDa,
    LP.GiaTheoNgay,
    LP.GiaTheoGio,
    LP.GiaTheoThang
FROM 
    Phong P
INNER JOIN 
    LoaiPhong LP ON P.MaLP = LP.MaLP
WHERE 
    P.IsActive = 1
ORDER BY P.MaPhong;

PRINT N'';
PRINT N'====================================================';
PRINT N'KẾT QUẢ CHẨN ĐOÁN';
PRINT N'====================================================';
PRINT N'- Nếu TotalRooms = 0: BẠN CHƯA CHẠY FILE 03_Data.sql';
PRINT N'- Nếu TotalRooms > 0 nhưng ActiveRooms = 0: TẤT CẢ PHÒNG BỊ VÔ HIỆU HÓA';
PRINT N'- Nếu stored procedure KHÔNG trả về dữ liệu: LỖI TRONG STORED PROCEDURE';
PRINT N'- Nếu stored procedure CÓ dữ liệu: VẤN ĐỀ Ở PHÍA APPLICATION (BUS/GUI)';
PRINT N'====================================================';

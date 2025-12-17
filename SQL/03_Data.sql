--================================================================================
-- FILE 3: 03_Data.sql
-- HỆ THỐNG QUẢN LÝ RESORT - DỮ LIỆU MẶC ĐỊNH (Refined & Consistent)
-- Mục đích: Chèn dữ liệu mẫu ban đầu cho database
-- Lưu ý: Chạy file này SAU KHI chạy 01_Tables_Schema.sql và 02_StoredProcedures.sql
--================================================================================

USE QLR;
GO
SET DATEFORMAT dmy;
GO

--- 6. DỮ LIỆU MẶC ĐỊNH (BASE DATA)
-- Cần Insert vào các bảng gốc (LoaiNV, ChiNhanh, NhanVien) trước

-- 1. LOẠI NHÂN VIÊN
INSERT INTO LoaiNhanVien (MaLoaiNV, TenLoaiNV, MoTa, CreatedBy, CreatedAt)
VALUES ('LNV00', N'Admin', N'Quản trị hệ thống resort, có toàn quyền thao tác', NULL, GETDATE());
GO

-- 2. CHI NHÁNH
INSERT INTO ChiNhanh (MaCN, TenCN, DiaChi, CreatedAt, IsActive)
VALUES
('CN01', N'Resort Biển Xanh', N'123 Đường Trần Phú, Nha Trang', GETDATE(), 1),
('CN02', N'Chi nhánh Phú Mỹ', N'123 Đường XYZ, TP.HCM', GETDATE(), 1);
GO

-- 3. NHÂN VIÊN
INSERT INTO NhanVien (MaNV, MaCN, CCCD, GioiTinh, HoTen, ChucVu, SDT, Email, MaLoaiNV, CreatedAt, IsActive)
VALUES
('NV01', 'CN01', '012345678901', N'Nam', N'Nguyễn Văn A', N'Giám đốc', '0912345678', 'admin@resort.com', 'LNV00', GETDATE(), 1),
('NV02', 'CN01', '023456789012', N'Nữ', N'Trần Thị B', N'Quản lý', '0923456789', 'quanly@resort.com', 'LNV00', GETDATE(), 1),
('NV03', 'CN01', '034567890123', N'Nam', N'Lê Văn C', N'Nhân viên', '0934567890', 'nhanvien@resort.com', 'LNV00', GETDATE(), 1),
('NV04', 'CN01', '045678901234', N'Nữ', N'Phạm Thị D', N'Nhân viên', '0945678901', 'nv2@resort.com', 'LNV00', GETDATE(), 1),
('NV05', 'CN02', '056789012345', N'Nam', N'Hoàng Văn E', N'Quản lý', '0956789012', 'ql2@resort.com', 'LNV00', GETDATE(), 1),
('NV06', 'CN02', '067890123456', N'Nữ', N'Võ Thị F', N'Nhân viên', '0967890123', 'nv3@resort.com', 'LNV00', GETDATE(), 1);
GO

-- Cập nhật MaQuanLy cho ChiNhanh
UPDATE ChiNhanh SET MaQuanLy = 'NV01', CreatedBy = 'NV01' WHERE MaCN = 'CN01';
UPDATE ChiNhanh SET MaQuanLy = 'NV05', CreatedBy = 'NV05' WHERE MaCN = 'CN02';
GO

-- 4. TÀI KHOẢN
INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
VALUES
('TK001', 'NV01', 'admin', 'admin123', N'Admin', GETDATE(), 'NV01', 1),
('TK002', 'NV02', 'quanly', 'quanly123', N'QuanLy', GETDATE(), 'NV01', 1),
('TK003', 'NV03', 'nhanvien', 'nv123456', N'NhanVien', GETDATE(), 'NV01', 1),
('TK004', 'NV04', 'nv2', 'nv123456', N'NhanVien', GETDATE(), 'NV01', 1),
('TK005', 'NV05', 'quanly2', 'quanly123', N'QuanLy', GETDATE(), 'NV01', 1),
('TK006', 'NV06', 'nv3', 'nv123456', N'NhanVien', GETDATE(), 'NV01', 1);
GO

-- 5. LOẠI KHÁCH HÀNG
INSERT INTO LoaiKhachHang (MaLKH, TenLKH, GiamGiaPercent, DiemToiThieu, MoTa, CreatedBy)
VALUES
(N'LKH01', N'Standard', 0, 0, N'Khách phổ thông, không ưu đãi.', N'NV01'),
(N'LKH02', N'Silver', 5, 500, N'Giảm giá nhẹ, tích lũy điểm.', N'NV01'), 
(N'LKH03', N'Gold', 10, 1500, N'Giảm giá tốt, ưu tiên đặt phòng.', N'NV01'),
(N'LKH04', N'VIP', 20, 3000, N'Khách hàng thân thiết, ưu đãi cao.', N'NV01');
GO

-- 6. KHÁCH HÀNG
INSERT INTO KhachHang (MaKH, HoTen, GioiTinh, NgaySinh, SDT, Email, IDType, IDNumber, DiaChi, MaLKH, CreatedBy)
VALUES
(N'KH001', N'Nguyễn Văn An', N'Nam', '12-05-1990', N'0901234567', N'an.nguyen@gmail.com', N'CCCD', N'012345678900', N'Hà Nội', N'LKH01', N'NV01'),
(N'KH002', N'Trần Thị Bình', N'Nữ', '27-03-1995', N'0912345678', N'tbinh@gmail.com', N'CCCD', N'023456789012', N'Hồ Chí Minh', N'LKH02', N'NV01'),
(N'KH003', N'Lê Minh Châu', N'Nữ', '10-10-1988', N'0987654321', N'leminhchau@yahoo.com', N'Passport', N'P1234567', N'Đà Nẵng', N'LKH03', N'NV01'),
(N'KH004', N'Phạm Quốc Dũng', N'Nam', '01-07-1982', N'0933666999', N'dung.pham@gmail.com', N'CCCD', N'034567890123', N'Hải Phòng', N'LKH04', N'NV01'),
(N'KH005', N'Huỳnh Mỹ Duyên', N'Nữ', '21-09-1999', N'0977998899', N'duyenhm@gmail.com', N'CCCD', N'045678901234', N'Cần Thơ', N'LKH02', N'NV01'),
(N'KH006', N'Đỗ Hoàng Phúc', N'Nam', '15-01-2000', N'0909090909', N'hoangphuc@gmail.com', N'Passport', N'P7788991', N'Nha Trang', N'LKH03', N'NV01'),
(N'KH007', N'Võ Nhật Quang', N'Nam', '30-12-1996', N'0911222333', N'nhatquang@gmail.com', N'CCCD', N'056789012345', N'Bình Dương', N'LKH01', N'NV01'),
(N'KH008', N'Phan Anh Tú', N'Nam', '14-04-1992', N'0933444555', N'anh.tu@gmail.com', N'CCCD', N'067890123456', N'Huế', N'LKH04', N'NV01'),
(N'KH009', N'Tô Mỹ Hạnh', N'Nữ', '09-11-1997', N'0944556677', N'myhanhto@gmail.com', N'CCCD', N'078901234567', N'Quảng Nam', N'LKH03', N'NV01'),
(N'KH010', N'Ngô Thùy Linh', N'Nữ', '18-06-2001', N'0988123456', N'linhngo2001@gmail.com', N'Passport', N'P88990012', N'Sài Gòn', N'LKH01', N'NV01');
GO

-- 7. LOẠI PHÒNG
INSERT INTO LoaiPhong (MaLP, TenLP, MoTa, IsNhaNguyenCan, SoPhongTrongNha, GiaTheoGio, GiaTheoNgay, GiaTheoThang, SucChuaToiDa, IsActive, CreatedBy)
VALUES
('LP001', N'Standard Garden View', N'Phòng tiêu chuẩn 25m², 1 giường Queen, ban công hướng vườn.', 0, 1, 250000, 1500000, NULL, 2, 1, 'NV01'),
('LP002', N'Superior Garden View (Twin)', N'Phòng 30m², 2 giường đơn, ban công hướng vườn.', 0, 1, 300000, 1800000, NULL, 2, 1, 'NV01'),
('LP003', N'Deluxe Ocean View', N'Phòng cao cấp 35m², 1 giường King, ban công riêng nhìn thẳng ra biển.', 0, 1, 400000, 2500000, NULL, 2, 1, 'NV01'),
('LP004', N'Family Room Ocean View', N'Phòng gia đình 50m², 1 giường King và 1 giường đơn, khu vực sofa, hướng biển.', 0, 1, 550000, 3500000, NULL, 4, 1, 'NV01'),
('LP005', N'Garden Bungalow', N'Nhà gỗ riêng biệt 45m² nằm trong vườn, có sân hiên riêng.', 1, 1, 650000, 4000000, NULL, 3, 1, 'NV01'),
('LP006', N'Private Pool Villa', N'Biệt thự 150m² hồ bơi riêng, 3 phòng ngủ.', 1, 3, 2000000, 12000000, NULL, 6, 1, 'NV01'),
('LP007', N'Junior Suite', N'Phòng hạng sang 70m² với phòng khách và phòng ngủ tách biệt.', 0, 1, 1000000, 6000000, NULL, 3, 1, 'NV01'),
('LP008', N'Presidential Suite', N'Phòng Tổng thống 200m², view toàn cảnh đại dương.', 0, 2, 8000000, 50000000, NULL, 4, 1, 'NV01');
GO

-- 8. PHÒNG
INSERT INTO Phong (MaPhong, MaCN, MaLP, SoPhong, ViTri, TrangThai, GhiChu, CreatedBy, IsActive)
VALUES
('P001', 'CN01', 'LP004', 'A101', N'Tầng 1 - Khu A', N'Đã đặt', NULL, 'NV01', 1),
('P002', 'CN01', 'LP004', 'A102', N'Tầng 1 - Khu A', N'Đang Dọn', NULL, 'NV01', 1),
('P003', 'CN01', 'LP001', 'A201', N'Tầng 2 - Khu A', N'Đã đặt', N'View biển', 'NV01', 1),
('P004', 'CN01', 'LP001', 'A202', N'Tầng 2 - Khu A', N'Đang Dọn', NULL, 'NV01', 1),
('P005', 'CN01', 'LP002', 'A301', N'Tầng 3 - Khu A', N'Trống', NULL, 'NV01', 1),
('P006', 'CN01', 'LP002', 'A302', N'Tầng 3 - Khu A', N'Đang Sử Dụng', NULL, 'NV01', 1),
('P007', 'CN01', 'LP003', 'V01', N'Khu Villa riêng', N'Trống', NULL, 'NV01', 1),
('P008', 'CN01', 'LP003', 'V02', N'Khu Villa riêng', N'Bảo trì', N'Đang sửa điện', 'NV01', 1),
('P009', 'CN02', 'LP004', 'B101', N'Tầng 1 - Khu B', N'Trống', NULL, 'NV01', 1),
('P010', 'CN02', 'LP004', 'B102', N'Tầng 1 - Khu B', N'Trống', NULL, 'NV01', 1),
('P011', 'CN02', 'LP001', 'B201', N'Tầng 2 - Khu B', N'Trống', NULL, 'NV01', 1),
('P012', 'CN02', 'LP001', 'B202', N'Tầng 2 - Khu B', N'Đang Dọn', NULL, 'NV01', 1),
('P013', 'CN02', 'LP002', 'B301', N'Tầng 3 - Khu B', N'Trống', NULL, 'NV01', 1),
('P014', 'CN02', 'LP002', 'B302', N'Tầng 3 - Khu B', N'Bảo trì', NULL, 'NV01', 1),
('P015', 'CN01', 'LP005', 'BG01', N'Khu Bungalow vườn', N'Trống', NULL, 'NV01', 1),
('P016', 'CN01', 'LP005', 'BG02', N'Khu Bungalow vườn', N'Trống', NULL, 'NV01', 1),
('P017', 'CN01', 'LP006', 'VL01', N'Khu Villa hồ bơi', N'Trống', NULL, 'NV01', 1),
('P018', 'CN01', 'LP007', 'JS01', N'Tầng 5 - Khu VIP', N'Trống', NULL, 'NV01', 1),
('P019', 'CN01', 'LP007', 'JS02', N'Tầng 5 - Khu VIP', N'Trống', NULL, 'NV01', 1),
('P020', 'CN01', 'LP008', 'PS01', N'Tầng 6 - Penthouse', N'Trống', NULL, 'NV01', 1),
('P021', 'CN02', 'LP003', 'V03', N'Khu Villa riêng', N'Trống', NULL, 'NV01', 1),
('P022', 'CN02', 'LP005', 'BG03', N'Khu Bungalow vườn', N'Trống', NULL, 'NV01', 1);
GO

-- 9. LOẠI THANH TOÁN
INSERT INTO LoaiThanhToan (MaLTT, TenLTT, CreatedBy, CreatedAt, IsActive)
VALUES
('LTT01', N'Tiền mặt', 'NV01', GETDATE(), 1),
('LTT02', N'Thẻ tín dụng', 'NV01', GETDATE(), 1),
('LTT03', N'Thẻ ghi nợ', 'NV01', GETDATE(), 1),
('LTT04', N'Chuyển khoản', 'NV01', GETDATE(), 1),
('LTT05', N'Ví điện tử', 'NV01', GETDATE(), 1);
GO

-- 10. DỊCH VỤ
INSERT INTO DichVu (MaDV, TenDV, LoaiDV, MoTa, Gia, ChoPhepDoiDiem, GiaTriDoiDiem, CreatedBy, CreatedAt, IsActive)
VALUES
('DV001', N'Dịch vụ Spa - Massage 60p', N'Spa', N'Massage toàn thân', 500000, 1, 5, 'NV01', GETDATE(), 1),
('DV002', N'Dịch vụ Spa - Facial', N'Spa', N'Chăm sóc da mặt', 800000, 1, 8, 'NV01', GETDATE(), 1),
('DV003', N'Buffet sáng', N'Ẩm thực', N'Buffet Á-Âu', 250000, 0, NULL, 'NV01', GETDATE(), 1),
('DV004', N'Buffet tối', N'Ẩm thực', N'Hải sản tươi sống', 650000, 1, 6, 'NV01', GETDATE(), 1),
('DV005', N'Giặt ủi', N'Tiện ích', N'Lấy trong ngày', 150000, 0, NULL, 'NV01', GETDATE(), 1),
('DV006', N'Xe đưa đón sân bay', N'Vận chuyển', N'1 chiều', 300000, 0, NULL, 'NV01', GETDATE(), 1),
('DV007', N'Thuê xe đạp', N'Vận chuyển', N'Theo giờ', 50000, 0, NULL, 'NV01', GETDATE(), 1),
('DV008', N'Lặn biển', N'Giải trí', N'Có hướng dẫn viên', 1200000, 1, 12, 'NV01', GETDATE(), 1),
('DV009', N'Kayak', N'Giải trí', N'Theo giờ', 200000, 0, NULL, 'NV01', GETDATE(), 1),
('DV010', N'Minibar', N'Tiện ích', N'Đồ uống', 150000, 0, NULL, 'NV01', GETDATE(), 1),
('DV011', N'Phòng họp 4h', N'Hội nghị', N'Tối đa 20 người', 2000000, 0, NULL, 'NV01', GETDATE(), 1),
('DV012', N'Giữ trẻ', N'Tiện ích', N'Theo giờ', 200000, 0, NULL, 'NV01', GETDATE(), 1);
GO

-- 11. KHÁCH HÀNG ĐIỂM & LỊCH SỬ (LOGIC MỚI: 100.000 VNĐ = 1 Point)
-- KH001: 54 điểm (từ DP006 5.4M)
-- KH002 (Silver >500): Start 400 + 152 (15.2M) - 5 (Spa) = 547
-- KH003 (Gold >1500): Start 1500 + 80 (8M) - 10 (Lan bien) = 1570
-- KH004 (VIP >3000): Start 2800 + 118 (11.8M) + 157 (15.7M) = 3075

INSERT INTO KhachHangDiem (MaKH, DiemHienTai, CapNhatLuc, CreatedBy, CreatedAt)
VALUES
('KH001', 54, GETDATE(), 'NV01', GETDATE()),
('KH002', 547, GETDATE(), 'NV01', GETDATE()),
('KH003', 1570, GETDATE(), 'NV01', GETDATE()),
('KH004', 3075, GETDATE(), 'NV01', GETDATE()),
('KH005', 65, GETDATE(), 'NV01', GETDATE()),
('KH006', 180, GETDATE(), 'NV01', GETDATE()),
('KH007', 0, GETDATE(), 'NV01', GETDATE()),
('KH008', 420, GETDATE(), 'NV01', GETDATE()),
('KH009', 135, GETDATE(), 'NV01', GETDATE()),
('KH010', 0, GETDATE(), 'NV01', GETDATE());
GO

-- 12. SỰ KIỆN
INSERT INTO SuKien (MaSK, TenSK, LoaiSuKien, MaCN, DiaDiem, GhiChu, TongChiPhi, CreatedBy, CreatedAt, IsActive)
VALUES
('SK001', N'Đám cưới', N'Cưới', 'CN01', N'Sảnh Grand Ballroom', NULL, NULL, 'NV01', GETDATE(), 1),
('SK002', N'Hội nghị', N'Hội nghị', 'CN01', N'Phòng họp', NULL, NULL, 'NV01', GETDATE(), 1),
('SK003', N'Team building', N'Team building', 'CN01', N'Sân vườn', NULL, NULL, 'NV01', GETDATE(), 1),
('SK004', N'Tiệc sinh nhật', N'Khác', 'CN01', N'Sảnh tiệc', NULL, NULL, 'NV01', GETDATE(), 1);
GO

-- 13. GÓI SỰ KIỆN
INSERT INTO GoiSuKien (MaGoiSK, TenGoiSK, MaSK, MoTa, GiaCoBan, SoKhachToiThieu, SoKhachToiDa, ThoiGianToiThieu, ThoiGianToiDa, DichVuKemTheo, IsGoiMacDinh, MaCN, CreatedBy, CreatedAt, IsActive)
VALUES
('GOI007', N'Đám cưới Nguyễn Văn An', 'SK001', N'Sảnh Grand, 200 khách', 85000000, 150, 250, 5, 10, N'MC, Ban nhạc, Buffet', 0, 'CN01', 'NV01', GETDATE(), 1),
('GOI008', N'Đám cưới bãi biển', 'SK001', N'Bãi biển, 80 khách', 65000000, 50, 100, 4, 8, N'Lều, Âm thanh, BBQ', 0, 'CN01', 'NV01', DATEADD(day, -20, GETDATE()), 1),
('GOI009', N'Đám cưới Phạm Quốc Dũng', 'SK001', N'Sảnh lớn, 300 khách', 120000000, 200, 400, 6, 12, N'Full option', 0, 'CN01', 'NV01', DATEADD(day, -15, GETDATE()), 1),
('GOI010', N'Hội nghị Cty ABC', 'SK002', N'50 người, 2 ngày', 25000000, 40, 60, 6, 12, N'Máy chiếu, Teabreak', 0, 'CN01', 'NV01', DATEADD(day, -30, GETDATE()), 1),
('GOI011', N'Hội nghị Ngân hàng XYZ', 'SK002', N'80 người', 18000000, 60, 100, 4, 8, N'High end', 0, 'CN01', 'NV01', DATEADD(day, -10, GETDATE()), 1),
('GOI012', N'Team building Cty XYZ', 'SK003', N'Action', 35000000, 25, 40, 12, 24, N'Full', 0, 'CN02', 'NV01', DATEADD(day, -25, GETDATE()), 1),
('GOI013', N'Team building Cty DEF', 'SK003', N'Leader', 12000000, 15, 30, 4, 6, N'Workshop', 0, 'CN01', 'NV01', DATEADD(day, -5, GETDATE()), 1);
GO

-- 14. KHUYẾN MÃI
INSERT INTO KhuyenMai (MaKM, TenKM, IsPhanTram, GiaTri, MaLKH, MaCN, MaLP, MaPhong, CouponCode, NgayBD, NgayKT, DieuKien, CreatedBy, CreatedAt, IsActive)
VALUES
('KM001', N'Giảm 20% khách VIP', 1, 20, 'LKH04', NULL, NULL, NULL, 'VIP20', DATEADD(day, -30, GETDATE()), DATEADD(day, 60, GETDATE()), N'Khách VIP', 'NV01', GETDATE(), 1),
('KM002', N'Giảm 500k Deluxe', 0, 500000, NULL, 'CN01', 'LP003', NULL, 'DELUXE500', DATEADD(day, -15, GETDATE()), DATEADD(day, 45, GETDATE()), N'Phòng Deluxe', 'NV01', GETDATE(), 1),
('KM003', N'Giảm 10% cuối tuần', 1, 10, NULL, NULL, NULL, NULL, 'WEEKEND10', DATEADD(day, -10, GETDATE()), DATEADD(day, 30, GETDATE()), N'Thứ 6,7,CN', 'NV01', GETDATE(), 1);
GO

-- 15. VOUCHER
INSERT INTO Voucher (MaVoucher, TenVoucher, CouponCode, IsPhanTram, GiaTri, SoLuong, SoLuongDaDung, MaLKH, MaCN, MaLP, MaPhong, NgayBD, NgayKT, DieuKien, TrangThai, CreatedBy, CreatedAt, IsActive)
VALUES
('VC001', N'Voucher giảm 15%', 'SUMMER2024', 1, 15, 100, 3, NULL, NULL, NULL, NULL, DATEADD(day, -20, GETDATE()), DATEADD(day, 40, GETDATE()), N'Bill > 2tr', 'Active', 'NV01', GETDATE(), 1),
('VC002', N'Voucher giảm 300k', 'NEW300', 0, 300000, 50, 0, NULL, NULL, NULL, NULL, DATEADD(day, -15, GETDATE()), DATEADD(day, 45, GETDATE()), NULL, 'Active', 'NV01', GETDATE(), 1);
GO

-- 16. ĐẶT PHÒNG
INSERT INTO DatPhong (MaDP, MaKH, MaNV, TrangThai, GhiChu, CreatedBy, CreatedAt, IsActive)
VALUES
('DP001', 'KH002', 'NV03', N'Hoàn tất', N'Đã check-in & thanh toán', 'NV03', DATEADD(day, -5, GETDATE()), 1),
('DP002', 'KH003', 'NV03', N'Đang sử dụng', N'Đang ở, chưa TT hết', 'NV03', DATEADD(day, -3, GETDATE()), 1),
('DP003', 'KH004', 'NV04', N'Đặt', N'Check-in ngày mai', 'NV04', DATEADD(day, -10, GETDATE()), 1),
('DP004', 'KH005', 'NV03', N'Đặt', N'Check-in 2 tuần tới', 'NV03', DATEADD(day, -7, GETDATE()), 1),
('DP005', 'KH006', 'NV04', N'Hủy', N'Khách hủy', 'NV04', DATEADD(day, -8, GETDATE()), 1),
('DP006', 'KH001', 'NV03', N'Hoàn tất', N'History (tháng trước)', 'NV03', DATEADD(day, -35, GETDATE()), 1),
('DP007', 'KH007', 'NV04', N'Hoàn tất', N'History', 'NV04', DATEADD(day, -32, GETDATE()), 1),
('DP008', 'KH008', 'NV03', N'Hoàn tất', N'History', 'NV03', DATEADD(day, -28, GETDATE()), 1),
('DP009', 'KH009', 'NV04', N'Hoàn tất', N'History (2 tháng trước)', 'NV04', DATEADD(day, -60, GETDATE()), 1),
('DP010', 'KH010', 'NV03', N'Hoàn tất', N'History', 'NV03', DATEADD(day, -55, GETDATE()), 1);
GO

-- 17. CHI TIẾT ĐẶT PHÒNG
INSERT INTO CTDatPhong (MaCTDP, MaDP, MaPhong, TrangThai, NgayDen, NgayDi, NguoiLon, TreEm, LoaiThue, GiaPhong, ThanhTien, CreatedBy, CreatedAt, IsActive)
VALUES
('CTDP001', 'DP001', 'P002', N'Hoàn tất', DATEADD(day, -5, GETDATE()), DATEADD(day, -1, GETDATE()), 2, 1, N'Ngày', 3500000, 14000000, 'NV03', DATEADD(day, -5, GETDATE()), 1),
('CTDP002', 'DP002', 'P006', N'Đang sử dụng', DATEADD(day, -3, GETDATE()), DATEADD(day, 1, GETDATE()), 2, 0, N'Ngày', 1800000, 7200000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTDP003', 'DP003', 'P001', N'Đặt', DATEADD(day, 1, GETDATE()), DATEADD(day, 4, GETDATE()), 4, 2, N'Ngày', 3500000, 10500000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTDP004', 'DP004', 'P003', N'Đặt', DATEADD(day, 14, GETDATE()), DATEADD(day, 17, GETDATE()), 2, 0, N'Ngày', 1500000, 4500000, 'NV03', DATEADD(day, -7, GETDATE()), 1),
('CTDP005', 'DP005', 'P010', N'Hủy', DATEADD(day, 5, GETDATE()), DATEADD(day, 8, GETDATE()), 2, 1, N'Ngày', 3500000, 10500000, 'NV04', DATEADD(day, -8, GETDATE()), 1),
('CTDP006', 'DP006', 'P005', N'Hoàn tất', DATEADD(day, -35, GETDATE()), DATEADD(day, -32, GETDATE()), 2, 0, N'Ngày', 1800000, 5400000, 'NV03', DATEADD(day, -35, GETDATE()), 1),
('CTDP007', 'DP007', 'P018', N'Hoàn tất', DATEADD(day, -32, GETDATE()), DATEADD(day, -30, GETDATE()), 2, 1, N'Ngày', 6000000, 12000000, 'NV04', DATEADD(day, -32, GETDATE()), 1),
('CTDP008', 'DP008', 'P007', N'Hoàn tất', DATEADD(day, -28, GETDATE()), DATEADD(day, -28, GETDATE()), 2, 0, N'Giờ', 400000, 1600000, 'NV03', DATEADD(day, -28, GETDATE()), 1),
('CTDP009', 'DP009', 'P009', N'Hoàn tất', DATEADD(day, -60, GETDATE()), DATEADD(day, -55, GETDATE()), 2, 2, N'Ngày', 3500000, 17500000, 'NV04', DATEADD(day, -60, GETDATE()), 1),
('CTDP010', 'DP010', 'P017', N'Hoàn tất', DATEADD(day, -55, GETDATE()), DATEADD(day, -53, GETDATE()), 4, 2, N'Ngày', 12000000, 24000000, 'NV03', DATEADD(day, -55, GETDATE()), 1);
GO

-- 18. CHI TIẾT DỊCH VỤ
INSERT INTO CTDichVu (MaCTDV, MaCTDP, MaDV, SoLuong, Gia, ThanhTien, CreatedBy, CreatedAt, IsActive)
VALUES
('CTDV001', 'CTDP001', 'DV003', 3, 250000, 750000, 'NV03', DATEADD(day, -5, GETDATE()), 1),
('CTDV002', 'CTDP001', 'DV004', 2, 650000, 1300000, 'NV03', DATEADD(day, -4, GETDATE()), 1),
('CTDV003', 'CTDP001', 'DV001', 2, 500000, 1000000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTDV004', 'CTDP002', 'DV003', 2, 250000, 500000, 'NV03', DATEADD(day, -2, GETDATE()), 1),
('CTDV005', 'CTDP002', 'DV008', 1, 1200000, 1200000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTDV006', 'CTDP003', 'DV003', 5, 250000, 1250000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTDV007', 'CTDP003', 'DV012', 10, 200000, 2000000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTDV008', 'CTDP004', 'DV011', 1, 2000000, 2000000, 'NV01', DATEADD(day, -20, GETDATE()), 1);
GO

-- 19. CHI TIẾT SỰ KIỆN
-- 19. CHI TIẾT SỰ KIỆN
INSERT INTO CTSuKien (MaCTSK, MaSK, MaKH, SoLuong, DonGia, GhiChu, DaThanhToan, TrangThai, NgayBD, NgayKT, TongKhach, CreatedBy, CreatedAt, IsActive)
VALUES
('CTSK001', 'SK001', 'KH001', 1, 85000000, N'Gói GOI007', 45000000, N'Lên kế hoạch', DATEADD(day, 20, GETDATE()), DATEADD(day, 20, GETDATE()), 200, 'NV01', DATEADD(day, -20, GETDATE()), 1),
('CTSK002', 'SK001', 'KH003', 1, 65000000, N'Gói GOI008', 35000000, N'Đang diễn ra', DATEADD(day, -5, GETDATE()), DATEADD(day, -5, GETDATE()), 80, 'NV01', DATEADD(day, -20, GETDATE()), 1),
('CTSK003', 'SK002', 'KH004', 1, 25000000, N'Gói GOI010', 15000000, N'Đã kết thúc', DATEADD(day, -30, GETDATE()), DATEADD(day, -28, GETDATE()), 50, 'NV01', DATEADD(day, -35, GETDATE()), 1);
GO

-- 20. ĐẶT CỌC
INSERT INTO DatCoc (MaDatCoc, MaDP, MaCTSK, MaKH, SoTien, NgayCoc, HinhThucThanhToan, LoaiCoc, TrangThai, GhiChu, CreatedBy, CreatedAt)
VALUES
('DC001', 'DP001', NULL, 'KH002', 5000000, DATEADD(day, -10, GETDATE()), N'Chuyển khoản', N'Đặt phòng', N'ĐÃ NHẬN', N'Coc 50%', 'NV03', DATEADD(day, -10, GETDATE())),
('DC002', 'DP002', NULL, 'KH003', 3000000, DATEADD(day, -8, GETDATE()), N'Tiền mặt', N'Đặt phòng', N'ĐÃ NHẬN', N'Coc 30%', 'NV03', DATEADD(day, -8, GETDATE())),
('DC003', 'DP003', NULL, 'KH004', 7000000, DATEADD(day, -10, GETDATE()), N'Thẻ tín dụng', N'Đặt phòng', N'ĐÃ NHẬN', N'Coc 50%', 'NV04', DATEADD(day, -10, GETDATE())),
('DC004', 'DP004', NULL, 'KH005', 2000000, DATEADD(day, -7, GETDATE()), N'Ví điện tử', N'Đặt phòng', N'ĐÃ NHẬN', N'Coc 40%', 'NV03', DATEADD(day, -7, GETDATE())),
('DC005', NULL, 'CTSK001', 'KH001', 45000000, DATEADD(day, -20, GETDATE()), N'Chuyển khoản', N'Sự kiện', N'ĐÃ NHẬN', N'Coc cuoi', 'NV01', DATEADD(day, -20, GETDATE())),
('DC006', NULL, 'CTSK002', 'KH003', 35000000, DATEADD(day, -25, GETDATE()), N'Thẻ tín dụng', N'Sự kiện', N'ĐÃ NHẬN', N'Coc bien', 'NV01', DATEADD(day, -25, GETDATE())),
('DC007', NULL, 'CTSK003', 'KH004', 15000000, DATEADD(day, -35, GETDATE()), N'Chuyển khoản', N'Sự kiện', N'ĐÃ NHẬN', N'Coc hoi nghi', 'NV01', DATEADD(day, -35, GETDATE()));
GO

-- 21. HÓA ĐƠN
INSERT INTO HoaDon (MaHD, MaDP, MaCTSK, LoaiHoaDon, MaKH, MaNV, MaKM, MaCN, TrangThai, NgayLap, TongTruocKM, TongTien, CreatedBy, CreatedAt, IsActive)
VALUES
('HD001', 'DP001', NULL, N'DatPhong', 'KH002', 'NV03', NULL, 'CN01', N'Đã TT', DATEADD(day, -1, GETDATE()), 16050000, 15247500, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('HD002', 'DP002', NULL, N'DatPhong', 'KH003', 'NV03', NULL, 'CN01', N'Chưa TT', DATEADD(day, -3, GETDATE()), 8900000, 8010000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('HD003', 'DP003', NULL, N'DatPhong', 'KH004', 'NV04', 'KM001', 'CN01', N'Chưa TT', DATEADD(day, -10, GETDATE()), 14750000, 11800000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('HD004', 'DP006', NULL, N'DatPhong', 'KH001', 'NV03', NULL, 'CN01', N'Đã TT', DATEADD(day, -32, GETDATE()), 5400000, 5400000, 'NV03', DATEADD(day, -32, GETDATE()), 1),
('HD005', 'DP007', NULL, N'DatPhong', 'KH007', 'NV04', NULL, 'CN01', N'Đã TT', DATEADD(day, -30, GETDATE()), 12000000, 12000000, 'NV04', DATEADD(day, -30, GETDATE()), 1),
('HD006', 'DP008', NULL, N'DatPhong', 'KH008', 'NV03', NULL, 'CN01', N'Đã TT', DATEADD(day, -28, GETDATE()), 1600000, 1440000, 'NV03', DATEADD(day, -28, GETDATE()), 1),
('HD007', 'DP009', NULL, N'DatPhong', 'KH009', 'NV04', NULL, 'CN02', N'Đã TT', DATEADD(day, -55, GETDATE()), 17500000, 15750000, 'NV04', DATEADD(day, -55, GETDATE()), 1),
('HD008', 'DP010', NULL, N'DatPhong', 'KH010', 'NV03', NULL, 'CN01', N'Đã TT', DATEADD(day, -53, GETDATE()), 24000000, 24000000, 'NV03', DATEADD(day, -53, GETDATE()), 1),
('HD009', NULL, 'CTSK001', N'SuKien', 'KH001', 'NV01', NULL, 'CN01', N'Đã TT', DATEADD(day, -20, GETDATE()), 85000000, 85000000, 'NV01', DATEADD(day, -20, GETDATE()), 1),
('HD010', NULL, 'CTSK002', N'SuKien', 'KH003', 'NV01', NULL, 'CN01', N'Đã TT', DATEADD(day, -5, GETDATE()), 65000000, 58500000, 'NV01', DATEADD(day, -5, GETDATE()), 1),
('HD011', NULL, 'CTSK003', N'SuKien', 'KH004', 'NV01', NULL, 'CN01', N'Đã TT', DATEADD(day, -28, GETDATE()), 25000000, 20000000, 'NV01', DATEADD(day, -28, GETDATE()), 1);
GO

-- 22. CHI TIẾT HÓA ĐƠN
INSERT INTO CTHoaDon (MaCTHD, MaHD, MoTa, SoLuong, DonGia, ThanhTien, CreatedBy, CreatedAt, IsActive)
VALUES
-- HD001 (KH002 - Silver 5%)
('CTHD001', 'HD001', N'Phòng Family (4 đêm)', 4, 3500000, 14000000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD002', 'HD001', N'Buffet sáng x3', 3, 250000, 750000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD003', 'HD001', N'Buffet tối x2', 2, 650000, 1300000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD004', 'HD001', N'Spa x2', 2, 500000, 1000000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD005', 'HD001', N'Giảm Silver 5%', 1, -802500, -802500, 'NV03', DATEADD(day, -1, GETDATE()), 1),

-- HD002 (KH003 - Gold 10%)
('CTHD006', 'HD002', N'Superior (4 đêm)', 4, 1800000, 7200000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTHD007', 'HD002', N'Buffet sáng x2', 2, 250000, 500000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTHD008', 'HD002', N'Lặn biển x1', 1, 1200000, 1200000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTHD009', 'HD002', N'Giảm Gold 10%', 1, -890000, -890000, 'NV03', DATEADD(day, -3, GETDATE()), 1),

-- HD003 (KH004 - VIP 20%)
('CTHD010', 'HD003', N'Phòng Deluxe Ocean (3 đêm)', 3, 2500000, 7500000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTHD011', 'HD003', N'Dịch vụ Minibar', 5, 150000, 750000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTHD012', 'HD003', N'Gói VIP 20% + Voucher -15%', 1, -2950000, -2950000, 'NV04', DATEADD(day, -10, GETDATE()), 1),

-- HD004 (KH001 - Standard 0%)
('CTHD013', 'HD004', N'Bungalow (3 đêm)', 3, 1800000, 5400000, 'NV03', DATEADD(day, -32, GETDATE()), 1),

-- HD005 (KH007 - Standard 0%)
('CTHD014', 'HD005', N'Junior Suite (2 đêm)', 2, 6000000, 12000000, 'NV04', DATEADD(day, -30, GETDATE()), 1),

-- HD006 (KH008 - VIP 20%)
('CTHD015', 'HD006', N'Deluxe Theo giờ (4h)', 4, 400000, 1600000, 'NV03', DATEADD(day, -28, GETDATE()), 1),
('CTHD016', 'HD006', N'Giảm VIP 20%', 1, -320000, -320000, 'NV03', DATEADD(day, -28, GETDATE()), 1),

-- HD007 (KH009 - Gold 10%)
('CTHD017', 'HD007', N'Family Room (5 đêm)', 5, 3500000, 17500000, 'NV04', DATEADD(day, -55, GETDATE()), 1),
('CTHD018', 'HD007', N'Giảm Gold 10%', 1, -1750000, -1750000, 'NV04', DATEADD(day, -55, GETDATE()), 1),

-- HD008 (KH010 - Standard 0%)
('CTHD019', 'HD008', N'Pool Villa (2 đêm)', 2, 12000000, 24000000, 'NV03', DATEADD(day, -53, GETDATE()), 1),

-- HD009 (Event - KH001 - Standard)
('CTHD020', 'HD009', N'Thanh toán Gói sự kiện: Đám cưới Nguyễn Văn An', 1, 85000000, 85000000, 'NV01', DATEADD(day, -20, GETDATE()), 1),

-- HD010 (Event - KH003 - Gold 10%)
('CTHD021', 'HD010', N'Thanh toán Gói sự kiện: Đám cưới bãi biển', 1, 65000000, 65000000, 'NV01', DATEADD(day, -5, GETDATE()), 1),
('CTHD022', 'HD010', N'Giảm Gold 10%', 1, -6500000, -6500000, 'NV01', DATEADD(day, -5, GETDATE()), 1),

-- HD011 (Event - KH004 - VIP 20%)
('CTHD023', 'HD011', N'Thanh toán Gói sự kiện: Hội nghị Cty ABC', 1, 25000000, 25000000, 'NV01', DATEADD(day, -28, GETDATE()), 1),
('CTHD024', 'HD011', N'Giảm VIP 20%', 1, -5000000, -5000000, 'NV01', DATEADD(day, -28, GETDATE()), 1);
GO

-- 23. THANH TOÁN
-- [FIX] Bổ sung đầy đủ ThanhToan cho các HoaDon có trạng thái 'Đã TT'
INSERT INTO ThanhToan (MaTT, MaHD, SoTien, MaLTT, NgayTT, CreatedBy, CreatedAt, IsActive)
VALUES
-- HD001: KH002 - TongTien = 15,247,500 (Đã TT đủ)
('TT001', 'HD001', 5000000, 'LTT04', DATEADD(day, -10, GETDATE()), 'NV03', DATEADD(day, -10, GETDATE()), 1),
('TT002', 'HD001', 10247500, 'LTT02', DATEADD(day, -1, GETDATE()), 'NV03', DATEADD(day, -1, GETDATE()), 1),
-- HD002: KH003 - TongTien = 8,010,000 (Chưa TT đủ - chỉ TT 6,500,000)
('TT003', 'HD002', 3000000, 'LTT01', DATEADD(day, -8, GETDATE()), 'NV03', DATEADD(day, -8, GETDATE()), 1),
('TT004', 'HD002', 3500000, 'LTT02', DATEADD(day, -3, GETDATE()), 'NV03', DATEADD(day, -3, GETDATE()), 1),
-- HD004: KH001 - TongTien = 5,400,000 (Đã TT)
('TT005', 'HD004', 5400000, 'LTT01', DATEADD(day, -32, GETDATE()), 'NV03', DATEADD(day, -32, GETDATE()), 1),
-- HD005: KH007 - TongTien = 12,000,000 (Đã TT)
('TT006', 'HD005', 12000000, 'LTT04', DATEADD(day, -30, GETDATE()), 'NV04', DATEADD(day, -30, GETDATE()), 1),
-- HD006: KH008 - TongTien = 1,440,000 (Đã TT)
('TT007', 'HD006', 1440000, 'LTT01', DATEADD(day, -28, GETDATE()), 'NV03', DATEADD(day, -28, GETDATE()), 1),
-- HD007: KH009 - TongTien = 15,750,000 (Đã TT)
('TT008', 'HD007', 15750000, 'LTT04', DATEADD(day, -55, GETDATE()), 'NV04', DATEADD(day, -55, GETDATE()), 1),
-- HD008: KH010 - TongTien = 24,000,000 (Đã TT)
('TT009', 'HD008', 24000000, 'LTT02', DATEADD(day, -53, GETDATE()), 'NV03', DATEADD(day, -53, GETDATE()), 1),
-- HD009: CTSK001 (Sự kiện Đám cưới An) - TongTien = 85,000,000 (Đặt cọc 45M + thanh toán 40M)
('TT010', 'HD009', 45000000, 'LTT04', DATEADD(day, -20, GETDATE()), 'NV01', DATEADD(day, -20, GETDATE()), 1),
('TT011', 'HD009', 40000000, 'LTT02', DATEADD(day, -19, GETDATE()), 'NV01', DATEADD(day, -19, GETDATE()), 1),
-- HD010: CTSK002 (Sự kiện Đám cưới biển) - TongTien = 58,500,000 (Đặt cọc 35M + thanh toán 23.5M)
('TT012', 'HD010', 35000000, 'LTT02', DATEADD(day, -25, GETDATE()), 'NV01', DATEADD(day, -25, GETDATE()), 1),
('TT013', 'HD010', 23500000, 'LTT04', DATEADD(day, -5, GETDATE()), 'NV01', DATEADD(day, -5, GETDATE()), 1),
-- HD011: CTSK003 (Hội nghị) - TongTien = 20,000,000 (Đặt cọc 15M + thanh toán 5M)
('TT014', 'HD011', 15000000, 'LTT04', DATEADD(day, -35, GETDATE()), 'NV01', DATEADD(day, -35, GETDATE()), 1),
('TT015', 'HD011', 5000000, 'LTT01', DATEADD(day, -28, GETDATE()), 'NV01', DATEADD(day, -28, GETDATE()), 1);
GO

-- 24. LỊCH SỬ ĐIỂM (KHỚP VỚI BẢNG KHÁCH HÀNG ĐIỂM)
INSERT INTO KhachHangLichSuDiem (MaKH, Ngay, LoaiThaoTac, Diem, GhiChu, NguoiThucHien, CreatedBy, CreatedAt)
VALUES
-- KH001 (54 pts)
('KH001', DATEADD(day, -32, GETDATE()), N'CONG', 54, N'Tích điểm HD004', 'System', 'NV03', DATEADD(day, -32, GETDATE())),
-- KH002 (547 pts)
('KH002', DATEADD(day, -100, GETDATE()), N'CONG', 400, N'Quà tặng khách hàng mới', 'System', 'NV01', DATEADD(day, -100, GETDATE())),
('KH002', DATEADD(day, -1, GETDATE()), N'CONG', 152, N'Tích điểm hóa đơn HD001', 'System', 'NV03', DATEADD(day, -1, GETDATE())),
('KH002', DATEADD(day, -1, GETDATE()), N'TRU', 5, N'Đổi dịch vụ Spa', 'System', 'NV03', DATEADD(day, -1, GETDATE())),
-- KH003 (1570 pts)
('KH003', DATEADD(day, -100, GETDATE()), N'CONG', 1500, N'Quà tặng nâng hạng Gold', 'System', 'NV01', DATEADD(day, -100, GETDATE())),
('KH003', DATEADD(day, -3, GETDATE()), N'CONG', 80, N'Tích điểm hóa đơn HD002', 'System', 'NV03', DATEADD(day, -3, GETDATE())),
('KH003', DATEADD(day, -2, GETDATE()), N'TRU', 10, N'Đổi dịch vụ Lặn biển', 'System', 'NV03', DATEADD(day, -2, GETDATE())),
-- KH004 (3075 pts)
('KH004', DATEADD(day, -100, GETDATE()), N'CONG', 2800, N'Quà tặng nâng hạng VIP', 'System', 'NV01', DATEADD(day, -100, GETDATE())),
('KH004', DATEADD(day, -10, GETDATE()), N'CONG', 118, N'Tích điểm HD003', 'System', 'NV04', DATEADD(day, -10, GETDATE())),
('KH004', DATEADD(day, -55, GETDATE()), N'CONG', 157, N'Tích điểm HD007', 'System', 'NV04', DATEADD(day, -55, GETDATE()));
GO

-- 25. VOUCHER USAGE (Khớp với SoLuongDaDung=3 của VC001)
INSERT INTO VoucherUsage (MaSuDung, MaVoucher, MaKH, MaHD, MaDP, NgaySuDung, GiaTriApDung, GhiChu, CreatedBy, CreatedAt)
VALUES
('VU001', 'VC001', 'KH004', 'HD003', 'DP003', DATEADD(day, -10, GETDATE()), 2212500, N'Giảm 15%', 'NV04', DATEADD(day, -10, GETDATE())),
('VU002', 'VC001', 'KH001', 'HD004', 'DP006', DATEADD(day, -32, GETDATE()), 810000, N'Giảm 15%', 'NV03', DATEADD(day, -32, GETDATE())),
('VU003', 'VC001', 'KH007', 'HD005', 'DP007', DATEADD(day, -30, GETDATE()), 1800000, N'Giảm 15%', 'NV04', DATEADD(day, -30, GETDATE()));
GO

PRINT N'✓ Đã chèn dữ liệu mẫu (đã chuẩn hóa) thành công!';
GO

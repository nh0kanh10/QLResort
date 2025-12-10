USE QLR;
SET QUOTED_IDENTIFIER ON;
GO

EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';
EXEC sp_MSforeachtable 'DELETE FROM ?';
EXEC sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL';
GO

INSERT INTO LoaiNhanVien (MaLoaiNV, TenLoaiNV, MoTa, CreatedBy, CreatedAt)
VALUES ('LNV00', N'Admin', N'Quản trị hệ thống', NULL, GETDATE());
GO

INSERT INTO ChiNhanh (MaCN, TenCN, DiaChi, CreatedAt, IsActive)
VALUES
('CN01', N'Resort Nha Trang', N'123 Trần Phú, Nha Trang', GETDATE(), 1),
('CN02', N'Resort TP.HCM', N'456 Nguyễn Huệ, TP.HCM', GETDATE(), 1);  
GO

INSERT INTO NhanVien (MaNV, MaCN, CCCD, GioiTinh, HoTen, ChucVu, SDT, Email, MaLoaiNV, CreatedAt, IsActive)
VALUES
('NV01', 'CN01', '012345678901', N'Nam', N'Nguyễn Văn A', N'Giám đốc', '0912345678', 'admin@resort.vn', 'LNV00', GETDATE(), 1),
('NV02', 'CN01', '023456789012', N'Nữ', N'Trần Thị B', N'Lễ tân', '0923456789', 'letan@resort.vn', 'LNV00', GETDATE(), 1),
('NV03', 'CN02', '034567890123', N'Nam', N'Lê Văn C', N'Quản lý', '0934567890', 'quanly2@resort.vn', 'LNV00', GETDATE(), 1),
('NV04', 'CN01', '045678901234', N'Nữ', N'Phạm Thị D', N'Phục vụ', '0945678901', 'phucvu@resort.vn', 'LNV00', GETDATE(), 1),
('NV05', 'CN02', '056789012345', N'Nam', N'Hoàng Văn E', N'Lễ tân', '0956789012', 'letan2@resort.vn', 'LNV00', GETDATE(), 1),
('NV06', 'CN01', '067890123456', N'Nữ', N'Võ Thị F', N'Kế toán', '0967890123', 'ketoan@resort.vn', 'LNV00', GETDATE(), 1);
GO

UPDATE ChiNhanh SET MaQuanLy = 'NV01', CreatedBy = 'NV01' WHERE MaCN = 'CN01';
UPDATE ChiNhanh SET MaQuanLy = 'NV03', CreatedBy = 'NV03' WHERE MaCN = 'CN02';
GO

INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
VALUES
('TK001', 'NV01', 'admin', '123456', N'Admin', GETDATE(), 'NV01', 1),
('TK002', 'NV02', 'letan', '123456', N'NhanVien', GETDATE(), 'NV01', 1);
GO

INSERT INTO LoaiKhachHang (MaLKH, TenLKH, GiamGiaPercent, DiemToiThieu, MoTa, CreatedBy)
VALUES
('LKH01', N'Standard', 0, 0, N'Khách thường', 'NV01'),
('LKH02', N'Silver', 5, 100, N'Khách thân thiết', 'NV01'),
('LKH03', N'Gold', 10, 500, N'Khách VIP', 'NV01');
GO

INSERT INTO KhachHang (MaKH, HoTen, GioiTinh, NgaySinh, SDT, Email, IDType, IDNumber, DiaChi, MaLKH, CreatedBy)
VALUES
('KH001', N'Nguyễn Văn An', N'Nam', '1990-05-12', '0901234567', 'an.nguyen@gmail.com', N'CCCD', '012345678900', N'Hà Nội', 'LKH01', 'NV01'),
('KH002', N'Trần Thị Bình', N'Nữ', '1995-03-27', '0912345678', 'binh.tran@gmail.com', N'CCCD', '023456789011', N'TP.HCM', 'LKH02', 'NV01'),
('KH003', N'Lê Minh Châu', N'Nữ', '1988-10-10', '0987654321', 'chau.le@yahoo.com', N'Passport', 'P1234567', N'Đà Nẵng', 'LKH03', 'NV01'),
('KH004', N'Phạm Quốc Dũng', N'Nam', '1982-07-01', '0933666999', 'dung.pham@gmail.com', N'CCCD', '034567890122', N'Hải Phòng', 'LKH01', 'NV01'),
('KH005', N'Hoàng Văn Em', N'Nam', '1990-06-15', '0944555666', 'em.hoang@gmail.com', N'CCCD', '045678901233', N'Nha Trang', 'LKH02', 'NV01'),
('KH006', N'Đỗ Thị Phương', N'Nữ', '1987-09-20', '0955444333', 'phuong.do@gmail.com', N'Passport', 'P2345678', N'Đà Nẵng', 'LKH03', 'NV01'),
('KH007', N'Trương Văn Long', N'Nam', '1975-12-05', '0966333222', 'long.truong@gmail.com', N'CCCD', '056789012344', N'Cần Thơ', 'LKH01', 'NV01'),
('KH008', N'Lý Thị Hoa', N'Nữ', '1992-04-18', '0977222111', 'hoa.ly@gmail.com', N'CCCD', '067890123455', N'Vũng Tàu', 'LKH02', 'NV01');
GO

INSERT INTO LoaiPhong (MaLP, TenLP, MoTa, IsNhaNguyenCan, SoPhongTrongNha, GiaTheoGio, GiaTheoNgay, GiaTheoThang, SucChuaToiDa, IsActive, CreatedBy)
VALUES
('LP001', N'Standard', N'Phòng tiêu chuẩn', 0, NULL, 200000, 800000, 20000000, 2, 1, 'NV01'),
('LP002', N'Deluxe', N'Phòng cao cấp', 0, NULL, 350000, 1500000, 40000000, 2, 1, 'NV01'),
('LP003', N'Suite', N'Phòng hạng sang', 0, NULL, 500000, 2500000, 65000000, 4, 1, 'NV01');
GO

INSERT INTO Phong (MaPhong, MaCN, MaLP, SoPhong, ViTri, TrangThai, CreatedBy, IsActive)
VALUES
('P001', 'CN01', 'LP001', '101', N'Tầng 1', N'Trống', 'NV01', 1),
('P002', 'CN01', 'LP001', '102', N'Tầng 1', N'Trống', 'NV01', 1),
('P003', 'CN01', 'LP002', '201', N'Tầng 2', N'Trống', 'NV01', 1),
('P004', 'CN01', 'LP002', '202', N'Tầng 2', N'Đã đặt', 'NV01', 1),
('P005', 'CN01', 'LP003', '301', N'Tầng 3', N'Đang sử dụng', 'NV01', 1),
('P006', 'CN01', 'LP003', '302', N'Tầng 3', N'Đang sử dụng', 'NV01', 1),
('P007', 'CN01', 'LP001', '103', N'Tầng 1', N'Trống', 'NV01', 1),
('P008', 'CN01', 'LP002', '203', N'Tầng 2', N'Trống', 'NV01', 1),
('P009', 'CN02', 'LP001', '101', N'Tầng 1', N'Trống', 'NV03', 1),
('P010', 'CN02', 'LP002', '201', N'Tầng 2', N'Trống', 'NV03', 1);
GO

INSERT INTO LoaiThanhToan (MaLTT, TenLTT, CreatedBy, IsActive)
VALUES
('LTT01', N'Tiền mặt', 'NV01', 1),
('LTT02', N'Chuyển khoản', 'NV01', 1),
('LTT03', N'Thẻ ATM', 'NV01', 1);
GO

INSERT INTO DichVu (MaDV, TenDV, LoaiDV, Gia, MoTa, CreatedBy, IsActive)
VALUES
('DV001', N'Ăn sáng buffet', N'F&B', 150000, N'Buffet sáng quốc tế', 'NV01', 1),
('DV002', N'Spa massage', N'Spa', 500000, N'Massage thư giãn 60 phút', 'NV01', 1),
('DV003', N'Karaoke VIP', N'Giải trí', 200000, N'Phòng karaoke', 'NV01', 1);
GO

INSERT INTO KhuyenMai (MaKM, TenKM, IsPhanTram, GiaTri, MaLKH, MaCN, CouponCode, NgayBD, NgayKT, DieuKien, CreatedBy, IsActive)
VALUES
('KM001', N'Giảm 10% cuối tuần', 1, 10, NULL, NULL, N'WEEKEND10', DATEADD(MONTH, -1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), N'Áp dụng T7, CN', 'NV01', 1),
('KM002', N'Giảm 500k khách VIP', 0, 500000, 'LKH03', NULL, N'GOLD500', DATEADD(MONTH, -2, GETDATE()), DATEADD(MONTH, 3, GETDATE()), N'Khách Gold', 'NV01', 1);
GO

INSERT INTO Voucher (MaVoucher, TenVoucher, CouponCode, IsPhanTram, GiaTri, SoLuong, SoLuongDaDung, NgayBD, NgayKT, DieuKien, TrangThai, CreatedBy, IsActive)
VALUES
('VC001', N'Voucher Tết 2024', N'TET2024', 1, 20, 100, 5, '2024-01-01', '2024-12-31', N'Đơn từ 5 triệu', N'Active', 'NV01', 1),
('VC002', N'Voucher 100k', N'SAVE100', 0, 100000, 500, 16, DATEADD(MONTH, -1, GETDATE()), DATEADD(MONTH, 11, GETDATE()), N'Mọi đơn', N'Active', 'NV01', 1);
GO

-- GoiSuKien - Event Package Catalog
INSERT INTO GoiSuKien (MaGoiSK, TenGoiSK, LoaiSuKien, MoTa, GiaCoBan, SoKhachToiThieu, SoKhachToiDa, CreatedBy, IsActive)
VALUES
-- 1. CƯỚI / LỄ HỎI
('GSK001', N'Cưới - Gói Cơ bản', N'Cưới', N'Lễ đơn giản, trang trí cơ bản, âm thanh nhỏ', 30000000, 30, 50, 'NV01', 1),
('GSK002', N'Cưới - Gói Tiêu chuẩn', N'Cưới', N'Lễ + tiệc nhẹ, sân khấu, ánh sáng', 55000000, 80, 120, 'NV01', 1),
('GSK003', N'Cưới - Gói Cao cấp', N'Cưới', N'Full-service: trang trí cao cấp, nhiếp ảnh, ban nhạc/DJ', 120000000, 150, 300, 'NV01', 1),
-- 2. HỘI NGHỊ / HỘI THẢO (MICE)
('GSK004', N'Hội nghị - Half Day', N'Hội nghị', N'Phòng + máy chiếu + tea-break', 8000000, 20, 50, 'NV01', 1),
('GSK005', N'Hội nghị - Full Day', N'Hội nghị', N'Thêm ăn trưa + 2 tea-break', 15000000, 20, 80, 'NV01', 1),
('GSK006', N'Hội nghị - Multi Day', N'Hội nghị', N'Bao phòng, ăn, teambuilding, logistics', 45000000, 30, 100, 'NV01', 1),
-- 3. TEAM BUILDING
('GSK007', N'Team Building - Basic', N'Team building', N'Hoạt động nửa ngày, MC, vật tư', 12000000, 20, 50, 'NV01', 1),
('GSK008', N'Team Building - Standard', N'Team building', N'1 ngày + ăn trưa + huấn luyện viên', 22000000, 30, 80, 'NV01', 1),
('GSK009', N'Team Building - Premium', N'Team building', N'2 ngày + Gala + hướng dẫn chuyên nghiệp', 50000000, 40, 120, 'NV01', 1),
-- 4. TIỆC CÁ NHÂN
('GSK010', N'Tiệc - Mini', N'Tiệc', N'Trang trí + âm thanh nhỏ', 5000000, 10, 30, 'NV01', 1),
('GSK011', N'Tiệc - Standard', N'Tiệc', N'Buffet nhẹ + trang trí chủ đề', 12000000, 30, 80, 'NV01', 1),
('GSK012', N'Tiệc - Deluxe', N'Tiệc', N'Trang trí chủ đề, DJ/biểu diễn, dịch vụ VIP', 25000000, 50, 150, 'NV01', 1),
-- 5. WELLNESS / RETREAT
('GSK013', N'Retreat - 1 Ngày', N'Wellness', N'Yoga + bữa nhẹ + spa', 3500000, 5, 20, 'NV01', 1),
('GSK014', N'Retreat - 3 Ngày', N'Wellness', N'Lộ trình, workshop, spa', 8500000, 8, 25, 'NV01', 1),
('GSK015', N'Retreat - 7 Ngày', N'Wellness', N'Toàn diện: chăm sóc, dinh dưỡng, tham vấn', 18000000, 5, 15, 'NV01', 1);
GO

-- SuKien - Actual Events
INSERT INTO SuKien (MaSK, TenSK, LoaiSuKien, MaCN, DiaDiem, TongChiPhi, CreatedBy, IsActive)
VALUES
('SK001', N'Tiệc cưới Nguyễn - Trần', N'Cưới', 'CN01', N'Sân vườn', 120000000, 'NV01', 1),
('SK002', N'Hội nghị FPT Q4/2024', N'Hội nghị', 'CN01', N'Hội trường', 15000000, 'NV01', 1),
('SK003', N'Team Building Viettel', N'Team building', 'CN02', N'Bãi biển', 50000000, 'NV03', 1),
('SK004', N'Sinh nhật CEO', N'Tiệc', 'CN01', N'Rooftop', 25000000, 'NV01', 1);
GO

-- CTSuKien - Event Package Details (which packages were selected)
INSERT INTO CTSuKien (MaCTSK, MaSK, MaGoiSK, SoLuong, DonGia, ThanhTien, GhiChu, CreatedBy, IsActive)
VALUES
('CTSK001', 'SK001', 'GSK003', 1, 120000000, 120000000, N'Gói cưới cao cấp 200 khách', 'NV01', 1),
('CTSK002', 'SK002', 'GSK005', 1, 15000000, 15000000, N'Hội nghị full day 50 người', 'NV01', 1),
('CTSK003', 'SK003', 'GSK009', 1, 50000000, 50000000, N'Team building 2 ngày 100 người', 'NV03', 1),
('CTSK004', 'SK004', 'GSK012', 1, 25000000, 25000000, N'Tiệc sinh nhật deluxe 100 khách', 'NV01', 1);
GO

INSERT INTO DatPhong (MaDP, MaKH, MaNV, NgayDen, NgayDi, NguoiLon, TreEm, TongTien, TrangThai, CreatedBy, CreatedAt, IsActive)
VALUES
('DP001', 'KH001', 'NV02', DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, -2, GETDATE()), 2, 0, 2400000, N'Trả phòng', 'NV02', DATEADD(DAY, -5, GETDATE()), 1),
('DP002', 'KH002', 'NV02', GETDATE(), DATEADD(DAY, 3, GETDATE()), 2, 1, 4500000, N'Đặt', 'NV02', GETDATE(), 1),
('DP003', 'KH003', 'NV02', DATEADD(HOUR, -3, GETDATE()), DATEADD(HOUR, 1, GETDATE()), 1, 0, 800000, N'Đang sử dụng', 'NV02', DATEADD(HOUR, -3, GETDATE()), 1),
('DP004', 'KH006', 'NV02', DATEADD(DAY, -10, GETDATE()), DATEADD(MONTH, 1, DATEADD(DAY, -10, GETDATE())), 2, 0, 65000000, N'Đang sử dụng', 'NV02', DATEADD(DAY, -10, GETDATE()), 1),
('DP005', 'KH005', 'NV02', DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 8, GETDATE()), 2, 1, 4500000, N'Đặt', 'NV02', GETDATE(), 1);
GO

INSERT INTO CTDatPhong (MaCTDP, MaDP, MaPhong, TrangThai, NgayDen, NgayDi, NguoiLon, TreEm, LoaiDat, SoLuongThue, GiaPhong, ThanhTien, CreatedBy, CreatedAt, IsActive)
VALUES
('CTDP001', 'DP001', 'P001', N'Trả phòng', DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, -2, GETDATE()), 2, 0, N'Theo ngày', 3, 800000, 2400000, 'NV02', DATEADD(DAY, -5, GETDATE()), 1),
('CTDP002', 'DP002', 'P003', N'Đặt', GETDATE(), DATEADD(DAY, 3, GETDATE()), 2, 1, N'Theo ngày', 3, 1500000, 4500000, 'NV02', GETDATE(), 1),
('CTDP003', 'DP003', 'P005', N'Đang sử dụng', DATEADD(HOUR, -3, GETDATE()), DATEADD(HOUR, 1, GETDATE()), 1, 0, N'Theo giờ', 4, 200000, 800000, 'NV02', DATEADD(HOUR, -3, GETDATE()), 1),
('CTDP004', 'DP004', 'P006', N'Đang sử dụng', DATEADD(DAY, -10, GETDATE()), DATEADD(MONTH, 1, DATEADD(DAY, -10, GETDATE())), 2, 0, N'Theo tháng', 1, 65000000, 65000000, 'NV02', DATEADD(DAY, -10, GETDATE()), 1),
('CTDP005', 'DP005', 'P004', N'Đặt', DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 8, GETDATE()), 2, 1, N'Theo ngày', 3, 1500000, 4500000, 'NV02', GETDATE(), 1);
GO

INSERT INTO HoaDon (MaHD, MaDP, MaKH, MaNV, MaKM, MaCN, TrangThai, NgayLap, TongTruocKM, TongTien, CreatedAt, CreatedBy, IsActive)
VALUES
('HD001', 'DP001', 'KH001', 'NV02', NULL, 'CN01', N'Đã TT', DATEADD(DAY, -2, GETDATE()), 2400000, 2400000, DATEADD(DAY, -2, GETDATE()), 'NV02', 1),
('HD002', 'DP002', 'KH002', 'NV02', NULL, 'CN01', N'Chưa TT', GETDATE(), 4500000, 4500000, GETDATE(), 'NV02', 1),
('HD003', 'DP003', 'KH003', 'NV02', NULL, 'CN01', N'Chưa TT', GETDATE(), 800000, 800000, GETDATE(), 'NV02', 1),
('HD004', 'DP004', 'KH006', 'NV02', 'KM002', 'CN01', N'Chưa TT', DATEADD(DAY, -10, GETDATE()), 65000000, 64500000, DATEADD(DAY, -10, GETDATE()), 'NV02', 1);
GO

INSERT INTO ThanhToan (MaTT, MaHD, SoTien, MaLTT, NgayTT, CreatedAt, CreatedBy, IsActive)
VALUES
('TT001', 'HD001', 2400000, 'LTT01', DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, -2, GETDATE()), 'NV02', 1);
GO

INSERT INTO CTDichVu (MaCTDV, MaCTDP, MaDV, SoLuong, ThanhTien, CreatedBy, IsActive)
VALUES
('CTDV001', 'CTDP002', 'DV001', 6, 900000, 'NV02', 1),
('CTDV002', 'CTDP002', 'DV002', 1, 500000, 'NV02', 1),
('CTDV003', 'CTDP004', 'DV001', 30, 4500000, 'NV02', 1);
GO

INSERT INTO DatCoc (MaDatCoc, MaDP, MaKH, SoTien, NgayCoc, LoaiCoc, TrangThai, CreatedBy, CreatedAt)
VALUES
('DC001', 'DP005', 'KH005', 1350000, GETDATE(), N'Booking', N'Đã cọc', 'NV02', GETDATE());
GO

INSERT INTO LostFound (MaLF, MaNV, MaCN, TenDo, NgayTimThay, DiaDiemTim, TrangThai, GhiChu, CreatedAt)
VALUES
('LF001', 'NV02', 'CN01', N'Ví da đen', DATEADD(DAY, -2, GETDATE()), N'Phòng P001', N'Chưa trả', N'Có CCCD bên trong', GETDATE()),
('LF002', 'NV02', 'CN01', N'iPhone 13 Pro', DATEADD(DAY, -5, GETDATE()), N'Nhà hàng', N'Đã trả', NULL, GETDATE());
GO

INSERT INTO Complaint (MaKN, MaKH, MaNV, MaCN, NgayGhi, NoiDung, MucDo, TrangThai, CreatedAt)
VALUES
('KN001', 'KH002', 'NV01', 'CN01', DATEADD(DAY, -3, GETDATE()), N'Điều hòa không mát', N'Trung bình', N'Đã xử lý', GETDATE()),
('KN002', 'KH003', 'NV01', 'CN01', DATEADD(DAY, -1, GETDATE()), N'Tiếng ồn ban đêm', N'Cao', N'Đang xử lý', GETDATE());
GO

INSERT INTO KhachHangDiem (MaKH, DiemHienTai, CapNhatLuc, CreatedBy, CreatedAt)
VALUES
('KH001', 24, GETDATE(), 'NV02', GETDATE()),
('KH002', 0, GETDATE(), 'NV02', GETDATE()),
('KH003', 0, GETDATE(), 'NV01', GETDATE()),
('KH004', 0, GETDATE(), 'NV02', GETDATE()),
('KH005', 45, GETDATE(), 'NV02', GETDATE()),
('KH006', 650, GETDATE(), 'NV02', GETDATE()),
('KH007', 0, GETDATE(), 'NV01', GETDATE()),
('KH008', 120, GETDATE(), 'NV01', GETDATE());
GO

INSERT INTO KhachHangLichSuDiem (MaKH, Ngay, LoaiThaoTac, Diem, GhiChu, NguoiThucHien, CreatedBy, CreatedAt)
VALUES
('KH001', DATEADD(DAY, -2, GETDATE()), N'Cộng điểm', 24, N'Thanh toán HD001 - 2,400,000 VNĐ', 'NV02', 'NV02', GETDATE()),
('KH005', GETDATE(), N'Cộng điểm', 45, N'Khách hàng mới', 'NV02', 'NV02', GETDATE()),
('KH006', DATEADD(DAY, -10, GETDATE()), N'Cộng điểm', 650, N'Thanh toán HD004 - 65,000,000 VNĐ', 'NV02', 'NV02', GETDATE());
GO

INSERT INTO VoucherUsage (MaSuDung, MaVoucher, MaKH, MaDP, NgaySuDung, GiaTriApDung, CreatedBy, CreatedAt)
VALUES
('VU001', 'VC002', 'KH005', 'DP005', GETDATE(), 100000, 'NV02', GETDATE());
GO
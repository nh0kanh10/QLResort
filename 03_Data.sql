--================================================================================
-- FILE 3: 03_Data.sql
-- HỆ THỐNG QUẢN LÝ RESORT - DỮ LIỆU MẶC ĐỊNH
-- Mục đích: Chèn dữ liệu mẫu ban đầu cho database
-- Lưu ý: Chạy file này SAU KHI chạy 01_Tables_Schema.sql và 02_StoredProcedures.sql
--================================================================================

USE QLR;
go
set dateformat dmy
go
GO

--- 6. DỮ LIỆU MẶC ĐỊNH (BASE DATA)
-- Cần Insert vào các bảng gốc (LoaiNV, ChiNhanh, NhanVien) trước
-- để các bảng sau có thể sử dụng giá trị CreatedBy, MaQuanLy...
-----------------------------------------------------------------------------------------------------------------------
-- INSERT LoaiNhanVien
INSERT INTO LoaiNhanVien (MaLoaiNV, TenLoaiNV, MoTa, CreatedBy,CreatedAt)
VALUES ('LNV00', N'Admin', N'Quản trị hệ thống resort, có toàn quyền thao tác', NULL, GETDATE());
GO

-- INSERT ChiNhanh (tạm thời chưa có MaQuanLy)
INSERT INTO ChiNhanh (MaCN, TenCN, DiaChi, CreatedAt ,IsActive)
VALUES
('CN01', N'Resort Biển Xanh', N'123 Đường Trần Phú, Nha Trang',GETDATE(), 1),
('CN02', N'Chi nhánh Phú Mỹ', N'123 Đường XYZ, TP.HCM', GETDATE(), 1);
GO

-- INSERT NhanVien (Sử dụng MaCN, MaLoaiNV đã có)
INSERT INTO NhanVien (MaNV,MaCN, CCCD, GioiTinh, HoTen, ChucVu, SDT, Email, MaLoaiNV,CreatedAt, IsActive)
VALUES
('NV01','CN01','012345678901', N'Nam', N'Nguyễn Văn A', N'Giám đốc', '0912345678', 'admin@resort.com', 'LNV00',GETDATE(), 1),
('NV02','CN01','023456789012', N'Nữ', N'Trần Thị B', N'Quản lý', '0923456789', 'quanly@resort.com', 'LNV00',GETDATE(), 1),
('NV03','CN01','034567890123', N'Nam', N'Lê Văn C', N'Nhân viên', '0934567890', 'nhanvien@resort.com', 'LNV00',GETDATE(), 1),
('NV04','CN01','045678901234', N'Nữ', N'Phạm Thị D', N'Nhân viên', '0945678901', 'nv2@resort.com', 'LNV00',GETDATE(), 1),
('NV05','CN02','056789012345', N'Nam', N'Hoàng Văn E', N'Quản lý', '0956789012', 'ql2@resort.com', 'LNV00',GETDATE(), 1),
('NV06','CN02','067890123456', N'Nữ', N'Võ Thị F', N'Nhân viên', '0967890123', 'nv3@resort.com', 'LNV00',GETDATE(), 1);
GO

-- Cập nhật lại MaQuanLy và CreatedBy cho ChiNhanh (sau khi NV đã tồn tại)
-- Lỗi logic ban đầu: update MaQuanLy (FK) trước khi NhanVien (PK) được tạo.
Update ChiNhanh SET MaQuanLy = 'NV01', CreatedBy = 'NV01' WHERE MaCN = 'CN01';
Update ChiNhanh SET MaQuanLy = 'NV05', CreatedBy = 'NV05' WHERE MaCN = 'CN02';
GO

-- INSERT TaiKhoan (Sử dụng MaNV đã có)
-- Tài khoản Admin
INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
VALUES
('TK001', 'NV01', 'admin', 'admin123', N'Admin', GETDATE(), 'NV01', 1);

-- Tài khoản Quản lý
INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
VALUES
('TK002', 'NV02', 'quanly', 'quanly123', N'QuanLy', GETDATE(), 'NV01', 1),
('TK005', 'NV05', 'quanly2', 'quanly123', N'QuanLy', GETDATE(), 'NV01', 1);

-- Tài khoản Nhân viên
INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
VALUES
('TK003', 'NV03', 'nhanvien', 'nv123456', N'NhanVien', GETDATE(), 'NV01', 1),
('TK004', 'NV04', 'nv2', 'nv123456', N'NhanVien', GETDATE(), 'NV01', 1),
('TK006', 'NV06', 'nv3', 'nv123456', N'NhanVien', GETDATE(), 'NV01', 1);
GO

-- INSERT LoaiKhachHang
INSERT INTO LoaiKhachHang (MaLKH, TenLKH, GiamGiaPercent, DiemToiThieu, MoTa, CreatedBy)
VALUES
(N'LKH01', N'Standard', 0, 0, N'Khách phổ thông, không ưu đãi.', N'NV01'), -- Sửa CreatedBy thành NV01
(N'LKH02', N'Silver', 5, 500, N'Giảm giá nhẹ, tích lũy điểm nhanh hơn.', N'NV01'),
(N'LKH03', N'Gold', 10, 1500, N'Giảm giá tốt, ưu tiên đặt phòng.', N'NV01'),
(N'LKH04', N'VIP', 20, 3000, N'Khách hàng thân thiết, ưu đãi cao, dịch vụ riêng.', N'NV01');
GO

-- INSERT KhachHang (Sử dụng MaLKH đã có)
INSERT INTO KhachHang  -------------
(MaKH, HoTen, GioiTinh, NgaySinh, SDT, Email, IDType, IDNumber, DiaChi, MaLKH, CreatedBy)
VALUES
(N'KH001', N'Nguyễn Văn An', N'Nam', '12-05-1990', N'0901234567', N'an.nguyen@gmail.com',
 N'CCCD', N'012345678900', N'Hà Nội', N'LKH01', N'NV01'),
(N'KH002', N'Trần Thị Bình', N'Nữ', '27-03-1995', N'0912345678', N'tbinh@gmail.com',
 N'CCCD', N'023456789012', N'Hồ Chí Minh', N'LKH02', N'NV01'),
(N'KH003', N'Lê Minh Châu', N'Nữ', '10-10-1988', N'0987654321', N'leminhchau@yahoo.com',
 N'Passport', N'P1234567', N'Đà Nẵng', N'LKH03', N'NV01'),
(N'KH004', N'Phạm Quốc Dũng', N'Nam', '01-07-1982', N'0933666999', N'dung.pham@gmail.com',
 N'CCCD', N'034567890123', N'Hải Phòng', N'LKH04', N'NV01'),
(N'KH005', N'Huỳnh Mỹ Duyên', N'Nữ', '21-09-1999', N'0977998899', N'duyenhm@gmail.com',
 N'CCCD', N'045678901234', N'Cần Thơ', N'LKH02', N'NV01'),
(N'KH006', N'Đỗ Hoàng Phúc', N'Nam', '15-01-2000', N'0909090909', N'hoangphuc@gmail.com',
 N'Passport', N'P7788991', N'Nha Trang', N'LKH03', N'NV01'),
(N'KH007', N'Võ Nhật Quang', N'Nam', '30-12-1996', N'0911222333', N'nhatquang@gmail.com',
 N'CCCD', N'056789012345', N'Bình Dương', N'LKH01', N'NV01'),
(N'KH008', N'Phan Anh Tú', N'Nam', '14-04-1992', N'0933444555', N'anh.tu@gmail.com',
 N'CCCD', N'067890123456', N'Huế', N'LKH04', N'NV01'),
(N'KH009', N'Tô Mỹ Hạnh', N'Nữ', '09-11-1997', N'0944556677', N'myhanhto@gmail.com',
 N'CCCD', N'078901234567', N'Quảng Nam', N'LKH03', N'NV01'),
(N'KH010', N'Ngô Thùy Linh', N'Nữ', '18-06-2001', N'0988123456', N'linhngo2001@gmail.com',
 N'Passport', N'P88990012', N'Sài Gòn', N'LKH01', N'NV01');
GO

-- INSERT LoaiPhong
INSERT INTO LoaiPhong (MaLP, TenLP, MoTa, IsNhaNguyenCan, SoPhongTrongNha, GiaTheoGio, GiaTheoNgay, GiaTheoThang, SucChuaToiDa, IsActive, CreatedBy)
VALUES
('LP001', N'Standard Garden View', N'Phòng tiêu chuẩn 25m², 1 giường Queen, ban công hướng vườn.', 0, 1, NULL, 1500000, NULL, 2, 1, 'NV01'),
('LP002', N'Superior Garden View (Twin)', N'Phòng 30m², 2 giường đơn, ban công hướng vườn.', 0, 1, NULL, 1800000, NULL, 2, 1, 'NV01'),
('LP003', N'Deluxe Ocean View', N'Phòng cao cấp 35m², 1 giường King, ban công riêng nhìn thẳng ra biển.', 0, 1, NULL, 2500000, NULL, 2, 1, 'NV01'),
('LP004', N'Family Room Ocean View', N'Phòng gia đình 50m², 1 giường King và 1 giường đơn, khu vực sofa, hướng biển.', 0, 1, NULL, 3500000, NULL, 4, 1, 'NV01'),
('LP005', N'Garden Bungalow', N'Nhà gỗ riêng biệt 45m² nằm trong vườn, có sân hiên riêng.', 1, 1, NULL, 4000000, NULL, 3, 1, 'NV01'),
('LP006', N'Private Pool Villa (3 Bedrooms)', N'Biệt thự 150m² có hồ bơi riêng, 3 phòng ngủ, phòng khách và bếp.', 1, 3, NULL, 12000000, NULL, 6, 1, 'NV01'),
('LP007', N'Junior Suite', N'Phòng hạng sang 70m² với phòng khách và phòng ngủ tách biệt, bồn tắm Jacuzzi.', 0, 1, NULL, 6000000, NULL, 3, 1, 'NV01'),
('LP008', N'Presidential Suite', N'Phòng Tổng thống 200m², 2 phòng ngủ, phòng ăn, quản gia 24/7, view toàn cảnh đại dương.', 0, 2, NULL, 50000000, NULL, 4, 1, 'NV01');
GO

-- INSERT Phong (Sử dụng MaCN, MaLP đã có)
INSERT INTO Phong (MaPhong, MaCN, MaLP, SoPhong, ViTri, TrangThai, GhiChu, CreatedBy, IsActive)
VALUES
('P001', 'CN01', 'LP004', 'A101', N'Tầng 1 - Khu A', N'Đã đặt', NULL, 'NV01', 1), -- Đã đặt bởi DP003 (check-in ngày mai)
('P002', 'CN01', 'LP004', 'A102', N'Tầng 1 - Khu A', N'Đang Dọn', NULL, 'NV01', 1), -- Vừa check-out hôm qua (DP001)
('P003', 'CN01', 'LP001', 'A201', N'Tầng 2 - Khu A', N'Đã đặt', N'View biển', 'NV01', 1), -- Đã đặt bởi DP004 (check-in sau 14 ngày)
('P004', 'CN01', 'LP001', 'A202', N'Tầng 2 - Khu A', N'Đang Dọn', NULL, 'NV01', 1),
('P005', 'CN01', 'LP002', 'A301', N'Tầng 3 - Khu A', N'Trống', NULL, 'NV01', 1),
('P006', 'CN01', 'LP002', 'A302', N'Tầng 3 - Khu A', N'Đang Sử Dụng', NULL, 'NV01', 1), -- Đang sử dụng bởi DP002 (check-out ngày mai)
('P007', 'CN01', 'LP003', 'V01', N'Khu Villa riêng', N'Trống', N'Biệt thự hồ bơi riêng', 'NV01', 1),
('P008', 'CN01', 'LP003', 'V02', N'Khu Villa riêng', N'Bảo trì', N'Đang sửa điện', 'NV01', 1),
('P009', 'CN02', 'LP004', 'B101', N'Tầng 1 - Khu B', N'Trống', NULL, 'NV01', 1),
('P010', 'CN02', 'LP004', 'B102', N'Tầng 1 - Khu B', N'Trống', NULL, 'NV01', 1), -- Booking DP005 đã hủy
('P011', 'CN02', 'LP001', 'B201', N'Tầng 2 - Khu B', N'Trống', NULL, 'NV01', 1),
('P012', 'CN02', 'LP001', 'B202', N'Tầng 2 - Khu B', N'Đang Dọn', NULL, 'NV01', 1),
('P013', 'CN02', 'LP002', 'B301', N'Tầng 3 - Khu B', N'Trống', NULL, 'NV01', 1),
('P014', 'CN02', 'LP002', 'B302', N'Tầng 3 - Khu B', N'Bảo trì', N'Sửa máy lạnh', 'NV01', 1),
('P015', 'CN01', 'LP005', 'BG01', N'Khu Bungalow vườn', N'Trống', N'Nhà gỗ độc lập', 'NV01', 1),
('P016', 'CN01', 'LP005', 'BG02', N'Khu Bungalow vườn', N'Trống', NULL, 'NV01', 1),
('P017', 'CN01', 'LP006', 'VL01', N'Khu Villa hồ bơi', N'Trống', N'Biệt thự 3 phòng ngủ, hồ bơi riêng', 'NV01', 1),
('P018', 'CN01', 'LP007', 'JS01', N'Tầng 5 - Khu VIP', N'Trống', N'Junior Suite cao cấp', 'NV01', 1),
('P019', 'CN01', 'LP007', 'JS02', N'Tầng 5 - Khu VIP', N'Trống', NULL, 'NV01', 1),
('P020', 'CN01', 'LP008', 'PS01', N'Tầng 6 - Penthouse', N'Trống', N'Presidential Suite - view 360 độ', 'NV01', 1),
('P021', 'CN02', 'LP003', 'V03', N'Khu Villa riêng', N'Trống', NULL, 'NV01', 1),
('P022', 'CN02', 'LP005', 'BG03', N'Khu Bungalow vườn', N'Trống', NULL, 'NV01', 1);
GO

-- INSERT LoaiThanhToan
INSERT INTO LoaiThanhToan (MaLTT, TenLTT, CreatedBy, CreatedAt, IsActive)
VALUES
('LTT01', N'Tiền mặt', 'NV01', GETDATE(), 1),
('LTT02', N'Thẻ tín dụng', 'NV01', GETDATE(), 1),
('LTT03', N'Thẻ ghi nợ', 'NV01', GETDATE(), 1),
('LTT04', N'Chuyển khoản', 'NV01', GETDATE(), 1),
('LTT05', N'Ví điện tử (Momo, ZaloPay)', 'NV01', GETDATE(), 1);
GO

-- INSERT DichVu (Dịch vụ resort thực tế)
INSERT INTO DichVu (MaDV, TenDV, LoaiDV, MoTa, Gia, ChoPhepDoiDiem, GiaTriDoiDiem, CreatedBy, CreatedAt, IsActive)
VALUES
('DV001', N'Dịch vụ Spa - Massage thư giãn 60 phút', N'Spa & Wellness', N'Massage toàn thân với tinh dầu tự nhiên', 500000, 1, 1000, 'NV01', GETDATE(), 1),
('DV002', N'Dịch vụ Spa - Chăm sóc da mặt', N'Spa & Wellness', N'Facial treatment với sản phẩm cao cấp', 800000, 1, 1600, 'NV01', GETDATE(), 1),
('DV003', N'Buffet sáng', N'Ẩm thực', N'Buffet sáng đầy đủ món Á - Âu', 250000, 0, NULL, 'NV01', GETDATE(), 1),
('DV004', N'Buffet tối', N'Ẩm thực', N'Buffet tối với hải sản tươi sống', 650000, 1, 1300, 'NV01', GETDATE(), 1),
('DV005', N'Dịch vụ giặt ủi', N'Tiện ích', N'Giặt ủi quần áo trong ngày', 150000, 0, NULL, 'NV01', GETDATE(), 1),
('DV006', N'Xe đưa đón sân bay', N'Vận chuyển', N'Xe đưa đón sân bay (1 chiều)', 300000, 0, NULL, 'NV01', GETDATE(), 1),
('DV007', N'Thuê xe đạp', N'Vận chuyển', N'Thuê xe đạp theo giờ', 50000, 0, NULL, 'NV01', GETDATE(), 1),
('DV008', N'Lặn biển có hướng dẫn', N'Giải trí', N'Lặn biển với hướng dẫn viên chuyên nghiệp', 1200000, 1, 2400, 'NV01', GETDATE(), 1),
('DV009', N'Chèo thuyền kayak', N'Giải trí', N'Thuê thuyền kayak theo giờ', 200000, 0, NULL, 'NV01', GETDATE(), 1),
('DV010', N'Dịch vụ minibar', N'Tiện ích', N'Đồ uống và snack trong phòng', 150000, 0, NULL, 'NV01', GETDATE(), 1),
('DV011', N'Phòng họp - 4 giờ', N'Hội nghị', N'Thuê phòng họp 4 giờ, tối đa 20 người', 2000000, 0, NULL, 'NV01', GETDATE(), 1),
('DV012', N'Dịch vụ chăm sóc trẻ em', N'Tiện ích', N'Giữ trẻ theo giờ (có cô giáo)', 200000, 0, NULL, 'NV01', GETDATE(), 1);
GO

-- INSERT KhachHangDiem (Điểm thưởng cho khách hàng)
INSERT INTO KhachHangDiem (MaKH, DiemHienTai, CapNhatLuc, CreatedBy, CreatedAt)
VALUES
('KH001', 0, GETDATE(), 'NV01', GETDATE()),
('KH002', 750, GETDATE(), 'NV01', GETDATE()),  -- Silver đã tích lũy
('KH003', 2100, GETDATE(), 'NV01', GETDATE()), -- Gold đã tích lũy
('KH004', 5000, GETDATE(), 'NV01', GETDATE()), -- VIP đã tích lũy
('KH005', 650, GETDATE(), 'NV01', GETDATE()),
('KH006', 1800, GETDATE(), 'NV01', GETDATE()),
('KH007', 0, GETDATE(), 'NV01', GETDATE()),
('KH008', 4200, GETDATE(), 'NV01', GETDATE()),
('KH009', 1350, GETDATE(), 'NV01', GETDATE()),
('KH010', 0, GETDATE(), 'NV01', GETDATE());
GO

-- INSERT SuKien (LOẠI sự kiện - category/template)
-- Lưu ý: SuKien chỉ là loại sự kiện (Đám cưới, Hội nghị, Team building)
-- Các sự kiện cụ thể mà khách đặt sẽ được lưu trong GoiSuKien
INSERT INTO SuKien (MaSK, TenSK, LoaiSuKien, MaCN, DiaDiem, GhiChu, TongChiPhi, CreatedBy, CreatedAt, IsActive)
VALUES
('SK001', N'Đám cưới', N'Cưới', 'CN01', N'Sảnh Grand Ballroom', N'Loại sự kiện đám cưới', NULL, 'NV01', GETDATE(), 1),
('SK002', N'Hội nghị', N'Hội nghị', 'CN01', N'Phòng họp', N'Loại sự kiện hội nghị', NULL, 'NV01', GETDATE(), 1),
('SK003', N'Team building', N'Team building', 'CN01', N'Khu vực sân vườn', N'Loại sự kiện team building', NULL, 'NV01', GETDATE(), 1),
('SK004', N'Tiệc sinh nhật', N'Khác', 'CN01', N'Sảnh tiệc', N'Loại sự kiện tiệc sinh nhật', NULL, 'NV01', GETDATE(), 1);
GO

-- INSERT GoiSuKien (GÓI SỰ KIỆN CỤ THỂ mà khách hàng thật sự đặt)
-- Lưu ý: 
-- - SuKien = LOẠI sự kiện (Đám cưới, Hội nghị, Team building)
-- - GoiSuKien = GÓI CỤ THỂ mà khách đặt (ví dụ: "Đám cưới Nguyễn Văn A", "Đám cưới bãi biển")
-- - CTSuKien = Chi tiết đặt gói sự kiện (link với SuKien theo schema hiện tại)
-- GoiSuKien đã được tạo trong 01_Tables_Schema.sql, nên có thể INSERT vào đây
INSERT INTO GoiSuKien (MaGoiSK, TenGoiSK, LoaiSuKien, MoTa, GiaCoBan, SoKhachToiThieu, SoKhachToiDa, 
                      ThoiGianToiThieu, ThoiGianToiDa, DichVuKemTheo, IsGoiMacDinh, MaCN, CreatedBy, CreatedAt, IsActive)
VALUES
-- Các gói đám cưới cụ thể
('GOI007', N'Đám cưới Nguyễn Văn An & Trần Thị Bình', N'Cưới', 
 N'Đám cưới tại sảnh Grand Ballroom, 200 khách mời, trang trí theo chủ đề màu hồng', 
 85000000, 150, 250, 5, 10, 
 N'Trang trí sảnh cưới, Dàn âm thanh chuyên nghiệp, Hệ thống ánh sáng LED, MC chuyên nghiệp, Ban nhạc sống, Buffet 5 món', 
 0, 'CN01', 'NV01', GETDATE(), 1),

('GOI008', N'Đám cưới bãi biển - Lê Minh Châu', N'Cưới',
 N'Đám cưới tổ chức tại bãi biển riêng của resort, 80 khách, không gian ngoài trời lãng mạn',
 65000000, 50, 100, 4, 8,
 N'Trang trí bãi biển, Lều cưới, Dàn âm thanh di động, MC, Nhạc acoustic, BBQ hải sản, Rượu champagne',
 0, 'CN01', 'NV01', DATEADD(day, -20, GETDATE()), 1),

('GOI009', N'Đám cưới Phạm Quốc Dũng', N'Cưới',
 N'Đám cưới sang trọng tại sảnh lớn, 300 khách, chủ đề màu vàng kim',
 120000000, 200, 400, 6, 12,
 N'Trang trí cao cấp, Dàn âm thanh 5.1, Hệ thống ánh sáng chuyên nghiệp, MC nổi tiếng, Ban nhạc sống, Buffet 7 món, Bar rượu miễn phí',
 0, 'CN01', 'NV01', DATEADD(day, -15, GETDATE()), 1),

-- Các gói hội nghị cụ thể
('GOI010', N'Hội nghị Công ty ABC - Qúy 4/2024', N'Hội nghị',
 N'Hội nghị tổng kết quý 4 của công ty ABC, 50 người tham gia, 2 ngày',
 25000000, 40, 60, 6, 12,
 N'Phòng họp lớn, Máy chiếu HD, Hệ thống âm thanh, Micro không dây, Tea break sáng, Buffet trưa, Coffee break chiều',
 0, 'CN01', 'NV01', DATEADD(day, -30, GETDATE()), 1),

('GOI011', N'Hội nghị khách hàng thân thiết - Ngân hàng XYZ', N'Hội nghị',
 N'Hội nghị khách hàng VIP của ngân hàng, 80 người, 1 ngày',
 18000000, 60, 100, 4, 8,
 N'Phòng họp lớn, Bục phát biểu, Hệ thống dịch thuật, Máy chiếu, Buffet trưa cao cấp, Quà tặng cho khách',
 0, 'CN01', 'NV01', DATEADD(day, -10, GETDATE()), 1),

-- Các gói team building cụ thể
('GOI012', N'Team building Công ty XYZ - Xây dựng đội nhóm', N'Team building',
 N'Chương trình team building 2 ngày 1 đêm cho công ty XYZ, 30 nhân viên',
 35000000, 25, 40, 12, 24,
 N'Khu vực hoạt động rộng, Dụng cụ team building đầy đủ, HLV chuyên nghiệp, Buffet trưa, BBQ tối, Nghỉ đêm tại resort',
 0, 'CN02', 'NV01', DATEADD(day, -25, GETDATE()), 1),

('GOI013', N'Team building Công ty DEF - Kỹ năng lãnh đạo', N'Team building',
 N'Chương trình team building nửa ngày về kỹ năng lãnh đạo, 20 người',
 12000000, 15, 30, 4, 6,
 N'Phòng workshop, Dụng cụ hoạt động, HLV kỹ năng, Bữa trưa nhẹ, Chứng nhận tham gia',
 0, 'CN01', 'NV01', DATEADD(day, -5, GETDATE()), 1);
GO



-- INSERT KhuyenMai (Khuyến mãi)
INSERT INTO KhuyenMai (MaKM, TenKM, IsPhanTram, GiaTri, MaLKH, MaCN, MaLP, MaPhong, CouponCode, NgayBD, NgayKT, DieuKien, CreatedBy, CreatedAt, IsActive)
VALUES
('KM001', N'Giảm 20% cho khách VIP', 1, 20, 'LKH04', NULL, NULL, NULL, 'VIP20', DATEADD(day, -30, GETDATE()), DATEADD(day, 60, GETDATE()), N'Áp dụng cho khách VIP', 'NV01', GETDATE(), 1),
('KM002', N'Giảm 500k cho phòng Deluxe', 0, 500000, NULL, 'CN01', 'LP003', NULL, 'DELUXE500', DATEADD(day, -15, GETDATE()), DATEADD(day, 45, GETDATE()), N'Áp dụng cho phòng Deluxe Ocean View', 'NV01', GETDATE(), 1),
('KM003', N'Giảm 10% cuối tuần', 1, 10, NULL, NULL, NULL, NULL, 'WEEKEND10', DATEADD(day, -10, GETDATE()), DATEADD(day, 30, GETDATE()), N'Áp dụng thứ 6,7,CN', 'NV01', GETDATE(), 1);
GO

-- INSERT Voucher
INSERT INTO Voucher (MaVoucher, TenVoucher, CouponCode, IsPhanTram, GiaTri, SoLuong, SoLuongDaDung, MaLKH, MaCN, MaLP, MaPhong, NgayBD, NgayKT, DieuKien, TrangThai, CreatedBy, CreatedAt, IsActive)
VALUES
('VC001', N'Voucher giảm 15% đơn hàng', 'SUMMER2024', 1, 15, 100, 5, NULL, NULL, NULL, NULL, DATEADD(day, -20, GETDATE()), DATEADD(day, 40, GETDATE()), N'Đơn hàng tối thiểu 2 triệu', 'Active', 'NV01', GETDATE(), 1),
('VC002', N'Voucher giảm 300k', 'NEW300', 0, 300000, 50, 2, NULL, NULL, NULL, NULL, DATEADD(day, -15, GETDATE()), DATEADD(day, 45, GETDATE()), NULL, 'Active', 'NV01', GETDATE(), 1);
GO

-- ==========================================
-- DỮ LIỆU BOOKING & GIAO DỊCH
-- Lưu ý: Đảm bảo không có double booking (2 booking cùng phòng, cùng thời gian)
-- ==========================================

-- INSERT DatPhong (Đặt phòng - một số đã thanh toán, một số chưa)
INSERT INTO DatPhong (MaDP, MaKH, MaNV, TrangThai, GhiChu, CreatedBy, CreatedAt, IsActive)
VALUES
-- Booking đã check-in và thanh toán
('DP001', 'KH002', 'NV03', N'Trả phòng', N'Khách đã check-in và thanh toán đủ', 'NV03', DATEADD(day, -5, GETDATE()), 1),
-- Booking đang ở (check-in rồi nhưng chưa thanh toán hết)
('DP002', 'KH003', 'NV03', N'Đang sử dụng', N'Khách đang ở phòng, chưa thanh toán đủ', 'NV03', DATEADD(day, -3, GETDATE()), 1),
-- Booking đã đặt nhưng chưa check-in (sắp đến)
('DP003', 'KH004', 'NV04', N'Đặt', N'Đặt trước, check-in ngày mai', 'NV04', DATEADD(day, -10, GETDATE()), 1),
-- Booking đã đặt nhưng check-in sau này
('DP004', 'KH005', 'NV03', N'Đặt', N'Đặt trước 2 tuần', 'NV03', DATEADD(day, -7, GETDATE()), 1),
-- Booking đã hủy
('DP005', 'KH006', 'NV04', N'Hủy', N'Khách hủy do thay đổi kế hoạch', 'NV04', DATEADD(day, -8, GETDATE()), 1);
GO

-- INSERT CTDatPhong (Chi tiết đặt phòng - ĐẢM BẢO KHÔNG OVERLAP)
INSERT INTO CTDatPhong (MaCTDP, MaDP, MaPhong, TrangThai, NgayDen, NgayDi, NguoiLon, TreEm, GiaPhong, ThanhTien, CreatedBy, CreatedAt, IsActive)
VALUES
-- DP001: P002 đã check-in từ 5 ngày trước, check-out hôm qua (đã thanh toán) - phòng này giờ TRỐNG
('CTDP001', 'DP001', 'P002', N'Hoàn tất', DATEADD(day, -5, GETDATE()), DATEADD(day, -1, GETDATE()), 2, 1, 3500000, 14000000, 'NV03', DATEADD(day, -5, GETDATE()), 1),
-- DP002: P006 đang sử dụng từ 3 ngày trước, check-out ngày mai (chưa thanh toán hết)
('CTDP002', 'DP002', 'P006', N'Đang sử dụng', DATEADD(day, -3, GETDATE()), DATEADD(day, 1, GETDATE()), 2, 0, 1800000, 7200000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
-- DP003: P001 check-in ngày mai, check-out sau 3 ngày (đã đặt)
('CTDP003', 'DP003', 'P001', N'Đặt', DATEADD(day, 1, GETDATE()), DATEADD(day, 4, GETDATE()), 4, 2, 3500000, 10500000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
-- DP004: P003 check-in sau 14 ngày, check-out sau 17 ngày
('CTDP004', 'DP004', 'P003', N'Đặt', DATEADD(day, 14, GETDATE()), DATEADD(day, 17, GETDATE()), 2, 0, 1500000, 4500000, 'NV03', DATEADD(day, -7, GETDATE()), 1),
-- DP005: P010 đã hủy (có thể dùng lại cho booking khác)
('CTDP005', 'DP005', 'P010', N'Hủy', DATEADD(day, 5, GETDATE()), DATEADD(day, 8, GETDATE()), 2, 1, 3500000, 10500000, 'NV04', DATEADD(day, -8, GETDATE()), 1);
GO

-- INSERT CTDichVu (Chi tiết dịch vụ cho các booking)
INSERT INTO CTDichVu (MaCTDV, MaCTDP, MaDV, SoLuong, Gia, ThanhTien, CreatedBy, CreatedAt, IsActive)
VALUES
-- Dịch vụ cho DP001 (đã hoàn tất)
('CTDV001', 'CTDP001', 'DV003', 3, 250000, 750000, 'NV03', DATEADD(day, -5, GETDATE()), 1), -- Buffet sáng x3
('CTDV002', 'CTDP001', 'DV004', 2, 650000, 1300000, 'NV03', DATEADD(day, -4, GETDATE()), 1), -- Buffet tối x2
('CTDV003', 'CTDP001', 'DV001', 2, 500000, 1000000, 'NV03', DATEADD(day, -3, GETDATE()), 1), -- Spa x2
-- Dịch vụ cho DP002 (đang sử dụng)
('CTDV004', 'CTDP002', 'DV003', 2, 250000, 500000, 'NV03', DATEADD(day, -2, GETDATE()), 1), -- Buffet sáng x2
('CTDV005', 'CTDP002', 'DV008', 1, 1200000, 1200000, 'NV03', DATEADD(day, -1, GETDATE()), 1), -- Lặn biển x1
-- Dịch vụ cho DP003 (đã đặt, chưa check-in)
('CTDV006', 'CTDP003', 'DV003', 5, 250000, 1250000, 'NV04', DATEADD(day, -10, GETDATE()), 1), -- Buffet sáng x5 (gia đình)
('CTDV007', 'CTDP003', 'DV012', 10, 200000, 2000000, 'NV04', DATEADD(day, -10, GETDATE()), 1), -- Giữ trẻ x10 giờ
-- Dịch vụ cho sự kiện (phòng họp)
('CTDV008', 'CTDP004', 'DV011', 1, 2000000, 2000000, 'NV01', DATEADD(day, -20, GETDATE()), 1); -- Phòng họp cho sự kiện
GO

-- INSERT CTSuKien (Chi tiết đặt sự kiện - khách hàng đặt các gói sự kiện cụ thể)
-- Lưu ý: Schema hiện tại CTSuKien link với SuKien (loại sự kiện), không phải GoiSuKien (gói cụ thể)
-- Nên ta dùng MaSK = 'SK001' (Đám cưới) cho các gói đám cưới, 'SK002' (Hội nghị) cho hội nghị, v.v.
-- Thông tin chi tiết về gói cụ thể (ví dụ: "Đám cưới Nguyễn Văn A") được lưu trong GoiSuKien
INSERT INTO CTSuKien (MaCTSK, MaSK, MaKH, MaCTDV, SoLuong, DonGia, GhiChu, DaThanhToan, TrangThai, NgayBD, NgayKT, TongKhach, CreatedBy, CreatedAt, IsActive)
VALUES
-- Đặt gói "Đám cưới Nguyễn Văn An & Trần Thị Bình" (GOI007) - tương ứng với SK001 (loại Đám cưới)
('CTSK001', 'SK001', 'KH001', 'CTDV008', 1, 85000000, 
 N'Đặt gói đám cưới tại sảnh Grand Ballroom, 200 khách, chủ đề màu hồng. Xem chi tiết gói tại GOI007', 
 45000000, N'Lên kế hoạch', DATEADD(day, 20, GETDATE()), DATEADD(day, 20, GETDATE()), 200, 'NV01', DATEADD(day, -20, GETDATE()), 1),
-- Đặt gói "Đám cưới bãi biển - Lê Minh Châu" (GOI008)
('CTSK002', 'SK001', 'KH003', 'CTDV008', 1, 65000000, 
 N'Đặt gói đám cưới bãi biển, 80 khách, không gian ngoài trời. Xem chi tiết gói tại GOI008', 
 35000000, N'Đang diễn ra', DATEADD(day, -5, GETDATE()), DATEADD(day, -5, GETDATE()), 80, 'NV01', DATEADD(day, -20, GETDATE()), 1),
-- Đặt gói "Hội nghị Công ty ABC - Qúy 4/2024" (GOI010)
('CTSK003', 'SK002', 'KH004', 'CTDV008', 1, 25000000, 
 N'Đặt gói hội nghị tổng kết quý 4, 50 người, 2 ngày. Xem chi tiết gói tại GOI010', 
 15000000, N'Đã kết thúc', DATEADD(day, -30, GETDATE()), DATEADD(day, -28, GETDATE()), 50, 'NV01', DATEADD(day, -35, GETDATE()), 1);
GO

-- INSERT DatCoc (Đặt cọc cho các booking)
INSERT INTO DatCoc (MaDatCoc, MaDP, MaCTSK, MaKH, SoTien, NgayCoc, HinhThucThanhToan, LoaiCoc, TrangThai, GhiChu, CreatedBy, CreatedAt)
VALUES
('DC001', 'DP001', NULL, 'KH002', 5000000, DATEADD(day, -10, GETDATE()), N'Chuyển khoản', N'Đặt phòng', N'ĐÃ NHẬN', N'Đặt cọc 50%', 'NV03', DATEADD(day, -10, GETDATE())),
('DC002', 'DP002', NULL, 'KH003', 3000000, DATEADD(day, -8, GETDATE()), N'Tiền mặt', N'Đặt phòng', N'ĐÃ NHẬN', N'Đặt cọc 30%', 'NV03', DATEADD(day, -8, GETDATE())),
('DC003', 'DP003', NULL, 'KH004', 7000000, DATEADD(day, -10, GETDATE()), N'Thẻ tín dụng', N'Đặt phòng', N'ĐÃ NHẬN', N'Đặt cọc 50%', 'NV04', DATEADD(day, -10, GETDATE())),
('DC004', 'DP004', NULL, 'KH005', 2000000, DATEADD(day, -7, GETDATE()), N'Ví điện tử', N'Đặt phòng', N'ĐÃ NHẬN', N'Đặt cọc 40%', 'NV03', DATEADD(day, -7, GETDATE())),
-- Đặt cọc cho sự kiện
('DC005', NULL, 'CTSK001', 'KH001', 45000000, DATEADD(day, -20, GETDATE()), N'Chuyển khoản', N'Sự kiện', N'ĐÃ NHẬN', N'Đặt cọc 50% cho đám cưới', 'NV01', DATEADD(day, -20, GETDATE())),
('DC006', NULL, 'CTSK002', 'KH003', 35000000, DATEADD(day, -25, GETDATE()), N'Thẻ tín dụng', N'Sự kiện', N'ĐÃ NHẬN', N'Đặt cọc 50% cho đám cưới bãi biển', 'NV01', DATEADD(day, -25, GETDATE())),
('DC007', NULL, 'CTSK003', 'KH004', 15000000, DATEADD(day, -35, GETDATE()), N'Chuyển khoản', N'Sự kiện', N'ĐÃ NHẬN', N'Đặt cọc 60% cho hội nghị', 'NV01', DATEADD(day, -35, GETDATE()));
GO

-- INSERT HoaDon (Hóa đơn - một số đã thanh toán, một số chưa)
INSERT INTO HoaDon (MaHD, MaDP, MaKH, MaNV, MaKM, MaCN, TrangThai, NgayLap, TongTruocKM, TongTien, CreatedBy, CreatedAt, IsActive)
VALUES
-- HD001: Đã thanh toán đủ (cho DP001)
('HD001', 'DP001', 'KH002', 'NV03', NULL, 'CN01', N'Đã TT', DATEADD(day, -1, GETDATE()), 16050000, 15247500, 'NV03', DATEADD(day, -1, GETDATE()), 1), -- Có giảm 5% Silver
-- HD002: Chưa thanh toán (cho DP002 - đang ở)
('HD002', 'DP002', 'KH003', 'NV03', NULL, 'CN01', N'Chưa TT', DATEADD(day, -3, GETDATE()), 8900000, 8010000, 'NV03', DATEADD(day, -3, GETDATE()), 1), -- Có giảm 10% Gold, chưa TT hết
-- HD003: Chưa thanh toán (cho DP003 - sắp check-in)
('HD003', 'DP003', 'KH004', 'NV04', 'KM001', 'CN01', N'Chưa TT', DATEADD(day, -10, GETDATE()), 14750000, 11800000, 'NV04', DATEADD(day, -10, GETDATE()), 1); -- Có giảm 20% VIP + voucher
GO

-- INSERT CTHoaDon (Chi tiết hóa đơn)
INSERT INTO CTHoaDon (MaCTHD, MaHD, MoTa, SoLuong, DonGia, ThanhTien, CreatedBy, CreatedAt, IsActive)
VALUES
-- Chi tiết HD001 (đã thanh toán)
('CTHD001', 'HD001', N'Phòng Family Ocean View (4 đêm)', 4, 3500000, 14000000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD002', 'HD001', N'Buffet sáng x3', 3, 250000, 750000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD003', 'HD001', N'Buffet tối x2', 2, 650000, 1300000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD004', 'HD001', N'Dịch vụ Spa x2', 2, 500000, 1000000, 'NV03', DATEADD(day, -1, GETDATE()), 1),
('CTHD005', 'HD001', N'Giảm giá Silver 5%', 1, -802500, -802500, 'NV03', DATEADD(day, -1, GETDATE()), 1),
-- Chi tiết HD002 (chưa thanh toán)
('CTHD006', 'HD002', N'Phòng Superior Twin (4 đêm)', 4, 1800000, 7200000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTHD007', 'HD002', N'Buffet sáng x2', 2, 250000, 500000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTHD008', 'HD002', N'Lặn biển x1', 1, 1200000, 1200000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
('CTHD009', 'HD002', N'Giảm giá Gold 10%', 1, -890000, -890000, 'NV03', DATEADD(day, -3, GETDATE()), 1),
-- Chi tiết HD003 (chưa thanh toán)
('CTHD010', 'HD003', N'Phòng Family Ocean View (3 đêm)', 3, 3500000, 10500000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTHD011', 'HD003', N'Buffet sáng x5', 5, 250000, 1250000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTHD012', 'HD003', N'Dịch vụ giữ trẻ x10 giờ', 10, 200000, 2000000, 'NV04', DATEADD(day, -10, GETDATE()), 1),
('CTHD013', 'HD003', N'Giảm giá VIP 20%', 1, -2950000, -2950000, 'NV04', DATEADD(day, -10, GETDATE()), 1);
GO

-- INSERT ThanhToan (Thanh toán - một số đã thanh toán đủ, một số còn thiếu)
INSERT INTO ThanhToan (MaTT, MaHD, SoTien, MaLTT, NgayTT, CreatedBy, CreatedAt, IsActive)
VALUES
-- Thanh toán cho HD001 (đã thanh toán đủ)
('TT001', 'HD001', 5000000, 'LTT04', DATEADD(day, -10, GETDATE()), 'NV03', DATEADD(day, -10, GETDATE()), 1), -- Đặt cọc
('TT002', 'HD001', 10247500, 'LTT02', DATEADD(day, -1, GETDATE()), 'NV03', DATEADD(day, -1, GETDATE()), 1), -- Thanh toán nốt bằng thẻ
-- Thanh toán cho HD002 (chưa thanh toán đủ - còn thiếu)
('TT003', 'HD002', 3000000, 'LTT01', DATEADD(day, -8, GETDATE()), 'NV03', DATEADD(day, -8, GETDATE()), 1), -- Đặt cọc bằng tiền mặt
('TT004', 'HD002', 3500000, 'LTT02', DATEADD(day, -3, GETDATE()), 'NV03', DATEADD(day, -3, GETDATE()), 1), -- Thanh toán thêm bằng thẻ
-- Còn thiếu: 8010000 - 6500000 = 1,510,000 VNĐ
-- Thanh toán cho HD003 (chỉ mới đặt cọc)
('TT005', 'HD003', 7000000, 'LTT02', DATEADD(day, -10, GETDATE()), 'NV04', DATEADD(day, -10, GETDATE()), 1); -- Đặt cọc bằng thẻ
-- Còn thiếu: 11800000 - 7000000 = 4,800,000 VNĐ
GO

-- INSERT KhachHangLichSuDiem (Lịch sử điểm thưởng)
INSERT INTO KhachHangLichSuDiem (MaKH, Ngay, LoaiThaoTac, Diem, GhiChu, NguoiThucHien, CreatedBy, CreatedAt)
VALUES
-- Điểm tích lũy từ các booking
('KH002', DATEADD(day, -5, GETDATE()), N'CONG', 8025, N'Tích lũy từ booking DP001', N'Hệ thống', 'NV03', DATEADD(day, -1, GETDATE())),
('KH003', DATEADD(day, -3, GETDATE()), N'CONG', 8900, N'Tích lũy từ booking DP002', N'Hệ thống', 'NV03', DATEADD(day, -3, GETDATE())),
('KH004', DATEADD(day, -10, GETDATE()), N'CONG', 11800, N'Tích lũy từ booking DP003', N'Hệ thống', 'NV04', DATEADD(day, -10, GETDATE())),
-- Điểm đã sử dụng (đổi dịch vụ)
('KH002', DATEADD(day, -4, GETDATE()), N'TRU', 500, N'Đổi điểm lấy dịch vụ Spa', N'Hệ thống', 'NV03', DATEADD(day, -4, GETDATE())),
('KH003', DATEADD(day, -2, GETDATE()), N'TRU', 2400, N'Đổi điểm lấy dịch vụ Lặn biển', N'Hệ thống', 'NV03', DATEADD(day, -2, GETDATE()));
GO

-- INSERT VoucherUsage (Lịch sử sử dụng voucher)
INSERT INTO VoucherUsage (MaSuDung, MaVoucher, MaKH, MaHD, MaDP, NgaySuDung, GiaTriApDung, GhiChu, CreatedBy, CreatedAt)
VALUES
('VU001', 'VC001', 'KH004', 'HD003', 'DP003', DATEADD(day, -10, GETDATE()), 2212500, N'Áp dụng voucher SUMMER2024 giảm 15%', 'NV04', DATEADD(day, -10, GETDATE()));
GO

PRINT N'✓ Đã chèn dữ liệu mẫu thành công!';
PRINT N'Lưu ý: Kiểm tra không có double booking - mỗi phòng chỉ có 1 booking active tại một thời điểm.';
GO

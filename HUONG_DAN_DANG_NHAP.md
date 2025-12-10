# HƯỚNG DẪN ĐĂNG NHẬP HỆ THỐNG

## Tài khoản mẫu để đăng nhập

Sau khi chạy file `SQLQuanLyResort.sql`, các tài khoản sau đã được tạo sẵn:

### 1. Tài khoản Admin (Toàn quyền)
- **Tên đăng nhập:** `admin`
- **Mật khẩu:** `admin123`
- **Role:** Admin
- **Nhân viên:** Nguyễn Văn A (NV01) - Giám đốc
- **Quyền:** Có thể truy cập tất cả các chức năng

### 2. Tài khoản Quản lý (CN01)
- **Tên đăng nhập:** `quanly`
- **Mật khẩu:** `quanly123`
- **Role:** QuanLy
- **Nhân viên:** Trần Thị B (NV02) - Quản lý
- **Quyền:** Tất cả trừ Quản lý Chi nhánh

### 3. Tài khoản Quản lý (CN02)
- **Tên đăng nhập:** `quanly2`
- **Mật khẩu:** `quanly123`
- **Role:** QuanLy
- **Nhân viên:** Hoàng Văn E (NV05) - Quản lý
- **Quyền:** Tất cả trừ Quản lý Chi nhánh

### 4. Tài khoản Nhân viên (CN01)
- **Tên đăng nhập:** `nhanvien`
- **Mật khẩu:** `nv123456`
- **Role:** NhanVien
- **Nhân viên:** Lê Văn C (NV03) - Nhân viên
- **Quyền:** Tất cả trừ:
  - Quản lý Chi nhánh
  - Quản lý Nhân viên
  - Quản lý Loại Nhân viên
  - Quản lý Tài khoản
  - Thống kê

### 5. Tài khoản Nhân viên (CN01)
- **Tên đăng nhập:** `nv2`
- **Mật khẩu:** `nv123456`
- **Role:** NhanVien
- **Nhân viên:** Phạm Thị D (NV04) - Nhân viên
- **Quyền:** Tương tự như tài khoản `nhanvien`

### 6. Tài khoản Nhân viên (CN02)
- **Tên đăng nhập:** `nv3`
- **Mật khẩu:** `nv123456`
- **Role:** NhanVien
- **Nhân viên:** Võ Thị F (NV06) - Nhân viên
- **Quyền:** Tương tự như tài khoản `nhanvien`

## Cách sử dụng

1. Chạy file `SQLQuanLyResort.sql` trong SQL Server Management Studio
2. Mở ứng dụng QLResort
3. Form đăng nhập sẽ hiển thị
4. Nhập tên đăng nhập và mật khẩu từ danh sách trên
5. Click "Đăng nhập"

## Lưu ý

- Tất cả mật khẩu đều được lưu dạng plain text (chưa hash) để dễ test
- Trong môi trường production, nên hash mật khẩu
- Role được lưu trực tiếp trong bảng TaiKhoan, không phụ thuộc vào ChucVu


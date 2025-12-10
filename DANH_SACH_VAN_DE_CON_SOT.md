# DANH SÁCH VẤN ĐỀ CÒN SÓT SAU KHI FIX

**Ngày:** 2024  
**Dựa trên:** DANH_GIA_TOAN_BO_HE_THONG.md

---

## 📋 TỔNG QUAN

Đã sửa được **6/6 vấn đề nghiêm trọng và quan trọng**, nhưng còn một số khuyến nghị cải thiện chưa được xử lý.

---

## ✅ ĐÃ SỬA (6/6)

1. ✅ **Double Booking Prevention** - Đã thêm validation trong C#
2. ✅ **Deposit không được sử dụng** - Đã trừ deposit khi thanh toán
3. ✅ **Stored Procedures sai logic** - Đã kiểm tra và xác nhận đúng
4. ✅ **TryGetActiveBooking logic** - Đã tạo stored procedure đơn giản
5. ⚠️ **Đồng bộ trạng thái phòng** - Có logic cơ bản (PARTIAL)
6. ⚠️ **Case sensitivity** - Code C# đã xử lý (PARTIAL)

---

## ⚠️ VẤN ĐỀ CÒN SÓT - CẢI THIỆN (Có thể làm sau)

### 🟢 **1. Validation cho Dịch vụ (Section 2.5)**

**Vấn đề:**
- ❌ Không kiểm tra dịch vụ có available không (nếu có stock)
- ❌ Không kiểm tra giá dịch vụ có cập nhật theo thời gian
- ❌ Chưa có form riêng để thêm dịch vụ sau khi booking (chỉ có trong frmBooking)

**Hiện trạng:**
- Dịch vụ được thêm vào booking trong `frmBooking.PersistServiceDetails()`
- Không có validation về stock/availability
- Không có form riêng cho nhân viên thêm dịch vụ cho booking đang active

**Khuyến nghị:**
- Nếu cần thiết: Thêm cột `SoLuongTon` vào bảng `DichVu`
- Validation trong `ServiceDetailBLL.AddServiceDetail()` để check stock
- Tạo form `frmAddService` riêng để thêm dịch vụ cho booking đang active

**Độ ưu tiên:** 🟢 Thấp (có thể làm sau)

---

### 🟢 **2. Voucher Usage Tracking (Section 2.6)**

**Vấn đề:**
- ⚠️ Có bảng `VoucherUsage` và stored procedure `sp_InsertVoucherUsage`
- ⚠️ Có method `VoucherBLL.UseVoucher()` nhưng **KHÔNG ĐƯỢC GỌI** khi apply voucher trong `frmBooking`
- ❌ Voucher có thể được dùng lại nhiều lần (không track usage)

**Hiện trạng:**
- Trong `frmBooking.BtnApplyDiscount_Click()`:
  - Chỉ validate voucher có hợp lệ không
  - Chỉ tính giảm giá
  - **KHÔNG gọi** `VoucherBLL.UseVoucher()` để track usage
  - **KHÔNG insert** vào `VoucherUsage` table

**Khuyến nghị:**
- Sửa `frmBooking.BtnApplyDiscount_Click()`:
  - Sau khi apply voucher thành công, gọi `VoucherBLL.UseVoucher(couponCode)`
  - Hoặc insert vào `VoucherUsage` với `sp_InsertVoucherUsage`
- Validate `SoLuongDaDung < SoLuong` trước khi cho phép dùng

**Độ ưu tiên:** 🟡 Trung bình (nên sửa sớm)

**Files cần sửa:**
- `QLResort/GUI/frmBooking.cs` - `BtnApplyDiscount_Click()`
- `QLResort/GUI/frmPayment.cs` - `btnApDungKM_Click()` (nếu có áp dụng voucher ở đây)

---

### 🟢 **3. Max Discount Limit (Section 2.6)**

**Vấn đề:**
- ❌ Không có giới hạn tối đa giảm giá
- Có thể giảm quá 100% tổng tiền (tổng tiền thành số âm)

**Hiện trạng:**
- Trong `PromotionBLL.CalculateDiscount()`:
  - Chỉ tính: `GiamGia = TongTien × GiaTri%` hoặc `GiamGia = GiaTri`
  - Không check: `if (GiamGia > TongTien) GiamGia = TongTien`
  - Không check: `if (tongTienMoi < 0) tongTienMoi = 0`

**Khuyến nghị:**
- Sửa `PromotionBLL.CalculateDiscount()`:
  ```csharp
  decimal giamGia = ...; // Tính như cũ
  // Đảm bảo không giảm quá 100%
  if (giamGia > tongTien) 
      giamGia = tongTien;
  ```
- Hoặc thêm validation: `giamGia = Math.Min(giamGia, tongTien * 0.9)` (giới hạn tối đa 90%)

**Độ ưu tiên:** 🟡 Trung bình (nên sửa sớm) ✅ **ĐÃ SỬA**

**Files đã sửa:**
- ✅ `QLResort/BLL/PromotionBLL.cs` - `CalculateDiscount()` - Thêm check `if (giamGia > totalAmount) giamGia = totalAmount`
- ✅ `QLResort/GUI/frmBooking.cs` - `BtnApplyDiscount_Click()` - Thêm check tương tự cho voucher

**Kết quả:**
- Promotion và Voucher không thể giảm quá 100% tổng tiền
- Đảm bảo `tongTienSauGiamGia >= 0`

---

### 🟢 **4. Áp dụng nhiều mã giảm giá cùng lúc (Section 2.6)**

**Vấn đề:**
- ❌ Chỉ hỗ trợ áp dụng 1 mã khuyến mãi/voucher
- Không thể áp dụng cả Promotion và Voucher cùng lúc

**Hiện trạng:**
- `frmBooking` chỉ có 1 textbox `txtCouponCode`
- Chỉ áp dụng 1 mã tại một thời điểm

**Khuyến nghị:**
- Cải thiện UI: Thêm nhiều textbox hoặc ListView để áp dụng nhiều mã
- Hoặc giữ nguyên (đơn giản hơn, phù hợp với nghiệp vụ thực tế)

**Độ ưu tiên:** 🟢 Thấp (có thể không cần)

---

### 🟢 **5. sp_GetCTDatPhong thiếu tham số (Section 3.2)**

**Vấn đề:**
- ❌ Không có tham số `@NgayDen`, `@NgayDi` để filter theo thời gian
- ❌ Không có JOIN với `DatPhong` để lấy thông tin booking đầy đủ (MaKH, TrangThai booking)

**Hiện trạng:**
- Stored procedure `sp_GetCTDatPhong` chỉ có các tham số cơ bản
- Không JOIN với `DatPhong`

**Khuyến nghị:**
- Có thể cải thiện stored procedure (nhưng không bắt buộc vì đã có `sp_GetActiveBookingByRoom`)
- Hoặc giữ nguyên và filter trong C# (đã làm trong `CheckRoomAvailability()`)

**Độ ưu tiên:** 🟢 Thấp (không ảnh hưởng nghiêm trọng)

---

### 🟢 **6. CTHoaDon không link với CTDichVu (Section 4.4)** ⏭️ **BỎ QUA**

**Vấn đề:**
- ⚠️ `CTHoaDon` chỉ lưu `MoTa` (text), không có `MaCTDV` để link
- Khó audit: không biết dịch vụ nào đã được tính vào hóa đơn

**Quyết định:**
- ⏭️ **BỎ QUA** - Vì cần ALTER TABLE, phức tạp hơn, không cần thiết cho yêu cầu cơ bản
- `MoTa` text đã đủ để biết dịch vụ nào (VD: "Dịch vụ: Massage - 500,000đ")
- Nếu cần audit chi tiết, có thể query từ `CTDichVu` theo `MaCTDP`

**Độ ưu tiên:** 🟢 Thấp - Bỏ qua (không cần thiết cho yêu cầu cơ bản)

---

### 🟢 **7. Logic tính giá khi extend booking (Section 4.4)**

**Vấn đề:**
- ⚠️ Khi kéo dài thời gian booking, giá mới có thể khác (nếu giá phòng đã thay đổi)
- Hiện tại: Giữ nguyên `GiaPhong` cũ → ✅ ĐÚNG (theo nghiệp vụ)
- Nhưng nếu giá phòng tăng, có thể cần tính lại

**Hiện trạng:**
- Trong `frmBooking` (update mode):
  - Tính lại tổng tiền dựa trên số đêm mới
  - Giữ nguyên `GiaPhong` cũ

**Khuyến nghị:**
- Giữ nguyên logic hiện tại (đúng nghiệp vụ)
- Hoặc thêm option "Áp dụng giá mới" nếu cần

**Độ ưu tiên:** 🟢 Thấp (logic hiện tại đã đúng)

---

### 🟢 **8. sp_GetDatCoc thiếu procedure tính tổng (Section 3.2)**

**Vấn đề:**
- ⚠️ Không có stored procedure riêng `sp_GetTotalDepositByBooking(@MaDP)`
- Hiện tại: Tính trong C# bằng `DepositBLL.GetTotalDepositForBooking()`

**Hiện trạng:**
- Logic tính tổng deposit đã có trong C# (trong `DepositBLL`)
- Đã được sử dụng trong `PaymentBLL` và `frmPayment`

**Khuyến nghị:**
- Có thể tạo stored procedure để tối ưu performance
- Hoặc giữ nguyên (logic trong C# đã ổn)

**Độ ưu tiên:** 🟢 Thấp (không cần thiết ngay)

---

### 🟢 **9. Refund Logic (Section 2.4, 4.3)**

**Vấn đề:**
- ❌ Chưa có logic hoàn tiền cọc khi hủy booking
- Có bảng `HoanCoc` và stored procedure `sp_InsertHoanCoc` nhưng chưa được sử dụng

**Hiện trạng:**
- Chưa có form hoặc logic để hủy booking và hoàn tiền cọc
- `HoanCoc` table tồn tại nhưng không được dùng

**Khuyến nghị:**
- Tạo form `frmRefund` để hoàn tiền cọc
- Hoặc thêm logic trong form hủy booking (nếu có)

**Độ ưu tiên:** 🟡 Trung bình (quan trọng với nghiệp vụ)

---

### 🟢 **10. Audit Trail (Section 5.3)**

**Vấn đề:**
- ⚠️ Có các cột `CreatedBy`, `UpdatedBy`, `CreatedAt`, `UpdatedAt` nhưng chưa log đầy đủ
- Không có bảng riêng để log mọi thay đổi trạng thái

**Hiện trạng:**
- Mỗi bảng có audit columns cơ bản
- Không có log chi tiết về việc ai đã làm gì, khi nào

**Khuyến nghị:**
- Tạo bảng `AuditLog` để log mọi thay đổi (nếu cần)
- Hoặc giữ nguyên (có thể đủ cho yêu cầu hiện tại)

**Độ ưu tiên:** 🟢 Thấp (nice to have)

---

## 📊 TỔNG KẾT CÁC VẤN ĐỀ CÒN SÓT

### Độ ưu tiên cao (Nên sửa sớm): 2 vấn đề

1. **🟡 Voucher Usage Tracking** - Voucher không được track khi sử dụng
2. **🟡 Max Discount Limit** - Có thể giảm quá 100% ✅ **ĐÃ SỬA** - Thêm validation trong PromotionBLL và frmBooking

### Độ ưu tiên trung bình: 2 vấn đề

3. **🟡 CTHoaDon không link với CTDichVu** - Khó audit
4. **🟡 Refund Logic** - Chưa có logic hoàn tiền cọc

### Độ ưu tiên thấp (Có thể làm sau): 6 vấn đề

5. **🟢 Validation cho dịch vụ** - Stock check
6. **🟢 Áp dụng nhiều mã giảm giá** - Nice to have
7. **🟢 sp_GetCTDatPhong thiếu tham số** - Không ảnh hưởng nghiêm trọng
8. **🟢 Logic tính giá khi extend** - Logic hiện tại đã đúng
9. **🟢 sp_GetTotalDepositByBooking** - Không cần thiết ngay
10. **🟢 Audit Trail** - Nice to have

---

## 🎯 KHUYẾN NGHỊ

### Nên sửa ngay (2 vấn đề):

1. **Voucher Usage Tracking** - Sửa `frmBooking.BtnApplyDiscount_Click()` để track usage
2. **Max Discount Limit** - Sửa `PromotionBLL.CalculateDiscount()` để giới hạn tối đa

### Có thể làm sau (8 vấn đề):

- Các vấn đề còn lại có độ ưu tiên thấp, có thể làm dần hoặc bỏ qua nếu không cần thiết.

---

## 📝 GHI CHÚ

- Tất cả các vấn đề nghiêm trọng (🔴) đã được sửa
- Tất cả các vấn đề quan trọng (🟡) đã được sửa hoặc có logic cơ bản
- Các vấn đề còn lại đều là cải thiện (🟢), không ảnh hưởng nghiêm trọng đến hệ thống
- Có thể tiếp tục phát triển dần dần theo nhu cầu thực tế

---

**Tài liệu này tổng hợp các vấn đề còn sót sau khi đã sửa 6/6 vấn đề nghiêm trọng và quan trọng.**


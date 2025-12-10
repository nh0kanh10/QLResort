// File: QLResort-master/QLResort/BLL/BookingBLL.cs (Code Đã Sửa)

using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.BookingDAL;
using System;
using System.Collections.Generic;
using System.Data;
using QLResort.Core.ClassHoTro; // Giữ nguyên ClassHoTro

namespace QLResort.BLL
{
    public class BookingBLL
    {
        private readonly BookingDAL bookingDAL = new BookingDAL();

        public OperationResult<List<Booking>> GetBookings(string maDP = null, string maKH = null, string maNV = null, string trangThai = null, bool? isActive = null)
        {
            var dalResult = bookingDAL.GetBookings(maDP, maKH, maNV, trangThai, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Booking>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Booking> list = new List<Booking>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapBooking(row));
                }
                return OperationResult<List<Booking>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Booking>>.Fail($"Lỗi khi xử lý dữ liệu đặt phòng: {ex.Message}");
            }
        }

        // ĐÃ SỬA: Đổi tên từ CreateBooking thành AddBooking và tối ưu tham số
        public OperationResult<Booking> AddBooking(Booking booking)
        {
            // 1. Kiểm tra tính hợp lệ cơ bản
            if (string.IsNullOrWhiteSpace(booking.MaKH))
                return OperationResult<Booking>.Fail("Mã khách hàng không được để trống");

            if (string.IsNullOrWhiteSpace(booking.MaNV))
                return OperationResult<Booking>.Fail("Mã nhân viên không được để trống");

            // 2. Tạo mã DP nếu chưa có và xử lý trùng khóa
            if (string.IsNullOrWhiteSpace(booking.MaDP))
            {
                int retryCount = 0;
                const int maxRetries = 5;
                
                while (retryCount < maxRetries)
                {
                    booking.MaDP = GenerateMaDP();
                    
                    // Kiểm tra xem mã đã tồn tại chưa
                    var existing = GetBookings(maDP: booking.MaDP);
                    if (existing.Success && existing.Data.Count == 0)
                    {
                        // Mã chưa tồn tại, có thể sử dụng
                        break;
                    }
                    
                    retryCount++;
                    if (retryCount >= maxRetries)
                    {
                        return OperationResult<Booking>.Fail("Không thể tạo mã đặt phòng duy nhất. Vui lòng thử lại.");
                    }
                    
                    // Đợi một chút trước khi thử lại
                    System.Threading.Thread.Sleep(10);
                }
            }

            // 3. Thiết lập các giá trị mặc định/hệ thống
            booking.TrangThai = booking.TrangThai ?? "Đặt";
            booking.CreatedBy = Session_Now.CurrentUser;
            booking.CreatedAt = DateTime.Now;
            booking.IsActive = true;

            // 4. Thử insert và xử lý lỗi trùng khóa
            var result = bookingDAL.Insert(booking);
            
            // Nếu lỗi trùng khóa, thử lại với mã mới
            if (!result.Success && !string.IsNullOrEmpty(result.ErrorMessage) && 
                (result.ErrorMessage.Contains("PRIMARY KEY") || result.ErrorMessage.Contains("duplicate")))
            {
                if (string.IsNullOrEmpty(booking.MaDP) || booking.MaDP.StartsWith("DP"))
                {
                    // Tạo mã mới và thử lại
                    booking.MaDP = GenerateMaDP();
                    result = bookingDAL.Insert(booking);
                }
            }
            
            // Nếu insert thành công, lấy lại booking với MaDP đã được tạo
            if (result.Success)
            {
                var bookings = GetBookings(maDP: booking.MaDP);
                if (bookings.Success && bookings.Data.Count > 0)
                {
                    return OperationResult<Booking>.Ok(bookings.Data[0]);
                }
                return OperationResult<Booking>.Ok(booking);
            }
            
            return OperationResult<Booking>.Fail(result.ErrorMessage);
        }

        public OperationResult<bool> UpdateBooking(string maDP, string trangThai, string ghiChu, bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maDP))
                return OperationResult<bool>.Fail("Mã đặt phòng không được để trống");

            Booking booking = new Booking
            {
                MaDP = maDP,
                TrangThai = trangThai,
                GhiChu = ghiChu,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now,
                IsActive = isActive ?? true
            };

            var result = bookingDAL.Update(booking); // Giả định BookingDAL có hàm Update(Booking)
            return result;
        }

        private string GenerateMaDP()
        {
            // Lấy tất cả mã DP từ database để tìm số lớn nhất
            var bookings = GetBookings();
            int maxNumber = 0;

            if (bookings.Success && bookings.Data != null)
            {
                foreach (var booking in bookings.Data)
                {
                    if (booking.MaDP != null && booking.MaDP.StartsWith("DP") && booking.MaDP.Length > 2)
                    {
                        if (int.TryParse(booking.MaDP.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            // Tạo mã mới và kiểm tra trùng
            int retryCount = 0;
            const int maxRetries = 100;
            string newMaDP;
            
            do
            {
                maxNumber++;
                newMaDP = $"DP{maxNumber:D3}";
                
                // Kiểm tra xem mã đã tồn tại chưa
                var existing = GetBookings(maDP: newMaDP);
                if (existing.Success && existing.Data.Count == 0)
                {
                    return newMaDP; // Mã chưa tồn tại, có thể sử dụng
                }
                
                retryCount++;
            } while (retryCount < maxRetries);
            
            // Nếu vẫn không tạo được mã duy nhất, dùng timestamp
            return $"DP{DateTime.Now:yyyyMMddHHmmss}";
        }

        // ĐÃ HOÀN THIỆN: Bổ sung mapping cho các cột ngày và số lượng khách
        private Booking MapBooking(DataRow row)
        {
            return new Booking
            {
                MaDP = row["MaDP"]?.ToString() ?? "",
                MaKH = row["MaKH"]?.ToString(),
                MaNV = row["MaNV"]?.ToString(),
                TrangThai = row["TrangThai"]?.ToString(),

                // MAPPING CÁC CỘT NGÀY VÀ SỐ LƯỢNG
                NgayDen = row["NgayDen"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["NgayDen"]) : (DateTime?)null,
                NgayDi = row["NgayDi"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["NgayDi"]) : (DateTime?)null,
                NguoiLon = row["NguoiLon"] != DBNull.Value ? (int?)Convert.ToInt32(row["NguoiLon"]) : (int?)null,
                TreEm = row["TreEm"] != DBNull.Value ? (int?)Convert.ToInt32(row["TreEm"]) : (int?)null,

                GhiChu = row["GhiChu"]?.ToString(),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null,
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"])
            };
        }
    }
}

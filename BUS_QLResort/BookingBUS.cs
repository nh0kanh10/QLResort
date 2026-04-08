using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using DAL_QLResort.BookingDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QLResort
{
    public class BookingBUS
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

        public OperationResult<Booking> AddBooking(Booking booking)
        {
            if (string.IsNullOrWhiteSpace(booking.MaKH))
                return OperationResult<Booking>.Fail("Mã khách hàng không được để trống");

            if (string.IsNullOrWhiteSpace(booking.MaNV))
                return OperationResult<Booking>.Fail("Mã nhân viên không được để trống");

            if (string.IsNullOrWhiteSpace(booking.MaDP))
            {
                int retryCount = 0;
                const int maxRetries = 5;
                
                while (retryCount < maxRetries)
                {
                    booking.MaDP = GenerateMaDP();
                    
                    var existing = GetBookings(maDP: booking.MaDP);
                    if (existing.Success && existing.Data.Count == 0)
                        break;
                    
                    retryCount++;
                    if (retryCount >= maxRetries)
                        return OperationResult<Booking>.Fail("Không thể tạo mã đặt phòng duy nhất. Vui lòng thử lại.");
                    
                    System.Threading.Thread.Sleep(10);
                }
            }

            booking.TrangThai = booking.TrangThai ?? "Đặt";
            booking.CreatedBy = Session_Now.CurrentUser;
            booking.CreatedAt = DateTime.Now;
            booking.IsActive = true;

            var result = bookingDAL.Insert(booking);
            
            if (!result.Success && !string.IsNullOrEmpty(result.ErrorMessage) && 
                (result.ErrorMessage.Contains("PRIMARY KEY") || result.ErrorMessage.Contains("duplicate")))
            {
                if (string.IsNullOrEmpty(booking.MaDP) || booking.MaDP.StartsWith("DP"))
                {
                    booking.MaDP = GenerateMaDP();
                    result = bookingDAL.Insert(booking);
                }
            }
            
            if (result.Success)
            {
                var bookings = GetBookings(maDP: booking.MaDP);
                if (bookings.Success && bookings.Data.Count > 0)
                    return OperationResult<Booking>.Ok(bookings.Data[0]);
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

            return bookingDAL.Update(booking);
        }

        public OperationResult<Booking> UpdateBooking(Booking booking)
        {
            if (booking == null) return OperationResult<Booking>.Fail("Dữ liệu không hợp lệ");
            
            var result = bookingDAL.Update(booking);
            if (result.Success) return OperationResult<Booking>.Ok(booking);
            
            return OperationResult<Booking>.Fail(result.ErrorMessage);
        }

        private string GenerateMaDP()
        {
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

            int retryCount = 0;
            const int maxRetries = 100;
            string newMaDP;
            
            do
            {
                maxNumber++;
                newMaDP = $"DP{maxNumber:D3}";
                
                var existing = GetBookings(maDP: newMaDP);
                if (existing.Success && existing.Data.Count == 0)
                    return newMaDP;
                
                retryCount++;
            } while (retryCount < maxRetries);
            
            return $"DP{DateTime.Now:yyyyMMddHHmmss}";
        }

        private Booking MapBooking(DataRow row)
        {
            return new Booking
            {
                MaDP = row["MaDP"]?.ToString() ?? "",
                MaKH = row["MaKH"]?.ToString(),
                MaNV = row["MaNV"]?.ToString(),
                TrangThai = row["TrangThai"]?.ToString(),
                NgayDen = row.Table.Columns.Contains("NgayDen") && row["NgayDen"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["NgayDen"]) : null,
                NgayDi = row.Table.Columns.Contains("NgayDi") && row["NgayDi"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["NgayDi"]) : null,
                NguoiLon = row.Table.Columns.Contains("NguoiLon") && row["NguoiLon"] != DBNull.Value ? (int?)Convert.ToInt32(row["NguoiLon"]) : null,
                TreEm = row.Table.Columns.Contains("TreEm") && row["TreEm"] != DBNull.Value ? (int?)Convert.ToInt32(row["TreEm"]) : null,
                GhiChu = row["GhiChu"]?.ToString(),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["UpdatedAt"]) : null,
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]),
                
                // Extended Map
                TenKH = row.Table.Columns.Contains("TenKH") && row["TenKH"] != DBNull.Value ? row["TenKH"].ToString() : null,
                TenNV = row.Table.Columns.Contains("TenNV") && row["TenNV"] != DBNull.Value ? row["TenNV"].ToString() : null
            };
        }
    }
}






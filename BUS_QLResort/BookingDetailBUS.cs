using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using DAL_QLResort.BookingDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QLResort
{
    public class BookingDetailBUS
    {
        private readonly BookingDetailDAL bookingDetailDAL = new BookingDetailDAL();

        public OperationResult<List<BookingDetail>> GetBookingDetails(string maCTDP = null, string maDP = null, string maPhong = null, string trangThai = null, bool? isActive = null)
        {
            var dalResult = bookingDetailDAL.GetBookingDetails(maCTDP, maDP, maPhong, trangThai, isActive);

            if (!dalResult.Success)
                return OperationResult<List<BookingDetail>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<BookingDetail> list = new List<BookingDetail>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapBookingDetail(row));
                }
                return OperationResult<List<BookingDetail>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<BookingDetail>>.Fail($"Lỗi khi xử lý dữ liệu chi tiết đặt phòng: {ex.Message}");
            }
        }

        public OperationResult<string> AddBookingDetail(string maDP, string maPhong, DateTime? ngayDen, DateTime? ngayDi,
            int? nguoiLon, int? treEm, decimal? giaPhong, decimal? thanhTien, string trangThai = "Đặt", string loaiThue = "Ngày", string excludeMaDP = null)
        {
            if (string.IsNullOrWhiteSpace(maDP))
                return OperationResult<string>.Fail("Mã đặt phòng không được để trống");

            if (string.IsNullOrWhiteSpace(maPhong))
                return OperationResult<string>.Fail("Mã phòng không được để trống");

            //  Kiểm tra phòng trống trước khi đặt 
            if (ngayDen.HasValue && ngayDi.HasValue)
            {
                var checkResult = CheckRoomAvailability(maPhong, ngayDen.Value, ngayDi.Value, excludeMaDP);
                if (!checkResult.Success) return OperationResult<string>.Fail(checkResult.ErrorMessage);
                
                if (!checkResult.Data)
                    return OperationResult<string>.Fail($"Phòng {maPhong} đã được đặt trong khoảng thời gian này!");
            }

            string maCTDP = GenerateMaCTDP();

            var result = bookingDetailDAL.Insert(maCTDP, maDP, maPhong, ngayDen, ngayDi, nguoiLon, treEm, giaPhong, thanhTien, Session_Now.CurrentUser, trangThai, true, loaiThue);
            if (!result.Success)
                return OperationResult<string>.Fail(result.ErrorMessage);

            return OperationResult<string>.Ok(maCTDP);
        }

        public OperationResult<bool> UpdateBookingDetail(string maCTDP, string trangThai, DateTime? ngayDen, DateTime? ngayDi,
            int? nguoiLon, int? treEm, decimal? giaPhong, decimal? thanhTien, bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maCTDP))
                return OperationResult<bool>.Fail("Mã chi tiết đặt phòng không được để trống");

            // Gọi DAL Update
            var result = bookingDetailDAL.Update(maCTDP, trangThai, ngayDen, ngayDi, nguoiLon, treEm, giaPhong, thanhTien, Session_Now.CurrentUser, isActive);
            return result;
        }

        public OperationResult<string> UpdateBookingDetail(BookingDetail detail)
        {
            if (detail == null) return OperationResult<string>.Fail("Dữ liệu không hợp lệ");

            var result = UpdateBookingDetail(
                detail.MaCTDP, 
                detail.TrangThai, 
                detail.NgayDen, 
                detail.NgayDi, 
                detail.NguoiLon, 
                detail.TreEm, 
                detail.GiaPhong, 
                detail.ThanhTien, 
                true); 

            if (result.Success) return OperationResult<string>.Ok(detail.MaCTDP);
            return OperationResult<string>.Fail(result.ErrorMessage);
        }

        public OperationResult<bool> CheckRoomAvailability(string maPhong, DateTime checkIn, DateTime checkOut, string excludeMaDP = null)
        {
            var result = GetBookingDetails(maPhong: maPhong, isActive: true);
            if (!result.Success) return OperationResult<bool>.Fail(result.ErrorMessage);

            var bookingBUS = new BookingBUS();

            foreach (var detail in result.Data)
            {
                if (!string.IsNullOrEmpty(excludeMaDP) && detail.MaDP == excludeMaDP) continue;
                
                if (detail.TrangThai == "Hủy" || detail.TrangThai == "Hoàn tất") continue;

                if (!string.IsNullOrEmpty(detail.MaDP))
                {
                    var parentBooking = bookingBUS.GetBookings(maDP: detail.MaDP);
                    if (parentBooking.Success && parentBooking.Data != null && parentBooking.Data.Count > 0)
                    {
                        var parentStatus = parentBooking.Data[0].TrangThai;
                        if (parentStatus == "Hủy" || parentStatus == "Hoàn tất") continue; 
                    }
                }
                
                if (detail.NgayDen.HasValue && detail.NgayDi.HasValue)
                {
                     if (detail.NgayDen.Value < checkOut && detail.NgayDi.Value > checkIn)
                     {
                         return OperationResult<bool>.Ok(false); 
                     }
                }
            }
            return OperationResult<bool>.Ok(true); 
        }

        private string GenerateMaCTDP()
        {
            var details = GetBookingDetails();
            int maxNumber = 0;

            if (details.Success && details.Data.Count > 0)
            {
                foreach (var detail in details.Data)
                {
                    if (detail.MaCTDP.StartsWith("CTDP") && detail.MaCTDP.Length > 4)
                    {
                        if (int.TryParse(detail.MaCTDP.Substring(4), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"CTDP{(maxNumber + 1):D3}";
        }


        private BookingDetail MapBookingDetail(DataRow row)
        {
            var detail = new BookingDetail();

            detail.MaCTDP = row["MaCTDP"]?.ToString() ?? "";
            detail.MaDP = row["MaDP"]?.ToString();
            detail.MaPhong = row["MaPhong"]?.ToString();

            detail.TrangThai = row["TrangThai"]?.ToString() ?? string.Empty;
            detail.NgayDen = row["NgayDen"] != DBNull.Value ? Convert.ToDateTime(row["NgayDen"]) : (DateTime?)null;
            detail.NgayDi = row["NgayDi"] != DBNull.Value ? Convert.ToDateTime(row["NgayDi"]) : (DateTime?)null;
            detail.NguoiLon = row["NguoiLon"] != DBNull.Value ? Convert.ToInt32(row["NguoiLon"]) : (int?)null;
            detail.TreEm = row["TreEm"] != DBNull.Value ? Convert.ToInt32(row["TreEm"]) : (int?)null;

            detail.GiaPhong = row["GiaPhong"] != DBNull.Value ? Convert.ToDecimal(row["GiaPhong"]) : (decimal?)null;
            detail.ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : (decimal?)null;

            // Mapping các trường hệ thống
            detail.CreatedBy = row["CreatedBy"]?.ToString();
            detail.CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now;
            detail.UpdatedBy = row["UpdatedBy"]?.ToString();
            detail.UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null;
            detail.IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]);

            // Mapping LoaiThue
            detail.LoaiThue = row.Table.Columns.Contains("LoaiThue") && row["LoaiThue"] != DBNull.Value 
                ? row["LoaiThue"].ToString() 
                : null;

            return detail;
        }
    }
}







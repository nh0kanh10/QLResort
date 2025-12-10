using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.BookingDAL;
using System;
using System.Collections.Generic;
using System.Data;
using QLResort.Core.ClassHoTro;

namespace QLResort.BLL
{
    public class BookingDetailBLL
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
            int? nguoiLon, int? treEm, decimal? giaPhong, decimal? thanhTien, string trangThai = "Đặt")
        {
            if (string.IsNullOrWhiteSpace(maDP))
                return OperationResult<string>.Fail("Mã đặt phòng không được để trống");

            if (string.IsNullOrWhiteSpace(maPhong))
                return OperationResult<string>.Fail("Mã phòng không được để trống");

            string maCTDP = GenerateMaCTDP();

            var result = bookingDetailDAL.Insert(maCTDP, maDP, maPhong, ngayDen, ngayDi, nguoiLon, treEm, giaPhong, thanhTien, Session_Now.CurrentUser, trangThai);
            if (!result.Success)
                return OperationResult<string>.Fail(result.ErrorMessage);

            return OperationResult<string>.Ok(maCTDP);
        }

        public OperationResult<bool> UpdateBookingDetail(string maCTDP, string trangThai, DateTime? ngayDen, DateTime? ngayDi,
            int? nguoiLon, int? treEm, decimal? giaPhong, decimal? thanhTien, bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maCTDP))
                return OperationResult<bool>.Fail("Mã chi tiết đặt phòng không được để trống");

            var result = bookingDetailDAL.Update(maCTDP, trangThai, ngayDen, ngayDi, nguoiLon, treEm, giaPhong, thanhTien, Session_Now.CurrentUser, isActive);
            return result;
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

        // Trong BookingDetailBLL.cs

        private BookingDetail MapBookingDetail(DataRow row)
        {
            // Sử dụng ClassHoTro.DataRowHelper nếu bạn có để xử lý DBNull an toàn hơn

            // Khởi tạo đối tượng
            var detail = new BookingDetail();

            // === DỮ LIỆU CƠ BẢN (Đảm bảo không NULL) ===
            detail.MaCTDP = row["MaCTDP"]?.ToString() ?? "";
            detail.MaDP = row["MaDP"]?.ToString();
            detail.MaPhong = row["MaPhong"]?.ToString();

            // === FIX LỖI THIẾU MAPPING: Dữ liệu nghiệp vụ ===
            detail.TrangThai = row["TrangThai"]?.ToString() ?? string.Empty; // FIX: Lấy Trạng thái, nếu NULL gán ""
            detail.NgayDen = row["NgayDen"] != DBNull.Value ? Convert.ToDateTime(row["NgayDen"]) : (DateTime?)null;
            detail.NgayDi = row["NgayDi"] != DBNull.Value ? Convert.ToDateTime(row["NgayDi"]) : (DateTime?)null;
            detail.NguoiLon = row["NguoiLon"] != DBNull.Value ? Convert.ToInt32(row["NguoiLon"]) : (int?)null;
            detail.TreEm = row["TreEm"] != DBNull.Value ? Convert.ToInt32(row["TreEm"]) : (int?)null;

            // === DỮ LIỆU TÀI CHÍNH & HỆ THỐNG ===
            detail.GiaPhong = row["GiaPhong"] != DBNull.Value ? Convert.ToDecimal(row["GiaPhong"]) : (decimal?)null;
            detail.ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : (decimal?)null;

            // Mapping các trường hệ thống
            detail.CreatedBy = row["CreatedBy"]?.ToString();
            detail.CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now;
            detail.UpdatedBy = row["UpdatedBy"]?.ToString();
            detail.UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null;
            detail.IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]);

            // **CHÚ Ý:** Nếu bạn cần các trường JOIN từ SQL (SoPhong, TenLP, v.v.), bạn cần thêm chúng vào BookingDetail Model

            return detail;
        }
    }
}


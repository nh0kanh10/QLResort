using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.BookingDAL
{
    public class BookingDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetBookings(string maDP = null, string maKH = null, string maNV = null, string trangThai = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    // FIX: Áp dụng ?.Trim() cho tất cả tham số chuỗi
                    SqlParameterHelper.Create("@MaDP", maDP ?.Trim()),
                    SqlParameterHelper.Create("@MaKH", maKH ?.Trim()),
                    SqlParameterHelper.Create("@MaNV", maNV ?.Trim()),
                    SqlParameterHelper.Create("@TrangThai", trangThai ?.Trim()),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Booking.GetDatPhong, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách đặt phòng: {ex.Message}");
            }
        }

        public OperationResult<Booking> Insert(Booking booking)
        {
            // Cần đảm bảo rằng các thuộc tính tài chính đã được thêm vào class Booking
            // và được gán giá trị hợp lệ (ít nhất là 0) trước khi gọi hàm này.

            try
            {
                // 🚀 FIX: Bổ sung TẤT CẢ các tham số BẮT BUỘC và cần thiết theo Stored Procedure
                SqlParameter[] parameters = new SqlParameter[]
                {
            // 1. Dữ liệu chính
            SqlParameterHelper.Create("@MaDP", booking.MaDP),
            SqlParameterHelper.Create("@MaKH", booking.MaKH),
            SqlParameterHelper.Create("@MaNV", booking.MaNV),
            
            // 2. Dữ liệu Thời gian và Khách hàng (BẮT BUỘC NOT NULL trong DB)
            // Lỗi "NgayDen cannot be NULL" xảy ra vì thiếu các tham số này
            // Ensure .Value is used for DateTime? if the database column is NOT NULL.
            SqlParameterHelper.Create("@NgayDen", booking.NgayDen.Value),
            SqlParameterHelper.Create("@NgayDi", booking.NgayDi.Value),
            SqlParameterHelper.Create("@NguoiLon", booking.NguoiLon.Value),
            SqlParameterHelper.Create("@TreEm", booking.TreEm ?? 0), // Dùng ?? 0 nếu DB cho phép DEFAULT 0 hoặc cần giá trị INT

            // 3. Dữ liệu Tài chính (BẮT BUỘC NOT NULL DEFAULT 0 trong DB)
            // Giả định các thuộc tính này đã có trong Booking Model
            SqlParameterHelper.Create("@TienDatCoc", booking.TienDatCoc ?? 0),
            SqlParameterHelper.Create("@TongGiamGia", booking.TongGiamGia ?? 0),
            SqlParameterHelper.Create("@MaKM", booking.MaKM), // Mã KM có thể NULL
            
            // 4. Dữ liệu Trạng thái và Ghi chú
            SqlParameterHelper.Create("@TrangThaiThanhToan", booking.TrangThaiThanhToan ?? "Chưa thanh toán"),
            SqlParameterHelper.Create("@TrangThai", booking.TrangThai),
            SqlParameterHelper.Create("@GhiChu", booking.GhiChu),
            
            // 5. Dữ liệu Hệ thống
            SqlParameterHelper.Create("@CreatedBy", booking.CreatedBy),
            SqlParameterHelper.Create("@IsActive", booking.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Booking.InsertDatPhong, parameters);

                // Cần đảm bảo MaDP được sinh ra trước khi gọi Insert
                // Nếu MaDP được DB tự động sinh ra (Identity), bạn cần dùng ExecuteScalar

                // Trả về Booking đã được thêm thành công
                return OperationResult<Booking>.Ok(booking);
            }
            catch (SqlException sqlEx)
            {
                // Xử lý lỗi trùng khóa chính (2627/2601)
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    // Sử dụng tiếng Anh và tiếng Việt để tập luyện
                    return OperationResult<Booking>.Fail($"Mã đặt phòng '{booking.MaDP}' đã tồn tại (Primary Key Violation). Vui lòng thử mã khác. Error code: {sqlEx.Number}.");
                }

                // Xử lý lỗi NULL value (Ví dụ: MaKH NULL, NgayDen NULL, etc.)
                if (sqlEx.Message.Contains("Cannot insert the value NULL into column"))
                {
                    return OperationResult<Booking>.Fail($"Lỗi dữ liệu: Giá trị NULL không hợp lệ cho một trong các cột bắt buộc. Vui lòng kiểm tra dữ liệu đầu vào. SQL Error: {sqlEx.Message}");
                }

                // Các lỗi SQL khác
                return OperationResult<Booking>.Fail($"Lỗi SQL khi thêm đặt phòng (SQL Insert Error): {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Các lỗi không phải SQL
                return OperationResult<Booking>.Fail($"Lỗi hệ thống khi thêm đặt phòng (System Error): {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Booking booking)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaDP", booking.MaDP),
                    SqlParameterHelper.Create("@TrangThai", booking.TrangThai),
                    SqlParameterHelper.Create("@GhiChu", booking.GhiChu),
                    SqlParameterHelper.Create("@UpdatedBy", booking.UpdatedBy),
                    SqlParameterHelper.Create("@IsActive", booking.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Booking.UpdateDatPhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật đặt phòng: {ex.Message}");
            }
        }
    }
}


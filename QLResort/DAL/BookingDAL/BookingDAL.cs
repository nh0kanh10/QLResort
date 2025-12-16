using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
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
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaDP", booking.MaDP),
                    SqlParameterHelper.Create("@MaKH", booking.MaKH),
                    SqlParameterHelper.Create("@MaNV", booking.MaNV),
                    
                    SqlParameterHelper.Create("@TrangThai", booking.TrangThai),
                    SqlParameterHelper.Create("@GhiChu", booking.GhiChu),
                    
                    SqlParameterHelper.Create("@CreatedBy", booking.CreatedBy),
                    SqlParameterHelper.Create("@IsActive", booking.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Booking.InsertDatPhong, parameters);

                return OperationResult<Booking>.Ok(booking);
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    return OperationResult<Booking>.Fail($"Mã đặt phòng '{booking.MaDP}' đã tồn tại (Primary Key Violation). Vui lòng thử mã khác. Error code: {sqlEx.Number}.");
                }

                if (sqlEx.Message.Contains("Cannot insert the value NULL into column"))
                {
                    return OperationResult<Booking>.Fail($"Lỗi dữ liệu: Giá trị NULL không hợp lệ cho một trong các cột bắt buộc. Vui lòng kiểm tra dữ liệu đầu vào. SQL Error: {sqlEx.Message}");
                }

                return OperationResult<Booking>.Fail($"Lỗi SQL khi thêm đặt phòng (SQL Insert Error): {sqlEx.Message}");
            }
            catch (Exception ex)
            {
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


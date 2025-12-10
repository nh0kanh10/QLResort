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
    public class BookingDetailDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetBookingDetails(string maCTDP = null, string maDP = null, string maPhong = null, string trangThai = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTDP", maCTDP?.Trim()),
                    SqlParameterHelper.Create("@MaDP", maDP?.Trim()),
                    SqlParameterHelper.Create("@MaPhong", maPhong?.Trim()),
                    SqlParameterHelper.Create("@TrangThai", trangThai ?.Trim()),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.BookingDetail.GetCTDatPhong, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách chi tiết đặt phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(string maCTDP, string maDP, string maPhong, DateTime? ngayDen, DateTime? ngayDi, 
            int? nguoiLon, int? treEm, decimal? giaPhong, decimal? thanhTien, string createdBy, string trangThai = "Đặt", bool isActive = true)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTDP", maCTDP),
                    SqlParameterHelper.Create("@MaDP", maDP),
                    SqlParameterHelper.Create("@MaPhong", maPhong),
                    SqlParameterHelper.Create("@TrangThai", trangThai ?? "Đặt"),
                    SqlParameterHelper.Create("@NgayDen", ngayDen),
                    SqlParameterHelper.Create("@NgayDi", ngayDi),
                    SqlParameterHelper.Create("@NguoiLon", nguoiLon),
                    SqlParameterHelper.Create("@TreEm", treEm),
                    SqlParameterHelper.Create("@GiaPhong", giaPhong),
                    SqlParameterHelper.Create("@ThanhTien", thanhTien),
                    SqlParameterHelper.Create("@CreatedBy", createdBy),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.BookingDetail.InsertCTDatPhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm chi tiết đặt phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(string maCTDP, string trangThai, DateTime? ngayDen, DateTime? ngayDi,
            int? nguoiLon, int? treEm, decimal? giaPhong, decimal? thanhTien, string updatedBy, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTDP", maCTDP),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@NgayDen", ngayDen),
                    SqlParameterHelper.Create("@NgayDi", ngayDi),
                    SqlParameterHelper.Create("@NguoiLon", nguoiLon),
                    SqlParameterHelper.Create("@TreEm", treEm),
                    SqlParameterHelper.Create("@GiaPhong", giaPhong),
                    SqlParameterHelper.Create("@ThanhTien", thanhTien),
                    SqlParameterHelper.Create("@UpdatedBy", updatedBy),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.BookingDetail.UpdateCTDatPhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật chi tiết đặt phòng: {ex.Message}");
            }
        }
    }
}


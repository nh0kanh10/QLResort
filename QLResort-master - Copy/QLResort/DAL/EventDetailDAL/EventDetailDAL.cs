using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.EventDetailDAL
{
    public class EventDetailDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetEventDetails(string maCTSK = null, string maSK = null,
            string maKH = null, string trangThai = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTSK", maCTSK),
                    SqlParameterHelper.Create("@MaSK", maSK),
                    SqlParameterHelper.Create("@MaKH", maKH),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.EventDetail.GetCTSuKien, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách chi tiết sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(EventDetail detail)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTSK", detail.MaCTSK),
                    SqlParameterHelper.Create("@MaSK", detail.MaSK),
                    SqlParameterHelper.Create("@MaKH", detail.MaKH),
                    SqlParameterHelper.Create("@MaCTDV", detail.MaCTDV ?? "CTDV001"), // Default service detail
                    SqlParameterHelper.Create("@SoLuong", detail.SoLuong),
                    SqlParameterHelper.Create("@DonGia", detail.DonGia),
                    SqlParameterHelper.Create("@GhiChu", detail.GhiChu),
                    SqlParameterHelper.Create("@DaThanhToan", detail.DaThanhToan),
                    SqlParameterHelper.Create("@TrangThai", detail.TrangThai ?? "Lên kế hoạch"),
                    SqlParameterHelper.Create("@NgayBD", detail.NgayBD),
                    SqlParameterHelper.Create("@NgayKT", detail.NgayKT),
                    SqlParameterHelper.Create("@TongKhach", detail.TongKhach),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", detail.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.EventDetail.InsertCTSuKien, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");

                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm chi tiết sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(EventDetail detail)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTSK", detail.MaCTSK),
                    SqlParameterHelper.Create("@TrangThai", detail.TrangThai),
                    SqlParameterHelper.Create("@DaThanhToan", detail.DaThanhToan),
                    SqlParameterHelper.Create("@GhiChu", detail.GhiChu),
                    SqlParameterHelper.Create("@TongKhach", detail.TongKhach),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", detail.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.EventDetail.UpdateCTSuKien, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật chi tiết sự kiện: {ex.Message}");
            }
        }

        public bool Exists(string maCTSK)
        {
            try
            {
                var result = GetEventDetails(maCTSK: maCTSK);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}


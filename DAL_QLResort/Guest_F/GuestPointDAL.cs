using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLResort.GuestPointDAL
{
    public class GuestPointDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetGuestPoint(string maKH)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKH", maKH)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.GuestPoint.GetKhachHangDiem, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy điểm khách hàng: {ex.Message}");
            }
        }

        public OperationResult<bool> DeductPoints(string maKH, int diemTru, string ghiChu, string nguoiThucHien, string createdBy)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKH", maKH),
                    SqlParameterHelper.Create("@DiemTru", diemTru),
                    SqlParameterHelper.Create("@GhiChu", ghiChu),
                    SqlParameterHelper.Create("@NguoiThucHien", nguoiThucHien),
                    SqlParameterHelper.Create("@CreatedBy", createdBy)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.GuestPoint.UpdateKhachHangDiem, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi trừ điểm khách hàng: {ex.Message}");
            }
        }
        public OperationResult<bool> AddPoints(string maKH, int diemCong, string ghiChu, string nguoiThucHien, string createdBy)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKH", maKH),
                    SqlParameterHelper.Create("@DiemCong", diemCong),
                    SqlParameterHelper.Create("@GhiChu", ghiChu),
                    SqlParameterHelper.Create("@NguoiThucHien", nguoiThucHien),
                    SqlParameterHelper.Create("@CreatedBy", createdBy)
                };

                fastQuery.ExecuteNonQueryProc("sp_AddKhachHangDiem", parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cộng điểm khách hàng: {ex.Message}");
            }
        }
    }
}





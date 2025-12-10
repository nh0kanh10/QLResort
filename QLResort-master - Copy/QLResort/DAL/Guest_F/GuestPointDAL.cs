using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.GuestPointDAL
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
    }
}


using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLResort.PaymentDAL
{
    public class PaymentTypeDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetPaymentTypes(string maLTT = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLTT", maLTT),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.PaymentType.GetLoaiThanhToan, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách loại thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(PaymentType paymentType)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLTT", paymentType.MaLTT),
                    SqlParameterHelper.Create("@TenLTT", paymentType.TenLTT),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", paymentType.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.PaymentType.InsertLoaiThanhToan, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm loại thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(PaymentType paymentType)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLTT", paymentType.MaLTT),
                    SqlParameterHelper.Create("@TenLTT", paymentType.TenLTT),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", paymentType.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.PaymentType.UpdateLoaiThanhToan, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật loại thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maLTT)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLTT", maLTT)
                };
                
                fastQuery.ExecuteNonQueryProc(StoredProcedures.PaymentType.DeleteLoaiThanhToan, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa loại thanh toán: {ex.Message}");
            }
        }
    }
}






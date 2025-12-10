using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.PaymentDAL
{
    public class PaymentDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetPayments(string maTT = null, string maHD = null, string maLTT = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTT", maTT),
                    SqlParameterHelper.Create("@MaHD", maHD),
                    SqlParameterHelper.Create("@MaLTT", maLTT),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Payment.GetThanhToan, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Payment payment)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTT", payment.MaTT),
                    SqlParameterHelper.Create("@MaHD", payment.MaHD),
                    SqlParameterHelper.Create("@SoTien", payment.SoTien),
                    SqlParameterHelper.Create("@MaLTT", payment.MaLTT),
                    SqlParameterHelper.Create("@NgayTT", payment.NgayTT),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", payment.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Payment.InsertThanhToan, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Payment payment)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTT", payment.MaTT),
                    SqlParameterHelper.Create("@SoTien", payment.SoTien),
                    SqlParameterHelper.Create("@MaLTT", payment.MaLTT),
                    SqlParameterHelper.Create("@NgayTT", payment.NgayTT),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", payment.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Payment.UpdateThanhToan, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maTT)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTT", maTT)
                };
                
                fastQuery.ExecuteNonQueryProc(StoredProcedures.Payment.DeleteThanhToan, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa thanh toán: {ex.Message}");
            }
        }
    }
}



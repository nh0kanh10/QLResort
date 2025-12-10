using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.ServiceDetailDAL
{
    public class ServiceDetailDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetServiceDetails(string maCTDV = null, string maCTDP = null, string maDV = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTDV", maCTDV),
                    SqlParameterHelper.Create("@MaCTDP", maCTDP),
                    SqlParameterHelper.Create("@MaDV", maDV),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.ServiceDetail.GetCTDichVu, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách chi tiết dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(ServiceDetail serviceDetail)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTDV", serviceDetail.MaCTDV),
                    SqlParameterHelper.Create("@MaCTDP", serviceDetail.MaCTDP),
                    SqlParameterHelper.Create("@MaDV", serviceDetail.MaDV),
                    SqlParameterHelper.Create("@SoLuong", serviceDetail.SoLuong),
                    SqlParameterHelper.Create("@Gia", serviceDetail.Gia),
                    SqlParameterHelper.Create("@ThanhTien", serviceDetail.ThanhTien),
                    SqlParameterHelper.Create("@CreatedBy", serviceDetail.CreatedBy),
                    SqlParameterHelper.Create("@IsActive", serviceDetail.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.ServiceDetail.InsertCTDichVu, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm chi tiết dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(ServiceDetail serviceDetail)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTDV", serviceDetail.MaCTDV),
                    SqlParameterHelper.Create("@SoLuong", serviceDetail.SoLuong),
                    SqlParameterHelper.Create("@Gia", serviceDetail.Gia),
                    SqlParameterHelper.Create("@ThanhTien", serviceDetail.ThanhTien),
                    SqlParameterHelper.Create("@UpdatedBy", serviceDetail.UpdatedBy),
                    SqlParameterHelper.Create("@IsActive", serviceDetail.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.ServiceDetail.UpdateCTDichVu, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật chi tiết dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maCTDV)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTDV", maCTDV)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.ServiceDetail.DeleteCTDichVu, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa chi tiết dịch vụ: {ex.Message}");
            }
        }
    }
}


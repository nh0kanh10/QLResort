using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLResort.ServiceDAL
{
    public class ServiceDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetServices(string maDV = null, string tenDV = null, string loaiDV = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaDV", maDV),
                    SqlParameterHelper.Create("@LoaiDV", loaiDV),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Service.GetDichVu, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Service service)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaDV", service.MaDV),
                    SqlParameterHelper.Create("@TenDV", service.TenDV),
                    SqlParameterHelper.Create("@LoaiDV", service.LoaiDV),
                    SqlParameterHelper.Create("@MoTa", service.MoTa),
                    SqlParameterHelper.Create("@Gia", service.Gia),
                    SqlParameterHelper.Create("@ChoPhepDoiDiem", service.ChoPhepDoiDiem),
                    SqlParameterHelper.Create("@GiaTriDoiDiem", service.GiaTriDoiDiem),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", service.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Service.InsertDichVu, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Service service)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaDV", service.MaDV),
                    SqlParameterHelper.Create("@TenDV", service.TenDV),
                    SqlParameterHelper.Create("@LoaiDV", service.LoaiDV),
                    SqlParameterHelper.Create("@MoTa", service.MoTa),
                    SqlParameterHelper.Create("@Gia", service.Gia),
                    SqlParameterHelper.Create("@ChoPhepDoiDiem", service.ChoPhepDoiDiem),
                    SqlParameterHelper.Create("@GiaTriDoiDiem", service.GiaTriDoiDiem),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", service.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Service.UpdateDichVu, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maDV)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaDV", maDV)
                };
                
                fastQuery.ExecuteNonQueryProc(StoredProcedures.Service.DeleteDichVu, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa dịch vụ: {ex.Message}");
            }
        }

        public bool Exists(string maDV)
        {
            try
            {
                var result = GetServices(maDV: maDV);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}











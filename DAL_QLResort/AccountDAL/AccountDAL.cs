using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLResort.AccountDAL
{
    public class AccountDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetAccounts(string maTK = null, string maNV = null, string tenDangNhap = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", maTK),
                    SqlParameterHelper.Create("@MaNV", maNV),
                    SqlParameterHelper.Create("@TenDangNhap", tenDangNhap),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Account.GetTaiKhoan, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách tài khoản: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Account account)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", account.MaTK),
                    SqlParameterHelper.Create("@MaNV", account.MaNV),
                    SqlParameterHelper.Create("@TenDangNhap", account.TenDangNhap),
                    SqlParameterHelper.Create("@MatKhau", account.MatKhau),
                    SqlParameterHelper.Create("@Role", account.Role ?? "NhanVien"),
                    SqlParameterHelper.Create("@CreatedBy", account.CreatedBy),
                    SqlParameterHelper.Create("@IsActive", account.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Account.InsertTaiKhoan, parameters);
                // Note: ExecuteNonQueryProc returns number of rows affected. 
                // Since this is likely not using output parameters in the SP provided, we assume success if no exception. 
                // But strictly, RowCount should receive a value. 
                // fastQuery.ExecuteNonQueryProc implementation typically returns int.
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm tài khoản: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Account account)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", account.MaTK),
                    SqlParameterHelper.Create("@TenDangNhap", account.TenDangNhap),
                    SqlParameterHelper.Create("@MatKhau", account.MatKhau),
                    SqlParameterHelper.Create("@Role", account.Role ?? "NhanVien"),
                    SqlParameterHelper.Create("@UpdatedBy", account.UpdatedBy),
                    SqlParameterHelper.Create("@IsActive", account.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Account.UpdateTaiKhoan, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật tài khoản: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maTK)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", maTK)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Account.DeleteTaiKhoan, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa tài khoản: {ex.Message}");
            }
        }

        public bool Exists(string maNV)
        {
            try
            {
                var result = GetAccounts(maNV: maNV);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}





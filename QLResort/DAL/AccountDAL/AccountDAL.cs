using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.AccountDAL
{
    public class AccountDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetAccounts(string maTK = null, string maNV = null, string tenDangNhap = null, bool? isActive = null)
        {
            try
            {
                string query = @"
                    SELECT MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
                    FROM TaiKhoan
                    WHERE (@MaTK IS NULL OR MaTK = @MaTK)
                      AND (@MaNV IS NULL OR MaNV = @MaNV)
                      AND (@TenDangNhap IS NULL OR TenDangNhap = @TenDangNhap)
                      AND (@IsActive IS NULL OR IsActive = @IsActive)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", maTK),
                    SqlParameterHelper.Create("@MaNV", maNV),
                    SqlParameterHelper.Create("@TenDangNhap", tenDangNhap),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteQuery(query, parameters);
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
                string query = @"
                    INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, Role, CreatedAt, CreatedBy, IsActive)
                    VALUES (@MaTK, @MaNV, @TenDangNhap, @MatKhau, @Role, @CreatedAt, @CreatedBy, @IsActive)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", account.MaTK),
                    SqlParameterHelper.Create("@MaNV", account.MaNV),
                    SqlParameterHelper.Create("@TenDangNhap", account.TenDangNhap),
                    SqlParameterHelper.Create("@MatKhau", account.MatKhau),
                    SqlParameterHelper.Create("@Role", account.Role ?? "NhanVien"),
                    SqlParameterHelper.Create("@CreatedAt", account.CreatedAt),
                    SqlParameterHelper.Create("@CreatedBy", account.CreatedBy),
                    SqlParameterHelper.Create("@IsActive", account.IsActive)
                };

                int result = fastQuery.ExecuteNonQuery(query, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");

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
                string query = @"
                    UPDATE TaiKhoan
                    SET TenDangNhap = @TenDangNhap,
                        MatKhau = @MatKhau,
                        Role = @Role,
                        UpdatedAt = @UpdatedAt,
                        UpdatedBy = @UpdatedBy,
                        IsActive = @IsActive
                    WHERE MaTK = @MaTK";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", account.MaTK),
                    SqlParameterHelper.Create("@TenDangNhap", account.TenDangNhap),
                    SqlParameterHelper.Create("@MatKhau", account.MatKhau),
                    SqlParameterHelper.Create("@Role", account.Role ?? "NhanVien"),
                    SqlParameterHelper.Create("@UpdatedAt", account.UpdatedAt),
                    SqlParameterHelper.Create("@UpdatedBy", account.UpdatedBy),
                    SqlParameterHelper.Create("@IsActive", account.IsActive)
                };

                fastQuery.ExecuteNonQuery(query, parameters);
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
                string query = "UPDATE TaiKhoan SET IsActive = 0 WHERE MaTK = @MaTK";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaTK", maTK)
                };

                fastQuery.ExecuteNonQuery(query, parameters);
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


using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLResort.EmployeeDALQL
{
    public class EmployeeDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetEmployeesDAL(
            string maCN = null,
            string maLoaiNV = null,
            string gioiTinh = null,
            string cccd = null,
            string chucVu = null,
            bool? isActive = null,
            string maNV = null)
        {
            try
            {
                // Sử dụng SqlParameterHelper thay vì tạo thủ công
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@MaLoaiNV", maLoaiNV),
                    SqlParameterHelper.Create("@GioiTinh", gioiTinh),
                    SqlParameterHelper.Create("@ChucVu", chucVu),
                    SqlParameterHelper.Create("@IsActive", isActive),
                    SqlParameterHelper.Create("@CCCD", cccd),
                    SqlParameterHelper.Create("@MaNV", maNV)
                };

                // Sử dụng constant thay vì magic string
                DataTable dt = fastQuery.ExecuteProc(
                    StoredProcedures.Employee.GetNhanVien,
                    parameters);

                return OperationResult<DataTable>.Ok(dt);
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi database cụ thể
                return OperationResult<DataTable>.Fail(
                    $"Lỗi database khi lấy danh sách nhân viên: {ex.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail(
                    $"Lỗi không mong muốn khi lấy danh sách nhân viên: {ex.Message}");
            }
        }

        public OperationResult<DataTable> GetEmployeeTypesDAL()
        {
            try
            {
                DataTable dt = fastQuery.ExecuteProc("sp_GetAllLoaiNhanVienHD");
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail("Lỗi khi lấy danh sách loại nhân viên: " + ex.Message);
            }
        }

        public OperationResult<bool> Insert(EmployeeM nv)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaNV", nv.MaNV),
                    SqlParameterHelper.Create("@MaCN", nv.MaCN),
                    SqlParameterHelper.Create("@CCCD", nv.CCCD),
                    SqlParameterHelper.Create("@GioiTinh", nv.GioiTinh),
                    SqlParameterHelper.Create("@HoTen", nv.HoTen),
                    SqlParameterHelper.Create("@ChucVu", nv.ChucVu),
                    SqlParameterHelper.Create("@SDT", nv.SDT),
                    SqlParameterHelper.Create("@Email", nv.Email),
                    SqlParameterHelper.Create("@MaLoaiNV", nv.MaLoaiNV),
                    SqlParameterHelper.Create("@DuongDanAnh", nv.DuongDanAnh),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", nv.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(
                    StoredProcedures.Employee.InsertNhanVien,
                    parameters);

                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");

                return OperationResult<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                return OperationResult<bool>.Fail($"Lỗi database khi thêm nhân viên: {ex.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm nhân viên: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(EmployeeM nv, string updatedBy)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaNV", nv.MaNV),
                    SqlParameterHelper.Create("@MaCN", nv.MaCN),
                    SqlParameterHelper.Create("@CCCD", nv.CCCD),
                    SqlParameterHelper.Create("@GioiTinh", nv.GioiTinh),
                    SqlParameterHelper.Create("@HoTen", nv.HoTen),
                    SqlParameterHelper.Create("@ChucVu", nv.ChucVu),
                    SqlParameterHelper.Create("@SDT", nv.SDT),
                    SqlParameterHelper.Create("@Email", nv.Email),
                    SqlParameterHelper.Create("@MaLoaiNV", nv.MaLoaiNV),
                    SqlParameterHelper.Create("@DuongDanAnh", nv.DuongDanAnh),
                    SqlParameterHelper.Create("@UpdatedBy", updatedBy),
                    SqlParameterHelper.Create("@IsActive", nv.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(
                    StoredProcedures.Employee.UpdateNhanVien,
                    parameters);

                return OperationResult<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                return OperationResult<bool>.Fail($"Lỗi database khi cập nhật nhân viên: {ex.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật nhân viên: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maNV)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaNV", maNV)
                };

                fastQuery.ExecuteNonQueryProc(
                    StoredProcedures.Employee.DeleteNhanVien,
                    parameters);

                return OperationResult<bool>.Ok(true);
            }
            catch (SqlException ex)
            {
                return OperationResult<bool>.Fail($"Lỗi database khi xóa nhân viên: {ex.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa nhân viên: {ex.Message}");
            }
        }

        // ===========================================
        // VÍ DỤ: SỬ DỤNG TRANSACTION
        // ===========================================

        /// <summary>
        /// Ví dụ: Thêm nhân viên và tạo tài khoản trong một transaction
        /// </summary>
        public OperationResult<bool> InsertEmployeeWithAccount(
            EmployeeM nv,
            string tenDangNhap,
            string matKhau)
        {
            try
            {
                fastQuery.ExecuteTransaction(transaction =>
                {
                    // 1. Thêm nhân viên
                    SqlParameter[] empParams = new SqlParameter[]
                    {
                        SqlParameterHelper.Create("@MaNV", nv.MaNV),
                        SqlParameterHelper.Create("@MaCN", nv.MaCN),
                        // ... các parameters khác
                    };
                    fastQuery.ExecuteNonQueryProcInTransaction(
                        transaction,
                        StoredProcedures.Employee.InsertNhanVien,
                        empParams);

                    // 2. Tạo tài khoản
                    SqlParameter[] accParams = new SqlParameter[]
                    {
                        SqlParameterHelper.Create("@MaTK", "TK" + nv.MaNV),
                        SqlParameterHelper.Create("@MaNV", nv.MaNV),
                        SqlParameterHelper.Create("@TenDangNhap", tenDangNhap),
                        SqlParameterHelper.Create("@MatKhau", matKhau),
                    };
                    // Giả sử có stored procedure này
                    // fastQuery.ExecuteNonQueryProcInTransaction(
                    //     transaction, "sp_InsertTaiKhoan", accParams);
                });

                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail(
                    $"Lỗi khi thêm nhân viên và tài khoản: {ex.Message}");
            }
        }
    }
}





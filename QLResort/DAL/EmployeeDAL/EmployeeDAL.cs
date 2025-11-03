using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.DAL.EmployeeDAL
{
    public class EmployeeDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetEmployeesDAL(string maCN = null, string maLoaiNV = null, string gioiTinh = null, string cccd = null,string chucVu = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaCN", (object)maCN ?? DBNull.Value),
                    new SqlParameter("@MaLoaiNV", (object)maLoaiNV ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", (object)gioiTinh ?? DBNull.Value),
                    new SqlParameter("@ChucVu", (object)chucVu ?? DBNull.Value),
                    new SqlParameter("@IsActive", (object)isActive ?? DBNull.Value),
                    new SqlParameter("@CCCD", (object)cccd ?? DBNull.Value)
                };
                    
                DataTable dt = fastQuery.ExecuteProc("sp_GetNhanVien", p);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
        }

        public OperationResult<DataTable> GetEmployeeTypesDAL()
        {
            try
            {
                DataTable dt = fastQuery.ExecuteProc("sp_GetAllLoaiNhanVien_Key_Value");
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
                SqlParameter[] p =
                {
                    new SqlParameter("@MaNV", nv.MaNV),
                    new SqlParameter("@MaCN", nv.MaCN),
                    new SqlParameter("@CCCD", nv.CCCD),
                    new SqlParameter("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@HoTen", (object)nv.HoTen ?? DBNull.Value),
                    new SqlParameter("@ChucVu", (object)nv.ChucVu ?? DBNull.Value),
                    new SqlParameter("@SDT", (object)nv.SDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)nv.Email ?? DBNull.Value),
                    new SqlParameter("@MaLoaiNV", (object)nv.MaLoaiNV ?? DBNull.Value),
                    new SqlParameter("@CreatedBy", Session_Now.CurrentUser),
                    new SqlParameter("@IsActive", nv.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc("sp_InsertNhanVien", p);
                if (result <= 0) return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        public OperationResult<bool> Update(EmployeeM nv, string updatedBy)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaNV", nv.MaNV),
                    new SqlParameter("@MaCN", nv.MaCN),
                    new SqlParameter("@CCCD", nv.CCCD),
                    new SqlParameter("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@HoTen", (object)nv.HoTen ?? DBNull.Value),
                    new SqlParameter("@ChucVu", (object)nv.ChucVu ?? DBNull.Value),
                    new SqlParameter("@SDT", (object)nv.SDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)nv.Email ?? DBNull.Value),
                    new SqlParameter("@MaLoaiNV", (object)nv.MaLoaiNV ?? DBNull.Value),
                    new SqlParameter("@UpdatedBy", updatedBy),
                    new SqlParameter("@IsActive", nv.IsActive)
                };

                fastQuery.ExecuteNonQueryProc("sp_UpdateNhanVien", p);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
        }

        public OperationResult<bool> Delete(string maNV)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@MaNV", maNV) };
                fastQuery.ExecuteNonQueryProc("sp_DeleteNhanVien", p);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

    }

}

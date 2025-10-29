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
    internal class EmployeeTypeDAL
    {
        private FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetAllInData()
        {
            try
            {
                DataTable dt = fastQuery.ExecuteProc("sp_GetAllLoaiNhanVien");
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail("Lỗi khi lấy dữ liệu loại nhân viên: " + ex.Message);
            }
        }

        public OperationResult<DataTable> GetAllHD()
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

        public OperationResult<bool> Insert(EmployeeType e)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaLoaiNV", e.MaLoaiNV),
                    new SqlParameter("@TenLoaiNV", e.TenLoaiNV),
                    new SqlParameter("@MoTa", (object)e.MoTa ?? DBNull.Value),
                    new SqlParameter("@CreatedBy", e.CreatedBy),
                    new SqlParameter("@IsActive", e.IsActive)
                };
                fastQuery.ExecuteNonQueryProc("sp_InsertLoaiNhanVien", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi thêm loại nhân viên: " + ex.Message);
            }
        }

        public OperationResult<bool> Update(string ma, string ten, string moTa, bool isActive)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaLoaiNV", ma),
                    new SqlParameter("@TenLoaiNV", ten),
                    new SqlParameter("@MoTa", (object)moTa ?? DBNull.Value),
                    new SqlParameter("@UpdatedBy", Session_Now.CurrentUser),
                    new SqlParameter("@IsActive", isActive)
                };
                fastQuery.ExecuteNonQueryProc("sp_UpdateLoaiNhanVien", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi cập nhật loại nhân viên: " + ex.Message);
            }
        }

        public OperationResult<bool> Delete(string maLoaiNV)
        {
            try
            {
                SqlParameter p = new SqlParameter("@MaLoaiNV", maLoaiNV);
                fastQuery.ExecuteNonQueryProc("sp_DeleteLoaiNhanVien_Hard", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi xóa loại nhân viên: " + ex.Message);
            }
        }
    }
}


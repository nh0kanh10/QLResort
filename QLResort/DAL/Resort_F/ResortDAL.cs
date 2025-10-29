using QLResort.Core;
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

namespace QLResort.DAL.Resort_F
{
    public class ResortDAL
    {
        FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetResort(string maCN = null,string tenCN=null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[]
                {
                new SqlParameter("@MaCN",(object)maCN ?? DBNull.Value),
                new SqlParameter("@TenCN",(object)tenCN ?? DBNull.Value),
                new SqlParameter("@IsActive",(object)isActive ?? DBNull.Value)

                };

                DataTable d = fastQuery.ExecuteProc("sp_GetChiNhanh", p);
                return OperationResult<DataTable>.Ok(d);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail("Lỗi khi lấy danh sách Resort: " + ex);
            }

        }

        public OperationResult<bool> AddResort(ResortM resort)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[]
                {
                    new SqlParameter("@MaCN", (object)resort.MaCN ?? DBNull.Value),
                    new SqlParameter("@TenCN", (object)resort.TenCN ?? DBNull.Value),
                    new SqlParameter("@DiaChi", (object)resort.DiaChi ?? DBNull.Value),
                    new SqlParameter("@CreatedBy", (object)resort.CreatedBy ?? DBNull.Value),
                    new SqlParameter("@IsActive", (object)resort.IsActive ?? DBNull.Value ),
                    new SqlParameter("@MaQuanLy", (object)resort.MaNQL ?? DBNull.Value )
                };

                fastQuery.ExecuteNonQueryProc("sp_AddChiNhanh", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi thêm chi nhánh: " + ex.Message);
            }
        }

        public OperationResult<bool> UpdateResort(string maCN, string tenCN, string diaChi, string updateBy, bool isActive)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaCN",(object)maCN ?? DBNull.Value),
                    new SqlParameter("@TenCN",(object)tenCN ?? DBNull.Value),
                    new SqlParameter("@DiaChi",(object)diaChi ?? DBNull.Value),
                    new SqlParameter("UpdateBy",(object)updateBy ?? DBNull.Value),
                    new SqlParameter("IsActive",(object)isActive ?? DBNull.Value)
                };
                fastQuery.ExecuteProc("sp_UpdateChiNhanh", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi cập nhật chi nhánh: " + ex);
            }
        }

        public OperationResult<bool> DeleteResort(string maCN)
        {
            try
            {
                SqlParameter p = new SqlParameter("@MaCN", maCN);
                fastQuery.ExecuteNonQueryProc("sp_DeleteChiNhanh", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi xóa chi nhánh: " + ex.Message);
            }
        }
    }
}

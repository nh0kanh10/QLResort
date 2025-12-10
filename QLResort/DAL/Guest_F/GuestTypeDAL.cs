using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.DAL.Guest_F
{
    internal class GuestTypeDAL
    {
        FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetGuestTypes(string maLKH = null, bool? isActive = null)
        {
            string proc = "sp_GetLoaiKhachHang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLKH", (object)maLKH ?? DBNull.Value),
                new SqlParameter("@IsActive", (object)isActive ?? DBNull.Value)
            };
            DataTable result = fastQuery.ExecuteProc(proc, parameters);
            if (result != null)
            {
                return OperationResult<DataTable>.Ok(result);
            }
            else
            {
                return OperationResult<DataTable>.Fail("Thất bại khi lấy danh sách loại khách.");
            }
        }

        public OperationResult<DataTable> GetGuestTypesForKH()
        {
            string proc = "sp_GetLoaiKhachHangForKH";
            DataTable result = fastQuery.ExecuteProc(proc, null);
            if (result != null)
            {
                return OperationResult<DataTable>.Ok(result);
            }
            else
            {
                return OperationResult<DataTable>.Fail("Thất bại khi lấy danh sách loại khách cho khách hàng.");
            }
        }

        public OperationResult<bool> UpdateGuestType(GuestType guestType)
        {
            string proc = "sp_UpdateLoaiKhachHang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLKH", guestType.MaLKH),
                new SqlParameter("@TenLKH", guestType.TenLKH),
                new SqlParameter("@GiamGiaPercent", guestType.GiamGiaPercent),
                new SqlParameter("@DiemToiThieu", guestType.DiemToiThieu),
                new SqlParameter("@MoTa", guestType.MoTa),
                new SqlParameter("@UpdatedBy", guestType.UpdatedBy),
                new SqlParameter("@IsActive", guestType.IsActive),
            };
            if (fastQuery.ExecuteNonQueryProc(proc, parameters) > 0)
            {
                return OperationResult<bool>.Ok(true);
            }
            else
            {
                return OperationResult<bool>.Fail("Thất bại khi cập nhật loại khách.");
            }
        }

        public OperationResult<bool> DeleteGuestType(string maLKH)
        {
            string proc = "sp_DeleteLoaiKhachHang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLKH", maLKH),
            };
            if (fastQuery.ExecuteNonQueryProc(proc, parameters) > 0)
            {
                return OperationResult<bool>.Ok(true);
            }
            else
            {
                return OperationResult<bool>.Fail("Thất bại khi xóa loại khách.");
            }
        }

        public OperationResult<bool> AddGuestType(GuestType guestType)
        {
            string proc = "sp_InsertLoaiKhachHang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLKH", guestType.MaLKH),
                new SqlParameter("@TenLKH", guestType.TenLKH),
                new SqlParameter("@GiamGiaPercent", guestType.GiamGiaPercent),
                new SqlParameter("@DiemToiThieu", guestType.DiemToiThieu),
                new SqlParameter("@MoTa", guestType.MoTa),
                new SqlParameter("@CreatedBy", guestType.CreatedBy),
                new SqlParameter("@IsActive", guestType.IsActive),
            };
            if (fastQuery.ExecuteNonQueryProc(proc, parameters) > 0)
            {
                return OperationResult<bool>.Ok(true);
            }
            else
            {
                return OperationResult<bool>.Fail("Thất bại khi thêm loại khách.");
            }
        }

    }
}

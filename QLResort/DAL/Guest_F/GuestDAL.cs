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

namespace QLResort.DAL.Guest_F
{
    internal class GuestDAL
    {
        FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetGuest(string maKH = null, string tenKH = null, string gioiTinh = null, string sdt = null, string id = null, string maLoaiKH = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaKH", (object)maKH ?? DBNull.Value),
                    new SqlParameter("@TenKH", (object)tenKH ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", (object)gioiTinh ?? DBNull.Value),
                    new SqlParameter("@SDT", (object)sdt ?? DBNull.Value),
                    new SqlParameter("@ID", (object)id ?? DBNull.Value),
                    new SqlParameter("@MaLoaiKH", (object)maLoaiKH ?? DBNull.Value),
                    new SqlParameter("@IsActive", (object)isActive ?? DBNull.Value)
                };
                DataTable dt = fastQuery.ExecuteProc("sp_GetKhachHang", p);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail("Lỗi khi lấy danh sách khách hàng: " + ex);
            }
        }

        public OperationResult<bool> AddGuest(Guest guest)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaKH", (object)guest.MaKH ?? DBNull.Value),
                    new SqlParameter("@HoTen", (object)guest.HoTen ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", (object)guest.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@NgaySinh", (object)guest.NgaySinh ?? DBNull.Value),
                    new SqlParameter("@SDT", (object)guest.SDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)guest.Email ?? DBNull.Value),
                    new SqlParameter("@IDType", (object)guest.IDType ?? (object)"CCCD"),
                    new SqlParameter("@IDNumber", (object)guest.IDNumber ?? DBNull.Value),
                    new SqlParameter("@DiaChi", (object)guest.DiaChi ?? DBNull.Value),
                    new SqlParameter("@MaLKH", (object)guest.MaLKH ?? DBNull.Value),
                    new SqlParameter("@CreateBy", (object)guest.UpdatedBy ?? DBNull.Value)
                };

                fastQuery.ExecuteNonQueryProc("sp_AddKhachHang", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi thêm khách hàng: " + ex.Message);
            }
        }
        public bool FindGuestByMaKH(string maKH)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@MaKH", (object)maKH ?? DBNull.Value)
                };
                DataTable dt = fastQuery.ExecuteProc("sp_GetKhachHang", p);
                return dt.Rows.Count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OperationResult<bool> UpdateGuest(Guest guest)
        {
            try
            {
                if(!FindGuestByMaKH(guest.MaKH)) return OperationResult<bool>.Fail("Mã khách hàng không tồn tại: " + guest.MaKH);
                SqlParameter[] p =
                {
                    new SqlParameter("@MaKH", (object)guest.MaKH ?? DBNull.Value),
                    new SqlParameter("@HoTen", (object)guest.HoTen ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", (object)guest.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@NgaySinh", (object)guest.NgaySinh ?? DBNull.Value),
                    new SqlParameter("@SDT", (object)guest.SDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)guest.Email ?? DBNull.Value),
                    new SqlParameter("@IDType", (object)guest.IDType ?? (object)"CCCD"),
                    new SqlParameter("@IDNumber", (object)guest.IDNumber ?? DBNull.Value),
                    new SqlParameter("@DiaChi", (object)guest.DiaChi ?? DBNull.Value),
                    new SqlParameter("@MaLKH", (object)guest.MaLKH ?? DBNull.Value),
                    new SqlParameter("@IsActive", (object)guest.IsActive ?? DBNull.Value),
                    new SqlParameter("@UpdatedBy", (object)guest.UpdatedBy ?? DBNull.Value)
                };
                fastQuery.ExecuteNonQueryProc("sp_UpdateKhachHang", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
        }
        public OperationResult<bool> DeleteGuest(string maKH)
        {
            try
            {
                if (!FindGuestByMaKH(maKH)) return OperationResult<bool>.Fail("Mã khách hàng không tồn tại: " + maKH);
                SqlParameter[] p =
                {
                    new SqlParameter("@MaKH", (object)maKH ?? DBNull.Value)
                };
                fastQuery.ExecuteNonQueryProc("sp_DeleteKhachHang", p);
                return OperationResult<bool>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }

    }

}

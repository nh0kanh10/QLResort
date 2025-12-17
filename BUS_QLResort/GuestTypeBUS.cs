using Tool_QLResort.Extensions;
using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using DAL_QLResort.Guest_F;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLResort
{
    public class GuestTypeBUS
    {
        FastQuery fastQuery = new FastQuery();
        GuestTypeDAL guestTypeDAL = new GuestTypeDAL();
        
        public OperationResult<DataTable> GetGuestTypeForGuest()
        {
            OperationResult<DataTable> dataTable = guestTypeDAL.GetGuestTypesForKH();
            if(dataTable.Success)
            {
                return OperationResult<DataTable>.Ok(dataTable.Data);
            }
            else
            {
                return OperationResult<DataTable>.Fail(dataTable.ErrorMessage);
            }
        }

        public OperationResult<List<GuestType>> GetGuestTypes(string maLKH = null, bool? isActive = null)
        {
            var dalResult = guestTypeDAL.GetGuestTypes(maLKH, isActive);
            if (!dalResult.Success)
                return OperationResult<List<GuestType>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<GuestType> list = new List<GuestType>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapGuestType(row));
                }
                return OperationResult<List<GuestType>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<GuestType>>.Fail($"Lỗi khi xử lý dữ liệu loại khách hàng: {ex.Message}");
            }
        }

        private GuestType MapGuestType(DataRow row)
        {
            return new GuestType()
            {
                MaLKH = row["MaLKH"]?.ToString(),
                TenLKH = row["TenLKH"]?.ToString(),
                GiamGiaPercent = row["GiamGiaPercent"] == DBNull.Value ? 0 : Convert.ToDecimal(row["GiamGiaPercent"]),
                DiemToiThieu = row["DiemToiThieu"] == DBNull.Value ? 0 : Convert.ToInt32(row["DiemToiThieu"]),
                MoTa = row["MoTa"]?.ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]),
                UpdatedBy = row["UpdatedBy"] == DBNull.Value ? null : row["UpdatedBy"]?.ToString()
            };
        }
        public OperationResult<bool> AddGuestType(string maLKH, string tenLKH, decimal giamGiaPercent, int diemToiThieu, string moTa, bool isActive)
        {
            try
            {
                var guestType = new GuestType
                {
                    MaLKH = maLKH,
                    TenLKH = tenLKH,
                    GiamGiaPercent = giamGiaPercent,
                    DiemToiThieu = diemToiThieu,
                    MoTa = moTa,
                    IsActive = isActive,
                    CreatedBy = Session_Now.CurrentUser
                };
                return guestTypeDAL.AddGuestType(guestType);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm loại khách hàng: {ex.Message}");
            }
        }

        public OperationResult<bool> UpdateGuestType(string maLKH, string tenLKH, decimal giamGiaPercent, int diemToiThieu, string moTa, bool isActive)
        {
            try
            {
                var guestType = new GuestType
                {
                    MaLKH = maLKH,
                    TenLKH = tenLKH,
                    GiamGiaPercent = giamGiaPercent,
                    DiemToiThieu = diemToiThieu,
                    MoTa = moTa,
                    IsActive = isActive,
                    UpdatedBy = Session_Now.CurrentUser
                };
                return guestTypeDAL.UpdateGuestType(guestType);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật loại khách hàng: {ex.Message}");
            }
        }

        public OperationResult<bool> DeleteGuestType(string maLKH)
        {
            try
            {
                return guestTypeDAL.DeleteGuestType(maLKH);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa loại khách hàng: {ex.Message}");
            }
        }
    }
}






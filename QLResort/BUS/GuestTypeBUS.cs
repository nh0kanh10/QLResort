using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Guest_F;
using QLResort.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.BUS
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
                GuestTypeMapper mapper = new GuestTypeMapper();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(mapper.Map(row));
                }
                return OperationResult<List<GuestType>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<GuestType>>.Fail($"Lỗi khi xử lý dữ liệu loại khách hàng: {ex.Message}");
            }
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

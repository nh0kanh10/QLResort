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

namespace QLResort.BLL
{
    public class GuestTypeBLL
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
    }
}

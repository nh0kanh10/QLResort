using QLResort.Core.Mappers;
using QLResort.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLResort.Mappers
{
    internal class GuestTypeMapper: IMapper<DataRow, GuestType>
    {
        public GuestType Map(DataRow row)
        {
            GuestType guestType = new GuestType();
            guestType.MaLKH = row["MaLKH"]?.ToString();
            guestType.TenLKH = row["TenLKH"]?.ToString();
            guestType.GiamGiaPercent = Convert.ToDecimal(row["GiamGiaPercent"]);
            guestType.DiemToiThieu = Convert.ToInt32(row["DiemToiThieu"]);
            guestType.MoTa = row["MoTa"]?.ToString();
            guestType.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
            guestType.CreatedBy = row["CreatedBy"]?.ToString();
            guestType.UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]);
            guestType.UpdatedBy = row["UpdatedBy"] == DBNull.Value ? null : row["UpdatedBy"]?.ToString();
            guestType.IsActive = Convert.ToBoolean(row["IsActive"]);
            return guestType;
        }

    }
}

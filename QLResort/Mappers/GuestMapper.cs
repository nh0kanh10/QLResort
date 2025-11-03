using QLResort.Core.Mappers;
using QLResort.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Mappers
{
    internal class GuestMapper:IMapper<DataRow,Guest> 
    {
       public Guest Map(DataRow row)
       {
            Guest guest = new Guest();
            guest.MaKH = row["MaKH"]?.ToString();
            guest.HoTen = row["HoTen"]?.ToString();
            guest.GioiTinh = row["GioiTinh"]?.ToString();
            guest.NgaySinh = Convert.ToDateTime(row["NgaySinh"]);
            guest.SDT = row["SDT"]?.ToString();
            guest.Email = row["Email"]?.ToString();
            guest.IDType = row["IDType"]?.ToString();
            guest.IDNumber = row["IDNumber"]?.ToString();
            guest.DiaChi = row["DiaChi"]?.ToString();
            guest.MaLKH = row["MaLKH"]?.ToString();
            guest.IsActive = Convert.ToBoolean(row["IsActive"]);
            guest.CreatedBy = row["CreatedBy"]?.ToString();
            guest.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
            guest.UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]);
            guest.UpdatedBy = row["UpdatedBy"] == DBNull.Value ? null : row["UpdatedBy"]?.ToString();
            return guest;
       }
    }
}

using QLResort.Core.Mappers;
using QLResort.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Mappers
{
    internal class EmployeeTypeMapper:IMapper<DataRow,EmployeeType>
    {
        public EmployeeType Map(DataRow row)
        {
            EmployeeType emp = new EmployeeType();
            emp.MaLoaiNV = row["MaLoaiNV"].ToString();
            emp.TenLoaiNV = row["TenLoaiNV"].ToString();
            emp.MoTa = row["MoTa"]?.ToString();
            emp.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
            emp.CreatedBy = row["CreatedBy"]?.ToString();
            emp.IsActive = Convert.ToBoolean(row["IsActive"]);
            emp.UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]);
            emp.UpdatedBy = row["UpdatedBy"] == DBNull.Value ? null : row["UpdatedBy"]?.ToString();
            return emp;
        }
    }
}

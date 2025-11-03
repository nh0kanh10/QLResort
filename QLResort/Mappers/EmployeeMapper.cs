using QLResort.Core.Mappers;
using QLResort.Core.Model;
using QLResort.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Mappers
{
    internal class EmployeeMapper:IMapper<DataRow,EmployeeM> 
    {
        public EmployeeM Map(DataRow row)
        {
            EmployeeM emp = new EmployeeM();
            emp.MaNV = row["MaNV"].ToString();
            emp.MaCN = row["MaCN"].ToString();
            emp.TenCN = row["TenCN"].ToString();
            emp.CCCD = row["CCCD"].ToString();
            emp.GioiTinh = row["GioiTinh"].ToString();
            emp.HoTen = row["HoTen"].ToString();
            emp.ChucVu = row["ChucVu"].ToString();
            emp.SDT = row["SDT"].ToString();
            emp.Email = row["Email"].ToString();
            emp.MaLoaiNV = row["MaLoaiNV"].ToString();
            emp.TenLoaiNV = row["TenLoaiNV"].ToString();
            emp.IsActive = Convert.ToBoolean(row["IsActive"]);
            emp.CreatedBy = row["CreatedBy"].ToString();
            emp.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
            emp.UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]);
            emp.UpdatedBy = row["UpdatedBy"] == DBNull.Value ? null : row["UpdatedBy"]?.ToString();
            return emp;
        }
    }
}

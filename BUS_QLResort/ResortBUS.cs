
using Tool_QLResort.ClassHoTro;
using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using DAL_QLResort.Resort_F;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLResort
{
    public class ResortBUS
    {
        private ResortDAL rDAL = new ResortDAL();

        public OperationResult<List<Resort>> GetResorts(string maCN = null,string tenCN = null, bool? isActive = null)
        {
            var dalResult = rDAL.GetResort(maCN, tenCN,isActive);

            if (!dalResult.Success)
                return OperationResult<List<Resort>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Resort> list = new List<Resort>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapResort(row));
                }
                return OperationResult<List<Resort>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Resort>>.Fail("Lỗi khi xử lý dữ liệu chi nhánh: " + ex.Message);
            }
        }

        public OperationResult<Resort> AddResort(string tenCN, string diaChi,bool isActive = true,string maNQL = null)
        {          
            var resultDuplicate = GetResorts(tenCN: tenCN);
            if (resultDuplicate.Success && resultDuplicate.Data.Count > 0)
                return OperationResult<Resort>.Fail("Trùng tên chi nhánh: " + tenCN);
            Resort resort = new Resort(tenCN,diaChi,Session_Now.CurrentUser, isActive, maNQL);          
                      
            var dalResult = rDAL.AddResort(resort);
            if (!dalResult.Success)
                return OperationResult<Resort>.Fail(dalResult.ErrorMessage);

            return OperationResult<Resort>.Ok(resort);
        }

        public OperationResult<Resort> UpdateResort(string maCN, string tenCN, string diaChi, bool isActive,string nQL)
        {
            Resort resort = new Resort
            {
                MaCN = maCN,
                TenCN = tenCN,
                DiaChi = diaChi,
                UpdatedBy = Session_Now.CurrentUser,
                IsActive = isActive,
                MaNQL = nQL
            };

            var dalResult = rDAL.UpdateResort(resort);
            if (!dalResult.Success)
                return OperationResult<Resort>.Fail(dalResult.ErrorMessage);

            return OperationResult<Resort>.Ok(resort);
        }

        public OperationResult<bool> DeleteResort(string maCN)
        {
          

            var dalResult = rDAL.DeleteResort(maCN);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok();
        }
        private Resort MapResort(DataRow row)
        {
            Resort resort = new Resort();
            resort.MaCN = row["MaCN"].ToString();
            resort.TenCN = row["TenCN"].ToString();
            resort.DiaChi = row["DiaChi"].ToString();
            resort.IsActive = Convert.ToBoolean(row["IsActive"]);
            resort.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
            resort.CreatedBy = row["CreatedBy"].ToString();
            resort.MaNQL = row["MaQuanLy"].ToString();  
            return resort;
        }

        public OperationResult<Dictionary<string, string>> GetDataEmployee()
        {
            try
            {
                EmployeeBUS empBUS = new EmployeeBUS();
                var result = empBUS.GetEmployeesBUS(isActive:true);

                if (!result.Success)
                    return OperationResult<Dictionary<string, string>>.Fail(result.ErrorMessage);

                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var emp in result.Data)
                {
                    if (!dict.ContainsKey(emp.MaNV))
                        dict.Add(emp.MaNV, emp.HoTen);
                }

                return OperationResult<Dictionary<string, string>>.Ok(dict);
            }
            catch (Exception ex)
            {
                return OperationResult<Dictionary<string, string>>.Fail("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
        }


    }
}
    







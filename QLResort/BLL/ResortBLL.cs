using QLResort.Core;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.Resort_F;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.BLL
{
    internal class ResortBLL
    {
        private ResortDAL rDAL = new ResortDAL();

        public OperationResult<List<ResortM>> GetResorts(string maCN = null,string tenCN = null, bool? isActive = null)
        {
            var dalResult = rDAL.GetResort(maCN, tenCN,isActive);

            if (!dalResult.Success)
                return OperationResult<List<ResortM>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<ResortM> list = new List<ResortM>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapResort(row));
                }
                return OperationResult<List<ResortM>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ResortM>>.Fail("Lỗi khi xử lý dữ liệu chi nhánh: " + ex.Message);
            }
        }

        public OperationResult<ResortM> AddResort(string tenCN, string diaChi,bool isActive = true,string maNQL = null)
        {          
            var resultDuplicate = GetResorts(tenCN: tenCN);
            if (resultDuplicate.Success && resultDuplicate.Data.Count > 0)
                return OperationResult<ResortM>.Fail("Trùng tên chi nhánh: " + tenCN);
            ResortM resort = new ResortM(tenCN,diaChi,Session_Now.CurrentUser, isActive, maNQL);          
                      
            var dalResult = rDAL.AddResort(resort);
            if (!dalResult.Success)
                return OperationResult<ResortM>.Fail(dalResult.ErrorMessage);

            return OperationResult<ResortM>.Ok(resort);
        }

        public OperationResult<ResortM> UpdateResort(string maCN, string tenCN, string diaChi, bool isActive)
        {
            if (!Validator.IsRequired(maCN))
                return OperationResult<ResortM>.Fail("Mã chi nhánh không hợp lệ");


            var resultDuplicate = GetResorts(maCN);
            if (resultDuplicate.Success && resultDuplicate.Data.Count > 0)
                return OperationResult<ResortM>.Fail("Chi nhánh đã tồn tại với mã: " + maCN);

            ResortM resort = new ResortM
            {
                MaCN = maCN,
                TenCN = tenCN,
                DiaChi = diaChi,
                UpdatedBy = Session_Now.CurrentUser,
                IsActive = isActive
            };

            var dalResult = rDAL.UpdateResort(maCN, tenCN, diaChi, Session_Now.CurrentUser, isActive);
            if (!dalResult.Success)
                return OperationResult<ResortM>.Fail(dalResult.ErrorMessage);

            return OperationResult<ResortM>.Ok(resort);
        }

        public OperationResult<bool> DeleteResort(string maCN)
        {
          

            var dalResult = rDAL.DeleteResort(maCN);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok();
        }
        // map nay chỉ đúng khi dữ liệu được đảm bảo //
        private ResortM MapResort(DataRow row)
        {
            //resort.CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.MinValue;
            //resort.CreatedBy = row["CreatedBy"] != DBNull.Value ? row["CreatedBy"].ToString() : "";
            ResortM resort = new ResortM();
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
                EmployeeBLL empBLL = new EmployeeBLL();
                var result = empBLL.GetEmployeesBLL(isActive:true);

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
    


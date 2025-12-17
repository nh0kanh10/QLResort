using Tool_QLResort.ClassHoTro;
using ET_QLResort;
using DAL_QLResort.EmployeeDALQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS_QLResort
{
    public class EmployeeTypeBUS
    {
        private EmployeeTypeDAL dal = new EmployeeTypeDAL();
        public OperationResult<List<EmployeeType>> GetAllInBUS()
        {
            try
            {
                EmployeeTypeDAL eTD = new EmployeeTypeDAL();
                var dtResult = eTD.GetAllHD();
                if (!dtResult.Success)
                    return OperationResult<List<EmployeeType>>.Fail(dtResult.ErrorMessage);

                List<EmployeeType> list = new List<EmployeeType>();
                foreach (DataRow row in dtResult.Data.Rows)
                {
                    list.Add(MapEmployeeType(row));
                }

                return OperationResult<List<EmployeeType>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<EmployeeType>>.Fail("Lỗi khi lấy danh sách loại nhân viên: " + ex.Message);
            }
        }

        private EmployeeType MapEmployeeType(DataRow row)
        {
            return new EmployeeType()
            {
                MaLoaiNV = row["MaLoaiNV"].ToString(),
                TenLoaiNV = row["TenLoaiNV"].ToString(),
                MoTa = row["MoTa"]?.ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]),
                UpdatedBy = row["UpdatedBy"] == DBNull.Value ? null : row["UpdatedBy"]?.ToString()
            };
        }
        

        //public OperationResult<List<EmployeeType>> GetAllHD()
        //{
        //    OperationResult<DataTable> dtResult = dal.GetAllHD();
        //    if (!dtResult.Success)
        //        return OperationResult<List<EmployeeType>>.Fail(dtResult.ErrorMessage);
        //    try
        //    {
        //        List<EmployeeType> list = new List<EmployeeType>();

        //        foreach (DataRow row in dtResult.Data.Rows)
        //        {
        //            list.Add(MapEmployeeType(row));
        //        }
        //        return OperationResult<List<EmployeeType>>.Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return OperationResult<List<EmployeeType>>.Fail("Lỗi khi lấy danh sách loại nhân viên đang hoạt động: " + ex.Message);
        //    }

        //}

        public OperationResult<EmployeeType> Add(string ten, string moTa, bool isActive)
        {
            if (!Validator.IsRequired(ten))
                return OperationResult<EmployeeType>.Fail("Tên loại nhân viên không được để trống");

            EmployeeType e = new EmployeeType(ten.Trim(), moTa?.Trim(), isActive);

            OperationResult<List<EmployeeType>> listResult = GetAllInBUS();
            if (!listResult.Success)
                return OperationResult<EmployeeType>.Fail("Lỗi khi lấy danh sách loại nhân viên: " + listResult.ErrorMessage);

            if(IsDuplicateName(listResult.Data, e.TenLoaiNV)) return OperationResult<EmployeeType>.Fail("Trùng tên loại nhân viên");       

            try
            {
                dal.Insert(e);
                return OperationResult<EmployeeType>.Ok(e);
            }
            catch (Exception ex)
            {
                return OperationResult<EmployeeType>.Fail("Lỗi khi thêm loại nhân viên: " + ex.Message);
            }
        }

        public bool IsDuplicateName(List<EmployeeType> list,string ten)
        {
            foreach (EmployeeType item in list)
            {
                if (Validator.IsEqualString(item.TenLoaiNV, ten))
                    return true;
            }
            return false;
        }


        public OperationResult<EmployeeType> Update(string ma, string ten, string moTa, bool isActive)
        {
            try
            {
                OperationResult<List<EmployeeType>> list = GetAllInBUS();
                if (!list.Success)
                {
                    return OperationResult<EmployeeType>.Fail(list.ErrorMessage);
                }
                dal.Update(ma, ten.Trim(), moTa?.Trim(), isActive);
                return OperationResult<EmployeeType>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<EmployeeType>.Fail("Lỗi khi cập nhật loại nhân viên: " + ex.Message);
            }
        }

        public OperationResult<EmployeeType> Delete(string ma)
        {
            try
            {
                dal.Delete(ma);
                return OperationResult<EmployeeType>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<EmployeeType>.Fail("Lỗi khi xóa loại nhân viên: " + ex.Message);
            }
        }

    }
}






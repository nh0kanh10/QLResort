using QLResort.Core.ClassHoTro;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.EmployeeDAL;
using QLResort.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.BLL
{
    public class EmployeeTypeBLL
    {
        private EmployeeTypeDAL dal = new EmployeeTypeDAL();
        public OperationResult<List<EmployeeType>> GetAllInBLL()
        {
            try
            {
                EmployeeTypeDAL eTD = new EmployeeTypeDAL();
                var dtResult = eTD.GetAllHD();
                if (!dtResult.Success)
                    return OperationResult<List<EmployeeType>>.Fail(dtResult.ErrorMessage);

                List<EmployeeType> list = new List<EmployeeType>();
                EmployeeTypeMapper eTM = new EmployeeTypeMapper();
                foreach (DataRow row in dtResult.Data.Rows)
                {
                    list.Add(eTM.Map(row));
                }

                return OperationResult<List<EmployeeType>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<EmployeeType>>.Fail("Lỗi khi lấy danh sách loại nhân viên: " + ex.Message);
            }
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

            OperationResult<List<EmployeeType>> listResult = GetAllInBLL();
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
                OperationResult<List<EmployeeType>> list = GetAllInBLL();
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

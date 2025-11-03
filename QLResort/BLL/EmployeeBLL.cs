using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.EmployeeDAL;
using QLResort.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.BLL
{
    internal class EmployeeBLL
    {
        EmployeeDAL EDAL = new EmployeeDAL();

        public OperationResult<List<EmployeeM>> GetEmployeesBLL(string maCN = null, string maLoaiNV = null, string gioiTinh = null,string cccd = null, string chucVu = null, bool? isActive = null)
        {
            var dalResult = EDAL.GetEmployeesDAL(maCN, maLoaiNV, gioiTinh,cccd, chucVu, isActive);

            if (!dalResult.Success)
                return OperationResult<List<EmployeeM>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<EmployeeM> list = new List<EmployeeM>();
                EmployeeMapper em = new EmployeeMapper();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(em.Map(row));
                }
                return OperationResult<List<EmployeeM>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<EmployeeM>>.Fail("Lỗi khi xử lý dữ liệu nhân viên: " + ex.Message);
            }
        }

        public OperationResult<Dictionary<string, string>> GetDataLoaiNVBLL()
        {
            var dalResult = EDAL.GetEmployeeTypesDAL();

            if (!dalResult.Success)
                return OperationResult<Dictionary<string, string>>.Fail(dalResult.ErrorMessage);

            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    string ma = row["MaLoaiNV"].ToString();
                    string ten = row["TenLoaiNV"].ToString();
                    if (!dict.ContainsKey(ma)) dict.Add(ma, ten);
                }
                return OperationResult<Dictionary<string, string>>.Ok(dict);
            }
            catch (Exception ex)
            {
                return OperationResult<Dictionary<string, string>>.Fail("Lỗi khi xử lý dữ liệu loại nhân viên: " + ex.Message);
            }
        }

        public OperationResult<EmployeeM> AddEmployee(string cccd, string hoTen, string gioiTinh, string chucVu, string sdt, string email, string maLoaiNV, bool isActive)
        {
            var listNV = EDAL.GetEmployeesDAL(cccd:cccd);
            if (!listNV.Success) return OperationResult<EmployeeM>.Fail(listNV.ErrorMessage);
            if (listNV.Data.Rows.Count > 0) return OperationResult<EmployeeM>.Fail("Số CMND đã tồn tại trong hệ thống: " + cccd);
            EmployeeM nv = new EmployeeM(cccd, gioiTinh, hoTen, chucVu, sdt, email, maLoaiNV, isActive);

            try
            {   
                var insertResult = EDAL.Insert(nv);
                if (!insertResult.Success)
                    return OperationResult<EmployeeM>.Fail(insertResult.ErrorMessage);

                return OperationResult<EmployeeM>.Ok(nv);
            }
            catch (Exception ex)
            {
                return OperationResult<EmployeeM>.Fail("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        public OperationResult<EmployeeM> UpdateEmployee(string maNV, string maCN, string cccd, string hoTen, string gioiTinh,
            string chucVu, string sdt, string email, string maLoaiNV, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return OperationResult<EmployeeM>.Fail("Mã nhân viên không hợp lệ.");

            EmployeeM nv = new EmployeeM()
            {
                MaNV = maNV,
                MaCN = maCN,
                CCCD = cccd,
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                ChucVu = chucVu,
                SDT = sdt,
                Email = email,
                MaLoaiNV = maLoaiNV,
                IsActive = isActive
            };

            try
            {
                var dalResult = EDAL.Update(nv, Session_Now.CurrentUser);
                if (!dalResult.Success)
                    return OperationResult<EmployeeM>.Fail(dalResult.ErrorMessage);

                return OperationResult<EmployeeM>.Ok(nv);
            }
            catch (Exception ex)
            {
                return OperationResult<EmployeeM>.Fail("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
        }


        public OperationResult<string> DeleteEmployee(string maNV)
        {
            try
            {
                EDAL.Delete(maNV);
                return OperationResult<string>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<string>.Fail("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

    }
}

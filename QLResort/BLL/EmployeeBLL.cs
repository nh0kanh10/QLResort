using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.EmployeeDAL;
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

        public OperationResult<List<EmployeeM>> GetEmployeesBLL(string maCN = null, string maLoaiNV = null, string gioiTinh = null, string chucVu = null, bool? isActive = null)
        {
            var dalResult = EDAL.GetEmployeesDAL(maCN, maLoaiNV, gioiTinh, chucVu, isActive);

            if (!dalResult.Success)
                return OperationResult<List<EmployeeM>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<EmployeeM> list = new List<EmployeeM>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapEmployee(row));
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

        private EmployeeM MapEmployee(DataRow row)
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
            return emp;
        }

        public OperationResult<EmployeeM> AddEmployee(string cccd, string hoTen, string gioiTinh, string chucVu, string sdt, string email, string maLoaiNV, bool isActive)
        {
            EmployeeM nv = new EmployeeM(cccd, gioiTinh, hoTen, chucVu, sdt, email, maLoaiNV, isActive);


            OperationResult<List<EmployeeM>> listNV = GetEmployeesBLL(Session_Now.CurrentResort);
            if (!listNV.Success) return OperationResult<EmployeeM>.Fail(listNV.ErrorMessage);

            foreach (var item in listNV.Data)
            {
                if (item.CCCD == cccd.Trim())
                    return OperationResult<EmployeeM>.Fail("CCCD đã tồn tại trong hệ thống");
            }
            try
            {
                EDAL.Insert(nv);
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

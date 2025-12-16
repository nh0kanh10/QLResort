using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.EmployeeDALQL;
using QLResort.Mappers;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BUS
{
    internal class EmployeeBUS
    {
        private readonly EmployeeDAL employeeDAL = new EmployeeDAL();

        public OperationResult<List<EmployeeM>> GetEmployeesBUS(string maCN = null, string maNV = null, string maLoaiNV = null, 
            string gioiTinh = null, string cccd = null, string chucVu = null, bool? isActive = null)
        {
            var dalResult = employeeDAL.GetEmployeesDAL(maCN, maLoaiNV, gioiTinh, cccd, chucVu, isActive, maNV);

            if (!dalResult.Success)
                return OperationResult<List<EmployeeM>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<EmployeeM> list = new List<EmployeeM>();
                EmployeeMapper mapper = new EmployeeMapper();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(mapper.Map(row));
                }
                return OperationResult<List<EmployeeM>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<EmployeeM>>.Fail("Lỗi khi xử lý dữ liệu nhân viên: " + ex.Message);
            }
        }

        public OperationResult<Dictionary<string, string>> GetDataLoaiNVBUS()
        {
            var dalResult = employeeDAL.GetEmployeeTypesDAL();

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

        public OperationResult<EmployeeM> AddEmployee(string cccd, string hoTen, string gioiTinh, string chucVu, 
            string sdt, string email, string maLoaiNV, bool isActive, string duongDanAnh = null)
        {
            var listNV = employeeDAL.GetEmployeesDAL(cccd: cccd);
            if (!listNV.Success) return OperationResult<EmployeeM>.Fail(listNV.ErrorMessage);
            if (listNV.Data.Rows.Count > 0) return OperationResult<EmployeeM>.Fail("Số CMND đã tồn tại trong hệ thống: " + cccd);
            
            EmployeeM nv = new EmployeeM(cccd, gioiTinh, hoTen, chucVu, sdt, email, maLoaiNV, isActive);
            nv.DuongDanAnh = duongDanAnh;

            try
            {   
                var insertResult = employeeDAL.Insert(nv);
                if (!insertResult.Success)
                    return OperationResult<EmployeeM>.Fail(insertResult.ErrorMessage);

                if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(sdt))
                {
                    try
                    {
                        AccountBUS accountBUS = new AccountBUS();
                        accountBUS.AddAccount(nv.MaNV, email, sdt);
                    }
                    catch { }
                }

                return OperationResult<EmployeeM>.Ok(nv);
            }
            catch (Exception ex)
            {
                return OperationResult<EmployeeM>.Fail("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        public OperationResult<EmployeeM> UpdateEmployee(string maNV, string maCN, string cccd, string hoTen, string gioiTinh,
            string chucVu, string sdt, string email, string maLoaiNV, bool isActive, string duongDanAnh = null)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return OperationResult<EmployeeM>.Fail("Mã nhân viên không hợp lệ.");

            EmployeeM nv = new EmployeeM()
            {
                MaNV = maNV,MaCN = maCN,CCCD = cccd,HoTen = hoTen,
                GioiTinh = gioiTinh,ChucVu = chucVu,SDT = sdt,Email = email,
                MaLoaiNV = maLoaiNV,DuongDanAnh = duongDanAnh,IsActive = isActive
            };

            try
            {
                var dalResult = employeeDAL.Update(nv, Session_Now.CurrentUser);
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
                employeeDAL.Delete(maNV);
                return OperationResult<string>.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult<string>.Fail("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }
    }
}

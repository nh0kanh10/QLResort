using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.AccountDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BUS
{
    public class AccountBUS
    {
        private readonly AccountDAL accountDAL = new AccountDAL();


        public OperationResult<List<Account>> GetAccounts(string maTK = null, string maNV = null, string tenDangNhap = null, bool? isActive = null)
        {
            var dalResult = accountDAL.GetAccounts(maTK, maNV, tenDangNhap, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Account>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Account> list = new List<Account>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapAccount(row));
                }
                return OperationResult<List<Account>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Account>>.Fail($"Lỗi khi xử lý dữ liệu tài khoản: {ex.Message}");
            }
        }

        public OperationResult<bool> AddAccount(string maNV, string tenDangNhap, string matKhau, string role = "NhanVien")
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return OperationResult<bool>.Fail("Mã nhân viên không được để trống");

            if (string.IsNullOrWhiteSpace(tenDangNhap))
                return OperationResult<bool>.Fail("Tên đăng nhập không được để trống");

            if (accountDAL.Exists(maNV))
                return OperationResult<bool>.Fail("Nhân viên này đã có tài khoản");

            // Validate role
            if (role != "NhanVien" && role != "QuanLy" && role != "Admin")
                return OperationResult<bool>.Fail("Role không hợp lệ. Chỉ chấp nhận: NhanVien, QuanLy, Admin");

            string maTK = GenerateMaTK();

            Account account = new Account
            {
                MaTK = maTK,
                MaNV = maNV,
                TenDangNhap = tenDangNhap,
                MatKhau = matKhau,
                Role = role,
                CreatedAt = DateTime.Now,
                CreatedBy = Session_Now.CurrentUser,
                IsActive = true
            };

            var dalResult = accountDAL.Insert(account);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateAccount(string maTK, string tenDangNhap = null, string matKhau = null, string role = null, bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maTK))
                return OperationResult<bool>.Fail("Mã tài khoản không hợp lệ");

            var existing = GetAccounts(maTK: maTK);
            if (!existing.Success || existing.Data.Count == 0)
                return OperationResult<bool>.Fail("Tài khoản không tồn tại");

            // Validate role nếu có
            if (!string.IsNullOrEmpty(role) && role != "NhanVien" && role != "QuanLy" && role != "Admin")
                return OperationResult<bool>.Fail("Role không hợp lệ. Chỉ chấp nhận: NhanVien, QuanLy, Admin");

            Account account = existing.Data[0];
            account.TenDangNhap = tenDangNhap ?? account.TenDangNhap;
            account.MatKhau = matKhau ?? account.MatKhau;
            account.Role = role ?? account.Role;
            account.IsActive = isActive ?? account.IsActive;
            account.UpdatedAt = DateTime.Now;
            account.UpdatedBy = Session_Now.CurrentUser;

            var dalResult = accountDAL.Update(account);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteAccount(string maTK)
        {
            if (string.IsNullOrWhiteSpace(maTK))
                return OperationResult<bool>.Fail("Mã tài khoản không hợp lệ");

            var dalResult = accountDAL.Delete(maTK);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaTK()
        {
            var accounts = GetAccounts();
            int maxNumber = 0;

            if (accounts.Success && accounts.Data.Count > 0)
            {
                foreach (var acc in accounts.Data)
                {
                    if (acc.MaTK.StartsWith("TK") && acc.MaTK.Length > 2)
                    {
                        if (int.TryParse(acc.MaTK.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"TK{(maxNumber + 1):D3}";
        }

        private Account MapAccount(DataRow row)
        {
            return new Account
            {
                MaTK = row.GetString("MaTK", ""),
                MaNV = row.GetString("MaNV", ""),
                TenDangNhap = row.GetString("TenDangNhap", ""),
                MatKhau = row.GetString("MatKhau"),
                Role = row.GetString("Role", "NhanVien"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                CreatedBy = row.GetString("CreatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt"),
                UpdatedBy = row.GetString("UpdatedBy"),
                IsActive = row.GetBool("IsActive", true)
            };
        }
    }
}


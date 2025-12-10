using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.PaymentDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class PaymentBLL
    {
        private readonly PaymentDAL paymentDAL = new PaymentDAL();

        public OperationResult<List<Payment>> GetPayments(string maTT = null, string maHD = null, string maLTT = null, bool? isActive = null)
        {
            var dalResult = paymentDAL.GetPayments(maTT, maHD, maLTT, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Payment>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Payment> list = new List<Payment>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapPayment(row));
                }
                return OperationResult<List<Payment>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Payment>>.Fail($"Lỗi khi xử lý dữ liệu thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> AddPayment(string maHD, decimal soTien, string maLTT, DateTime ngayTT)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                return OperationResult<bool>.Fail("Mã hóa đơn không được để trống");

            if (soTien <= 0)
                return OperationResult<bool>.Fail("Số tiền phải lớn hơn 0");

            if (string.IsNullOrWhiteSpace(maLTT))
                return OperationResult<bool>.Fail("Loại thanh toán không được để trống");

            string maTT = GenerateMaTT();

            Payment payment = new Payment
            {
                MaTT = maTT,
                MaHD = maHD,
                SoTien = soTien,
                MaLTT = maLTT,
                NgayTT = ngayTT,
                IsActive = true,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = paymentDAL.Insert(payment);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdatePayment(string maTT, decimal soTien, string maLTT, DateTime ngayTT)
        {
            if (string.IsNullOrWhiteSpace(maTT))
                return OperationResult<bool>.Fail("Mã thanh toán không hợp lệ");

            Payment payment = new Payment
            {
                MaTT = maTT,
                SoTien = soTien,
                MaLTT = maLTT,
                NgayTT = ngayTT,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now
            };

            var dalResult = paymentDAL.Update(payment);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeletePayment(string maTT)
        {
            if (string.IsNullOrWhiteSpace(maTT))
                return OperationResult<bool>.Fail("Mã thanh toán không hợp lệ");

            var dalResult = paymentDAL.Delete(maTT);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaTT()
        {
            var payments = GetPayments();
            int maxNumber = 0;
            
            if (payments.Success && payments.Data.Count > 0)
            {
                foreach (var payment in payments.Data)
                {
                    if (payment.MaTT.StartsWith("TT") && payment.MaTT.Length > 2)
                    {
                        if (int.TryParse(payment.MaTT.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"TT{(maxNumber + 1):D3}";
        }

        private Payment MapPayment(DataRow row)
        {
            return new Payment
            {
                MaTT = row["MaTT"]?.ToString() ?? "",
                MaHD = row["MaHD"]?.ToString(),
                SoTien = row["SoTien"] != DBNull.Value ? Convert.ToDecimal(row["SoTien"]) : (decimal?)null,
                MaLTT = row["MaLTT"]?.ToString(),
                NgayTT = row["NgayTT"] != DBNull.Value ? Convert.ToDateTime(row["NgayTT"]) : (DateTime?)null,
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
            };
        }
    }
}



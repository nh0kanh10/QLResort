using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.PaymentDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class PaymentTypeBLL
    {
        private readonly PaymentTypeDAL paymentTypeDAL = new PaymentTypeDAL();

        public OperationResult<List<PaymentType>> GetPaymentTypes(string maLTT = null, bool? isActive = null)
        {
            var dalResult = paymentTypeDAL.GetPaymentTypes(maLTT, isActive);

            if (!dalResult.Success)
                return OperationResult<List<PaymentType>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<PaymentType> list = new List<PaymentType>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapPaymentType(row));
                }
                return OperationResult<List<PaymentType>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<PaymentType>>.Fail($"Lỗi khi xử lý dữ liệu loại thanh toán: {ex.Message}");
            }
        }

        public OperationResult<bool> AddPaymentType(string tenLTT, bool isActive = true)
        {
            if (string.IsNullOrWhiteSpace(tenLTT))
                return OperationResult<bool>.Fail("Tên loại thanh toán không được để trống");

            string maLTT = GenerateMaLTT();

            PaymentType paymentType = new PaymentType
            {
                MaLTT = maLTT,
                TenLTT = tenLTT,
                IsActive = isActive,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = paymentTypeDAL.Insert(paymentType);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdatePaymentType(string maLTT, string tenLTT, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(maLTT))
                return OperationResult<bool>.Fail("Mã loại thanh toán không hợp lệ");

            if (string.IsNullOrWhiteSpace(tenLTT))
                return OperationResult<bool>.Fail("Tên loại thanh toán không được để trống");

            PaymentType paymentType = new PaymentType
            {
                MaLTT = maLTT,
                TenLTT = tenLTT,
                IsActive = isActive,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now
            };

            var dalResult = paymentTypeDAL.Update(paymentType);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeletePaymentType(string maLTT)
        {
            if (string.IsNullOrWhiteSpace(maLTT))
                return OperationResult<bool>.Fail("Mã loại thanh toán không hợp lệ");

            var dalResult = paymentTypeDAL.Delete(maLTT);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaLTT()
        {
            var types = GetPaymentTypes();
            int maxNumber = 0;
            
            if (types.Success && types.Data.Count > 0)
            {
                foreach (var type in types.Data)
                {
                    if (type.MaLTT.StartsWith("LTT") && type.MaLTT.Length > 3)
                    {
                        if (int.TryParse(type.MaLTT.Substring(3), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"LTT{(maxNumber + 1):D3}";
        }

        private PaymentType MapPaymentType(DataRow row)
        {
            return new PaymentType
            {
                MaLTT = row["MaLTT"]?.ToString() ?? "",
                TenLTT = row["TenLTT"]?.ToString(),
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
            };
        }
    }
}



using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Validation;
using QLResort.DAL.ServiceDAL;
using QLResort.Mappers;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class ServiceBLL
    {
        private readonly ServiceDAL serviceDAL = new ServiceDAL();

        public OperationResult<List<Service>> GetServices(string maDV = null, string tenDV = null, string loaiDV = null, bool? isActive = null)
        {
            var dalResult = serviceDAL.GetServices(maDV, tenDV, loaiDV, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Service>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Service> list = new List<Service>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapService(row));
                }
                return OperationResult<List<Service>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Service>>.Fail($"Lỗi khi xử lý dữ liệu dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> AddService(
            string tenDV, 
            string loaiDV, 
            string moTa, 
            decimal? gia, 
            bool choPhepDoiDiem, 
            int? giaTriDoiDiem, 
            bool isActive)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(tenDV))
                return OperationResult<bool>.Fail("Tên dịch vụ không được để trống");

            if (tenDV.Length > 200)
                return OperationResult<bool>.Fail("Tên dịch vụ không được vượt quá 200 ký tự");

            var priceResult = SimpleValidator.ValidatePrice(gia, required: false);
            if (!priceResult.IsValid)
                return OperationResult<bool>.Fail(priceResult.ErrorMessage);

            if (choPhepDoiDiem && (!giaTriDoiDiem.HasValue || giaTriDoiDiem.Value <= 0))
                return OperationResult<bool>.Fail("Nếu cho phép đổi điểm thì giá trị đổi điểm phải lớn hơn 0");

            // Tạo mã dịch vụ
            string maDV = GenerateMaDV();

            Service service = new Service
            {
                MaDV = maDV,
                TenDV = tenDV,
                LoaiDV = loaiDV,
                MoTa = moTa,
                Gia = gia,
                ChoPhepDoiDiem = choPhepDoiDiem,
                GiaTriDoiDiem = giaTriDoiDiem,
                IsActive = isActive,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = serviceDAL.Insert(service);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateService(
            string maDV,
            string tenDV,
            string loaiDV,
            string moTa,
            decimal? gia,
            bool choPhepDoiDiem,
            int? giaTriDoiDiem,
            bool isActive)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(maDV))
                return OperationResult<bool>.Fail("Mã dịch vụ không hợp lệ");

            if (!serviceDAL.Exists(maDV))
                return OperationResult<bool>.Fail("Dịch vụ không tồn tại");

            if (string.IsNullOrWhiteSpace(tenDV))
                return OperationResult<bool>.Fail("Tên dịch vụ không được để trống");

            var priceResult = SimpleValidator.ValidatePrice(gia, required: false);
            if (!priceResult.IsValid)
                return OperationResult<bool>.Fail(priceResult.ErrorMessage);

            Service service = new Service
            {
                MaDV = maDV,
                TenDV = tenDV,
                LoaiDV = loaiDV,
                MoTa = moTa,
                Gia = gia,
                ChoPhepDoiDiem = choPhepDoiDiem,
                GiaTriDoiDiem = giaTriDoiDiem,
                IsActive = isActive,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now
            };

            var dalResult = serviceDAL.Update(service);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteService(string maDV)
        {
            if (string.IsNullOrWhiteSpace(maDV))
                return OperationResult<bool>.Fail("Mã dịch vụ không hợp lệ");

            if (!serviceDAL.Exists(maDV))
                return OperationResult<bool>.Fail("Dịch vụ không tồn tại");

            var dalResult = serviceDAL.Delete(maDV);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaDV()
        {
            var services = GetServices();
            int maxNumber = 0;
            
            if (services.Success && services.Data.Count > 0)
            {
                foreach (var sv in services.Data)
                {
                    if (sv.MaDV.StartsWith("DV") && sv.MaDV.Length > 2)
                    {
                        if (int.TryParse(sv.MaDV.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"DV{(maxNumber + 1):D3}";
        }

        private Service MapService(DataRow row)
        {
            return new Service
            {
                MaDV = row.GetString("MaDV", ""),
                TenDV = row.GetString("TenDV"),
                LoaiDV = row.GetString("LoaiDV"),
                MoTa = row.GetString("MoTa"),
                Gia = row.GetNullableDecimal("Gia"),
                ChoPhepDoiDiem = row.GetBool("ChoPhepDoiDiem"),
                GiaTriDoiDiem = row.GetNullableInt("GiaTriDoiDiem"),
                IsActive = row.GetBool("IsActive", true),
                CreatedBy = row.GetString("CreatedBy"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                UpdatedBy = row.GetString("UpdatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt")
            };
        }
    }
}








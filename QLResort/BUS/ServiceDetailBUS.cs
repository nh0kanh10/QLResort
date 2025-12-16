using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.ServiceDetailDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BUS
{
    public class ServiceDetailBUS
    {
        private readonly ServiceDetailDAL serviceDetailDAL = new ServiceDetailDAL();

        public OperationResult<List<ServiceDetail>> GetServiceDetails(string maCTDV = null, string maCTDP = null, string maDV = null, bool? isActive = null)
        {
            var dalResult = serviceDetailDAL.GetServiceDetails(maCTDV, maCTDP, maDV, isActive);

            if (!dalResult.Success)
                return OperationResult<List<ServiceDetail>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<ServiceDetail> list = new List<ServiceDetail>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapServiceDetail(row));
                }
                return OperationResult<List<ServiceDetail>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ServiceDetail>>.Fail($"Lỗi khi xử lý dữ liệu chi tiết dịch vụ: {ex.Message}");
            }
        }

        public OperationResult<bool> AddServiceDetail(string maCTDP, string maDV, int soLuong, decimal gia, decimal thanhTien)
        {
            if (string.IsNullOrWhiteSpace(maCTDP))
                return OperationResult<bool>.Fail("Mã chi tiết đặt phòng không được để trống");

            if (string.IsNullOrWhiteSpace(maDV))
                return OperationResult<bool>.Fail("Mã dịch vụ không được để trống");

            if (soLuong <= 0)
                return OperationResult<bool>.Fail("Số lượng phải lớn hơn 0");

            if (gia < 0)
                return OperationResult<bool>.Fail("Giá không hợp lệ");

            string maCTDV = GenerateMaCTDV();

            ServiceDetail serviceDetail = new ServiceDetail
            {
                MaCTDV = maCTDV,
                MaCTDP = maCTDP,
                MaDV = maDV,
                SoLuong = soLuong,
                Gia = gia,
                ThanhTien = thanhTien,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            var result = serviceDetailDAL.Insert(serviceDetail);
            return result;
        }

        public OperationResult<bool> UpdateServiceDetail(string maCTDV, int? soLuong, decimal? gia, decimal? thanhTien, bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maCTDV))
                return OperationResult<bool>.Fail("Mã chi tiết dịch vụ không được để trống");

            ServiceDetail serviceDetail = new ServiceDetail
            {
                MaCTDV = maCTDV,
                SoLuong = soLuong,
                Gia = gia,
                ThanhTien = thanhTien,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now,
                IsActive = isActive ?? true
            };

            var result = serviceDetailDAL.Update(serviceDetail);
            return result;
        }

        public OperationResult<bool> DeleteServiceDetail(string maCTDV)
        {
            if (string.IsNullOrWhiteSpace(maCTDV))
                return OperationResult<bool>.Fail("Mã chi tiết dịch vụ không được để trống");

            var result = serviceDetailDAL.Delete(maCTDV);
            return result;
        }

        private string GenerateMaCTDV()
        {
            var details = GetServiceDetails();
            int maxNumber = 0;

            if (details.Success && details.Data.Count > 0)
            {
                foreach (var detail in details.Data)
                {
                    if (detail.MaCTDV.StartsWith("CTDV") && detail.MaCTDV.Length > 4)
                    {
                        if (int.TryParse(detail.MaCTDV.Substring(4), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"CTDV{(maxNumber + 1):D3}";
        }

        private ServiceDetail MapServiceDetail(DataRow row)
        {
            return new ServiceDetail
            {
                MaCTDV = row["MaCTDV"]?.ToString() ?? "",
                MaCTDP = row["MaCTDP"]?.ToString(),
                MaDV = row["MaDV"]?.ToString(),
                SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : (int?)null,
                Gia = row["Gia"] != DBNull.Value ? Convert.ToDecimal(row["Gia"]) : (decimal?)null,
                ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : (decimal?)null,
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null,
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"])
            };
        }
    }
}


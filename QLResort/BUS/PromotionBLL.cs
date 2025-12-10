using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.PromotionDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLResort.BLL
{
    public class PromotionBLL
    {
        private readonly PromotionDAL promotionDAL = new PromotionDAL();

        public OperationResult<List<Promotion>> GetPromotions(string maKM = null, string couponCode = null, string maCN = null, string maLKH = null, bool? isActive = null)
        {
            var dalResult = promotionDAL.GetPromotions(maKM, couponCode, maCN, maLKH, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Promotion>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Promotion> list = new List<Promotion>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapPromotion(row));
                }
                return OperationResult<List<Promotion>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Promotion>>.Fail($"Lỗi khi xử lý dữ liệu khuyến mãi: {ex.Message}");
            }
        }

        public OperationResult<Promotion> GetPromotionByCode(string couponCode, string maCN = null, string maLKH = null)
        {
            var promotions = GetPromotions(couponCode: couponCode, maCN: maCN, maLKH: maLKH, isActive: true);
            
            if (!promotions.Success)
                return OperationResult<Promotion>.Fail(promotions.ErrorMessage);

            var promotion = promotions.Data.FirstOrDefault();
            if (promotion == null)
                return OperationResult<Promotion>.Fail("Không tìm thấy khuyến mãi với mã này");

            // Kiểm tra thời gian hiệu lực
            if (promotion.NgayBD.HasValue && promotion.NgayBD.Value > DateTime.Now)
                return OperationResult<Promotion>.Fail("Khuyến mãi chưa có hiệu lực");

            if (promotion.NgayKT.HasValue && promotion.NgayKT.Value < DateTime.Now)
                return OperationResult<Promotion>.Fail("Khuyến mãi đã hết hạn");

            return OperationResult<Promotion>.Ok(promotion);
        }

        public decimal CalculateDiscount(Promotion promotion, decimal totalAmount, string maCN = null, string maLKH = null, string maLP = null, string maPhong = null)
        {
            if (promotion == null || !promotion.IsActive)
                return 0;

            // Kiểm tra điều kiện áp dụng
            if (!string.IsNullOrEmpty(promotion.MaCN) && promotion.MaCN != maCN)
                return 0;

            if (!string.IsNullOrEmpty(promotion.MaLKH) && promotion.MaLKH != maLKH)
                return 0;

            if (!string.IsNullOrEmpty(promotion.MaLP) && promotion.MaLP != maLP)
                return 0;

            if (!string.IsNullOrEmpty(promotion.MaPhong) && promotion.MaPhong != maPhong)
                return 0;

            // Kiểm tra thời gian
            if (promotion.NgayBD.HasValue && promotion.NgayBD.Value > DateTime.Now)
                return 0;

            if (promotion.NgayKT.HasValue && promotion.NgayKT.Value < DateTime.Now)
                return 0;

            // Tính giảm giá
            if (promotion.IsPhanTram && promotion.GiaTri.HasValue)
            {
                // Giảm theo phần trăm
                return totalAmount * promotion.GiaTri.Value / 100;
            }
            else if (!promotion.IsPhanTram && promotion.GiaTri.HasValue)
            {
                // Giảm theo số tiền cố định
                return promotion.GiaTri.Value > totalAmount ? totalAmount : promotion.GiaTri.Value;
            }

            return 0;
        }

        public OperationResult<bool> AddPromotion(Promotion promotion)
        {
            if (string.IsNullOrWhiteSpace(promotion.TenKM))
                return OperationResult<bool>.Fail("Tên khuyến mãi không được để trống");

            if (!promotion.GiaTri.HasValue || promotion.GiaTri.Value <= 0)
                return OperationResult<bool>.Fail("Giá trị khuyến mãi phải lớn hơn 0");

            if (promotion.NgayBD.HasValue && promotion.NgayKT.HasValue && promotion.NgayKT.Value < promotion.NgayBD.Value)
                return OperationResult<bool>.Fail("Ngày kết thúc phải sau ngày bắt đầu");

            promotion.MaKM = GenerateMaKM();
            promotion.CreatedBy = Session_Now.CurrentUser;
            promotion.CreatedAt = DateTime.Now;

            var dalResult = promotionDAL.Insert(promotion);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdatePromotion(Promotion promotion)
        {
            if (string.IsNullOrWhiteSpace(promotion.MaKM))
                return OperationResult<bool>.Fail("Mã khuyến mãi không hợp lệ");

            if (string.IsNullOrWhiteSpace(promotion.TenKM))
                return OperationResult<bool>.Fail("Tên khuyến mãi không được để trống");

            promotion.UpdatedBy = Session_Now.CurrentUser;
            promotion.UpdatedAt = DateTime.Now;

            var dalResult = promotionDAL.Update(promotion);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeletePromotion(string maKM)
        {
            if (string.IsNullOrWhiteSpace(maKM))
                return OperationResult<bool>.Fail("Mã khuyến mãi không hợp lệ");

            var dalResult = promotionDAL.Delete(maKM);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaKM()
        {
            var promotions = GetPromotions();
            int maxNumber = 0;
            
            if (promotions.Success && promotions.Data.Count > 0)
            {
                foreach (var prom in promotions.Data)
                {
                    if (prom.MaKM.StartsWith("KM") && prom.MaKM.Length > 2)
                    {
                        if (int.TryParse(prom.MaKM.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"KM{(maxNumber + 1):D3}";
        }

        private Promotion MapPromotion(DataRow row)
        {
            return new Promotion
            {
                MaKM = row["MaKM"]?.ToString() ?? "",
                TenKM = row["TenKM"]?.ToString(),
                IsPhanTram = row["IsPhanTram"] != DBNull.Value && Convert.ToBoolean(row["IsPhanTram"]),
                GiaTri = row["GiaTri"] != DBNull.Value ? Convert.ToDecimal(row["GiaTri"]) : (decimal?)null,
                MaLKH = row["MaLKH"]?.ToString(),
                MaCN = row["MaCN"]?.ToString(),
                MaLP = row["MaLP"]?.ToString(),
                MaPhong = row["MaPhong"]?.ToString(),
                CouponCode = row["CouponCode"]?.ToString(),
                NgayBD = row["NgayBD"] != DBNull.Value ? Convert.ToDateTime(row["NgayBD"]) : (DateTime?)null,
                NgayKT = row["NgayKT"] != DBNull.Value ? Convert.ToDateTime(row["NgayKT"]) : (DateTime?)null,
                DieuKien = row["DieuKien"]?.ToString(),
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
            };
        }
    }
}



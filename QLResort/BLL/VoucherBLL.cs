using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.VoucherDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class VoucherBLL
    {
        private readonly VoucherDAL voucherDAL = new VoucherDAL();

        public OperationResult<List<Voucher>> GetVouchers(string maVoucher = null, string couponCode = null,
            string maLKH = null, string maCN = null, string trangThai = null, bool? isActive = null)
        {
            var dalResult = voucherDAL.GetVouchers(maVoucher, couponCode, maLKH, maCN, trangThai, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Voucher>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Voucher> list = new List<Voucher>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapVoucher(row));
                }
                return OperationResult<List<Voucher>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Voucher>>.Fail($"Lỗi khi xử lý dữ liệu voucher: {ex.Message}");
            }
        }

        public OperationResult<bool> AddVoucher(
            string tenVoucher,
            bool isPhanTram,
            decimal? giaTri,
            string couponCode = null,
            int? soLuong = null,
            string maLKH = null,
            string maCN = null,
            string maLP = null,
            string maPhong = null,
            DateTime? ngayBD = null,
            DateTime? ngayKT = null,
            string dieuKien = null,
            string trangThai = "Active",
            bool isActive = true)
        {
            if (string.IsNullOrWhiteSpace(tenVoucher))
                return OperationResult<bool>.Fail("Tên voucher không được để trống");

            string maVoucher = GenerateMaVoucher();

            Voucher voucher = new Voucher
            {
                MaVoucher = maVoucher,
                TenVoucher = tenVoucher,
                CouponCode = couponCode,
                IsPhanTram = isPhanTram,
                GiaTri = giaTri,
                SoLuong = soLuong,
                SoLuongDaDung = 0,
                MaLKH = maLKH,
                MaCN = maCN,
                MaLP = maLP,
                MaPhong = maPhong,
                NgayBD = ngayBD,
                NgayKT = ngayKT,
                DieuKien = dieuKien,
                TrangThai = trangThai,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now,
                IsActive = isActive
            };

            var dalResult = voucherDAL.Insert(voucher);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateVoucher(
            string maVoucher,
            string tenVoucher = null,
            bool? isPhanTram = null,
            decimal? giaTri = null,
            int? soLuong = null,
            DateTime? ngayBD = null,
            DateTime? ngayKT = null,
            string dieuKien = null,
            string trangThai = null,
            bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maVoucher))
                return OperationResult<bool>.Fail("Mã voucher không hợp lệ");

            if (!voucherDAL.Exists(maVoucher))
                return OperationResult<bool>.Fail("Voucher không tồn tại");

            var existing = GetVouchers(maVoucher: maVoucher);
            if (!existing.Success || existing.Data.Count == 0)
                return OperationResult<bool>.Fail("Voucher không tồn tại");

            Voucher voucher = existing.Data[0];
            voucher.TenVoucher = tenVoucher ?? voucher.TenVoucher;
            voucher.IsPhanTram = isPhanTram ?? voucher.IsPhanTram;
            voucher.GiaTri = giaTri ?? voucher.GiaTri;
            voucher.SoLuong = soLuong ?? voucher.SoLuong;
            voucher.NgayBD = ngayBD ?? voucher.NgayBD;
            voucher.NgayKT = ngayKT ?? voucher.NgayKT;
            voucher.DieuKien = dieuKien ?? voucher.DieuKien;
            voucher.TrangThai = trangThai ?? voucher.TrangThai;
            voucher.IsActive = isActive ?? voucher.IsActive;
            voucher.UpdatedAt = DateTime.Now;

            var dalResult = voucherDAL.Update(voucher);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteVoucher(string maVoucher)
        {
            if (string.IsNullOrWhiteSpace(maVoucher))
                return OperationResult<bool>.Fail("Mã voucher không hợp lệ");

            if (!voucherDAL.Exists(maVoucher))
                return OperationResult<bool>.Fail("Voucher không tồn tại");

            // Soft delete
            var result = UpdateVoucher(maVoucher, null, null, null, null, null, null, "Inactive", isActive: false);
            return result;
        }

        private string GenerateMaVoucher()
        {
            var vouchers = GetVouchers();
            int maxNumber = 0;

            if (vouchers.Success && vouchers.Data.Count > 0)
            {
                foreach (var voucher in vouchers.Data)
                {
                    if (voucher.MaVoucher.StartsWith("VC") && voucher.MaVoucher.Length > 2)
                    {
                        if (int.TryParse(voucher.MaVoucher.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"VC{(maxNumber + 1):D3}";
        }

        private Voucher MapVoucher(DataRow row)
        {
            return new Voucher
            {
                MaVoucher = row.GetString("MaVoucher", ""),
                TenVoucher = row.GetString("TenVoucher", ""),
                CouponCode = row.GetString("CouponCode"),
                IsPhanTram = row.GetBool("IsPhanTram", true),
                GiaTri = row.GetNullableDecimal("GiaTri"),
                SoLuong = row.GetNullableInt("SoLuong"),
                SoLuongDaDung = row.GetNullableInt("SoLuongDaDung")??0,
                MaLKH = row.GetString("MaLKH"),
                MaCN = row.GetString("MaCN"),
                MaLP = row.GetString("MaLP"),
                MaPhong = row.GetString("MaPhong"),
                NgayBD = row.GetNullableDateTime("NgayBD"),
                NgayKT = row.GetNullableDateTime("NgayKT"),
                DieuKien = row.GetString("DieuKien"),
                TrangThai = row.GetString("TrangThai", "Active"),
                CreatedBy = row.GetString("CreatedBy"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                UpdatedBy = row.GetString("UpdatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt"),
                IsActive = row.GetBool("IsActive", true)
            };
        }
    }
}


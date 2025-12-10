using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Validation;
using QLResort.DAL.RoomTypeDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class RoomTypeBLL
    {
        private readonly RoomTypeDAL roomTypeDAL = new RoomTypeDAL();

        public OperationResult<List<RoomType>> GetRoomTypes(string maLP = null, bool? isActive = null)
        {
            var dalResult = roomTypeDAL.GetRoomTypes(maLP, isActive);

            if (!dalResult.Success)
                return OperationResult<List<RoomType>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<RoomType> list = new List<RoomType>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapRoomType(row));
                }
                return OperationResult<List<RoomType>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<RoomType>>.Fail($"Lỗi khi xử lý dữ liệu loại phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> AddRoomType(
            string tenLP,
            string moTa,
            bool isNhaNguyenCan,
            int soPhongTrongNha,
            decimal? giaTheoGio,
            decimal? giaTheoNgay,
            decimal? giaTheoThang,
            int? sucChuaToiDa,
            bool isActive)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(tenLP))
                return OperationResult<bool>.Fail("Tên loại phòng không được để trống");

            if (tenLP.Length > 100)
                return OperationResult<bool>.Fail("Tên loại phòng không được vượt quá 100 ký tự");

            if (isNhaNguyenCan && soPhongTrongNha <= 0)
                return OperationResult<bool>.Fail("Nhà nguyên căn phải có số phòng lớn hơn 0");

            if (giaTheoNgay.HasValue)
            {
                var priceResult = SimpleValidator.ValidatePrice(giaTheoNgay, required: false);
                if (!priceResult.IsValid)
                    return OperationResult<bool>.Fail(priceResult.ErrorMessage);
            }

            if (sucChuaToiDa.HasValue && sucChuaToiDa.Value <= 0)
                return OperationResult<bool>.Fail("Sức chứa tối đa phải lớn hơn 0");

            // Tạo mã loại phòng
            string maLP = GenerateMaLP();

            RoomType roomType = new RoomType
            {
                MaLP = maLP,
                TenLP = tenLP,
                MoTa = moTa,
                IsNhaNguyenCan = isNhaNguyenCan,
                SoPhongTrongNha = soPhongTrongNha,
                GiaTheoGio = giaTheoGio,
                GiaTheoNgay = giaTheoNgay,
                GiaTheoThang = giaTheoThang,
                SucChuaToiDa = sucChuaToiDa,
                IsActive = isActive,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = roomTypeDAL.Insert(roomType);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateRoomType(
            string maLP,
            string tenLP,
            string moTa,
            bool isNhaNguyenCan,
            int soPhongTrongNha,
            decimal? giaTheoGio,
            decimal? giaTheoNgay,
            decimal? giaTheoThang,
            int? sucChuaToiDa,
            bool isActive)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(maLP))
                return OperationResult<bool>.Fail("Mã loại phòng không hợp lệ");

            if (!roomTypeDAL.Exists(maLP))
                return OperationResult<bool>.Fail("Loại phòng không tồn tại");

            if (string.IsNullOrWhiteSpace(tenLP))
                return OperationResult<bool>.Fail("Tên loại phòng không được để trống");

            RoomType roomType = new RoomType
            {
                MaLP = maLP,
                TenLP = tenLP,
                MoTa = moTa,
                IsNhaNguyenCan = isNhaNguyenCan,
                SoPhongTrongNha = soPhongTrongNha,
                GiaTheoGio = giaTheoGio,
                GiaTheoNgay = giaTheoNgay,
                GiaTheoThang = giaTheoThang,
                SucChuaToiDa = sucChuaToiDa,
                IsActive = isActive,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now
            };

            var dalResult = roomTypeDAL.Update(roomType);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteRoomType(string maLP)
        {
            if (string.IsNullOrWhiteSpace(maLP))
                return OperationResult<bool>.Fail("Mã loại phòng không hợp lệ");

            if (!roomTypeDAL.Exists(maLP))
                return OperationResult<bool>.Fail("Loại phòng không tồn tại");

            var dalResult = roomTypeDAL.Delete(maLP);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaLP()
        {
            var roomTypes = GetRoomTypes();
            int maxNumber = 0;
            
            if (roomTypes.Success && roomTypes.Data.Count > 0)
            {
                foreach (var rt in roomTypes.Data)
                {
                    if (rt.MaLP.StartsWith("LP") && rt.MaLP.Length > 2)
                    {
                        if (int.TryParse(rt.MaLP.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"LP{(maxNumber + 1):D3}";
        }

        private RoomType MapRoomType(DataRow row)
        {
            return new RoomType
            {
                MaLP = row.GetString("MaLP", ""),
                TenLP = row.GetString("TenLP"),
                MoTa = row.GetString("MoTa"),
                IsNhaNguyenCan = row.GetBool("IsNhaNguyenCan"),
                SoPhongTrongNha = row.GetNullableInt("SoPhongTrongNha") ?? 0,
                GiaTheoGio = row.GetNullableDecimal("GiaTheoGio"),
                GiaTheoNgay = row.GetNullableDecimal("GiaTheoNgay"),
                GiaTheoThang = row.GetNullableDecimal("GiaTheoThang"),
                SucChuaToiDa = row.GetNullableInt("SucChuaToiDa"),
                IsActive = row.GetBool("IsActive", true),
                CreatedBy = row.GetString("CreatedBy"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                UpdatedBy = row.GetString("UpdatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt")
            };
        }
    }
}








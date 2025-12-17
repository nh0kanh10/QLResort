using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using DAL_QLResort.RoomDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QLResort
{
    public class RoomImageBUS
    {
        private readonly RoomImageDAL roomImageDAL = new RoomImageDAL();

        public OperationResult<List<RoomImage>> GetRoomImages(string maAnh = null, string maPhong = null, bool? isActive = null)
        {
            var dalResult = roomImageDAL.GetRoomImages(maAnh, maPhong, isActive);

            if (!dalResult.Success)
                return OperationResult<List<RoomImage>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<RoomImage> list = new List<RoomImage>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapRoomImage(row));
                }
                return OperationResult<List<RoomImage>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<RoomImage>>.Fail($"Lỗi khi xử lý dữ liệu ảnh phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> AddRoomImage(string maPhong, string duongDan, string ghiChu = null)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
                return OperationResult<bool>.Fail("Mã phòng không được để trống");

            if (string.IsNullOrWhiteSpace(duongDan))
                return OperationResult<bool>.Fail("Đường dẫn ảnh không được để trống");

            string maAnh = GenerateMaAnh();

            RoomImage roomImage = new RoomImage
            {
                MaAnh = maAnh,
                MaPhong = maPhong,
                DuongDan = duongDan,
                GhiChu = ghiChu,
                IsActive = true,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = roomImageDAL.Insert(roomImage);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateRoomImage(string maAnh, string duongDan, string ghiChu = null)
        {
            if (string.IsNullOrWhiteSpace(maAnh))
                return OperationResult<bool>.Fail("Mã ảnh không hợp lệ");

            if (string.IsNullOrWhiteSpace(duongDan))
                return OperationResult<bool>.Fail("Đường dẫn ảnh không được để trống");

            var existingImages = GetRoomImages(maAnh: maAnh);
            if (!existingImages.Success || existingImages.Data.Count == 0)
                return OperationResult<bool>.Fail("Ảnh không tồn tại");

            RoomImage roomImage = existingImages.Data[0];
            roomImage.DuongDan = duongDan;
            roomImage.GhiChu = ghiChu;
            roomImage.UpdatedBy = Session_Now.CurrentUser;
            roomImage.UpdatedAt = DateTime.Now;

            var dalResult = roomImageDAL.Update(roomImage);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteRoomImage(string maAnh)
        {
            if (string.IsNullOrWhiteSpace(maAnh))
                return OperationResult<bool>.Fail("Mã ảnh không hợp lệ");

            var dalResult = roomImageDAL.Delete(maAnh);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaAnh()
        {
            var images = GetRoomImages();
            int maxNumber = 0;
            
            if (images.Success && images.Data.Count > 0)
            {
                foreach (var img in images.Data)
                {
                    if (img.MaAnh.StartsWith("IMG") && img.MaAnh.Length > 3)
                    {
                        if (int.TryParse(img.MaAnh.Substring(3), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"IMG{(maxNumber + 1):D3}";
        }

        private RoomImage MapRoomImage(DataRow row)
        {
            return new RoomImage
            {
                MaAnh = row["MaAnh"]?.ToString() ?? "",
                MaPhong = row["MaPhong"]?.ToString(),
                DuongDan = row["DuongDan"]?.ToString(),
                GhiChu = row["GhiChu"]?.ToString(),
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
            };
        }
    }
}








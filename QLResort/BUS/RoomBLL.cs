using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Validation;
using QLResort.DAL.RoomDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class RoomBLL
    {
        private readonly RoomDAL roomDAL = new RoomDAL();

        public OperationResult<List<Room>> GetRooms(string maPhong = null, string maCN = null, string maLP = null, string trangThai = null, bool? isActive = null)
        {
            var dalResult = roomDAL.GetRooms(maPhong, maCN, maLP, trangThai, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Room>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Room> list = new List<Room>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapRoom(row));
                }
                return OperationResult<List<Room>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Room>>.Fail($"Lỗi khi xử lý dữ liệu phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> AddRoom(
            string maCN,
            string maLP,
            string soPhong,
            string viTri,
            string trangThai,
            string ghiChu,
            bool isActive)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(maCN))
                return OperationResult<bool>.Fail("Mã chi nhánh không được để trống");

            if (string.IsNullOrWhiteSpace(maLP))
                return OperationResult<bool>.Fail("Mã loại phòng không được để trống");

            if (string.IsNullOrWhiteSpace(soPhong))
                return OperationResult<bool>.Fail("Số phòng không được để trống");

            // Kiểm tra số phòng đã tồn tại trong chi nhánh chưa
            var existingRooms = GetRooms(maCN: maCN);
            if (existingRooms.Success)
            {
                foreach (var r in existingRooms.Data)
                {
                    if (r.SoPhong == soPhong && r.MaCN == maCN)
                        return OperationResult<bool>.Fail($"Số phòng {soPhong} đã tồn tại trong chi nhánh này");
                }
            }

            // Tạo mã phòng
            string maPhong = GenerateMaPhong();

            Room room = new Room
            {
                MaPhong = maPhong,
                MaCN = maCN,
                MaLP = maLP,
                SoPhong = soPhong,
                ViTri = viTri,
                TrangThai = trangThai ?? "Trống",
                GhiChu = ghiChu,
                IsActive = isActive,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = roomDAL.Insert(room);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateRoom(
            string maPhong,
            string maCN,
            string maLP,
            string soPhong,
            string viTri,
            string trangThai,
            string ghiChu,
            bool isActive)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(maPhong))
                return OperationResult<bool>.Fail("Mã phòng không hợp lệ");

            if (!roomDAL.Exists(maPhong))
                return OperationResult<bool>.Fail("Phòng không tồn tại");

            if (string.IsNullOrWhiteSpace(soPhong))
                return OperationResult<bool>.Fail("Số phòng không được để trống");

            Room room = new Room
            {
                MaPhong = maPhong,
                MaCN = maCN,
                MaLP = maLP,
                SoPhong = soPhong,
                ViTri = viTri,
                TrangThai = trangThai ?? "Trống",
                GhiChu = ghiChu,
                IsActive = isActive,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now
            };

            var dalResult = roomDAL.Update(room);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteRoom(string maPhong)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
                return OperationResult<bool>.Fail("Mã phòng không hợp lệ");

            if (!roomDAL.Exists(maPhong))
                return OperationResult<bool>.Fail("Phòng không tồn tại");

            var dalResult = roomDAL.Delete(maPhong);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaPhong()
        {
            var rooms = GetRooms();
            int maxNumber = 0;
            
            if (rooms.Success && rooms.Data.Count > 0)
            {
                foreach (var room in rooms.Data)
                {
                    if (room.MaPhong.StartsWith("P") && room.MaPhong.Length > 1)
                    {
                        if (int.TryParse(room.MaPhong.Substring(1), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"P{(maxNumber + 1):D3}";
        }

        private Room MapRoom(DataRow row)
        {
            return new Room
            {
                MaPhong = row.GetString("MaPhong", ""),
                MaCN = row.GetString("MaCN"),
                MaLP = row.GetString("MaLP"),
                SoPhong = row.GetString("SoPhong"),
                ViTri = row.GetString("ViTri"),
                TrangThai = row.GetString("TrangThai", "Trống"),
                GhiChu = row.GetString("GhiChu"),
                IsActive = row.GetBool("IsActive", true),
                CreatedBy = row.GetString("CreatedBy"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                UpdatedBy = row.GetString("UpdatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt"),
                TenLoaiPhong = row.GetString("TenLoaiPhong"),
                SucChuaToiDa = row.GetNullableInt("SucChuaToiDa"),
                GiaTheoNgay = row.GetNullableDecimal("GiaTheoNgay"),
                GiaTheoGio = row.GetNullableDecimal("GiaTheoGio"),
                GiaTheoThang = row.GetNullableDecimal("GiaTheoThang"),
            };
        }
    }
}








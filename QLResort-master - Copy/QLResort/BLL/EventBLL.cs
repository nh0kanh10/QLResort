using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.EventDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class EventBLL
    {
        private readonly EventDAL eventDAL = new EventDAL();

        public OperationResult<List<Event>> GetEvents(string maSK = null, string maCN = null,
            string loaiSuKien = null, bool? isActive = null)
        {
            var dalResult = eventDAL.GetEvents(maSK, maCN, loaiSuKien, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Event>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Event> list = new List<Event>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapEvent(row));
                }
                return OperationResult<List<Event>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Event>>.Fail($"Lỗi khi xử lý dữ liệu sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> AddEvent(
            string tenSK,
            string loaiSuKien,
            string maCN,
            string diaDiem = null,
            string ghiChu = null,
            decimal? tongChiPhi = null,
            bool isActive = true)
        {
            if (string.IsNullOrWhiteSpace(tenSK))
                return OperationResult<bool>.Fail("Tên sự kiện không được để trống");

            if (string.IsNullOrWhiteSpace(loaiSuKien))
                return OperationResult<bool>.Fail("Loại sự kiện không được để trống");

            if (string.IsNullOrWhiteSpace(maCN))
                return OperationResult<bool>.Fail("Mã chi nhánh không được để trống");

            string maSK = GenerateMaSK();

            Event evt = new Event
            {
                MaSK = maSK,
                TenSK = tenSK,
                LoaiSuKien = loaiSuKien,
                MaCN = maCN,
                DiaDiem = diaDiem,
                GhiChu = ghiChu,
                TongChiPhi = tongChiPhi,
                IsActive = isActive,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = eventDAL.Insert(evt);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateEvent(
            string maSK,
            string tenSK = null,
            string loaiSuKien = null,
            string diaDiem = null,
            string ghiChu = null,
            decimal? tongChiPhi = null,
            bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maSK))
                return OperationResult<bool>.Fail("Mã sự kiện không hợp lệ");

            if (!eventDAL.Exists(maSK))
                return OperationResult<bool>.Fail("Sự kiện không tồn tại");

            Event evt = new Event
            {
                MaSK = maSK,
                TenSK = tenSK,
                LoaiSuKien = loaiSuKien,
                DiaDiem = diaDiem,
                GhiChu = ghiChu,
                TongChiPhi = tongChiPhi,
                IsActive = isActive ?? true,
                UpdatedBy = Session_Now.CurrentUser,
                UpdatedAt = DateTime.Now
            };

            var dalResult = eventDAL.Update(evt);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteEvent(string maSK)
        {
            if (string.IsNullOrWhiteSpace(maSK))
                return OperationResult<bool>.Fail("Mã sự kiện không hợp lệ");

            if (!eventDAL.Exists(maSK))
                return OperationResult<bool>.Fail("Sự kiện không tồn tại");

            // Soft delete
            var result = UpdateEvent(maSK, null, null, null, null, null, false);
            return result;
        }

        private string GenerateMaSK()
        {
            var events = GetEvents();
            int maxNumber = 0;

            if (events.Success && events.Data.Count > 0)
            {
                foreach (var evt in events.Data)
                {
                    if (evt.MaSK.StartsWith("SK") && evt.MaSK.Length > 2)
                    {
                        if (int.TryParse(evt.MaSK.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"SK{(maxNumber + 1):D3}";
        }

        private Event MapEvent(DataRow row)
        {
            return new Event
            {
                MaSK = row.GetString("MaSK", ""),
                TenSK = row.GetString("TenSK", ""),
                LoaiSuKien = row.GetString("LoaiSuKien", ""),
                MaCN = row.GetString("MaCN", ""),
                DiaDiem = row.GetString("DiaDiem"),
                GhiChu = row.GetString("GhiChu"),
                TongChiPhi = row.GetNullableDecimal("TongChiPhi"),
                IsActive = row.GetBool("IsActive", true),
                CreatedBy = row.GetString("CreatedBy"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                UpdatedBy = row.GetString("UpdatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt")
            };
        }
    }
}


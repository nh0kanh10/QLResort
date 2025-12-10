using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.EventDetailDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class EventDetailBLL
    {
        private readonly EventDetailDAL eventDetailDAL = new EventDetailDAL();

        public OperationResult<List<EventDetail>> GetEventDetails(string maCTSK = null, string maSK = null,
            string maKH = null, string trangThai = null, bool? isActive = null)
        {
            var dalResult = eventDetailDAL.GetEventDetails(maCTSK, maSK, maKH, trangThai, isActive);

            if (!dalResult.Success)
                return OperationResult<List<EventDetail>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<EventDetail> list = new List<EventDetail>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapEventDetail(row));
                }
                return OperationResult<List<EventDetail>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<EventDetail>>.Fail($"Lỗi khi xử lý dữ liệu chi tiết sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> AddEventDetail(
            string maSK,
            string maKH,
            decimal donGia,
            DateTime ngayBD,
            DateTime ngayKT,
            int soLuong = 1,
            int? tongKhach = null,
            decimal daThanhToan = 0,
            string ghiChu = null,
            string trangThai = "Lên kế hoạch")
        {
            if (string.IsNullOrWhiteSpace(maSK))
                return OperationResult<bool>.Fail("Mã sự kiện không được để trống");

            if (string.IsNullOrWhiteSpace(maKH))
                return OperationResult<bool>.Fail("Mã khách hàng không được để trống");

            string maCTSK = GenerateMaCTSK();

            EventDetail detail = new EventDetail
            {
                MaCTSK = maCTSK,
                MaSK = maSK,
                MaKH = maKH,
                SoLuong = soLuong,
                DonGia = donGia,
                ThanhTien = donGia * soLuong,
                NgayBD = ngayBD,
                NgayKT = ngayKT,
                TongKhach = tongKhach,
                DaThanhToan = daThanhToan,
                GhiChu = ghiChu,
                TrangThai = trangThai,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = Session_Now.CurrentUser
            };

            var dalResult = eventDetailDAL.Insert(detail);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateEventDetail(
            string maCTSK,
            string trangThai = null,
            decimal? daThanhToan = null,
            string ghiChu = null,
            int? tongKhach = null,
            bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maCTSK))
                return OperationResult<bool>.Fail("Mã chi tiết sự kiện không hợp lệ");

            if (!eventDetailDAL.Exists(maCTSK))
                return OperationResult<bool>.Fail("Chi tiết sự kiện không tồn tại");

            var existing = GetEventDetails(maCTSK: maCTSK);
            if (!existing.Success || existing.Data.Count == 0)
                return OperationResult<bool>.Fail("Chi tiết sự kiện không tồn tại");

            EventDetail detail = existing.Data[0];
            detail.TrangThai = trangThai ?? detail.TrangThai;
            detail.DaThanhToan = daThanhToan ?? detail.DaThanhToan;
            detail.GhiChu = ghiChu ?? detail.GhiChu;
            detail.TongKhach = tongKhach ?? detail.TongKhach;
            detail.IsActive = isActive ?? detail.IsActive;
            detail.UpdatedAt = DateTime.Now;
            detail.UpdatedBy = Session_Now.CurrentUser;

            var dalResult = eventDetailDAL.Update(detail);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaCTSK()
        {
            var details = GetEventDetails();
            int maxNumber = 0;

            if (details.Success && details.Data.Count > 0)
            {
                foreach (var detail in details.Data)
                {
                    if (detail.MaCTSK.StartsWith("CTSK") && detail.MaCTSK.Length > 4)
                    {
                        if (int.TryParse(detail.MaCTSK.Substring(4), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"CTSK{(maxNumber + 1):D3}";
        }

        private EventDetail MapEventDetail(DataRow row)
        {
            return new EventDetail
            {
                MaCTSK = row.GetString("MaCTSK", ""),
                MaSK = row.GetString("MaSK", ""),
                MaKH = row.GetString("MaKH", ""),
                MaCTDV = row.GetString("MaCTDV"),
                SoLuong = row.GetNullableInt("SoLuong")??1,
                DonGia = row.GetNullableDecimal("DonGia")??0,
                ThanhTien = row.GetNullableDecimal("ThanhTien")??0,
                GhiChu = row.GetString("GhiChu"),
                DaThanhToan = row.GetNullableDecimal("DaThanhToan") ?? 0,
                TrangThai = row.GetString("TrangThai", "Lên kế hoạch"),
                NgayBD = row.GetNullableDateTime("NgayBD") ?? DateTime.Now,
                NgayKT = row.GetNullableDateTime("NgayKT") ?? DateTime.Now,
                TongKhach = row.GetNullableInt("TongKhach"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                CreatedBy = row.GetString("CreatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt"),
                UpdatedBy = row.GetString("UpdatedBy"),
                IsActive = row.GetBool("IsActive", true)
            };
        }
    }
}


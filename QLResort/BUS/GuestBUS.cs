using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.Guest_F;
using QLResort.Mappers;
using System;
using System.Collections.Generic;

namespace QLResort.BUS
{
    internal class GuestBUS
    {
        private readonly GuestDAL dal = new GuestDAL();

        public OperationResult<List<Guest>> GetGuests(string maKH = null, string tenKH = null, string gioiTinh = null, 
            string sdt = null, string id = null, string maLoaiKH = null, bool? isActive = null)
        {
            var dalResult = dal.GetGuest(maKH, tenKH, gioiTinh, sdt, id, maLoaiKH, isActive);
            if (!dalResult.Success)
                return OperationResult<List<Guest>>.Fail(dalResult.ErrorMessage);
            try
            {
                List<Guest> list = new List<Guest>();
                GuestMapper mapGuest = new GuestMapper();
                foreach (System.Data.DataRow row in dalResult.Data.Rows)
                {
                    list.Add(mapGuest.Map(row));
                }
                return OperationResult<List<Guest>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Guest>>.Fail("Lỗi khi xử lý dữ liệu khách hàng: " + ex.Message);
            }
        }

        public OperationResult<bool> AddGuestBAL(string tenKH, string gioiTinh, DateTime ngaySinh, string sdt, string email, 
            string idType, string idNumber, string diaChi, string maLKH, string createdBy, bool isActive)
        {
            var result = dal.GetGuest(id: idNumber);
            if (!result.Success) return OperationResult<bool>.Fail(result.ErrorMessage);
            if (result.Data.Rows.Count > 0) return OperationResult<bool>.Fail("Số CMND/HChiếu đã tồn tại trong hệ thống: " + idNumber);
            
            Guest guest = new Guest(tenKH, gioiTinh, ngaySinh, sdt, email, idType, idNumber, diaChi, maLKH, isActive, createdBy);
            var dalAddResult = dal.AddGuest(guest);
            if (!dalAddResult.Success)
                return OperationResult<bool>.Fail(dalAddResult.ErrorMessage);
            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateGuestBAL(string maKH, string tenKH, string gioiTinh, DateTime ngaySinh, 
            string sdt, string email, string idType, string idNumber, string diaChi, string maLKH, 
            string updatedBy, DateTime updateAt, bool isActive)
        {
            var result = dal.GetGuest(id: idNumber);
            if (!result.Success) return OperationResult<bool>.Fail(result.ErrorMessage);
            if (result.Data.Rows.Count > 0)
            {
                var existingMaKH = result.Data.Rows[0]["MaKH"]?.ToString();
                if (existingMaKH != maKH)
                    return OperationResult<bool>.Fail("Số CMND/HChiếu đã tồn tại trong hệ thống: " + idNumber);
            }
            
            Guest guest = new Guest()
            {
                MaKH = maKH,
                HoTen = tenKH,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinh,
                SDT = sdt,
                Email = email,
                IDType = idType,
                IDNumber = idNumber,
                DiaChi = diaChi,
                MaLKH = maLKH,
                UpdatedAt = updateAt,
                UpdatedBy = updatedBy,
                IsActive = isActive
            };
            
            var dalUpdateResult = dal.UpdateGuest(guest);
            if (!dalUpdateResult.Success)
                return OperationResult<bool>.Fail(dalUpdateResult.ErrorMessage);
            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteGuestBAL(string maKH)
        {
            var dalDeleteResult = dal.DeleteGuest(maKH);
            if (!dalDeleteResult.Success)
                return OperationResult<bool>.Fail(dalDeleteResult.ErrorMessage);
            return OperationResult<bool>.Ok(true);
        }
    }
}

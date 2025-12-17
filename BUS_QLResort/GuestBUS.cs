using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using DAL_QLResort.Guest_F;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QLResort
{
    public class GuestBUS
    {
        private readonly GuestDAL dal = new GuestDAL();

        public OperationResult<List<GuestM>> GetGuests(string maKH = null, string tenKH = null, string gioiTinh = null, 
            string sdt = null, string id = null, string maLoaiKH = null, bool? isActive = null)
        {
            var dalResult = dal.GetGuest(maKH, tenKH, gioiTinh, sdt, id, maLoaiKH, isActive);
            if (!dalResult.Success)
                return OperationResult<List<GuestM>>.Fail(dalResult.ErrorMessage);
            try
            {
                List<GuestM> list = new List<GuestM>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapGuest(row));
                }
                return OperationResult<List<GuestM>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<GuestM>>.Fail("Lỗi khi xử lý dữ liệu khách hàng: " + ex.Message);
            }
        }

        private GuestM MapGuest(DataRow row)
        {
            return new GuestM()
            {
                MaKH = row["MaKH"]?.ToString(),
                HoTen = row["HoTen"]?.ToString(),
                GioiTinh = row["GioiTinh"]?.ToString(),
                NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                SDT = row["SDT"]?.ToString(),
                Email = row["Email"]?.ToString(),
                IDType = row["IDType"]?.ToString(),
                IDNumber = row["IDNumber"]?.ToString(),
                DiaChi = row["DiaChi"]?.ToString(),
                MaLKH = row["MaLKH"]?.ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]),
                UpdatedBy = row["UpdatedBy"] == DBNull.Value ? null : row["UpdatedBy"]?.ToString()
            };
        }

        public OperationResult<bool> AddGuestBAL(string tenKH, string gioiTinh, DateTime ngaySinh, string sdt, string email, 
            string idType, string idNumber, string diaChi, string maLKH, string createdBy, bool isActive)
        {
            var result = dal.GetGuest(id: idNumber);
            if (!result.Success) return OperationResult<bool>.Fail(result.ErrorMessage);
            if (result.Data.Rows.Count > 0) return OperationResult<bool>.Fail("Số CMND/HChiếu đã tồn tại trong hệ thống: " + idNumber);
            
            GuestM guest = new GuestM(tenKH, gioiTinh, ngaySinh, sdt, email, idType, idNumber, diaChi, maLKH, isActive, createdBy);
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
            
            GuestM guest = new GuestM()
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


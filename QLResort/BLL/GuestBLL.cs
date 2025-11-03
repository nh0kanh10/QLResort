using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.Guest_F;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.BLL
{
    internal class GuestBLL
    {
        private GuestDAL dal = new GuestDAL();
        public OperationResult<List<Guest>> GetGuests(string maKH = null, string tenKH = null, string gioiTinh = null, string sdt = null, string id = null, string maLoaiKH = null, bool? isActive = null)
        {
            var dalResult = dal.GetGuest(maKH, tenKH, gioiTinh, sdt, id, maLoaiKH, isActive);
            if (!dalResult.Success)
                return OperationResult<List<Guest>>.Fail(dalResult.ErrorMessage);
            try
            {
                List<Guest> list = new List<Guest>();
                foreach (System.Data.DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapGuest(row));
                }
                return OperationResult<List<Guest>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Guest>>.Fail("Lỗi khi xử lý dữ liệu khách hàng: " + ex.Message);
            }
        }
        /// <summary>
        /// function add guest 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public OperationResult<bool>AddGuestBAL(string tenKH,string gioiTinh,DateTime ngaySinh,string sdt,string email,string idType,string idNumber, string diaChi,string maLKH,
        string createdBy,bool isActive)
        {
           var result = dal.GetGuest(id:idNumber);
           if (!result.Success) return OperationResult<bool>.Fail(result.ErrorMessage);
           if(result.Data.Rows.Count > 0) return OperationResult<bool>.Fail("Số CMND/HChiếu đã tồn tại trong hệ thống: " + idNumber);
           

        }
        public Guest MapGuest(DataRow row)
        {
            Guest guest = new Guest();
            guest.MaKH = row["MaKH"]?.ToString();
            guest.HoTen = row["HoTen"]?.ToString();
            guest.GioiTinh = row["GioiTinh"]?.ToString();
            guest.NgaySinh = row["NgaySinh"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["NgaySinh"]);
            guest.SDT = row["SDT"]?.ToString();
            guest.Email = row["Email"]?.ToString();
            guest.IDType = row["IDType"]?.ToString();
            guest.IDNumber = row["IDNumber"]?.ToString();
            guest.DiaChi = row["DiaChi"]?.ToString();
            guest.MaLKH = row["MaLKH"]?.ToString();
            guest.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
            guest.UpdatedAt = row["UpdatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UpdatedAt"]);
            guest.CreatedBy = row["CreatedBy"]?.ToString();
            guest.UpdatedBy = row["UpdatedBy"]?.ToString();
            guest.IsActive = Convert.ToBoolean(row["IsActive"]);
            return guest;
        }
    }
}

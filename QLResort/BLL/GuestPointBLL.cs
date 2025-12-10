using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.GuestPointDAL;
using System;
using System.Data;
using QLResort.Core.ClassHoTro;

namespace QLResort.BLL
{
    public class GuestPointBLL
    {
        private readonly GuestPointDAL guestPointDAL = new GuestPointDAL();

        public OperationResult<GuestPoint> GetGuestPoint(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return OperationResult<GuestPoint>.Fail("Mã khách hàng không được để trống");

            var dalResult = guestPointDAL.GetGuestPoint(maKH);

            if (!dalResult.Success)
                return OperationResult<GuestPoint>.Fail(dalResult.ErrorMessage);

            try
            {
                if (dalResult.Data.Rows.Count == 0)
                {
                    // Nếu chưa có điểm, trả về điểm 0
                    return OperationResult<GuestPoint>.Ok(new GuestPoint
                    {
                        MaKH = maKH,
                        DiemHienTai = 0,
                        CapNhatLuc = DateTime.Now,
                        CreatedAt = DateTime.Now
                    });
                }

                DataRow row = dalResult.Data.Rows[0];
                GuestPoint point = new GuestPoint
                {
                    MaKH = row["MaKH"]?.ToString() ?? maKH,
                    DiemHienTai = row["DiemHienTai"] != DBNull.Value ? Convert.ToInt32(row["DiemHienTai"]) : 0,
                    CapNhatLuc = row["CapNhatLuc"] != DBNull.Value ? Convert.ToDateTime(row["CapNhatLuc"]) : DateTime.Now,
                    CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                    CreatedBy = row["CreatedBy"]?.ToString(),
                    UpdatedBy = row["UpdatedBy"]?.ToString(),
                    UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
                };

                return OperationResult<GuestPoint>.Ok(point);
            }
            catch (Exception ex)
            {
                return OperationResult<GuestPoint>.Fail($"Lỗi khi xử lý dữ liệu điểm khách hàng: {ex.Message}");
            }
        }

        public OperationResult<bool> DeductPoints(string maKH, int diemTru, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return OperationResult<bool>.Fail("Mã khách hàng không được để trống");

            if (diemTru <= 0)
                return OperationResult<bool>.Fail("Số điểm trừ phải lớn hơn 0");

            // Kiểm tra điểm hiện tại
            var pointResult = GetGuestPoint(maKH);
            if (!pointResult.Success)
                return OperationResult<bool>.Fail(pointResult.ErrorMessage);

            if (pointResult.Data.DiemHienTai < diemTru)
                return OperationResult<bool>.Fail($"Không đủ điểm. Điểm hiện tại: {pointResult.Data.DiemHienTai}, cần: {diemTru}");

            var result = guestPointDAL.DeductPoints(maKH, diemTru, ghiChu, Session_Now.CurrentUser, Session_Now.CurrentUser);
            return result;
        }
    }
}


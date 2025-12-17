using Tool_QLResort.Extensions;
using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using DAL_QLResort.LostFoundDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QLResort
{
    public class LostFoundBUS
    {
        private readonly LostFoundDAL lostFoundDAL = new LostFoundDAL();

        public OperationResult<List<LostFoundItem>> GetLostFoundItems(string maLF = null, string maKH = null,
            string maNV = null, string maCN = null, string trangThai = null)
        {
            var dalResult = lostFoundDAL.GetLostFound(maLF, maKH, maNV, maCN, trangThai);

            if (!dalResult.Success)
                return OperationResult<List<LostFoundItem>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<LostFoundItem> list = new List<LostFoundItem>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapLostFoundItem(row));
                }
                return OperationResult<List<LostFoundItem>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<LostFoundItem>>.Fail($"Lỗi khi xử lý dữ liệu đồ thất lạc: {ex.Message}");
            }
        }

        public OperationResult<bool> AddLostFoundItem(
            string tenDo,
            string maNV,
            string maCN,
            DateTime ngayTimThay,
            string diaDiemTim = null,
            string maKH = null,
            string ghiChu = null)
        {
            if (string.IsNullOrWhiteSpace(tenDo))
                return OperationResult<bool>.Fail("Tên đồ không được để trống");

            if (string.IsNullOrWhiteSpace(maNV))
                return OperationResult<bool>.Fail("Mã nhân viên không được để trống");

            if (string.IsNullOrWhiteSpace(maCN))
                return OperationResult<bool>.Fail("Mã chi nhánh không được để trống");

            string maLF = GenerateMaLF();

            LostFoundItem item = new LostFoundItem
            {
                MaLF = maLF,
                TenDo = tenDo,
                MaNV = maNV,
                MaCN = maCN,
                NgayTimThay = ngayTimThay,
                DiaDiemTim = diaDiemTim,
                MaKH = maKH,
                TrangThai = "Chưa trả",
                GhiChu = ghiChu,
                CreatedAt = DateTime.Now
            };

            var dalResult = lostFoundDAL.Insert(item);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateLostFoundItem(
            string maLF,
            string maKH = null,
            string trangThai = null,
            DateTime? ngayTra = null,
            string nguoiNhan = null,
            string ghiChu = null)
        {
            if (string.IsNullOrWhiteSpace(maLF))
                return OperationResult<bool>.Fail("Mã đồ thất lạc không hợp lệ");

            if (!lostFoundDAL.Exists(maLF))
                return OperationResult<bool>.Fail("Đồ thất lạc không tồn tại");

            LostFoundItem item = new LostFoundItem
            {
                MaLF = maLF,
                MaKH = maKH,
                TrangThai = trangThai,
                NgayTra = ngayTra,
                NguoiNhan = nguoiNhan,
                GhiChu = ghiChu,
                UpdatedAt = DateTime.Now
            };

            var dalResult = lostFoundDAL.Update(item);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteLostFoundItem(string maLF)
        {
            if (string.IsNullOrWhiteSpace(maLF))
                return OperationResult<bool>.Fail("Mã đồ thất lạc không hợp lệ");

            if (!lostFoundDAL.Exists(maLF))
                return OperationResult<bool>.Fail("Đồ thất lạc không tồn tại");

            // Soft delete - update IsActive = 0
            LostFoundItem item = new LostFoundItem
            {
                MaLF = maLF,
                IsActive = false,
                UpdatedAt = DateTime.Now
            };

            // Note: Cần thêm method UpdateIsActive vào DAL hoặc sử dụng Update
            // Tạm thời sử dụng cách đơn giản: update trạng thái thành "Hủy"
            var updateResult = UpdateLostFoundItem(maLF, null, "Hủy", null, null, "Đã xóa");
            if (!updateResult.Success)
                return OperationResult<bool>.Fail(updateResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaLF()
        {
            var items = GetLostFoundItems();
            int maxNumber = 0;

            if (items.Success && items.Data.Count > 0)
            {
                foreach (var item in items.Data)
                {
                    if (item.MaLF.StartsWith("LF") && item.MaLF.Length > 2)
                    {
                        if (int.TryParse(item.MaLF.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"LF{(maxNumber + 1):D3}";
        }

        private LostFoundItem MapLostFoundItem(DataRow row)
        {
            return new LostFoundItem
            {
                MaLF = row.GetString("MaLF", ""),
                MaKH = row.GetString("MaKH"),
                MaNV = row.GetString("MaNV", ""),
                MaCN = row.GetString("MaCN", ""),
                TenDo = row.GetString("TenDo", ""),
                NgayTimThay = row.GetNullableDateTime("NgayTimThay") ?? DateTime.Now,
                DiaDiemTim = row.GetString("DiaDiemTim"),
                TrangThai = row.GetString("TrangThai", "Chưa trả"),
                NgayTra = row.GetNullableDateTime("NgayTra"),
                NguoiNhan = row.GetString("NguoiNhan"),
                GhiChu = row.GetString("GhiChu"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                UpdatedAt = row.GetNullableDateTime("UpdatedAt")
            };
        }
    }
}







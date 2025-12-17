using Tool_QLResort.Extensions;
using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using DAL_QLResort.EventPackageDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QLResort
{
    public class EventPackageBUS
    {
        private readonly EventPackageDAL eventPackageDAL = new EventPackageDAL();

        public OperationResult<List<EventPackage>> GetEventPackages(string maGoiSK = null, string maSK = null,
            string maCN = null, bool? isGoiMacDinh = null, bool? isActive = null)
        {
            var dalResult = eventPackageDAL.GetEventPackages(maGoiSK, maSK, maCN, isGoiMacDinh, isActive);

            if (!dalResult.Success)
                return OperationResult<List<EventPackage>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<EventPackage> list = new List<EventPackage>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapEventPackage(row));
                }
                return OperationResult<List<EventPackage>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<EventPackage>>.Fail($"Lỗi khi xử lý dữ liệu gói sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> AddEventPackage(
            string tenGoiSK,
            string maSK,
            decimal giaCoBan,
            int soKhachToiThieu = 10,
            int? soKhachToiDa = null,
            int? thoiGianToiThieu = null,
            int? thoiGianToiDa = null,
            string moTa = null,
            string dichVuKemTheo = null,
            string maCN = null,
            bool isGoiMacDinh = false,
            bool isActive = true)
        {
            if (string.IsNullOrWhiteSpace(tenGoiSK))
                return OperationResult<bool>.Fail("Tên gói sự kiện không được để trống");

            if (string.IsNullOrWhiteSpace(maSK))
                return OperationResult<bool>.Fail("Loại sự kiện không được để trống");

            string maGoiSK = GenerateMaGoiSK();

            EventPackage package = new EventPackage
            {
                MaGoiSK = maGoiSK,
                TenGoiSK = tenGoiSK,
                MaSK = maSK,
                MoTa = moTa,
                GiaCoBan = giaCoBan,
                SoKhachToiThieu = soKhachToiThieu,
                SoKhachToiDa = soKhachToiDa,
                ThoiGianToiThieu = thoiGianToiThieu,
                ThoiGianToiDa = thoiGianToiDa,
                DichVuKemTheo = dichVuKemTheo,
                IsGoiMacDinh = isGoiMacDinh,
                MaCN = maCN,
                IsActive = isActive,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = eventPackageDAL.Insert(package);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateEventPackage(
            string maGoiSK,
            string tenGoiSK = null,
            string moTa = null,
            decimal? giaCoBan = null,
            int? soKhachToiThieu = null,
            int? soKhachToiDa = null,
            int? thoiGianToiThieu = null,
            int? thoiGianToiDa = null,
            string dichVuKemTheo = null,
            string maCN = null,
            bool? isActive = null)
        {
            if (string.IsNullOrWhiteSpace(maGoiSK))
                return OperationResult<bool>.Fail("Mã gói sự kiện không hợp lệ");

            if (!eventPackageDAL.Exists(maGoiSK))
                return OperationResult<bool>.Fail("Gói sự kiện không tồn tại");

            var existing = GetEventPackages(maGoiSK: maGoiSK);
            if (!existing.Success || existing.Data.Count == 0)
                return OperationResult<bool>.Fail("Gói sự kiện không tồn tại");

            EventPackage package = existing.Data[0];
            package.TenGoiSK = tenGoiSK ?? package.TenGoiSK;
            package.MoTa = moTa ?? package.MoTa;
            package.GiaCoBan = giaCoBan ?? package.GiaCoBan;
            package.SoKhachToiThieu = soKhachToiThieu ?? package.SoKhachToiThieu;
            package.SoKhachToiDa = soKhachToiDa ?? package.SoKhachToiDa;
            package.ThoiGianToiThieu = thoiGianToiThieu ?? package.ThoiGianToiThieu;
            package.ThoiGianToiDa = thoiGianToiDa ?? package.ThoiGianToiDa;
            package.DichVuKemTheo = dichVuKemTheo ?? package.DichVuKemTheo;
            package.MaCN = maCN ?? package.MaCN;
            package.IsActive = isActive ?? package.IsActive;
            package.UpdatedAt = DateTime.Now;
            package.UpdatedBy = Session_Now.CurrentUser;

            var dalResult = eventPackageDAL.Update(package);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaGoiSK()
        {
            var packages = GetEventPackages();
            int maxNumber = 0;

            if (packages.Success && packages.Data.Count > 0)
            {
                foreach (var pkg in packages.Data)
                {
                    if (pkg.MaGoiSK.StartsWith("GOI") && pkg.MaGoiSK.Length > 3)
                    {
                        if (int.TryParse(pkg.MaGoiSK.Substring(3), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"GOI{(maxNumber + 1):D3}";
        }

        private EventPackage MapEventPackage(DataRow row)
        {
            return new EventPackage
            {
                MaGoiSK = row.GetString("MaGoiSK", ""),
                TenGoiSK = row.GetString("TenGoiSK", ""),
                MaSK = row.GetString("MaSK", ""),
                MoTa = row.GetString("MoTa"),
                GiaCoBan = row.GetNullableDecimal("GiaCoBan")??0,
                SoKhachToiThieu = row.GetNullableInt("SoKhachToiThieu")??10,
                SoKhachToiDa = row.GetNullableInt("SoKhachToiDa"),
                ThoiGianToiThieu = row.GetNullableInt("ThoiGianToiThieu"),
                ThoiGianToiDa = row.GetNullableInt("ThoiGianToiDa"),
                DichVuKemTheo = row.GetString("DichVuKemTheo"),
                IsGoiMacDinh = row.GetBool("IsGoiMacDinh", false),
                MaCN = row.GetString("MaCN"),
                TenCN = row.GetString("TenCN"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                CreatedBy = row.GetString("CreatedBy"),
                UpdatedAt = row.GetNullableDateTime("UpdatedAt"),
                UpdatedBy = row.GetString("UpdatedBy"),
                IsActive = row.GetBool("IsActive", true)
            };
        }
    }
}







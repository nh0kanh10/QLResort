using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.EventPackageDAL
{
    public class EventPackageDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetEventPackages(string maGoiSK = null, string loaiSuKien = null,
            string maCN = null, bool? isGoiMacDinh = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaGoiSK", maGoiSK),
                    SqlParameterHelper.Create("@LoaiSuKien", loaiSuKien),
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@IsGoiMacDinh", isGoiMacDinh),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.EventPackage.GetGoiSuKien, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách gói sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(EventPackage package)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaGoiSK", package.MaGoiSK),
                    SqlParameterHelper.Create("@TenGoiSK", package.TenGoiSK),
                    SqlParameterHelper.Create("@LoaiSuKien", package.LoaiSuKien),
                    SqlParameterHelper.Create("@MoTa", package.MoTa),
                    SqlParameterHelper.Create("@GiaCoBan", package.GiaCoBan),
                    SqlParameterHelper.Create("@SoKhachToiThieu", package.SoKhachToiThieu),
                    SqlParameterHelper.Create("@SoKhachToiDa", package.SoKhachToiDa),
                    SqlParameterHelper.Create("@ThoiGianToiThieu", package.ThoiGianToiThieu),
                    SqlParameterHelper.Create("@ThoiGianToiDa", package.ThoiGianToiDa),
                    SqlParameterHelper.Create("@DichVuKemTheo", package.DichVuKemTheo),
                    SqlParameterHelper.Create("@IsGoiMacDinh", package.IsGoiMacDinh),
                    SqlParameterHelper.Create("@MaCN", package.MaCN),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", package.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.EventPackage.InsertGoiSuKien, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");

                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm gói sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(EventPackage package)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaGoiSK", package.MaGoiSK),
                    SqlParameterHelper.Create("@TenGoiSK", package.TenGoiSK),
                    SqlParameterHelper.Create("@MoTa", package.MoTa),
                    SqlParameterHelper.Create("@GiaCoBan", package.GiaCoBan),
                    SqlParameterHelper.Create("@SoKhachToiThieu", package.SoKhachToiThieu),
                    SqlParameterHelper.Create("@SoKhachToiDa", package.SoKhachToiDa),
                    SqlParameterHelper.Create("@ThoiGianToiThieu", package.ThoiGianToiThieu),
                    SqlParameterHelper.Create("@ThoiGianToiDa", package.ThoiGianToiDa),
                    SqlParameterHelper.Create("@DichVuKemTheo", package.DichVuKemTheo),
                    SqlParameterHelper.Create("@MaCN", package.MaCN),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", package.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.EventPackage.UpdateGoiSuKien, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật gói sự kiện: {ex.Message}");
            }
        }

        public bool Exists(string maGoiSK)
        {
            try
            {
                var result = GetEventPackages(maGoiSK: maGoiSK);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}


using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.PromotionDAL
{
    public class PromotionDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetPromotions(string maKM = null, string couponCode = null, string maCN = null, string maLKH = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKM", maKM),
                    SqlParameterHelper.Create("@IsActive", isActive),
                    SqlParameterHelper.Create("@NgayHienTai", (DateTime?)null)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Promotion.GetKhuyenMai, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách khuyến mãi: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Promotion promotion)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKM", promotion.MaKM),
                    SqlParameterHelper.Create("@TenKM", promotion.TenKM),
                    SqlParameterHelper.Create("@IsPhanTram", promotion.IsPhanTram),
                    SqlParameterHelper.Create("@GiaTri", promotion.GiaTri),
                    SqlParameterHelper.Create("@MaLKH", promotion.MaLKH),
                    SqlParameterHelper.Create("@MaCN", promotion.MaCN),
                    SqlParameterHelper.Create("@MaLP", promotion.MaLP),
                    SqlParameterHelper.Create("@MaPhong", promotion.MaPhong),
                    SqlParameterHelper.Create("@CouponCode", promotion.CouponCode),
                    SqlParameterHelper.Create("@NgayBD", promotion.NgayBD),
                    SqlParameterHelper.Create("@NgayKT", promotion.NgayKT),
                    SqlParameterHelper.Create("@DieuKien", promotion.DieuKien),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", promotion.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Promotion.InsertKhuyenMai, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm khuyến mãi: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Promotion promotion)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKM", promotion.MaKM),
                    SqlParameterHelper.Create("@TenKM", promotion.TenKM),
                    SqlParameterHelper.Create("@IsPhanTram", promotion.IsPhanTram),
                    SqlParameterHelper.Create("@GiaTri", promotion.GiaTri),
                    SqlParameterHelper.Create("@MaLKH", promotion.MaLKH),
                    SqlParameterHelper.Create("@MaCN", promotion.MaCN),
                    SqlParameterHelper.Create("@MaLP", promotion.MaLP),
                    SqlParameterHelper.Create("@MaPhong", promotion.MaPhong),
                    SqlParameterHelper.Create("@CouponCode", promotion.CouponCode),
                    SqlParameterHelper.Create("@NgayBD", promotion.NgayBD),
                    SqlParameterHelper.Create("@NgayKT", promotion.NgayKT),
                    SqlParameterHelper.Create("@DieuKien", promotion.DieuKien),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", promotion.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Promotion.UpdateKhuyenMai, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật khuyến mãi: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maKM)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKM", maKM)
                };
                
                fastQuery.ExecuteNonQueryProc(StoredProcedures.Promotion.DeleteKhuyenMai, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa khuyến mãi: {ex.Message}");
            }
        }
    }
}



using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.VoucherDAL
{
    public class VoucherDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetVouchers(string maVoucher = null, string couponCode = null,
            string maLKH = null, string maCN = null, string trangThai = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaVoucher", maVoucher),
                    SqlParameterHelper.Create("@CouponCode", couponCode),
                    SqlParameterHelper.Create("@MaLKH", maLKH),
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Voucher.GetVoucher, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách voucher: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Voucher voucher)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaVoucher", voucher.MaVoucher),
                    SqlParameterHelper.Create("@TenVoucher", voucher.TenVoucher),
                    SqlParameterHelper.Create("@CouponCode", voucher.CouponCode),
                    SqlParameterHelper.Create("@IsPhanTram", voucher.IsPhanTram),
                    SqlParameterHelper.Create("@GiaTri", voucher.GiaTri),
                    SqlParameterHelper.Create("@SoLuong", voucher.SoLuong),
                    SqlParameterHelper.Create("@MaLKH", voucher.MaLKH),
                    SqlParameterHelper.Create("@MaCN", voucher.MaCN),
                    SqlParameterHelper.Create("@MaLP", voucher.MaLP),
                    SqlParameterHelper.Create("@MaPhong", voucher.MaPhong),
                    SqlParameterHelper.Create("@NgayBD", voucher.NgayBD),
                    SqlParameterHelper.Create("@NgayKT", voucher.NgayKT),
                    SqlParameterHelper.Create("@DieuKien", voucher.DieuKien),
                    SqlParameterHelper.Create("@TrangThai", voucher.TrangThai),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", voucher.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Voucher.InsertVoucher, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm voucher: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Voucher voucher)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaVoucher", voucher.MaVoucher),
                    SqlParameterHelper.Create("@TenVoucher", voucher.TenVoucher),
                    SqlParameterHelper.Create("@IsPhanTram", voucher.IsPhanTram),
                    SqlParameterHelper.Create("@GiaTri", voucher.GiaTri),
                    SqlParameterHelper.Create("@SoLuong", voucher.SoLuong),
                    SqlParameterHelper.Create("@NgayBD", voucher.NgayBD),
                    SqlParameterHelper.Create("@NgayKT", voucher.NgayKT),
                    SqlParameterHelper.Create("@DieuKien", voucher.DieuKien),
                    SqlParameterHelper.Create("@TrangThai", voucher.TrangThai),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", voucher.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Voucher.UpdateVoucher, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật voucher: {ex.Message}");
            }
        }

        public bool Exists(string maVoucher)
        {
            try
            {
                var result = GetVouchers(maVoucher: maVoucher);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}


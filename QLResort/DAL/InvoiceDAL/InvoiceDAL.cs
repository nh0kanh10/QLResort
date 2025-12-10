using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.InvoiceDAL
{
    public class InvoiceDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetInvoices(string maHD = null, string maDP = null, string maKH = null, string maCN = null, string trangThai = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaHD", maHD),
                    SqlParameterHelper.Create("@MaDP", maDP),
                    SqlParameterHelper.Create("@MaKH", maKH),
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Invoice.GetHoaDon, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách hóa đơn: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Invoice invoice)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaHD", invoice.MaHD),
                    SqlParameterHelper.Create("@MaDP", invoice.MaDP),
                    SqlParameterHelper.Create("@MaKH", invoice.MaKH),
                    SqlParameterHelper.Create("@MaNV", invoice.MaNV),
                    SqlParameterHelper.Create("@MaKM", invoice.MaKM),

                    SqlParameterHelper.Create("@MaCN", invoice.MaCN),
                    SqlParameterHelper.Create("@TrangThai", invoice.TrangThai, SqlDbType.NVarChar), // Fix encoding
                    SqlParameterHelper.Create("@NgayLap", invoice.NgayLap),
                    SqlParameterHelper.Create("@TongTruocKM", invoice.TongTruocKM),
                    SqlParameterHelper.Create("@TongTien", invoice.TongTien),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", invoice.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Invoice.InsertHoaDon, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm hóa đơn: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Invoice invoice)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaHD", invoice.MaHD),
                    SqlParameterHelper.Create("@MaKM", invoice.MaKM),
                    SqlParameterHelper.Create("@TrangThai", invoice.TrangThai, SqlDbType.NVarChar), // Fix encoding
                    SqlParameterHelper.Create("@TongTruocKM", invoice.TongTruocKM),
                    SqlParameterHelper.Create("@TongTien", invoice.TongTien),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", invoice.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Invoice.UpdateHoaDon, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật hóa đơn: {ex.Message}");
            }
        }

        public OperationResult<DataTable> GetInvoiceDetails(string maCTHD = null, string maHD = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTHD", maCTHD),
                    SqlParameterHelper.Create("@MaHD", maHD),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Invoice.GetCTHoaDon, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy chi tiết hóa đơn: {ex.Message}");
            }
        }

        public OperationResult<bool> InsertInvoiceDetail(InvoiceDetail detail)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCTHD", detail.MaCTHD),
                    SqlParameterHelper.Create("@MaHD", detail.MaHD),
                    SqlParameterHelper.Create("@MoTa", detail.MoTa),
                    SqlParameterHelper.Create("@SoLuong", detail.SoLuong),
                    SqlParameterHelper.Create("@DonGia", detail.DonGia),
                    SqlParameterHelper.Create("@ThanhTien", detail.ThanhTien),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", detail.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Invoice.InsertCTHoaDon, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm chi tiết hóa đơn: {ex.Message}");
            }
        }
    }
}



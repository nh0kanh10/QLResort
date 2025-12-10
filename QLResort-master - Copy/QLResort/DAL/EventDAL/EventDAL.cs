using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.EventDAL
{
    public class EventDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetEvents(string maSK = null, string maCN = null, 
            string loaiSuKien = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaSK", maSK),
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@LoaiSuKien", loaiSuKien),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Event.GetSuKien, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Event evt)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaSK", evt.MaSK),
                    SqlParameterHelper.Create("@TenSK", evt.TenSK),
                    SqlParameterHelper.Create("@LoaiSuKien", evt.LoaiSuKien),
                    SqlParameterHelper.Create("@MaCN", evt.MaCN),
                    SqlParameterHelper.Create("@DiaDiem", evt.DiaDiem),
                    SqlParameterHelper.Create("@GhiChu", evt.GhiChu),
                    SqlParameterHelper.Create("@TongChiPhi", evt.TongChiPhi),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", evt.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Event.InsertSuKien, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm sự kiện: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Event evt)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaSK", evt.MaSK),
                    SqlParameterHelper.Create("@TenSK", evt.TenSK),
                    SqlParameterHelper.Create("@LoaiSuKien", evt.LoaiSuKien),
                    SqlParameterHelper.Create("@DiaDiem", evt.DiaDiem),
                    SqlParameterHelper.Create("@GhiChu", evt.GhiChu),
                    SqlParameterHelper.Create("@TongChiPhi", evt.TongChiPhi),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", evt.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Event.UpdateSuKien, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật sự kiện: {ex.Message}");
            }
        }

        public bool Exists(string maSK)
        {
            try
            {
                var result = GetEvents(maSK: maSK);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}


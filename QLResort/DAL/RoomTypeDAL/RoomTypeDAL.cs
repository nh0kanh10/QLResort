using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.RoomTypeDAL
{
    public class RoomTypeDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetRoomTypes(string maLP = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLP", maLP),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.RoomType.GetLoaiPhong, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách loại phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(RoomType roomType)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLP", roomType.MaLP),
                    SqlParameterHelper.Create("@TenLP", roomType.TenLP),
                    SqlParameterHelper.Create("@MoTa", roomType.MoTa),
                    SqlParameterHelper.Create("@IsNhaNguyenCan", roomType.IsNhaNguyenCan),
                    SqlParameterHelper.Create("@SoPhongTrongNha", roomType.SoPhongTrongNha),
                    SqlParameterHelper.Create("@GiaTheoGio", roomType.GiaTheoGio),
                    SqlParameterHelper.Create("@GiaTheoNgay", roomType.GiaTheoNgay),
                    SqlParameterHelper.Create("@GiaTheoThang", roomType.GiaTheoThang),
                    SqlParameterHelper.Create("@SucChuaToiDa", roomType.SucChuaToiDa),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", roomType.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.RoomType.InsertLoaiPhong, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm loại phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(RoomType roomType)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLP", roomType.MaLP),
                    SqlParameterHelper.Create("@TenLP", roomType.TenLP),
                    SqlParameterHelper.Create("@MoTa", roomType.MoTa),
                    SqlParameterHelper.Create("@IsNhaNguyenCan", roomType.IsNhaNguyenCan),
                    SqlParameterHelper.Create("@SoPhongTrongNha", roomType.SoPhongTrongNha),
                    SqlParameterHelper.Create("@GiaTheoGio", roomType.GiaTheoGio),
                    SqlParameterHelper.Create("@GiaTheoNgay", roomType.GiaTheoNgay),
                    SqlParameterHelper.Create("@GiaTheoThang", roomType.GiaTheoThang),
                    SqlParameterHelper.Create("@SucChuaToiDa", roomType.SucChuaToiDa),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", roomType.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.RoomType.UpdateLoaiPhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật loại phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maLP)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLP", maLP)
                };
                
                fastQuery.ExecuteNonQueryProc(StoredProcedures.RoomType.DeleteLoaiPhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa loại phòng: {ex.Message}");
            }
        }

        public bool Exists(string maLP)
        {
            try
            {
                var result = GetRoomTypes(maLP: maLP);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}








using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLResort.RoomDAL
{
    public class RoomImageDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetRoomImages(string maAnh = null, string maPhong = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaAnh", maAnh),
                    SqlParameterHelper.Create("@MaPhong", maPhong),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.RoomImage.GetHinhAnhPhong, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách ảnh phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(RoomImage roomImage)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaAnh", roomImage.MaAnh),
                    SqlParameterHelper.Create("@MaPhong", roomImage.MaPhong),
                    SqlParameterHelper.Create("@DuongDan", roomImage.DuongDan),
                    SqlParameterHelper.Create("@GhiChu", roomImage.GhiChu),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", roomImage.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.RoomImage.InsertHinhAnhPhong, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm ảnh phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(RoomImage roomImage)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaAnh", roomImage.MaAnh),
                    SqlParameterHelper.Create("@DuongDan", roomImage.DuongDan),
                    SqlParameterHelper.Create("@GhiChu", roomImage.GhiChu),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", roomImage.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.RoomImage.UpdateHinhAnhPhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật ảnh phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maAnh)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaAnh", maAnh)
                };
                
                fastQuery.ExecuteNonQueryProc(StoredProcedures.RoomImage.DeleteHinhAnhPhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa ảnh phòng: {ex.Message}");
            }
        }
    }
}






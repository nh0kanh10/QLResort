using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.RoomDAL
{
    public class RoomDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetRooms(string maPhong = null, string maCN = null, string maLP = null, string trangThai = null, bool? isActive = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaPhong", maPhong),
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@MaLP", maLP),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@IsActive", isActive)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Room.GetPhong, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Room room)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaPhong", room.MaPhong),
                    SqlParameterHelper.Create("@MaCN", room.MaCN),
                    SqlParameterHelper.Create("@MaLP", room.MaLP),
                    SqlParameterHelper.Create("@SoPhong", room.SoPhong),
                    SqlParameterHelper.Create("@ViTri", room.ViTri),
                    SqlParameterHelper.Create("@TrangThai", room.TrangThai),
                    SqlParameterHelper.Create("@GhiChu", room.GhiChu),
                    SqlParameterHelper.Create("@CreatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", room.IsActive)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.Room.InsertPhong, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Room room)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaPhong", room.MaPhong),
                    SqlParameterHelper.Create("@MaCN", room.MaCN),
                    SqlParameterHelper.Create("@MaLP", room.MaLP),
                    SqlParameterHelper.Create("@SoPhong", room.SoPhong),
                    SqlParameterHelper.Create("@ViTri", room.ViTri),
                    SqlParameterHelper.Create("@TrangThai", room.TrangThai),
                    SqlParameterHelper.Create("@GhiChu", room.GhiChu),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser),
                    SqlParameterHelper.Create("@IsActive", room.IsActive)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Room.UpdatePhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật phòng: {ex.Message}");
            }
        }

        public OperationResult<bool> Delete(string maPhong)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaPhong", maPhong)
                };
                
                fastQuery.ExecuteNonQueryProc(StoredProcedures.Room.DeletePhong, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi xóa phòng: {ex.Message}");
            }
        }

        public bool Exists(string maPhong)
        {
            try
            {
                var result = GetRooms(maPhong: maPhong);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}








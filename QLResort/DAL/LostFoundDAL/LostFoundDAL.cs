using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.LostFoundDAL
{
    public class LostFoundDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetLostFound(string maLF = null, string maKH = null, 
            string maNV = null, string maCN = null, string trangThai = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLF", maLF),
                    SqlParameterHelper.Create("@MaKH", maKH),
                    SqlParameterHelper.Create("@MaNV", maNV),
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@TrangThai", trangThai)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.LostFound.GetLostFound, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách đồ thất lạc: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(LostFoundItem item)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLF", item.MaLF),
                    SqlParameterHelper.Create("@MaKH", item.MaKH),
                    SqlParameterHelper.Create("@MaNV", item.MaNV),
                    SqlParameterHelper.Create("@MaCN", item.MaCN),
                    SqlParameterHelper.Create("@TenDo", item.TenDo),
                    SqlParameterHelper.Create("@NgayTimThay", item.NgayTimThay),
                    SqlParameterHelper.Create("@DiaDiemTim", item.DiaDiemTim),
                    SqlParameterHelper.Create("@TrangThai", item.TrangThai),
                    SqlParameterHelper.Create("@GhiChu", item.GhiChu)
                };

                int result = fastQuery.ExecuteNonQueryProc(StoredProcedures.LostFound.InsertLostFound, parameters);
                if (result <= 0)
                    return OperationResult<bool>.Fail("Không có dữ liệu nào được thêm.");
                
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm đồ thất lạc: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(LostFoundItem item)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaLF", item.MaLF),
                    SqlParameterHelper.Create("@MaKH", item.MaKH),
                    SqlParameterHelper.Create("@TrangThai", item.TrangThai),
                    SqlParameterHelper.Create("@NgayTra", item.NgayTra),
                    SqlParameterHelper.Create("@NguoiNhan", item.NguoiNhan),
                    SqlParameterHelper.Create("@GhiChu", item.GhiChu),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.LostFound.UpdateLostFound, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật đồ thất lạc: {ex.Message}");
            }
        }

        public bool Exists(string maLF)
        {
            try
            {
                var result = GetLostFound(maLF: maLF);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}


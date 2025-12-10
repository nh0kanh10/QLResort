using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.DAL.ComplaintDAL
{
    public class ComplaintDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public OperationResult<DataTable> GetComplaints(string maKN = null, string maKH = null, 
            string maNV = null, string maCN = null, string trangThai = null, string mucDo = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKN", maKN),
                    SqlParameterHelper.Create("@MaKH", maKH),
                    SqlParameterHelper.Create("@MaNV", maNV),
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@MucDo", mucDo)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Complaint.GetComplaint, parameters);
                return OperationResult<DataTable>.Ok(dt);
            }
            catch (Exception ex)
            {
                return OperationResult<DataTable>.Fail($"Lỗi khi lấy danh sách khiếu nại: {ex.Message}");
            }
        }

        public OperationResult<bool> Insert(Complaint complaint)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKN", complaint.MaKN),
                    SqlParameterHelper.Create("@MaKH", complaint.MaKH),
                    SqlParameterHelper.Create("@MaCN", complaint.MaCN),
                    SqlParameterHelper.Create("@NoiDung", complaint.NoiDung),
                    SqlParameterHelper.Create("@MucDo", complaint.MucDo),
                    SqlParameterHelper.Create("@TrangThai", complaint.TrangThai),
                    SqlParameterHelper.Create("@GhiChu", complaint.GhiChu)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Complaint.InsertComplaint, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi thêm khiếu nại: {ex.Message}");
            }
        }

        public OperationResult<bool> Update(Complaint complaint)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaKN", complaint.MaKN),
                    SqlParameterHelper.Create("@MaNV", complaint.MaNV),
                    SqlParameterHelper.Create("@TrangThai", complaint.TrangThai),
                    SqlParameterHelper.Create("@KetQua", complaint.KetQua),
                    SqlParameterHelper.Create("@SoTienBoiThuong", complaint.SoTienBoiThuong),
                    SqlParameterHelper.Create("@GhiChu", complaint.GhiChu),
                    SqlParameterHelper.Create("@UpdatedBy", Session_Now.CurrentUser)
                };

                fastQuery.ExecuteNonQueryProc(StoredProcedures.Complaint.UpdateComplaint, parameters);
                return OperationResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Fail($"Lỗi khi cập nhật khiếu nại: {ex.Message}");
            }
        }

        public bool Exists(string maKN)
        {
            try
            {
                var result = GetComplaints(maKN: maKN);
                return result.Success && result.Data.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}


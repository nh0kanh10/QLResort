using System;
using System.Data;
using System.Data.SqlClient;
using Tool_QLResort.Database;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;

namespace DAL_QLResort.Statistics
{
    public class StatisticsDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        public decimal GetDoanhThu(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDoanhThu, parameters);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DoanhThu"]);
                return 0;
            }
            catch { return 0; }
        }

        public decimal GetChiPhi(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetChiPhi, parameters);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ChiPhi"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["ChiPhi"]);
                return 0;
            }
            catch { return 0; }
        }

        public decimal GetDatCoc(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDatCoc, parameters);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["DatCoc"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DatCoc"]);
                return 0;
            }
            catch { return 0; }
        }

        public decimal GetHoanTien(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetHoanTien, parameters);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["HoanTien"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["HoanTien"]);
                return 0;
            }
            catch { return 0; }
        }

        public int GetTongDatPhong(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetTongDatPhong, parameters);
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch { return 0; }
        }

        public int GetDatPhongTheoTrangThai(string trangThai, string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDatPhongTheoTrangThai, parameters);
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch { return 0; }
        }

        public int GetTongSuKien(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetTongSuKien, parameters);
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch { return 0; }
        }

        public decimal GetDoanhThuSuKien(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDoanhThuSuKien, parameters);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DoanhThu"]);
                return 0;
            }
            catch { return 0; }
        }

        public int GetTongKhachHang()
        {
            try
            {
                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetTongKhachHang, null);
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch { return 0; }
        }

        public int GetKhachHangMoi(int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetKhachHangMoi, parameters);
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch { return 0; }
        }

        public decimal GetDoanhThuDichVu(string maCN = null, int? year = null, int? month = null)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDoanhThuDichVu, parameters);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DoanhThu"]);
                return 0;
            }
            catch { return 0; }
        }
    }
}




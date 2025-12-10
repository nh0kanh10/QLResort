using System;
using System.Data;
using System.Data.SqlClient;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;

namespace QLResort.DAL.Statistics
{
    public class StatisticsDAL
    {
        private readonly FastQuery fastQuery = new FastQuery();

        /// <summary>
        /// Lấy doanh thu từ HoaDon đã thanh toán
        /// </summary>
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

        /// <summary>
        /// Lấy chi phí
        /// </summary>
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

        /// <summary>
        /// Lấy tổng đặt cọc
        /// </summary>
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

        /// <summary>
        /// Lấy tổng hoàn tiền
        /// </summary>
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

        /// <summary>
        /// Lấy tổng số đặt phòng
        /// </summary>
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

        /// <summary>
        /// Lấy số đặt phòng theo trạng thái
        /// </summary>
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

        /// <summary>
        /// Lấy tổng số sự kiện
        /// </summary>
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

        /// <summary>
        /// Lấy doanh thu sự kiện
        /// </summary>
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

        /// <summary>
        /// Lấy tổng số khách hàng
        /// </summary>
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

        /// <summary>
        /// Lấy số khách hàng mới
        /// </summary>
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

        /// <summary>
        /// Lấy doanh thu dịch vụ
        /// </summary>
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Model;

namespace QLResort.DAL.DepositDAL
{
    public class DepositDAL
    {
        private readonly string connectionString;

        public DepositDAL()
        {
            connectionString = ReadAndGet.GetConnectionString();
        }

        /// <summary>
        /// Lấy danh sách deposit theo điều kiện
        /// </summary>
        public List<Deposit> GetDeposits(string maDatCoc = null, string maDP = null, string maKH = null, 
                                         string loaiCoc = null, string trangThai = null)
        {
            List<Deposit> deposits = new List<Deposit>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.Statistics.GetDatCoc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(maDatCoc))
                        cmd.Parameters.AddWithValue("@MaDatCoc", maDatCoc);
                    if (!string.IsNullOrEmpty(maDP))
                        cmd.Parameters.AddWithValue("@MaDP", maDP);
                    if (!string.IsNullOrEmpty(maKH))
                        cmd.Parameters.AddWithValue("@MaKH", maKH);
                    if (!string.IsNullOrEmpty(loaiCoc))
                        cmd.Parameters.AddWithValue("@LoaiCoc", loaiCoc);
                    if (!string.IsNullOrEmpty(trangThai))
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deposits.Add(MapReaderToDeposit(reader));
                        }
                    }
                }
            }

            return deposits;
        }

        /// <summary>
        /// Lấy deposit theo mã
        /// </summary>
        public Deposit GetDepositById(string maDatCoc)
        {
            var deposits = GetDeposits(maDatCoc: maDatCoc);
            return deposits.Count > 0 ? deposits[0] : null;
        }

        /// <summary>
        /// Lấy deposit theo mã đặt phòng
        /// </summary>
        public List<Deposit> GetDepositsByBooking(string maDP)
        {
            return GetDeposits(maDP: maDP);
        }

        /// <summary>
        /// Thêm mới deposit
        /// </summary>
        public OperationResult AddDeposit(Deposit deposit)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.Deposit.InsertDatCoc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaDatCoc", deposit.MaDatCoc);
                        cmd.Parameters.AddWithValue("@MaDP", deposit.MaDP ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaCTSK", deposit.MaCTSK ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaKH", deposit.MaKH);
                        cmd.Parameters.AddWithValue("@SoTien", deposit.SoTien);
                        cmd.Parameters.AddWithValue("@HinhThucThanhToan", deposit.HinhThucThanhToan ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@LoaiCoc", deposit.LoaiCoc ?? "Đặt phòng");
                        cmd.Parameters.AddWithValue("@TrangThai", deposit.TrangThai ?? "ĐÃ NHẬN");
                        cmd.Parameters.AddWithValue("@GhiChu", deposit.GhiChu ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CreatedBy", deposit.CreatedBy);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return new OperationResult
                {
                    Success = true,
                    Message = "Thêm deposit thành công"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Lỗi khi thêm deposit: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Cập nhật deposit
        /// </summary>
        public OperationResult UpdateDeposit(Deposit deposit)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.Deposit.UpdateDatCoc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaDatCoc", deposit.MaDatCoc);
                        cmd.Parameters.AddWithValue("@SoTien", deposit.SoTien);
                        cmd.Parameters.AddWithValue("@HinhThucThanhToan", deposit.HinhThucThanhToan ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", deposit.TrangThai);
                        cmd.Parameters.AddWithValue("@GhiChu", deposit.GhiChu ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@UpdatedBy", deposit.UpdatedBy);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return new OperationResult
                {
                    Success = true,
                    Message = "Cập nhật deposit thành công"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Lỗi khi cập nhật deposit: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Tạo mã deposit mới
        /// </summary>
        public string GenerateDepositCode()
        {
            string newCode = "DC001";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 MaDatCoc FROM DatCoc ORDER BY MaDatCoc DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string lastCode = result.ToString();
                            int number = int.Parse(lastCode.Substring(2)) + 1;
                            newCode = $"DC{number:D3}";
                        }
                    }
                }
            }
            catch
            {
                // Nếu có lỗi, trả về mã mặc định
            }

            return newCode;
        }

        /// <summary>
        /// Map DataReader sang Deposit object
        /// </summary>
        private Deposit MapReaderToDeposit(SqlDataReader reader)
        {
            return new Deposit
            {
                MaDatCoc = reader["MaDatCoc"].ToString(),
                MaDP = reader["MaDP"] == DBNull.Value ? null : reader["MaDP"].ToString(),
                MaCTSK = reader["MaCTSK"] == DBNull.Value ? null : reader["MaCTSK"].ToString(),
                MaKH = reader["MaKH"].ToString(),
                SoTien = Convert.ToDecimal(reader["SoTien"]),
                NgayCoc = Convert.ToDateTime(reader["NgayCoc"]),
                HinhThucThanhToan = reader["HinhThucThanhToan"] == DBNull.Value ? null : reader["HinhThucThanhToan"].ToString(),
                LoaiCoc = reader["LoaiCoc"].ToString(),
                TrangThai = reader["TrangThai"].ToString(),
                GhiChu = reader["GhiChu"] == DBNull.Value ? null : reader["GhiChu"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                CreatedBy = reader["CreatedBy"] == DBNull.Value ? null : reader["CreatedBy"].ToString(),
                UpdatedAt = reader["UpdatedAt"] == DBNull.Value ? null : (DateTime?)reader["UpdatedAt"],
                UpdatedBy = reader["UpdatedBy"] == DBNull.Value ? null : reader["UpdatedBy"].ToString()
            };
        }
    }
}

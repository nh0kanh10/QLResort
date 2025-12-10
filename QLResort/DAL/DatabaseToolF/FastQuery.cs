using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.DAL.DatabaseToolF
{
    public class FastQuery
    {
        private readonly string connectionString;

        public FastQuery()
        {
            // Lấy connection string từ App.config
            var connString = ConfigurationManager.ConnectionStrings["QLResortDB"];
            if (connString == null || string.IsNullOrEmpty(connString.ConnectionString))
            {
                // Fallback về connection string cũ nếu không tìm thấy trong config
                connectionString = "Data Source=.;Initial Catalog=QLR;Integrated Security=True;Max Pool Size=100;Min Pool Size=5;Connection Timeout=30;Pooling=true;";
            }
            else
            {
                connectionString = connString.ConnectionString;
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 30;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 30;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 30;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ExecuteProc(string procName, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 30;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi SQL khi thực thi {procName}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thực thi {procName}: {ex.Message}", ex);
            }
        }

        public int ExecuteNonQueryProc(string procName, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 30;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        int affected = cmd.ExecuteNonQuery();
                        return affected;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi SQL khi thực thi {procName}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi hệ thống khi thực thi {procName}: {ex.Message}", ex);
            }
        }

        // ===========================================
        // TRANSACTION SUPPORT
        // ===========================================

        /// <summary>
        /// Thực thi một action trong transaction
        /// </summary>
        public void ExecuteTransaction(Action<SqlTransaction> action)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        action(transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Thực thi stored procedure trong transaction
        /// </summary>
        public int ExecuteNonQueryProcInTransaction(
            SqlTransaction transaction, 
            string procName, 
            params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(procName, transaction.Connection, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteNonQuery();
            }
        }



    }
}

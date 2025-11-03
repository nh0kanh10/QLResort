using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.DAL.DatabaseToolF
{
    public class FastQuery
    {
        private string connectionString = "Data Source=.;Initial Catalog=QLR;Integrated Security=True";
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
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ExecuteProc(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        int affected = cmd.ExecuteNonQuery();
                        return affected;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi SQL khi thực thi {procName}: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi hệ thống khi thực thi {procName}: {ex.Message}");
            }
        }



    }
}

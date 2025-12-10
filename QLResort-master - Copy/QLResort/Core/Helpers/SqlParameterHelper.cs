using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLResort.Core.Helpers
{
    /// <summary>
    /// Helper class để tạo SqlParameter dễ dàng hơn
    /// Giảm code duplication và tăng tính nhất quán
    /// </summary>
    public static class SqlParameterHelper
    {
        /// <summary>
        /// Tạo một SqlParameter với xử lý NULL tự động
        /// </summary>
        public static SqlParameter Create(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>
        /// Tạo một SqlParameter với kiểu dữ liệu cụ thể
        /// </summary>
        public static SqlParameter Create(string name, object value, SqlDbType dbType)
        {
            var param = new SqlParameter(name, dbType);
            param.Value = value ?? DBNull.Value;
            return param;
        }

        /// <summary>
        /// Tạo một SqlParameter cho output
        /// </summary>
        public static SqlParameter CreateOutput(string name, SqlDbType dbType, int size = -1)
        {
            var param = new SqlParameter(name, dbType, size);
            param.Direction = ParameterDirection.Output;
            return param;
        }

        /// <summary>
        /// Tạo mảng SqlParameter từ dictionary
        /// </summary>
        public static SqlParameter[] CreateFromDictionary(Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return null;

            var sqlParams = new List<SqlParameter>();
            foreach (var kvp in parameters)
            {
                sqlParams.Add(Create(kvp.Key, kvp.Value));
            }
            return sqlParams.ToArray();
        }
    }
}








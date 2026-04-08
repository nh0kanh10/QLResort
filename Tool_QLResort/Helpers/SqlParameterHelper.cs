using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tool_QLResort.Helpers
{
    
    public static class SqlParameterHelper
    {
        /// <summary>
        /// Tạo một SqlParameter với xử lý NULL tự động
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParameter Create(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>
        /// Tạo một SqlParameter với kiểu dữ liệu cụ thể
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        
        public static SqlParameter Create(string name, object value, SqlDbType dbType)
        {
            var param = new SqlParameter(name, dbType);
            param.Value = value ?? DBNull.Value;
            return param;
        }

        /// <summary>
        /// Tạo một SqlParameter cho output
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static SqlParameter CreateOutput(string name, SqlDbType dbType, int size = -1)
        {
            var param = new SqlParameter(name, dbType, size);
            param.Direction = ParameterDirection.Output;
            return param;
        }

        /// <summary>
        /// Tạo mảng SqlParameter từ dictionary
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
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









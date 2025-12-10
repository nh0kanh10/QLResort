using System;
using System.Data;

namespace QLResort.Core.Extensions
{
    public static class DataRowExtensions
    {
        public static bool HasColumn(this DataRow row, string columnName)
        {
            return row?.Table?.Columns?.Contains(columnName) == true;
        }

        public static string GetString(this DataRow row, string columnName, string defaultValue = null)
        {
            if (row.HasColumn(columnName) && row[columnName] != DBNull.Value)
            {
                return row[columnName].ToString();
            }

            return defaultValue;
        }

        public static bool GetBool(this DataRow row, string columnName, bool defaultValue = false)
        {
            if (row.HasColumn(columnName) && row[columnName] != DBNull.Value)
            {
                return Convert.ToBoolean(row[columnName]);
            }

            return defaultValue;
        }

        public static bool? GetNullableBool(this DataRow row, string columnName)
        {
            if (row.HasColumn(columnName) && row[columnName] != DBNull.Value)
            {
                return Convert.ToBoolean(row[columnName]);
            }

            return null;
        }

        public static int? GetNullableInt(this DataRow row, string columnName)
        {
            if (row.HasColumn(columnName) && row[columnName] != DBNull.Value)
            {
                return Convert.ToInt32(row[columnName]);
            }

            return null;
        }

        public static decimal? GetNullableDecimal(this DataRow row, string columnName)
        {
            if (row.HasColumn(columnName) && row[columnName] != DBNull.Value)
            {
                return Convert.ToDecimal(row[columnName]);
            }

            return null;
        }

        public static DateTime? GetNullableDateTime(this DataRow row, string columnName)
        {
            if (row.HasColumn(columnName) && row[columnName] != DBNull.Value)
            {
                return Convert.ToDateTime(row[columnName]);
            }

            return null;
        }
    }
}


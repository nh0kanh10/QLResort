using System;
using System.Configuration;

namespace QLResort.Core.ClassHoTro
{
    public static class ReadAndGet
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["QLResortDB"]?.ConnectionString 
                   ?? "Data Source=.;Initial Catalog=QLR;Integrated Security=True";
        }
    }
}

using System;
using System.Configuration;

namespace Tool_QLResort.ClassHoTro
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


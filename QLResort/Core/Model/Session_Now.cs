using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public static class Session_Now
    {
        public static string CurrentUser { get; set; } = "NV01";
        public static string CurrentResort { get; set; } = "CN01";
        public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUser);
        public static void Logout()
        {
            CurrentUser = null;
            CurrentResort = null;
        }
    }

}

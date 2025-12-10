using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public static class Session_Now
    {
        public static string CurrentUser { get; set; }
        public static string CurrentResort { get; set; }
        public static string CurrentRole { get; set; } = "NhanVien"; // NhanVien, QuanLy, Admin
        public static Account CurrentAccount { get; set; }
        public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUser);
        public static bool IsAdmin => CurrentRole == "Admin";
        public static bool IsQuanLy => CurrentRole == "QuanLy" || CurrentRole == "Admin";
        public static bool IsNhanVien => CurrentRole == "NhanVien";
        
        public static void Logout()
        {
            CurrentUser = null;
            CurrentResort = null;
            CurrentRole = "NhanVien";
            CurrentAccount = null;
        }
    }

}

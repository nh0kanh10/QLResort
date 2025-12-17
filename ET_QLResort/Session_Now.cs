using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public static class Session_Now
    {
        private static string _currentUser;
        private static string _currentResort;
        private static string _currentRole = "NhanVien";
        private static Account _currentAccount;

        public static string CurrentUser 
        { 
            get { return _currentUser; } 
            set { _currentUser = value; } 
        }
        
        public static string CurrentResort 
        { 
            get { return _currentResort; } 
            set { _currentResort = value; } 
        }
        
        public static string CurrentRole 
        { 
            get { return _currentRole; } 
            set { _currentRole = value; } 
        }
        
        public static Account CurrentAccount 
        { 
            get { return _currentAccount; } 
            set { _currentAccount = value; } 
        }
        
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

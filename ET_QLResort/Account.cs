using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Account : BaseModel
    {
        private string _maTK;
        private string _maNV;
        private string _tenDangNhap;
        private string _matKhau;
        private string _role = "NhanVien";

        public string MaTK 
        { 
            get { return _maTK; } 
            set { _maTK = value; } 
        }
        
        public string MaNV 
        { 
            get { return _maNV; } 
            set { _maNV = value; } 
        }
        
        public string TenDangNhap 
        { 
            get { return _tenDangNhap; } 
            set { _tenDangNhap = value; } 
        }
        
        public string MatKhau 
        { 
            get { return _matKhau; } 
            set { _matKhau = value; } 
        }
        
        public string Role 
        { 
            get { return _role; } 
            set { _role = value; } 
        }
    }
}

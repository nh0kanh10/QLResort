using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class EmployeeType : BaseModel
    {
        public static int stt = 0;
        
        private string _maLoaiNV;
        private string _tenLoaiNV;
        private string _moTa;

        public string MaLoaiNV 
        { 
            get { return _maLoaiNV; } 
            set { _maLoaiNV = value; } 
        }
        
        public string TenLoaiNV 
        { 
            get { return _tenLoaiNV; } 
            set { _tenLoaiNV = value; } 
        }
        
        public string MoTa 
        { 
            get { return _moTa; } 
            set { _moTa = value; } 
        }
        
        public EmployeeType()
        {
        }

        public EmployeeType(string tenLoaiNV, string moTa, bool isActive)
        {
            MaLoaiNV = $"LNV{stt.ToString("D3")}";
            TenLoaiNV = tenLoaiNV;
            MoTa = moTa;
            CreatedAt = DateTime.Now;
            CreatedBy = Session_Now.CurrentUser;         
            IsActive = isActive;
        }     
    }
}

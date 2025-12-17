using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Resort : BaseModel
    {
        public static int stt = 1;
        
        private string _maCN;
        private string _tenCN;
        private string _diaChi;
        private string _maNQL;

        public string MaCN 
        { 
            get { return _maCN; } 
            set { _maCN = value; } 
        }
        
        public string TenCN 
        { 
            get { return _tenCN; } 
            set { _tenCN = value; } 
        }
        
        public string DiaChi 
        { 
            get { return _diaChi; } 
            set { _diaChi = value; } 
        }
        
        public string MaNQL 
        { 
            get { return _maNQL; } 
            set { _maNQL = value; } 
        }

        public Resort() { }

        public Resort(string tenResort, string diaChi, string createBy, bool isActive = true, string maNQL = null)
        {
            MaCN = $"CN{stt++.ToString("D3")}";
            TenCN = tenResort;
            DiaChi = diaChi;
            CreatedAt = DateTime.Now;
            CreatedBy = createBy;
            IsActive = isActive;
            MaNQL = maNQL;
        }
    }
}

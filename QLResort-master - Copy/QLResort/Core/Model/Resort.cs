using QLResort.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core
{
    public class ResortM:BaseModel
    {
        public static int stt = 1;
        public string MaCN { get; set; }
        public string TenCN { get; set; }
        public string DiaChi { get; set; }

        public string MaNQL { get; set; }

        public ResortM() { }

        public ResortM(string tenResort, string diaChi ,string createBy,bool isActive = true,string maNQL = null)
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

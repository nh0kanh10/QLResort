using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class EmployeeType : BaseModel
    {
        public static int stt = 0;
        public string MaLoaiNV { get; set; }
        public string TenLoaiNV { get; set; }
        public string MoTa { get; set; }
        public EmployeeType()
        {
           
        }

        public EmployeeType( string tenLoaiNV, string moTa,bool isActive)
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

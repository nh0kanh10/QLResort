using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class GuestType: BaseModel
    {
        public string MaLKH { get; set; } = "";
        public string TenLKH { get; set; } = "";
        public decimal GiamGiaPercent { get; set; }
        public int DiemToiThieu { get; set; }
        public string MoTa { get; set; }
      
    }
}

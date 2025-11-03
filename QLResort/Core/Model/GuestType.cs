using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class GuestType
    {
        public string MaLKH { get; set; } = "";
        public string TenLKH { get; set; } = "";
        public decimal GiamGiaPercent { get; set; }
        public int DiemToiThieu { get; set; }
        public string MoTa { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Payment
    {
        public string MaTT { get; set; }
        public string MaHD { get; set; }
        public decimal? SoTien { get; set; }
        public string MaLTT { get; set; }
        public DateTime? NgayTT { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

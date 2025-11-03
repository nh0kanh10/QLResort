using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class PaymentType
    {
        public string MaLTT { get; set; }
        public string TenLTT { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

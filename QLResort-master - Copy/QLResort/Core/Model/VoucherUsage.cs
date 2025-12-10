using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class VoucherUsage
    {
        public string MaSuDung { get; set; }
        public string MaVoucher { get; set; }
        public string MaKH { get; set; }
        public string MaHD { get; set; }
        public string MaDP { get; set; }
        public DateTime NgaySuDung { get; set; }
        public decimal? GiaTriApDung { get; set; }
        public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}

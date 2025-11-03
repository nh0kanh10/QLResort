using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Event
    {
        public string MaSK { get; set; }
        public string TenSK { get; set; }
        public string LoaiSuKien { get; set; }
        public string MaCN { get; set; }
        public string DiaDiem { get; set; }
        public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public decimal? TongChiPhi { get; set; }
    }
}

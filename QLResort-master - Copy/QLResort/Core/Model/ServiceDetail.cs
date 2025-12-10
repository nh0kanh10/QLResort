using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class ServiceDetail
    {
        public string MaCTDV { get; set; }
        public string MaCTDP { get; set; }
        public string MaDV { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public decimal? ThanhTien { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

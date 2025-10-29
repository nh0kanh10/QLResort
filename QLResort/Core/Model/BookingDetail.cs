using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class BookingDetail
    {
        public string MaCTDP { get; set; }
        public string MaDP { get; set; }
        public string MaPhong { get; set; }
        public string MaCTDV { get; set; }
        public decimal? GiaPhong { get; set; }
        public int? SoDem { get; set; }
        public decimal? ThanhTien { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

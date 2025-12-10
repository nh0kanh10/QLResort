using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class BookingDetail:BaseModel
    {
        public string MaCTDP { get; set; }
        public DateTime? NgayDen { get; set; }
        public DateTime? NgayDi { get; set; }  
        public int? NguoiLon { get; set; }     
        public int? TreEm { get; set; }
        public string MaDP { get; set; }
        public string MaPhong { get; set; }
        public string MaCTDV { get; set; }
        public decimal? GiaPhong { get; set; }
        public int? SoDem { get; set; }
        public decimal? ThanhTien { get; set; }
        public string TrangThai { get; set; }
    }
}

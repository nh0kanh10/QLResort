using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Booking
    {
        public string MaDP { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string TrangThai { get; set; }
        public DateTime? NgayDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public int? NguoiLon { get; set; }
        public int? TreEm { get; set; }
        public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

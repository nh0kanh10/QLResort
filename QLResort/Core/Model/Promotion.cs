using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Promotion: BaseModel
    {
        public string MaKM { get; set; }
        public string TenKM { get; set; }
        public bool IsPhanTram { get; set; }
        public decimal? GiaTri { get; set; }
        public string MaLKH { get; set; }
        public string MaCN { get; set; }
        public string MaLP { get; set; }
        public string MaPhong { get; set; }
        public string CouponCode { get; set; }
        public DateTime? NgayBD { get; set; }
        public DateTime? NgayKT { get; set; }
        public string DieuKien { get; set; }

    }
}

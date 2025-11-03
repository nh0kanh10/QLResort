using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Voucher
    {
        public string MaVoucher { get; set; }
        public string TenVoucher { get; set; }
        public string CouponCode { get; set; }
        public bool IsPhanTram { get; set; }
        public decimal? GiaTri { get; set; }
        public int? SoLuong { get; set; }
        public int SoLuongDaDung { get; set; }
        public string MaLKH { get; set; }
        public string MaCN { get; set; }
        public string MaLP { get; set; }
        public string MaPhong { get; set; }
        public DateTime? NgayBD { get; set; }
        public DateTime? NgayKT { get; set; }
        public string DieuKien { get; set; }
        public string TrangThai { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

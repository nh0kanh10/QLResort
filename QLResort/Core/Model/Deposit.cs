using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public  class Deposit
    {
        public string MaDatCoc { get; set; }
        public string MaDP { get; set; }
        public string MaCTSK { get; set; }
        public string MaKH { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayCoc { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string LoaiCoc { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}

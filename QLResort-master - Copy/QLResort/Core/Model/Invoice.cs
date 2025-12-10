using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Invoice: BaseModel
    {
        public string MaHD { get; set; }
        public string MaDP { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string MaKM { get; set; }
        public string MaCN { get; set; }
        public string TrangThai { get; set; }
        public DateTime? NgayLap { get; set; }
        public decimal? TongTruocKM { get; set; }
        public decimal? TongTien { get; set; }
    }
}

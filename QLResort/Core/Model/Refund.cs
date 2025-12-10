using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Refund: BaseModel
    {
        public string MaPhieuHoan { get; set; }
        public string MaDatCoc { get; set; }
        public decimal SoTienHoan { get; set; }
        public DateTime NgayHoan { get; set; }
        public string HinhThucHoan { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class InvoiceDetail: BaseModel
    {
        public string MaCTHD { get; set; }
        public string MaHD { get; set; }
        public string MoTa { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? ThanhTien { get; set; }

    }
}

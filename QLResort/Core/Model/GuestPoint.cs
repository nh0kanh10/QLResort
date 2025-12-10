using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class GuestPoint: BaseModel
    {
        public string MaKH { get; set; }
        public int DiemHienTai { get; set; }
        public DateTime CapNhatLuc { get; set; }

    }
}

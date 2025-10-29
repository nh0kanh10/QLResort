using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class GuestPointHistory
    {
        public int Id { get; set; }
        public string MaKH { get; set; }
        public DateTime Ngay { get; set; }
        public string LoaiThaoTac { get; set; }
        public int Diem { get; set; }
        public string GhiChu { get; set; }
        public string NguoiThucHien { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}

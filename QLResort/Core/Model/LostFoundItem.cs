using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class LostFoundItem
    {
        public string MaLF { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string MaCN { get; set; }
        public string TenDo { get; set; }
        public DateTime NgayTimThay { get; set; }
        public string DiaDiemTim { get; set; }
        public string TrangThai { get; set; }
        public DateTime? NgayTra { get; set; }
        public string NguoiNhan { get; set; }
        public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}

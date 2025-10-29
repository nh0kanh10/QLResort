using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Room
    {
        public string MaPhong { get; set; }
        public string MaCN { get; set; }
        public string MaLP { get; set; }
        public string SoPhong { get; set; }
        public string ViTri { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

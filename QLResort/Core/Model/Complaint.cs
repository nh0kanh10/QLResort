using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Complaint
    {
        public string MaKN { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string MaCN { get; set; }
        public DateTime NgayGhi { get; set; }
        public string NoiDung { get; set; }
        public string MucDo { get; set; }
        public string TrangThai { get; set; }
        public string KetQua { get; set; }
        public decimal SoTienBoiThuong { get; set; }
        public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

    }
}

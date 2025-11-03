using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class RoomType
    {
        static int stt = 1;
        public string MaLP { get; set; }
        public string TenLP { get; set; }
        public string MoTa { get; set; }
        public bool IsNhaNguyenCan { get; set; }
        public int SoPhongTrongNha { get; set; }
        public decimal? GiaTheoGio { get; set; }
        public decimal? GiaTheoNgay { get; set; }
        public decimal? GiaTheoThang { get; set; }
        public int? SucChuaToiDa { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class EventDetail: BaseModel
    {
        public string MaCTSK { get; set; }
        public string MaSK { get; set; }
        public string MaKH { get; set; }
        public string MaCTDV { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }
        public decimal DaThanhToan { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public int? TongKhach { get; set; }

    }
}

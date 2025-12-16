// File: QLResort.Core.Model/Room.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    
    public class Room:BaseModel
    {
        
        public string MaPhong { get; set; }
        public string MaCN { get; set; }
        public string MaLP { get; set; }
        public string SoPhong { get; set; }
        public string ViTri { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string TenLoaiPhong { get; set; }     
        public int? SucChuaToiDa { get; set; }       
        public decimal? GiaTheoNgay { get; set; }    
        public decimal? GiaTheoGio { get; set; }     
        public decimal? GiaTheoThang { get; set; }   

    }
}

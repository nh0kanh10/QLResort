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
        // Thuộc tính gốc của bảng Phong
        public string MaPhong { get; set; }
        public string MaCN { get; set; }
        public string MaLP { get; set; }
        public string SoPhong { get; set; }
        public string ViTri { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        // <--- BỔ SUNG CÁC THUỘC TÍNH TỪ LOAIPHONG (ROOMTYPE) --->
        public string TenLoaiPhong { get; set; }
        public int? SucChuaToiDa { get; set; } // Lấy từ LoaiPhong
        public decimal? GiaTheoNgay { get; set; } // Lấy từ LoaiPhong
        public decimal? GiaTheoGio { get; set; } // Lấy từ LoaiPhong
        public decimal? GiaTheoThang { get; set; } // Lấy từ LoaiPhong


    }
}

// File: QLResort.Core.Model/Room.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    /// <summary>
    /// Room (Phong) - Represents a physical room
    /// 
    /// DESIGN NOTE: Includes joined data from LoaiPhong (RoomType) for UI convenience
    /// 
    /// DB Fields: MaPhong, MaCN, MaLP, SoPhong, ViTri, TrangThai, GhiChu
    /// Joined Fields: TenLoaiPhong, SucChuaToiDa, GiaTheoNgay, GiaTheoGio, GiaTheoThang (from LoaiPhong)
    /// </summary>
    public class Room:BaseModel
    {
        // === DATABASE FIELDS (from Phong table) ===
        public string MaPhong { get; set; }
        public string MaCN { get; set; }
        public string MaLP { get; set; }
        public string SoPhong { get; set; }
        public string ViTri { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        // === JOINED FIELDS (from LoaiPhong table via JOIN) ===
        // Populated by BUS layer for display convenience
        public string TenLoaiPhong { get; set; }     // Room type name
        public int? SucChuaToiDa { get; set; }       // Max capacity
        public decimal? GiaTheoNgay { get; set; }    // Daily rate
        public decimal? GiaTheoGio { get; set; }     // Hourly rate
        public decimal? GiaTheoThang { get; set; }   // Monthly rate

    }
}

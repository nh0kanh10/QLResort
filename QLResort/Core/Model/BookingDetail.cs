using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class BookingDetail:BaseModel
    {
        // Primary key and references
        public string MaCTDP { get; set; }
        public string MaDP { get; set; }
        public string MaPhong { get; set; }
        public string MaCN { get; set; }
        public string MaNV { get; set; }
        public string MaCTDV { get; set; }
        
        // Dates
        public DateTime? NgayDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public DateTime? NgayCheckIn { get; set; }
        public DateTime? NgayCheckOut { get; set; }
        
        // Guest information
        public int? NguoiLon { get; set; }
        public int? TreEm { get; set; }
        
        // Booking type and pricing
        public string LoaiThue { get; set; } // "Giờ", "Ngày", "Tháng"
        public decimal? GiaPhong { get; set; }
        public int? SoDem { get; set; }
        public decimal? ThanhTien { get; set; }
        
        // Status and notes
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        
        // BaseModel: CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    }
}

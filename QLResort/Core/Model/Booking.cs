using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    /// <summary>
    /// Booking (DatPhong) - Represents a booking header/transaction
    /// 
    /// RELATIONSHIP: 1 Booking → MANY BookingDetails (1 booking có thể đặt nhiều phòng)
    /// Example: Khách A đặt 3 phòng cho gia đình → 1 Booking, 3 BookingDetails
    /// 
    /// DESIGN NOTE: This class serves BOTH as:
    /// 1. DB Entity (maps to DatPhong table)
    /// 2. ViewModel (contains aggregated/display fields for UI convenience)
    /// 
    /// DB Fields: MaDP, MaKH, MaNV, TrangThai, GhiChu (+ BaseModel audit fields)
    /// Display Fields: All others (populated by BUS layer from related tables)
    /// </summary>
    public class Booking : BaseModel
    {
        // ========================================
        // DATABASE FIELDS (from DatPhong table)
        // ========================================
        
        public string MaDP { get; set; }        // Primary key
        public string MaKH { get; set; }        // Customer reference
        public string MaNV { get; set; }        // Staff who created booking
        public string TrangThai { get; set; }   // Status: "Đặt", "Đang sử dụng", "Đã trả phòng", etc.
        public string GhiChu { get; set; }      // Notes
        
        // BaseModel inherits: CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive

        // ========================================
        // DISPLAY FIELDS (NOT in DB, populated by BUS from related tables)
        // For UI binding convenience - represent aggregated/derived data
        // ========================================
        
        // --- From FIRST BookingDetail (for display summary) ---
        // Note: Actual values per room are in BookingDetail table
        public DateTime? NgayDen { get; set; }  // From first BookingDetail
        public DateTime? NgayDi { get; set; }   // From first BookingDetail
        public int? NguoiLon { get; set; }      // From first BookingDetail
        public int? TreEm { get; set; }         // From first BookingDetail

        // --- Aggregated Financial Data ---
        // Calculated/summed from related tables by BUS layer
        
        public decimal? TongTien { get; set; }          // Grand total (all rooms + services - discounts)
        public decimal? TienDatCoc { get; set; }        // Total deposits (sum from DatCoc table)
        public decimal? TongGiamGia { get; set; }       // Total discounts applied
        public string MaKM { get; set; }                // Promotion code used (from HoaDon)
        public decimal? TongTienPhong { get; set; }     // Sum of all rooms (from CTDatPhong)
        public decimal? TongTienDichVu { get; set; }    // Sum of all services (from CTDichVu)
        public decimal? TongHoaDon { get; set; }        // Final invoice amount
        public string TrangThaiThanhToan { get; set; }  // Payment status (derived from ThanhToan)
    }
}

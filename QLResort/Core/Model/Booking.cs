using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Booking : BaseModel
    {
        // === THÔNG TIN CƠ BẢN VÀ NGHIỆP VỤ ===
        public string MaDP { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string TrangThai { get; set; }
        public DateTime? NgayDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public int? NguoiLon { get; set; }
        public int? TreEm { get; set; }
        public string GhiChu { get; set; }

        // === THÔNG TIN TÀI CHÍNH BỔ SUNG (REQUIRED FOR ACCURATE BILLING) ===

        // Tổng tiền của toàn bộ booking (từ DB)
        public decimal? TongTien { get; set; }

        // Tiền đã cọc trước
        public decimal? TienDatCoc { get; set; }

        // Tổng tiền giảm giá (từ khuyến mãi)
        public decimal? TongGiamGia { get; set; }

        // Mã khuyến mãi đã áp dụng (nếu có)
        public string MaKM { get; set; }

        // Tổng tiền phòng từ tất cả BookingDetails
        public decimal? TongTienPhong { get; set; }

        // Tổng tiền dịch vụ từ tất cả ServiceDetails
        public decimal? TongTienDichVu { get; set; }

        // Tổng hóa đơn cuối cùng (TongTienPhong + TongTienDichVu - TongGiamGia)
        public decimal? TongHoaDon { get; set; }

        // Trạng thái thanh toán (ví dụ: "Chưa thanh toán", "Đã cọc", "Đã thanh toán đủ")
        public string TrangThaiThanhToan { get; set; }
    }
}

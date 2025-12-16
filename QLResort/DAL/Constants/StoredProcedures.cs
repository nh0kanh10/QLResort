namespace QLResort.DAL.Constants
{
    /// <summary>
    /// Constants cho tên các Stored Procedures
    /// Tránh magic strings và dễ refactor
    /// </summary>
    public static class StoredProcedures
    {
        
        public static class Employee
        {
            public const string GetNhanVien = "sp_GetNhanVien";
            public const string InsertNhanVien = "sp_InsertNhanVien";
            public const string UpdateNhanVien = "sp_UpdateNhanVien";
            public const string DeleteNhanVien = "sp_DeleteNhanVien";
        }

        public static class EmployeeType
        {
            public const string GetLoaiNV = "sp_GetLoaiNV";
            public const string InsertLoaiNhanVien = "sp_InsertLoaiNhanVien";
            public const string UpdateLoaiNhanVien = "sp_UpdateLoaiNhanVien";
            public const string DeleteLoaiNhanVien_Hard = "sp_DeleteLoaiNhanVien_Hard";
        }

        public static class Guest
        {
            public const string GetKhachHang = "sp_GetKhachHang";
            public const string AddKhachHang = "sp_AddKhachHang";
            public const string UpdateKhachHang = "sp_UpdateKhachHang";
            public const string DeleteKhachHang = "sp_DeleteKhachHang";
        }

        public static class GuestType
        {
            public const string GetLoaiKhachHang = "sp_GetLoaiKhachHang";
            public const string GetLoaiKhachHangForKH = "sp_GetLoaiKhachHangForKH";
            public const string GetLoaiKhachHang_Key_Value = "sp_GetLoaiKhachHang_Key_Value";
            public const string InsertLoaiKhachHang = "sp_InsertLoaiKhachHang";
            public const string UpdateLoaiKhachHang = "sp_UpdateLoaiKhachHang";
            public const string DeleteLoaiKhachHang = "sp_DeleteLoaiKhachHang";
        }

        public static class Resort
        {
            public const string GetChiNhanh = "sp_GetChiNhanh";
            public const string AddChiNhanh = "sp_AddChiNhanh";
            public const string UpdateChiNhanh = "sp_UpdateChiNhanh";
            public const string DeleteChiNhanh = "sp_DeleteChiNhanh";
            public const string DeleteChiNhanh_Hard = "sp_DeleteChiNhanh_Hard";
        }

        public static class Service
        {
            public const string GetDichVu = "sp_GetDichVu";
            public const string InsertDichVu = "sp_InsertDichVu";
            public const string UpdateDichVu = "sp_UpdateDichVu";
            public const string DeleteDichVu = "sp_DeleteDichVu";
        }

        public static class RoomType
        {
            public const string GetLoaiPhong = "sp_GetLoaiPhong";
            public const string InsertLoaiPhong = "sp_InsertLoaiPhong";
            public const string UpdateLoaiPhong = "sp_UpdateLoaiPhong";
            public const string DeleteLoaiPhong = "sp_DeleteLoaiPhong";
        }

        public static class Room
        {
            public const string GetPhong = "sp_GetPhong";
            public const string InsertPhong = "sp_InsertPhong";
            public const string UpdatePhong = "sp_UpdatePhong";
            public const string DeletePhong = "sp_DeletePhong";
        }

        public static class RoomImage
        {
            public const string GetHinhAnhPhong = "sp_GetHinhAnhPhong";
            public const string InsertHinhAnhPhong = "sp_InsertHinhAnhPhong";
            public const string UpdateHinhAnhPhong = "sp_UpdateHinhAnhPhong";
            public const string DeleteHinhAnhPhong = "sp_DeleteHinhAnhPhong";
        }

        public static class PaymentType
        {
            public const string GetLoaiThanhToan = "sp_GetLoaiThanhToan";
            public const string InsertLoaiThanhToan = "sp_InsertLoaiThanhToan";
            public const string UpdateLoaiThanhToan = "sp_UpdateLoaiThanhToan";
            public const string DeleteLoaiThanhToan = "sp_DeleteLoaiThanhToan";
        }

        public static class Promotion
        {
            public const string GetKhuyenMai = "sp_GetKhuyenMai";
            public const string InsertKhuyenMai = "sp_InsertKhuyenMai";
            public const string UpdateKhuyenMai = "sp_UpdateKhuyenMai";
            public const string DeleteKhuyenMai = "sp_DeleteKhuyenMai";
        }

        public static class Invoice
        {
            public const string GetHoaDon = "sp_GetHoaDon";
            public const string InsertHoaDon = "sp_InsertHoaDon";
            public const string UpdateHoaDon = "sp_UpdateHoaDon";
            public const string GetCTHoaDon = "sp_GetCTHoaDon";
            public const string InsertCTHoaDon = "sp_InsertCTHoaDon";
        }

        public static class Payment
        {
            public const string GetThanhToan = "sp_GetThanhToan";
            public const string InsertThanhToan = "sp_InsertThanhToan";
            public const string UpdateThanhToan = "sp_UpdateThanhToan";
            public const string DeleteThanhToan = "sp_DeleteThanhToan";
        }

        public static class Booking
        {
            public const string GetDatPhong = "sp_GetDatPhong";
            public const string InsertDatPhong = "sp_InsertDatPhong";
            public const string UpdateDatPhong = "sp_UpdateDatPhong";
        }

        public static class BookingDetail
        {
            public const string GetCTDatPhong = "sp_GetCTDatPhong";
            public const string InsertCTDatPhong = "sp_InsertCTDatPhong";
            public const string UpdateCTDatPhong = "sp_UpdateCTDatPhong";
        }

        public static class ServiceDetail
        {
            public const string GetCTDichVu = "sp_GetCTDichVu";
            public const string InsertCTDichVu = "sp_InsertCTDichVu";
            public const string UpdateCTDichVu = "sp_UpdateCTDichVu";
            public const string DeleteCTDichVu = "sp_DeleteCTDichVu";
        }

        public static class GuestPoint
        {
            public const string GetKhachHangDiem = "sp_GetKhachHangDiem";
            public const string UpdateKhachHangDiem = "sp_UpdateKhachHangDiem";
        }

        public static class LostFound
        {
            public const string GetLostFound = "sp_GetLostFound";
            public const string InsertLostFound = "sp_InsertLostFound";
            public const string UpdateLostFound = "sp_UpdateLostFound";
        }

        public static class Event
        {
            public const string GetSuKien = "sp_GetSuKien";
            public const string InsertSuKien = "sp_InsertSuKien";
            public const string UpdateSuKien = "sp_UpdateSuKien";
        }

        public static class EventDetail
        {
            public const string GetCTSuKien = "sp_GetCTSuKien";
            public const string InsertCTSuKien = "sp_InsertCTSuKien";
            public const string UpdateCTSuKien = "sp_UpdateCTSuKien";
        }

        public static class Complaint
        {
            public const string GetComplaint = "sp_GetComplaint";
            public const string InsertComplaint = "sp_InsertComplaint";
            public const string UpdateComplaint = "sp_UpdateComplaint";
        }

        public static class Voucher
        {
            public const string GetVoucher = "sp_GetVoucher";
            public const string InsertVoucher = "sp_InsertVoucher";
            public const string UpdateVoucher = "sp_UpdateVoucher";
        }

        public static class VoucherUsage
        {
            public const string GetVoucherUsage = "sp_GetVoucherUsage";
            public const string InsertVoucherUsage = "sp_InsertVoucherUsage";
        }

        public static class EventPackage
        {
            public const string GetGoiSuKien = "sp_GetGoiSuKien";
            public const string InsertGoiSuKien = "sp_InsertGoiSuKien";
            public const string UpdateGoiSuKien = "sp_UpdateGoiSuKien";
        }

        public static class Statistics
        {
            public const string GetDoanhThu = "sp_GetDoanhThu";
            public const string GetChiPhi = "sp_GetChiPhi";
            public const string GetDatCoc = "sp_GetDatCoc";
            public const string GetHoanTien = "sp_GetHoanTien";
            public const string GetTongDatPhong = "sp_GetTongDatPhong";
            public const string GetDatPhongTheoTrangThai = "sp_GetDatPhongTheoTrangThai";
            public const string GetTongSuKien = "sp_GetTongSuKien";
            public const string GetDoanhThuSuKien = "sp_GetDoanhThuSuKien";
            public const string GetTongKhachHang = "sp_GetTongKhachHang";
            public const string GetKhachHangMoi = "sp_GetKhachHangMoi";
            public const string GetDoanhThuDichVu = "sp_GetDoanhThuDichVu";
        }

        public static class Account
        {
            public const string GetTaiKhoan = "sp_GetTaiKhoan";
            public const string InsertTaiKhoan = "sp_InsertTaiKhoan";
            public const string UpdateTaiKhoan = "sp_UpdateTaiKhoan";
        }

        public static class Deposit
        {
            public const string GetDatCocList = "sp_GetDatCocList";
            public const string InsertDatCoc = "sp_InsertDatCoc";
            public const string UpdateDatCoc = "sp_UpdateDatCoc";
            public const string GenerateMaDatCoc = "sp_GenerateMaDatCoc";
        }
    }
}


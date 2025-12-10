using System;
using QLResort.DAL.Statistics;
using QLResort.DAL.RoomDAL;
using QLResort.DAL.ServiceDAL;
using QLResort.DAL.EmployeeDALQL;

namespace QLResort.BUS
{
    /// <summary>
    /// Model chứa dữ liệu thống kê tổng hợp
    /// </summary>
    public class StatisticsData
    {
        // Phòng
        public int TongPhong { get; set; }
        public int PhongTrong { get; set; }
        public int PhongDangSuDung { get; set; }
        public int PhongBaoTri { get; set; }
        public int PhongNgung { get; set; }

        // Tài chính
        public decimal DoanhThu { get; set; }
        public decimal ChiPhi { get; set; }
        public decimal LoiNhuan => DoanhThu - ChiPhi;
        public decimal DatCoc { get; set; }
        public decimal HoanTien { get; set; }

        // Đặt phòng
        public int TongDatPhong { get; set; }
        public int DatPhongHoanTat { get; set; }
        public int DatPhongHuy { get; set; }
        public decimal TiLeThanhCong => TongDatPhong > 0 ? (DatPhongHoanTat * 100.0m / TongDatPhong) : 0;

        // Sự kiện
        public int TongSuKien { get; set; }
        public decimal DoanhThuSuKien { get; set; }

        // Khách hàng & Nhân viên
        public int TongKhachHang { get; set; }
        public int KhachHangMoi { get; set; }
        public int TongNhanVien { get; set; }

        // Dịch vụ
        public int TongDichVu { get; set; }
        public decimal DoanhThuDichVu { get; set; }
    }

    /// <summary>
    /// Business Logic Layer cho Thống kê
    /// </summary>
    public class StatisticsBUS
    {
        private readonly StatisticsDAL statisticsDAL = new StatisticsDAL();
        private readonly RoomDAL roomDAL = new RoomDAL();
        private readonly ServiceDAL serviceDAL = new ServiceDAL();
        private readonly EmployeeDAL employeeDAL = new EmployeeDAL();

        /// <summary>
        /// Lấy toàn bộ dữ liệu thống kê
        /// </summary>
        public StatisticsData GetAllStatistics(string maCN = null, int? year = null, int? month = null)
        {
            var data = new StatisticsData();

            // ========== Phòng ==========
            data.TongPhong = GetTongPhong(maCN);
            data.PhongTrong = GetPhongTheoTrangThai(maCN, "Trống");
            data.PhongDangSuDung = GetPhongTheoTrangThai(maCN, "Đã đặt") +
                                   GetPhongTheoTrangThai(maCN, "Đang Sử Dụng") +
                                   GetPhongTheoTrangThai(maCN, "Đang Dọn");
            data.PhongBaoTri = GetPhongTheoTrangThai(maCN, "Bảo trì");
            data.PhongNgung = GetPhongTheoTrangThai(maCN, "Ngưng hoạt động");

            // ========== Tài chính ==========
            data.DoanhThu = statisticsDAL.GetDoanhThu(maCN, year, month);
            data.ChiPhi = statisticsDAL.GetChiPhi(maCN, year, month);
            data.DatCoc = statisticsDAL.GetDatCoc(maCN, year, month);
            data.HoanTien = statisticsDAL.GetHoanTien(maCN, year, month);

            // ========== Đặt phòng ==========
            data.TongDatPhong = statisticsDAL.GetTongDatPhong(maCN, year, month);
            data.DatPhongHoanTat = statisticsDAL.GetDatPhongTheoTrangThai("Hoàn tất", maCN, year, month);
            data.DatPhongHuy = statisticsDAL.GetDatPhongTheoTrangThai("Hủy", maCN, year, month);

            // ========== Sự kiện ==========
            data.TongSuKien = statisticsDAL.GetTongSuKien(maCN, year, month);
            data.DoanhThuSuKien = statisticsDAL.GetDoanhThuSuKien(maCN, year, month);

            // ========== Khách hàng & Nhân viên ==========
            data.TongKhachHang = statisticsDAL.GetTongKhachHang();
            data.KhachHangMoi = statisticsDAL.GetKhachHangMoi(year, month);
            data.TongNhanVien = GetTongNhanVien(maCN);

            // ========== Dịch vụ ==========
            data.TongDichVu = GetTongDichVu();
            data.DoanhThuDichVu = statisticsDAL.GetDoanhThuDichVu(maCN, year, month);

            return data;
        }

        #region Helper Methods

        private int GetTongPhong(string maCN)
        {
            try
            {
                var result = roomDAL.GetRooms(maCN: maCN, isActive: true);
                return result.Success && result.Data != null ? result.Data.Rows.Count : 0;
            }
            catch { return 0; }
        }

        private int GetPhongTheoTrangThai(string maCN, string trangThai)
        {
            try
            {
                var result = roomDAL.GetRooms(maCN: maCN, trangThai: trangThai, isActive: true);
                return result.Success && result.Data != null ? result.Data.Rows.Count : 0;
            }
            catch { return 0; }
        }

        private int GetTongNhanVien(string maCN)
        {
            try
            {
                var result = employeeDAL.GetEmployeesDAL(maCN: maCN, isActive: true);
                return result.Success && result.Data != null ? result.Data.Rows.Count : 0;
            }
            catch { return 0; }
        }

        private int GetTongDichVu()
        {
            try
            {
                var result = serviceDAL.GetServices(isActive: true);
                return result.Success && result.Data != null ? result.Data.Rows.Count : 0;
            }
            catch { return 0; }
        }

        #endregion
    }
}

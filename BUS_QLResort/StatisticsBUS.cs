using ET_QLResort;
using DAL_QLResort.Statistics;
using DAL_QLResort.RoomDAL;
using DAL_QLResort.ServiceDAL;
using DAL_QLResort.EmployeeDALQL;

namespace BUS_QLResort
{
    public class StatisticsBUS
    {
        private readonly StatisticsDAL statisticsDAL = new StatisticsDAL();
        private readonly RoomDAL roomDAL = new RoomDAL();
        private readonly ServiceDAL serviceDAL = new ServiceDAL();
        private readonly EmployeeDAL employeeDAL = new EmployeeDAL();

        public StatisticsData GetAllStatistics(string maCN = null, int? year = null, int? month = null)
        {
            var data = new StatisticsData();

            data.TongPhong = GetTongPhong(maCN);
            data.PhongTrong = GetPhongTheoTrangThai(maCN, "Trống");
            data.PhongDangSuDung = GetPhongTheoTrangThai(maCN, "Đã đặt") +
                                   GetPhongTheoTrangThai(maCN, "Đang Sử Dụng") +
                                   GetPhongTheoTrangThai(maCN, "Đang Dọn");
            data.PhongBaoTri = GetPhongTheoTrangThai(maCN, "Bảo trì");
            data.PhongNgung = GetPhongTheoTrangThai(maCN, "Ngưng hoạt động");

            data.DoanhThu = statisticsDAL.GetDoanhThu(maCN, year, month);
            data.ChiPhi = statisticsDAL.GetChiPhi(maCN, year, month);
            data.DatCoc = statisticsDAL.GetDatCoc(maCN, year, month);
            data.HoanTien = statisticsDAL.GetHoanTien(maCN, year, month);

            data.TongDatPhong = statisticsDAL.GetTongDatPhong(maCN, year, month);
            data.DatPhongHoanTat = statisticsDAL.GetDatPhongTheoTrangThai("Hoàn tất", maCN, year, month);
            data.DatPhongHuy = statisticsDAL.GetDatPhongTheoTrangThai("Hủy", maCN, year, month);

            data.TongSuKien = statisticsDAL.GetTongSuKien(maCN, year, month);
            data.DoanhThuSuKien = statisticsDAL.GetDoanhThuSuKien(maCN, year, month);

            data.TongKhachHang = statisticsDAL.GetTongKhachHang();
            data.KhachHangMoi = statisticsDAL.GetKhachHangMoi(year, month);
            data.TongNhanVien = GetTongNhanVien(maCN);

            data.TongDichVu = GetTongDichVu();
            data.DoanhThuDichVu = statisticsDAL.GetDoanhThuDichVu(maCN, year, month);

            return data;
        }

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
    }
}






namespace QLResort.Core.Model
{
    public class StatisticsData
    {
        public int TongPhong { get; set; }
        public int PhongTrong { get; set; }
        public int PhongDangSuDung { get; set; }
        public int PhongBaoTri { get; set; }
        public int PhongNgung { get; set; }

        public decimal DoanhThu { get; set; }
        public decimal ChiPhi { get; set; }
        public decimal LoiNhuan => DoanhThu - ChiPhi;
        public decimal DatCoc { get; set; }
        public decimal HoanTien { get; set; }

        public int TongDatPhong { get; set; }
        public int DatPhongHoanTat { get; set; }
        public int DatPhongHuy { get; set; }
        public decimal TiLeThanhCong => TongDatPhong > 0 ? (DatPhongHoanTat * 100.0m / TongDatPhong) : 0;

        public int TongSuKien { get; set; }
        public decimal DoanhThuSuKien { get; set; }

        public int TongKhachHang { get; set; }
        public int KhachHangMoi { get; set; }
        public int TongNhanVien { get; set; }

        public int TongDichVu { get; set; }
        public decimal DoanhThuDichVu { get; set; }
    }
}

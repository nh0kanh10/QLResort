namespace ET_QLResort
{
    public class StatisticsData
    {
        private int _tongPhong;
        private int _phongTrong;
        private int _phongDangSuDung;
        private int _phongBaoTri;
        private int _phongNgung;
        private decimal _doanhThu;
        private decimal _chiPhi;
        private decimal _datCoc;
        private decimal _hoanTien;
        private int _tongDatPhong;
        private int _datPhongHoanTat;
        private int _datPhongHuy;
        private int _tongSuKien;
        private decimal _doanhThuSuKien;
        private int _tongKhachHang;
        private int _khachHangMoi;
        private int _tongNhanVien;
        private int _tongDichVu;
        private decimal _doanhThuDichVu;

        public int TongPhong 
        { 
            get { return _tongPhong; } 
            set { _tongPhong = value; } 
        }
        
        public int PhongTrong 
        { 
            get { return _phongTrong; } 
            set { _phongTrong = value; } 
        }
        
        public int PhongDangSuDung 
        { 
            get { return _phongDangSuDung; } 
            set { _phongDangSuDung = value; } 
        }
        
        public int PhongBaoTri 
        { 
            get { return _phongBaoTri; } 
            set { _phongBaoTri = value; } 
        }
        
        public int PhongNgung 
        { 
            get { return _phongNgung; } 
            set { _phongNgung = value; } 
        }

        public decimal DoanhThu 
        { 
            get { return _doanhThu; } 
            set { _doanhThu = value; } 
        }
        
        public decimal ChiPhi 
        { 
            get { return _chiPhi; } 
            set { _chiPhi = value; } 
        }
        
        public decimal LoiNhuan => DoanhThu - ChiPhi;
        
        public decimal DatCoc 
        { 
            get { return _datCoc; } 
            set { _datCoc = value; } 
        }
        
        public decimal HoanTien 
        { 
            get { return _hoanTien; } 
            set { _hoanTien = value; } 
        }

        public int TongDatPhong 
        { 
            get { return _tongDatPhong; } 
            set { _tongDatPhong = value; } 
        }
        
        public int DatPhongHoanTat 
        { 
            get { return _datPhongHoanTat; } 
            set { _datPhongHoanTat = value; } 
        }
        
        public int DatPhongHuy 
        { 
            get { return _datPhongHuy; } 
            set { _datPhongHuy = value; } 
        }
        
        public decimal TiLeThanhCong => TongDatPhong > 0 ? (DatPhongHoanTat * 100.0m / TongDatPhong) : 0;

        public int TongSuKien 
        { 
            get { return _tongSuKien; } 
            set { _tongSuKien = value; } 
        }
        
        public decimal DoanhThuSuKien 
        { 
            get { return _doanhThuSuKien; } 
            set { _doanhThuSuKien = value; } 
        }

        public int TongKhachHang 
        { 
            get { return _tongKhachHang; } 
            set { _tongKhachHang = value; } 
        }
        
        public int KhachHangMoi 
        { 
            get { return _khachHangMoi; } 
            set { _khachHangMoi = value; } 
        }
        
        public int TongNhanVien 
        { 
            get { return _tongNhanVien; } 
            set { _tongNhanVien = value; } 
        }

        public int TongDichVu 
        { 
            get { return _tongDichVu; } 
            set { _tongDichVu = value; } 
        }
        
        public decimal DoanhThuDichVu 
        { 
            get { return _doanhThuDichVu; } 
            set { _doanhThuDichVu = value; } 
        }
    }
}

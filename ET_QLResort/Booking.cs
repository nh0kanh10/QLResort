using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Booking : BaseModel
    {
        private string _maDP;
        private string _maKH;
        private string _maNV;
        private string _trangThai;
        private string _ghiChu;
        private DateTime? _ngayDen;
        private DateTime? _ngayDi;
        private int? _nguoiLon;
        private int? _treEm;
        private decimal? _tongTien;
        private decimal? _tienDatCoc;
        private decimal? _tongGiamGia;
        private string _maKM;
        private decimal? _tongTienPhong;
        private decimal? _tongTienDichVu;
        private decimal? _tongHoaDon;
        private string _trangThaiThanhToan;

        public string MaDP 
        { 
            get { return _maDP; } 
            set { _maDP = value; } 
        }
        
        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public string MaNV 
        { 
            get { return _maNV; } 
            set { _maNV = value; } 
        }
        
        public string TrangThai 
        { 
            get { return _trangThai; } 
            set { _trangThai = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
        
        public DateTime? NgayDen 
        { 
            get { return _ngayDen; } 
            set { _ngayDen = value; } 
        }
        
        public DateTime? NgayDi 
        { 
            get { return _ngayDi; } 
            set { _ngayDi = value; } 
        }
        
        public int? NguoiLon 
        { 
            get { return _nguoiLon; } 
            set { _nguoiLon = value; } 
        }
        
        public int? TreEm 
        { 
            get { return _treEm; } 
            set { _treEm = value; } 
        }
        
        public decimal? TongTien 
        { 
            get { return _tongTien; } 
            set { _tongTien = value; } 
        }
        
        public decimal? TienDatCoc 
        { 
            get { return _tienDatCoc; } 
            set { _tienDatCoc = value; } 
        }
        
        public decimal? TongGiamGia 
        { 
            get { return _tongGiamGia; } 
            set { _tongGiamGia = value; } 
        }
        
        public string MaKM 
        { 
            get { return _maKM; } 
            set { _maKM = value; } 
        }
        
        public decimal? TongTienPhong 
        { 
            get { return _tongTienPhong; } 
            set { _tongTienPhong = value; } 
        }
        
        public decimal? TongTienDichVu 
        { 
            get { return _tongTienDichVu; } 
            set { _tongTienDichVu = value; } 
        }
        
        public decimal? TongHoaDon 
        { 
            get { return _tongHoaDon; } 
            set { _tongHoaDon = value; } 
        }
        
        public string TrangThaiThanhToan 
        { 
            get { return _trangThaiThanhToan; } 
            set { _trangThaiThanhToan = value; } 
        }

        // Extended Properties (ViewModel)
        public string TenKH { get; set; }
        public string TenNV { get; set; }
        public string Phong { get; set; } // [NEW] For Grid Display
    }
}

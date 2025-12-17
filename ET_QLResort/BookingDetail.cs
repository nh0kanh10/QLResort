using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class BookingDetail : BaseModel
    {
        private string _maCTDP;
        private string _maDP;
        private string _maPhong;
        private string _maCN;
        private string _maNV;
        private string _maCTDV;
        private DateTime? _ngayDen;
        private DateTime? _ngayDi;
        private DateTime? _ngayCheckIn;
        private DateTime? _ngayCheckOut;
        private int? _nguoiLon;
        private int? _treEm;
        private string _loaiThue;
        private decimal? _giaPhong;
        private int? _soDem;
        private decimal? _thanhTien;
        private string _trangThai;
        private string _ghiChu;

        public string MaCTDP 
        { 
            get { return _maCTDP; } 
            set { _maCTDP = value; } 
        }
        
        public string MaDP 
        { 
            get { return _maDP; } 
            set { _maDP = value; } 
        }
        
        public string MaPhong 
        { 
            get { return _maPhong; } 
            set { _maPhong = value; } 
        }
        
        public string MaCN 
        { 
            get { return _maCN; } 
            set { _maCN = value; } 
        }
        
        public string MaNV 
        { 
            get { return _maNV; } 
            set { _maNV = value; } 
        }
        
        public string MaCTDV 
        { 
            get { return _maCTDV; } 
            set { _maCTDV = value; } 
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
        
        public DateTime? NgayCheckIn 
        { 
            get { return _ngayCheckIn; } 
            set { _ngayCheckIn = value; } 
        }
        
        public DateTime? NgayCheckOut 
        { 
            get { return _ngayCheckOut; } 
            set { _ngayCheckOut = value; } 
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
        
        public string LoaiThue 
        { 
            get { return _loaiThue; } 
            set { _loaiThue = value; } 
        }
        
        public decimal? GiaPhong 
        { 
            get { return _giaPhong; } 
            set { _giaPhong = value; } 
        }
        
        public int? SoDem 
        { 
            get { return _soDem; } 
            set { _soDem = value; } 
        }
        
        public decimal? ThanhTien 
        { 
            get { return _thanhTien; } 
            set { _thanhTien = value; } 
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Invoice : BaseModel
    {
        private string _maHD;
        private string _maDP;
        private string _maCTSK;
        private string _loaiHoaDon;
        private string _maKH;
        private string _maNV;
        private string _maKM;
        private string _maCN;
        private string _trangThai;
        private DateTime? _ngayLap;
        private decimal? _tongTruocKM;
        private decimal? _tongTien;

        public string MaHD 
        { 
            get { return _maHD; } 
            set { _maHD = value; } 
        }
        
        public string MaDP 
        { 
            get { return _maDP; } 
            set { _maDP = value; } 
        }
        
        public string MaCTSK 
        { 
            get { return _maCTSK; } 
            set { _maCTSK = value; } 
        }
        
        public string LoaiHoaDon 
        { 
            get { return _loaiHoaDon; } 
            set { _loaiHoaDon = value; } 
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
        
        public string MaKM 
        { 
            get { return _maKM; } 
            set { _maKM = value; } 
        }
        
        public string MaCN 
        { 
            get { return _maCN; } 
            set { _maCN = value; } 
        }
        
        public string TrangThai 
        { 
            get { return _trangThai; } 
            set { _trangThai = value; } 
        }
        
        public DateTime? NgayLap 
        { 
            get { return _ngayLap; } 
            set { _ngayLap = value; } 
        }
        
        public decimal? TongTruocKM 
        { 
            get { return _tongTruocKM; } 
            set { _tongTruocKM = value; } 
        }
        
        public decimal? TongTien 
        { 
            get { return _tongTien; } 
            set { _tongTien = value; } 
        }
    }
}

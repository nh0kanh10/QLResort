// File: QLResort.Core.Model/Room.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Room : BaseModel
    {
        private string _maPhong;
        private string _maCN;
        private string _maLP;
        private string _soPhong;
        private string _viTri;
        private string _trangThai;
        private string _ghiChu;
        private string _tenLoaiPhong;
        private int? _sucChuaToiDa;
        private decimal? _giaTheoNgay;
        private decimal? _giaTheoGio;
        private decimal? _giaTheoThang;

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
        
        public string MaLP 
        { 
            get { return _maLP; } 
            set { _maLP = value; } 
        }
        
        public string SoPhong 
        { 
            get { return _soPhong; } 
            set { _soPhong = value; } 
        }
        
        public string ViTri 
        { 
            get { return _viTri; } 
            set { _viTri = value; } 
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
        
        public string TenLoaiPhong 
        { 
            get { return _tenLoaiPhong; } 
            set { _tenLoaiPhong = value; } 
        }
        
        public int? SucChuaToiDa 
        { 
            get { return _sucChuaToiDa; } 
            set { _sucChuaToiDa = value; } 
        }
        
        public decimal? GiaTheoNgay 
        { 
            get { return _giaTheoNgay; } 
            set { _giaTheoNgay = value; } 
        }
        
        public decimal? GiaTheoGio 
        { 
            get { return _giaTheoGio; } 
            set { _giaTheoGio = value; } 
        }
        
        public decimal? GiaTheoThang 
        { 
            get { return _giaTheoThang; } 
            set { _giaTheoThang = value; } 
        }
    }
}

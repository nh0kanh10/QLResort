using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class InvoiceDetail : BaseModel
    {
        private string _maCTHD;
        private string _maHD;
        private string _moTa;
        private int? _soLuong;
        private decimal? _donGia;
        private decimal? _thanhTien;

        public string MaCTHD 
        { 
            get { return _maCTHD; } 
            set { _maCTHD = value; } 
        }
        
        public string MaHD 
        { 
            get { return _maHD; } 
            set { _maHD = value; } 
        }
        
        public string MoTa 
        { 
            get { return _moTa; } 
            set { _moTa = value; } 
        }
        
        public int? SoLuong 
        { 
            get { return _soLuong; } 
            set { _soLuong = value; } 
        }
        
        public decimal? DonGia 
        { 
            get { return _donGia; } 
            set { _donGia = value; } 
        }
        
        public decimal? ThanhTien 
        { 
            get { return _thanhTien; } 
            set { _thanhTien = value; } 
        }
    }
}

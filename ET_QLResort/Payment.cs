using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Payment : BaseModel
    {
        private string _maTT;
        private string _maHD;
        private decimal? _soTien;
        private string _maLTT;
        private DateTime? _ngayTT;

        public string MaTT 
        { 
            get { return _maTT; } 
            set { _maTT = value; } 
        }
        
        public string MaHD 
        { 
            get { return _maHD; } 
            set { _maHD = value; } 
        }
        
        public decimal? SoTien 
        { 
            get { return _soTien; } 
            set { _soTien = value; } 
        }
        
        public string MaLTT 
        { 
            get { return _maLTT; } 
            set { _maLTT = value; } 
        }
        
        public DateTime? NgayTT 
        { 
            get { return _ngayTT; } 
            set { _ngayTT = value; } 
        }
    }
}

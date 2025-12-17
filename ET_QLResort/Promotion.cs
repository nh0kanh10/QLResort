using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Promotion : BaseModel
    {
        private string _maKM;
        private string _tenKM;
        private bool _isPhanTram;
        private decimal? _giaTri;
        private string _maLKH;
        private string _maCN;
        private string _maLP;
        private string _maPhong;
        private string _couponCode;
        private DateTime? _ngayBD;
        private DateTime? _ngayKT;
        private string _dieuKien;

        public string MaKM 
        { 
            get { return _maKM; } 
            set { _maKM = value; } 
        }
        
        public string TenKM 
        { 
            get { return _tenKM; } 
            set { _tenKM = value; } 
        }
        
        public bool IsPhanTram 
        { 
            get { return _isPhanTram; } 
            set { _isPhanTram = value; } 
        }
        
        public decimal? GiaTri 
        { 
            get { return _giaTri; } 
            set { _giaTri = value; } 
        }
        
        public string MaLKH 
        { 
            get { return _maLKH; } 
            set { _maLKH = value; } 
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
        
        public string MaPhong 
        { 
            get { return _maPhong; } 
            set { _maPhong = value; } 
        }
        
        public string CouponCode 
        { 
            get { return _couponCode; } 
            set { _couponCode = value; } 
        }
        
        public DateTime? NgayBD 
        { 
            get { return _ngayBD; } 
            set { _ngayBD = value; } 
        }
        
        public DateTime? NgayKT 
        { 
            get { return _ngayKT; } 
            set { _ngayKT = value; } 
        }
        
        public string DieuKien 
        { 
            get { return _dieuKien; } 
            set { _dieuKien = value; } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Voucher : BaseModel
    {
        private string _maVoucher;
        private string _tenVoucher;
        private string _couponCode;
        private bool _isPhanTram;
        private decimal? _giaTri;
        private int? _soLuong;
        private int _soLuongDaDung;
        private string _maLKH;
        private string _maCN;
        private string _maLP;
        private string _maPhong;
        private DateTime? _ngayBD;
        private DateTime? _ngayKT;
        private string _dieuKien;
        private string _trangThai;

        public string MaVoucher 
        { 
            get { return _maVoucher; } 
            set { _maVoucher = value; } 
        }
        
        public string TenVoucher 
        { 
            get { return _tenVoucher; } 
            set { _tenVoucher = value; } 
        }
        
        public string CouponCode 
        { 
            get { return _couponCode; } 
            set { _couponCode = value; } 
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
        
        public int? SoLuong 
        { 
            get { return _soLuong; } 
            set { _soLuong = value; } 
        }
        
        public int SoLuongDaDung 
        { 
            get { return _soLuongDaDung; } 
            set { _soLuongDaDung = value; } 
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
        
        public string TrangThai 
        { 
            get { return _trangThai; } 
            set { _trangThai = value; } 
        }
    }
}

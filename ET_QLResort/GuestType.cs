using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class GuestType : BaseModel
    {
        private string _maLKH = "";
        private string _tenLKH = "";
        private decimal _giamGiaPercent;
        private int _diemToiThieu;
        private string _moTa;

        public string MaLKH 
        { 
            get { return _maLKH; } 
            set { _maLKH = value; } 
        }
        
        public string TenLKH 
        { 
            get { return _tenLKH; } 
            set { _tenLKH = value; } 
        }
        
        public decimal GiamGiaPercent 
        { 
            get { return _giamGiaPercent; } 
            set { _giamGiaPercent = value; } 
        }
        
        public int DiemToiThieu 
        { 
            get { return _diemToiThieu; } 
            set { _diemToiThieu = value; } 
        }
        
        public string MoTa 
        { 
            get { return _moTa; } 
            set { _moTa = value; } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Event : BaseModel
    {
        private string _maSK;
        private string _tenSK;
        private string _loaiSuKien;
        private string _maCN;
        private string _diaDiem;
        private string _ghiChu;
        private decimal? _tongChiPhi;

        public string MaSK 
        { 
            get { return _maSK; } 
            set { _maSK = value; } 
        }
        
        public string TenSK 
        { 
            get { return _tenSK; } 
            set { _tenSK = value; } 
        }
        
        public string LoaiSuKien 
        { 
            get { return _loaiSuKien; } 
            set { _loaiSuKien = value; } 
        }
        
        public string MaCN 
        { 
            get { return _maCN; } 
            set { _maCN = value; } 
        }
        
        public string DiaDiem 
        { 
            get { return _diaDiem; } 
            set { _diaDiem = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
        
        public decimal? TongChiPhi 
        { 
            get { return _tongChiPhi; } 
            set { _tongChiPhi = value; } 
        }
    }
}

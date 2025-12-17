using System;

namespace ET_QLResort
{
    public class EventPackage : BaseModel
    {
        private string _maGoiSK;
        private string _tenGoiSK;
        private string _maSK;
        private string _moTa;
        private decimal _giaCoBan;
        private int _soKhachToiThieu;
        private int? _soKhachToiDa;
        private int? _thoiGianToiThieu;
        private int? _thoiGianToiDa;
        private string _dichVuKemTheo;
        private bool _isGoiMacDinh;
        private string _maCN;
        private string _tenCN;
        private string _loaiSuKien;

        public string LoaiSuKien 
        { 
            get { return _loaiSuKien; } 
            set { _loaiSuKien = value; } 
        }

        public string MaGoiSK 
        { 
            get { return _maGoiSK; } 
            set { _maGoiSK = value; } 
        }
        
        public string TenGoiSK 
        { 
            get { return _tenGoiSK; } 
            set { _tenGoiSK = value; } 
        }
        
        public string MaSK 
        { 
            get { return _maSK; } 
            set { _maSK = value; } 
        }
        
        public string MoTa 
        { 
            get { return _moTa; } 
            set { _moTa = value; } 
        }
        
        public decimal GiaCoBan 
        { 
            get { return _giaCoBan; } 
            set { _giaCoBan = value; } 
        }
        
        public int SoKhachToiThieu 
        { 
            get { return _soKhachToiThieu; } 
            set { _soKhachToiThieu = value; } 
        }
        
        public int? SoKhachToiDa 
        { 
            get { return _soKhachToiDa; } 
            set { _soKhachToiDa = value; } 
        }
        
        public int? ThoiGianToiThieu 
        { 
            get { return _thoiGianToiThieu; } 
            set { _thoiGianToiThieu = value; } 
        }
        
        public int? ThoiGianToiDa 
        { 
            get { return _thoiGianToiDa; } 
            set { _thoiGianToiDa = value; } 
        }
        
        public string DichVuKemTheo 
        { 
            get { return _dichVuKemTheo; } 
            set { _dichVuKemTheo = value; } 
        }
        
        public bool IsGoiMacDinh 
        { 
            get { return _isGoiMacDinh; } 
            set { _isGoiMacDinh = value; } 
        }
        
        public string MaCN 
        { 
            get { return _maCN; } 
            set { _maCN = value; } 
        }
        
        public string TenCN 
        { 
            get { return _tenCN; } 
            set { _tenCN = value; } 
        }
    }
}

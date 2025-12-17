using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Deposit : BaseModel
    {
        private string _maDatCoc;
        private string _maDP;
        private string _maCTSK;
        private string _maKH;
        private decimal _soTien;
        private DateTime _ngayCoc;
        private string _hinhThucThanhToan;
        private string _loaiCoc;
        private string _trangThai;
        private string _ghiChu;

        public string MaDatCoc 
        { 
            get { return _maDatCoc; } 
            set { _maDatCoc = value; } 
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
        
        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public decimal SoTien 
        { 
            get { return _soTien; } 
            set { _soTien = value; } 
        }
        
        public DateTime NgayCoc 
        { 
            get { return _ngayCoc; } 
            set { _ngayCoc = value; } 
        }
        
        public string HinhThucThanhToan 
        { 
            get { return _hinhThucThanhToan; } 
            set { _hinhThucThanhToan = value; } 
        }
        
        public string LoaiCoc 
        { 
            get { return _loaiCoc; } 
            set { _loaiCoc = value; } 
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

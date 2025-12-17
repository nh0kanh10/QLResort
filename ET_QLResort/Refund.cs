using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Refund : BaseModel
    {
        private string _maPhieuHoan;
        private string _maDatCoc;
        private decimal _soTienHoan;
        private DateTime _ngayHoan;
        private string _hinhThucHoan;
        private string _trangThai;
        private string _ghiChu;

        public string MaPhieuHoan 
        { 
            get { return _maPhieuHoan; } 
            set { _maPhieuHoan = value; } 
        }
        
        public string MaDatCoc 
        { 
            get { return _maDatCoc; } 
            set { _maDatCoc = value; } 
        }
        
        public decimal SoTienHoan 
        { 
            get { return _soTienHoan; } 
            set { _soTienHoan = value; } 
        }
        
        public DateTime NgayHoan 
        { 
            get { return _ngayHoan; } 
            set { _ngayHoan = value; } 
        }
        
        public string HinhThucHoan 
        { 
            get { return _hinhThucHoan; } 
            set { _hinhThucHoan = value; } 
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

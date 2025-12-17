using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class LostFoundItem : BaseModel
    {
        private string _maLF;
        private string _maKH;
        private string _maNV;
        private string _maCN;
        private string _tenDo;
        private DateTime _ngayTimThay;
        private string _diaDiemTim;
        private string _trangThai;
        private DateTime? _ngayTra;
        private string _nguoiNhan;
        private string _ghiChu;

        public string MaLF 
        { 
            get { return _maLF; } 
            set { _maLF = value; } 
        }
        
        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public string MaNV 
        { 
            get { return _maNV; } 
            set { _maNV = value; } 
        }
        
        public string MaCN 
        { 
            get { return _maCN; } 
            set { _maCN = value; } 
        }
        
        public string TenDo 
        { 
            get { return _tenDo; } 
            set { _tenDo = value; } 
        }
        
        public DateTime NgayTimThay 
        { 
            get { return _ngayTimThay; } 
            set { _ngayTimThay = value; } 
        }
        
        public string DiaDiemTim 
        { 
            get { return _diaDiemTim; } 
            set { _diaDiemTim = value; } 
        }
        
        public string TrangThai 
        { 
            get { return _trangThai; } 
            set { _trangThai = value; } 
        }
        
        public DateTime? NgayTra 
        { 
            get { return _ngayTra; } 
            set { _ngayTra = value; } 
        }
        
        public string NguoiNhan 
        { 
            get { return _nguoiNhan; } 
            set { _nguoiNhan = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
    }
}

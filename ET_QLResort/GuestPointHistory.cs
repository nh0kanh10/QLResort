using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class GuestPointHistory : BaseModel
    {
        private int _id;
        private string _maKH;
        private DateTime _ngay;
        private string _loaiThaoTac;
        private int _diem;
        private string _ghiChu;
        private string _nguoiThucHien;

        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }
        
        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public DateTime Ngay 
        { 
            get { return _ngay; } 
            set { _ngay = value; } 
        }
        
        public string LoaiThaoTac 
        { 
            get { return _loaiThaoTac; } 
            set { _loaiThaoTac = value; } 
        }
        
        public int Diem 
        { 
            get { return _diem; } 
            set { _diem = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
        
        public string NguoiThucHien 
        { 
            get { return _nguoiThucHien; } 
            set { _nguoiThucHien = value; } 
        }
    }
}

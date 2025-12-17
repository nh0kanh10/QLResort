using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class RoomImage : BaseModel
    {
        private string _maAnh;
        private string _maPhong;
        private string _duongDan;
        private string _ghiChu;

        public string MaAnh 
        { 
            get { return _maAnh; } 
            set { _maAnh = value; } 
        }
        
        public string MaPhong 
        { 
            get { return _maPhong; } 
            set { _maPhong = value; } 
        }
        
        public string DuongDan 
        { 
            get { return _duongDan; } 
            set { _duongDan = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
    }
}

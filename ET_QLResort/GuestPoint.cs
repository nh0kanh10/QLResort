using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class GuestPoint : BaseModel
    {
        private string _maKH;
        private int _diemHienTai;
        private DateTime _capNhatLuc;

        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public int DiemHienTai 
        { 
            get { return _diemHienTai; } 
            set { _diemHienTai = value; } 
        }
        
        public DateTime CapNhatLuc 
        { 
            get { return _capNhatLuc; } 
            set { _capNhatLuc = value; } 
        }
    }
}

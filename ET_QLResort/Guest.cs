using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class GuestM : BaseModel
    {
        public static int stt = 1;
        
        private string _maKH;
        private string _hoTen;
        private string _gioiTinh;
        private DateTime _ngaySinh;
        private string _sdt;
        private string _email;
        private string _idType = "CCCD";
        private string _idNumber;
        private string _diaChi;
        private string _maLKH;

        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public string HoTen 
        { 
            get { return _hoTen; } 
            set { _hoTen = value; } 
        }
        
        public string GioiTinh 
        { 
            get { return _gioiTinh; } 
            set { _gioiTinh = value; } 
        }
        
        public DateTime NgaySinh 
        { 
            get { return _ngaySinh; } 
            set { _ngaySinh = value; } 
        }
        
        public string SDT 
        { 
            get { return _sdt; } 
            set { _sdt = value; } 
        }
        
        public string Email 
        { 
            get { return _email; } 
            set { _email = value; } 
        }
        
        public string IDType 
        { 
            get { return _idType; } 
            set { _idType = value; } 
        }
        
        public string IDNumber 
        { 
            get { return _idNumber; } 
            set { _idNumber = value; } 
        }
        
        public string DiaChi 
        { 
            get { return _diaChi; } 
            set { _diaChi = value; } 
        }
        
        public string MaLKH 
        { 
            get { return _maLKH; } 
            set { _maLKH = value; } 
        }

        public GuestM(string hoTen, string gioiTinh, DateTime ngaySinh, string sDT, string email,
            string iDType, string iDNumber, string diaChi, string maLKH, bool isActive, string createBy)
        {
            MaKH = $"KH{stt.ToString("D3")}";
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SDT = sDT;
            Email = email;
            IDType = iDType;
            IDNumber = iDNumber;
            DiaChi = diaChi;
            MaLKH = maLKH;
            CreatedBy = createBy;
            IsActive = isActive;
            CreatedAt = DateTime.Now;
        }
        
        public GuestM()
        {
        }
    }
}

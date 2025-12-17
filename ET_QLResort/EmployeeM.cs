using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class EmployeeM : BaseModel
    {
        public static int stt = 0;
        
        private string _maNV;
        private string _maCN;
        private string _cccd;
        private string _gioiTinh;
        private string _hoTen;
        private string _chucVu;
        private string _sdt;
        private string _email;
        private string _maLoaiNV;
        private string _duongDanAnh;
        private string _tenLoaiNV;
        private string _tenCN;

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
        
        public string CCCD 
        { 
            get { return _cccd; } 
            set { _cccd = value; } 
        }
        
        public string GioiTinh 
        { 
            get { return _gioiTinh; } 
            set { _gioiTinh = value; } 
        }
        
        public string HoTen 
        { 
            get { return _hoTen; } 
            set { _hoTen = value; } 
        }
        
        public string ChucVu 
        { 
            get { return _chucVu; } 
            set { _chucVu = value; } 
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
        
        public string MaLoaiNV 
        { 
            get { return _maLoaiNV; } 
            set { _maLoaiNV = value; } 
        }
        
        public string DuongDanAnh 
        { 
            get { return _duongDanAnh; } 
            set { _duongDanAnh = value; } 
        }
        
        public string TenLoaiNV 
        { 
            get { return _tenLoaiNV; } 
            set { _tenLoaiNV = value; } 
        }
        
        public string TenCN 
        { 
            get { return _tenCN; } 
            set { _tenCN = value; } 
        }

        public EmployeeM() { }
        
        public EmployeeM(string cCCD, string gioiTinh, string hoTen, string chucVu, string sDT, string email, string maLoaiNV, bool isActive)
        {
            MaNV = $"NV{stt.ToString("D3")}";
            MaCN = Session_Now.CurrentResort;
            CCCD = cCCD;
            GioiTinh = gioiTinh;
            HoTen = hoTen;
            ChucVu = chucVu;
            SDT = sDT;
            Email = email;
            MaLoaiNV = maLoaiNV;
            CreatedBy = Session_Now.CurrentUser;
            CreatedAt = DateTime.Now;
            IsActive = isActive;
        }

        public EmployeeM(string maNV, string maCN, string cCCD, string gioiTinh, string hoTen, string chucVu, string sDT, string email, string maLoaiNV, bool isActive)
        {
            MaNV = maNV;
            MaCN = maCN;
            CCCD = cCCD;
            GioiTinh = gioiTinh;
            HoTen = hoTen;
            ChucVu = chucVu;
            SDT = sDT;
            Email = email;
            MaLoaiNV = maLoaiNV;
            IsActive = isActive;
        }
    }
}

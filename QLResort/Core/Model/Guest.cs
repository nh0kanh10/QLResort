using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Guest:BaseModel
    {
        static public int stt = 1;
        public Guest( string hoTen, string gioiTinh, DateTime? ngaySinh, string sDT, string email, string iDType, string iDNumber, string diaChi, string maLKH, bool isActive)
        {
            MaKH =  $"KH{stt.ToString("D3")}";
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SDT = sDT;
            Email = email;
            IDType = iDType;
            IDNumber = iDNumber;
            DiaChi = diaChi;
            MaLKH = maLKH;
            CreatedBy = Session_Now.CurrentUser;
            IsActive = isActive;
            CreatedAt = DateTime.Now;
        }
        public Guest()
        {
            // Parameterless constructor for flexibility
        }
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string IDType { get; set; } = "CCCD";
        public string IDNumber { get; set; }
        public string DiaChi { get; set; }
        public string MaLKH { get; set; }
       
    }
}

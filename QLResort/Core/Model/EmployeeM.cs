using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class EmployeeM : BaseModel
    {
        public static int stt = 0;
        public string MaNV { get; set; }
        public string MaCN { get; set; }
        public string CCCD { get; set; }
        public string GioiTinh { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string MaLoaiNV { get; set; }

        public string TenLoaiNV { get; set; }
        public string TenCN { get; set; }

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

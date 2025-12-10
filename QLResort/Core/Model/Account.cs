using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Account : BaseModel
    {
        public string MaTK { get; set; }
        public string MaNV { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Role { get; set; } = "NhanVien"; // NhanVien, QuanLy, Admin
        
        // BaseModel inherits: CreatedAt, CreatedBy, UpdatedAt, UpdatedBy, IsActive
    }
}

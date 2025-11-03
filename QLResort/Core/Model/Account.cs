using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Account
    {
        public string MaTK { get; set; }
        public string MaNV { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

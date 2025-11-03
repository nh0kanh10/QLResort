using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    public class Service
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public string LoaiDV { get; set; }
        public string MoTa { get; set; }
        public decimal? Gia { get; set; }
        public bool ChoPhepDoiDiem { get; set; }
        public int? GiaTriDoiDiem { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}

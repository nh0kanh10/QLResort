using System;

namespace QLResort.Core.Model
{
    public class EventPackage : BaseModel
    {
        public string MaGoiSK { get; set; }
        public string TenGoiSK { get; set; }
        public string LoaiSuKien { get; set; }
        public string MoTa { get; set; }
        public decimal GiaCoBan { get; set; }
        public int SoKhachToiThieu { get; set; }
        public int? SoKhachToiDa { get; set; }
        public int? ThoiGianToiThieu { get; set; }
        public int? ThoiGianToiDa { get; set; }
        public string DichVuKemTheo { get; set; }
        public bool IsGoiMacDinh { get; set; }
        public string MaCN { get; set; }
        public string TenCN { get; set; }
    }
}


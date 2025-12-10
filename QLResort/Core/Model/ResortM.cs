using QLResort.Core.Model;
using System;


namespace QLResort.Core
{
    public class Resort:BaseModel
    {
        public static int stt = 1;
        public string MaCN { get; set; }
        public string TenCN { get; set; }
        public string DiaChi { get; set; }

        public string MaNQL { get; set; }

        public Resort() { }

        public Resort(string tenResort, string diaChi ,string createBy,bool isActive = true,string maNQL = null)
        {
            MaCN = $"CN{stt.ToString("D3")}";          
            TenCN = tenResort;
            DiaChi = diaChi;
            CreatedAt = DateTime.Now;
            CreatedBy = createBy;
            IsActive = isActive;
            MaNQL = maNQL;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.Model
{
    
    public class Booking : BaseModel
    {
        public string MaDP { get; set; }            
        public string MaKH { get; set; }            
        public string MaNV { get; set; }            
        public string TrangThai { get; set; }       
        public string GhiChu { get; set; }          
        
        
        public DateTime? NgayDen { get; set; }  
        public DateTime? NgayDi { get; set; }   
        public int? NguoiLon { get; set; }      
        public int? TreEm { get; set; }         
        public decimal? TongTien { get; set; }          
        public decimal? TienDatCoc { get; set; }        
        public decimal? TongGiamGia { get; set; }       
        public string MaKM { get; set; }                
        public decimal? TongTienPhong { get; set; }     
        public decimal? TongTienDichVu { get; set; }
        public decimal? TongHoaDon { get; set; }      
        public string TrangThaiThanhToan { get; set; }  
    }
}

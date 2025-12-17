using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class VoucherUsage
    {
        private string _maSuDung;
        private string _maVoucher;
        private string _maKH;
        private string _maHD;
        private string _maDP;
        private DateTime _ngaySuDung;
        private decimal? _giaTriApDung;
        private string _ghiChu;
        private DateTime _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;

        public string MaSuDung 
        { 
            get { return _maSuDung; } 
            set { _maSuDung = value; } 
        }
        
        public string MaVoucher 
        { 
            get { return _maVoucher; } 
            set { _maVoucher = value; } 
        }
        
        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public string MaHD 
        { 
            get { return _maHD; } 
            set { _maHD = value; } 
        }
        
        public string MaDP 
        { 
            get { return _maDP; } 
            set { _maDP = value; } 
        }
        
        public DateTime NgaySuDung 
        { 
            get { return _ngaySuDung; } 
            set { _ngaySuDung = value; } 
        }
        
        public decimal? GiaTriApDung 
        { 
            get { return _giaTriApDung; } 
            set { _giaTriApDung = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
        
        public DateTime CreatedAt 
        { 
            get { return _createdAt; } 
            set { _createdAt = value; } 
        }
        
        public string CreatedBy 
        { 
            get { return _createdBy; } 
            set { _createdBy = value; } 
        }
        
        public DateTime? UpdatedAt 
        { 
            get { return _updatedAt; } 
            set { _updatedAt = value; } 
        }
        
        public string UpdatedBy 
        { 
            get { return _updatedBy; } 
            set { _updatedBy = value; } 
        }
    }
}

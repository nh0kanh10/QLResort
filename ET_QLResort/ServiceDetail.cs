using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class ServiceDetail
    {
        private string _maCTDV;
        private string _maCTDP;
        private string _maDV;
        private int? _soLuong;
        private decimal? _gia;
        private decimal? _thanhTien;
        private DateTime _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        private bool _isActive;

        public string MaCTDV 
        { 
            get { return _maCTDV; } 
            set { _maCTDV = value; } 
        }
        
        public string MaCTDP 
        { 
            get { return _maCTDP; } 
            set { _maCTDP = value; } 
        }
        
        public string MaDV 
        { 
            get { return _maDV; } 
            set { _maDV = value; } 
        }
        
        public int? SoLuong 
        { 
            get { return _soLuong; } 
            set { _soLuong = value; } 
        }
        
        public decimal? Gia 
        { 
            get { return _gia; } 
            set { _gia = value; } 
        }
        
        public decimal? ThanhTien 
        { 
            get { return _thanhTien; } 
            set { _thanhTien = value; } 
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
        
        public bool IsActive 
        { 
            get { return _isActive; } 
            set { _isActive = value; } 
        }
    }
}

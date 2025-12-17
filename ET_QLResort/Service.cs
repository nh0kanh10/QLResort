using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Service : BaseModel
    {
        private string _maDV;
        private string _tenDV;
        private string _loaiDV;
        private string _moTa;
        private decimal? _gia;
        private bool _choPhepDoiDiem;
        private int? _giaTriDoiDiem;

        public string MaDV 
        { 
            get { return _maDV; } 
            set { _maDV = value; } 
        }
        
        public string TenDV 
        { 
            get { return _tenDV; } 
            set { _tenDV = value; } 
        }
        
        public string LoaiDV 
        { 
            get { return _loaiDV; } 
            set { _loaiDV = value; } 
        }
        
        public string MoTa 
        { 
            get { return _moTa; } 
            set { _moTa = value; } 
        }
        
        public decimal? Gia 
        { 
            get { return _gia; } 
            set { _gia = value; } 
        }
        
        public bool ChoPhepDoiDiem 
        { 
            get { return _choPhepDoiDiem; } 
            set { _choPhepDoiDiem = value; } 
        }
        
        public int? GiaTriDoiDiem 
        { 
            get { return _giaTriDoiDiem; } 
            set { _giaTriDoiDiem = value; } 
        }
    }
}

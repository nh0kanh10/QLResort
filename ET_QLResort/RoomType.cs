using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class RoomType : BaseModel
    {
        private string _maLP;
        private string _tenLP;
        private string _moTa;
        private bool _isNhaNguyenCan;
        private int _soPhongTrongNha;
        private decimal? _giaTheoGio;
        private decimal? _giaTheoNgay;
        private decimal? _giaTheoThang;
        private int? _sucChuaToiDa;

        public string MaLP 
        { 
            get { return _maLP; } 
            set { _maLP = value; } 
        }
        
        public string TenLP 
        { 
            get { return _tenLP; } 
            set { _tenLP = value; } 
        }
        
        public string MoTa 
        { 
            get { return _moTa; } 
            set { _moTa = value; } 
        }
        
        public bool IsNhaNguyenCan 
        { 
            get { return _isNhaNguyenCan; } 
            set { _isNhaNguyenCan = value; } 
        }
        
        public int SoPhongTrongNha 
        { 
            get { return _soPhongTrongNha; } 
            set { _soPhongTrongNha = value; } 
        }
        
        public decimal? GiaTheoGio 
        { 
            get { return _giaTheoGio; } 
            set { _giaTheoGio = value; } 
        }
        
        public decimal? GiaTheoNgay 
        { 
            get { return _giaTheoNgay; } 
            set { _giaTheoNgay = value; } 
        }
        
        public decimal? GiaTheoThang 
        { 
            get { return _giaTheoThang; } 
            set { _giaTheoThang = value; } 
        }
        
        public int? SucChuaToiDa 
        { 
            get { return _sucChuaToiDa; } 
            set { _sucChuaToiDa = value; } 
        }
    }
}

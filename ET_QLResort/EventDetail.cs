using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class EventDetail : BaseModel
    {
        private string _maCTSK;
        private string _maSK;
        private string _maKH;

        private int _soLuong;
        private decimal _donGia;
        private decimal _thanhTien;
        private string _ghiChu;
        private decimal _daThanhToan;
        private string _trangThai;
        private DateTime _ngayBD;
        private DateTime _ngayKT;
        private int? _tongKhach;

        public string MaCTSK 
        { 
            get { return _maCTSK; } 
            set { _maCTSK = value; } 
        }
        
        public string MaSK 
        { 
            get { return _maSK; } 
            set { _maSK = value; } 
        }
        
        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        

        
        public int SoLuong 
        { 
            get { return _soLuong; } 
            set { _soLuong = value; } 
        }
        
        public decimal DonGia 
        { 
            get { return _donGia; } 
            set { _donGia = value; } 
        }
        
        public decimal ThanhTien 
        { 
            get { return _thanhTien; } 
            set { _thanhTien = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
        
        public decimal DaThanhToan 
        { 
            get { return _daThanhToan; } 
            set { _daThanhToan = value; } 
        }
        
        public string TrangThai 
        { 
            get { return _trangThai; } 
            set { _trangThai = value; } 
        }
        
        public DateTime NgayBD 
        { 
            get { return _ngayBD; } 
            set { _ngayBD = value; } 
        }
        
        public DateTime NgayKT 
        { 
            get { return _ngayKT; } 
            set { _ngayKT = value; } 
        }
        
        public int? TongKhach 
        { 
            get { return _tongKhach; } 
            set { _tongKhach = value; } 
        }
    }
}

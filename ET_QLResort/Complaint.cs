using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class Complaint : BaseModel
    {
        private string _maKN;
        private string _maKH;
        private string _maNV;
        private string _maCN;
        private DateTime _ngayGhi;
        private string _noiDung;
        private string _mucDo;
        private string _trangThai;
        private string _ketQua;
        private decimal _soTienBoiThuong;
        private string _ghiChu;

        public string MaKN 
        { 
            get { return _maKN; } 
            set { _maKN = value; } 
        }
        
        public string MaKH 
        { 
            get { return _maKH; } 
            set { _maKH = value; } 
        }
        
        public string MaNV 
        { 
            get { return _maNV; } 
            set { _maNV = value; } 
        }
        
        public string MaCN 
        { 
            get { return _maCN; } 
            set { _maCN = value; } 
        }
        
        public DateTime NgayGhi 
        { 
            get { return _ngayGhi; } 
            set { _ngayGhi = value; } 
        }
        
        public string NoiDung 
        { 
            get { return _noiDung; } 
            set { _noiDung = value; } 
        }
        
        public string MucDo 
        { 
            get { return _mucDo; } 
            set { _mucDo = value; } 
        }
        
        public string TrangThai 
        { 
            get { return _trangThai; } 
            set { _trangThai = value; } 
        }
        
        public string KetQua 
        { 
            get { return _ketQua; } 
            set { _ketQua = value; } 
        }
        
        public decimal SoTienBoiThuong 
        { 
            get { return _soTienBoiThuong; } 
            set { _soTienBoiThuong = value; } 
        }
        
        public string GhiChu 
        { 
            get { return _ghiChu; } 
            set { _ghiChu = value; } 
        }
    }
}

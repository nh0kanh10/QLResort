using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class PaymentType : BaseModel
    {
        private string _maLTT;
        private string _tenLTT;

        public string MaLTT 
        { 
            get { return _maLTT; } 
            set { _maLTT = value; } 
        }
        
        public string TenLTT 
        { 
            get { return _tenLTT; } 
            set { _tenLTT = value; } 
        }
    }
}

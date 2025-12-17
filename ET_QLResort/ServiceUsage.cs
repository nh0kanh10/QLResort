using System;

namespace ET_QLResort
{
    public class ServiceUsage
    {
        private Service _service;
        private int _quantity = 1;
        private decimal _unitPrice;
        private bool _paidByPoint;

        public Service Service 
        { 
            get { return _service; } 
            set { _service = value; } 
        }
        
        public int Quantity 
        { 
            get { return _quantity; } 
            set { _quantity = value; } 
        }
        
        public decimal UnitPrice 
        { 
            get { return _unitPrice; } 
            set { _unitPrice = value; } 
        }
        
        public bool PaidByPoint 
        { 
            get { return _paidByPoint; } 
            set { _paidByPoint = value; } 
        }

        public string ServiceCode => Service?.MaDV;
        public string ServiceName => Service?.TenDV;
        public decimal Total => UnitPrice * Quantity;

        public ServiceUsage Clone()
        {
            return new ServiceUsage
            {
                Service = Service,
                Quantity = Quantity,
                UnitPrice = UnitPrice,
                PaidByPoint = PaidByPoint
            };
        }
    }
}

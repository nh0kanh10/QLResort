using System;

namespace QLResort.Core.Model
{
    public class ServiceUsage
    {
        public Service Service { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public bool PaidByPoint { get; set; }

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


using OrderingSystem.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; } // Enum or separate entity
        public PaymentProvider PaymentProvider { get; set; }
        public decimal Amount { get; set; }
    }
}

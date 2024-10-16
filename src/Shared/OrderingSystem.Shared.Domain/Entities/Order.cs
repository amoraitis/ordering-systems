using OrderingSystem.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; } // Enum or separate entity
        public List<OrderDetail> OrderDetails { get; set; }
        public Invoice Invoice { get; set; }
    }
}

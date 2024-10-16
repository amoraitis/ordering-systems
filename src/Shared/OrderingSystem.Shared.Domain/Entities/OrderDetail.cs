using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
    }
}

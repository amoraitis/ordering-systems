using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public Order Order { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceUrl { get; set; }
    }
}

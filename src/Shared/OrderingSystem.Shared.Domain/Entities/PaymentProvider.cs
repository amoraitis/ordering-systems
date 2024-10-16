using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Domain.Entities
{
    public class PaymentProvider
    {
        public int PaymentProviderId { get; set; }
        public string Name { get; set; }
        public string PaymentInitiationURL { get; set; }
    }
}

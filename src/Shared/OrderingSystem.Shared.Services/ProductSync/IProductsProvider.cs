using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderingSystem.Shared.Domain.Entities;

namespace OrderingSystem.Shared.Services.ProductSync
{
    public interface IProductsProvider
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}

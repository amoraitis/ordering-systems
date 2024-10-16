using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderingSystem.Shared.Domain.Entities;

namespace OrderingSystem.Shared.Services.ProductSync
{
    public class FakeApiStoreProductsProvider : IProductsProvider
    {
        public FakeApiStoreProductsProvider()
        {
            
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            // Call an external API to get products
            // Example of fetching from an API
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "API Product 1", Price = 100 },
                new Product { ProductId = 2, Name = "API Product 2", Price = 150 }
            };
            return await Task.FromResult(products);
        }
    }
}

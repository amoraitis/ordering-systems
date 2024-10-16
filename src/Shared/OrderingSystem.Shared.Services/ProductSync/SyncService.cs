using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Services.ProductSync
{
    public interface ISyncService
    {
        Task SyncPerformAsync();
    }

    public class SyncService : ISyncService
    {
        private readonly ILogger<SyncService> _logger;
        private readonly IEnumerable<IProductsProvider> _productsProviders;

        public SyncService(ILogger<SyncService> logger, IEnumerable<IProductsProvider> productsProviders)
        {
            _logger = logger;
            _productsProviders = productsProviders;
        }

        public async Task SyncPerformAsync()
        {
            _logger.LogInformation("Performing product sync...");


            foreach(var provider in _productsProviders)
            {
                var products = await provider.GetProductsAsync();
                // Process the products (e.g., save to database, update cache, etc.)
                foreach (var product in products)
                {
                    _logger.LogInformation($"Synced Product: {product.Name} - {product.Price}");
                    // Save or update product logic here
                }
            }

            _logger.LogInformation("Product sync completed.");
        }
    }
}

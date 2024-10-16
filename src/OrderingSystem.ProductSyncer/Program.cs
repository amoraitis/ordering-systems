using OrderingSystem.Shared.Infrastructure.Messaging;
using OrderingSystem.Shared.Services.ProductSync;

namespace OrderingSystem.ProductSyncer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            // Configure RabbitMQ settings
            builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));

            // Register RabbitMQ services
            builder.Services.AddSingleton<RabbitMQConnection>();
            builder.Services.AddSingleton<RabbitMQPublisher>();
            builder.Services.AddSingleton<RabbitMQConsumer>();

            builder.Services.AddSingleton<RabbitMQConsumer>();
            builder.Services.AddSingleton<IProductsProvider, FakeApiStoreProductsProvider>();
            // Register the ProductSyncerWorker as a hosted service
            builder.Services.AddHostedService<ProductSyncerWorker>();

            // Register the SyncService that will handle the actual sync logic
            builder.Services.AddScoped<ISyncService, SyncService>();
            var host = builder.Build();
            host.Run();
        }
    }
}
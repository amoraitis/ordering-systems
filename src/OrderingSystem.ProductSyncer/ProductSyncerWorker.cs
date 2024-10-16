using Microsoft.Extensions.Options;
using OrderingSystem.Shared.Common.Helpers;
using OrderingSystem.Shared.Infrastructure.Messaging;
using OrderingSystem.Shared.Services.ProductSync;

namespace OrderingSystem.ProductSyncer
{
    public class ProductSyncerWorker : BackgroundService
    {
        private readonly ILogger<ProductSyncerWorker> _logger;
        private readonly RabbitMQConsumer _rabbitMqConsumer;
        private readonly ISyncService _syncService;
        private readonly string _syncSchedule;

        public ProductSyncerWorker(
            ILogger<ProductSyncerWorker> logger,
            RabbitMQConsumer rabbitMqConsumer,
            IOptions<RabbitMQSettings> rabbitMqOptions,
            ISyncService syncService,
            IConfiguration config)
        {
            _logger = logger;
            _rabbitMqConsumer = rabbitMqConsumer;
            _syncService = syncService;
            _syncSchedule = "TODO:";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Product Syncer Worker started.");

            // Start the RabbitMQ consumer to listen for ad-hoc sync requests
            _rabbitMqConsumer.StartListening(HandleAdhocSyncRequest);

            // Schedule the sync to run daily at the specified time
            await ScheduleSync(stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                // Wait for further ad-hoc messages or schedule sync
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task HandleAdhocSyncRequest(string message)
        {
            _logger.LogInformation($"Ad-hoc sync requested: {message}");
            await _syncService.SyncPerformAsync();
        }

        private async Task ScheduleSync(CancellationToken stoppingToken)
        {
            // Set up the cron schedule for daily sync
            while (!stoppingToken.IsCancellationRequested)
            {
                var nextRunTime = CronExpressionParser.Parse(_syncSchedule).GetNextOccurrence(DateTime.UtcNow);
                var delay = nextRunTime - DateTime.UtcNow;

                if (delay.HasValue && delay.Value.TotalMilliseconds > 0)
                {
                    await Task.Delay(delay.Value, stoppingToken);
                }

                // Execute daily sync
                await _syncService.SyncPerformAsync();
            }
        }
    }
}

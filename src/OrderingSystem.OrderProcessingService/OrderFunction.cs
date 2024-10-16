using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OrderingSystem.Shared.Domain.Entities;
using OrderingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderingSystem.OrderProcessingService
{
    public class OrderFunction
    {
        private readonly IOrderService _orderService;

        public OrderFunction(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Function("ProcessOrder")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing order...");

            // Parse request body to order object
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var order = JsonSerializer.Deserialize<Order>(requestBody);

            // Process order and publish message to RabbitMQ
            await _orderService.PlaceOrderAsync(order);

            return new OkObjectResult("Order processed successfully");
        }
    }
}

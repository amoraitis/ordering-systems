using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OrderingSystem.Shared.Domain.Entities;
using OrderingSystem.Shared.Infrastructure.Messaging;
using OrderingSystem.Shared.Infrastructure.Repositories;

namespace OrderingSystem.Shared.Services
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(Order order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly RabbitMQPublisher _rabbitMqPublisher;

        public OrderService(IOrderRepository orderRepository, RabbitMQPublisher rabbitMqPublisher)
        {
            _orderRepository = orderRepository;
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        public async Task PlaceOrderAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);

            string orderMessage = JsonSerializer.Serialize(order);
            _rabbitMqPublisher.Publish(orderMessage);
        }
    }
}

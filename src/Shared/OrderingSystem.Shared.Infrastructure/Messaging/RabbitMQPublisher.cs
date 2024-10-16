using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Infrastructure.Messaging
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQConnection _connection;
        private readonly RabbitMQSettings _settings;

        public RabbitMQPublisher(RabbitMQConnection connection, RabbitMQSettings settings)
        {
            _connection = connection;
            _settings = settings;
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _connection.GetChannel().BasicPublish(exchange: _settings.Exchange,
                routingKey: _settings.RoutingKey,
                true,
                basicProperties: null,
                body: body);
        }
    }
}

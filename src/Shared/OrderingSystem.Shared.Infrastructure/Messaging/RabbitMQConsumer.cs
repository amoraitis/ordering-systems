using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OrderingSystem.Shared.Infrastructure.Messaging
{
    public class RabbitMQConsumer
    {
        private readonly RabbitMQConnection _connection;
        private readonly RabbitMQSettings _settings;

        public RabbitMQConsumer(RabbitMQConnection connection, RabbitMQSettings settings)
        {
            _connection = connection;
            _settings = settings;
        }

        public void StartListening(Func<string, Task> onMessageReceived)
        {
            var consumer = new EventingBasicConsumer(_connection.GetChannel());
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                await onMessageReceived(message); // Process the message
            };

            _connection.GetChannel().BasicConsume(_settings.QueueName, true, consumer: consumer);
        }
    }
}

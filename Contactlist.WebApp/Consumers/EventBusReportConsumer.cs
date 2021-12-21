using AutoMapper;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Core;
using EventBusRabbitMQ.Events;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactlist.WebApp.Consumers
{
    public class EventBusReportConsumer
    {
        private readonly IRabbitMQPersistantConnection _persistentConnection;

        private readonly IMapper _mapper;

        public EventBusReportConsumer(IRabbitMQPersistantConnection persistentConnection)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
          
        }

        public void Consume()
        {
            if (!_persistentConnection.isConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.ReportCreateQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusConstants.ReportCreateQueue, autoAck: true, consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.Span);
            var @event = JsonConvert.DeserializeObject<ReportCreateEvents>(message);

            if (e.RoutingKey == EventBusConstants.ReportCreateQueue)
            {
               
            }
        }

        public void Disconnect()
        {
            _persistentConnection.Dispose();
        }
    }
}
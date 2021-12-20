using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ
{
    public interface IRabbitMQPersistantConnection: IDisposable 
    {
        bool isConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}

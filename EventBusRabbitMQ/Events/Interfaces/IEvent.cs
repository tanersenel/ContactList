using System;

namespace EventBusRabbitMQ.Events.Interfaces
{
    public abstract class IEvent
    {
        public Guid RequestId { get; private init; }
        public DateTime CreationDate { get; private init; }

        public IEvent()
        {
            RequestId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
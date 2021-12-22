using EventBusRabbitMQ;
using EventBusRabbitMQ.Events.Interfaces;
using EventBusRabbitMQ.Producer;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;

namespace EventBusRabbitMQ.Producer
{
    [TestFixture]
    public class EventBusRabbitMQProducerTests
    {
        private IRabbitMQPersistantConnection subRabbitMQPersistantConnection;
        private ILogger<EventBusRabbitMQProducer> subLogger;

        [SetUp]
        public void SetUp()
        {
            this.subRabbitMQPersistantConnection = Substitute.For<IRabbitMQPersistantConnection>();
            this.subLogger = Substitute.For<ILogger<EventBusRabbitMQProducer>>();
        }

        private EventBusRabbitMQProducer CreateEventBusRabbitMQProducer()
        {
            return new EventBusRabbitMQProducer(
                this.subRabbitMQPersistantConnection,
                this.subLogger,
                5);
        }

        [Test]
        public void Publish_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eventBusRabbitMQProducer = this.CreateEventBusRabbitMQProducer();
            string queueName = null;
            IEvent @event = null;

            // Act
            eventBusRabbitMQProducer.Publish(
                queueName,
                @event);

            // Assert
            Assert.Fail();
        }
    }
}

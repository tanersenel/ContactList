using Contactlist.WebApp.Consumers;
using EventBusRabbitMQ;
using NSubstitute;
using NUnit.Framework;

namespace Contactlist.WebApp.Consumers
{
    [TestFixture]
    public class EventBusReportConsumerTests
    {
        private IRabbitMQPersistantConnection subRabbitMQPersistantConnection;

        [SetUp]
        public void SetUp()
        {
            this.subRabbitMQPersistantConnection = Substitute.For<IRabbitMQPersistantConnection>();
        }

        private EventBusReportConsumer CreateEventBusReportConsumer()
        {
            return new EventBusReportConsumer(
                this.subRabbitMQPersistantConnection);
        }

        [Test]
        public void Consume_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eventBusReportConsumer = this.CreateEventBusReportConsumer();

            // Act
            eventBusReportConsumer.Consume();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Disconnect_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eventBusReportConsumer = this.CreateEventBusReportConsumer();

            // Act
            eventBusReportConsumer.Disconnect();

            // Assert
            Assert.Fail();
        }
    }
}

using AutoMapper;
using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Repostories.Interfaces;
using Contactlist.Sourcing.Controllers;
using EventBusRabbitMQ.Producer;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Controllers
{
    [TestFixture]
    public class ReportControllerTests
    {
        private IReportRepository subReportRepository;
        private IMapper subMapper;
        private EventBusRabbitMQProducer subEventBusRabbitMQProducer;
        private ILogger<ReportController> subLogger;

        [SetUp]
        public void SetUp()
        {
            this.subReportRepository = Substitute.For<IReportRepository>();
            this.subMapper = Substitute.For<IMapper>();
            this.subEventBusRabbitMQProducer = Substitute.For<EventBusRabbitMQProducer>();
            this.subLogger = Substitute.For<ILogger<ReportController>>();
        }

        private ReportController CreateReportController()
        {
            return new ReportController(
                this.subReportRepository,
                this.subMapper,
                this.subEventBusRabbitMQProducer,
                this.subLogger);
        }

        [Test]
        public async Task GetReports_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportController = this.CreateReportController();

            // Act
            var result = await reportController.GetReports();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportController = this.CreateReportController();
            string id = null;

            // Act
            var result = await reportController.GetReport(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task CreateReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportController = this.CreateReportController();
            Report report = null;

            // Act
            var result = await reportController.CreateReport(
                report);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task DeleteReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportController = this.CreateReportController();
            string id = null;

            // Act
            var result = await reportController.DeleteReport(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task CompleteReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportController = this.CreateReportController();
            string id = null;

            // Act
            var result = await reportController.CompleteReport(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void TestEvent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportController = this.CreateReportController();

            // Act
            var result = reportController.TestEvent();

            // Assert
            Assert.Fail();
        }
    }
}

using Contactlist.Reporting.Data;
using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Hubs;
using Contactlist.Reporting.Repostories;
using Microsoft.AspNetCore.SignalR;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Repostories
{
    [TestFixture]
    public class ReportRepositoryTests
    {
        private IReportContext subReportContext;
        private IHubContext<ReportHub> subHubContext;

        [SetUp]
        public void SetUp()
        {
            this.subReportContext = Substitute.For<IReportContext>();
            this.subHubContext = Substitute.For<IHubContext<ReportHub>>();
        }

        private ReportRepository CreateReportRepository()
        {
            return new ReportRepository(
                this.subReportContext,
                this.subHubContext);
        }

        [Test]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportRepository = this.CreateReportRepository();
            Report report = null;

            // Act
            await reportRepository.Create(
                report);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportRepository = this.CreateReportRepository();
            string id = null;

            // Act
            var result = await reportRepository.Delete(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetReports_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportRepository = this.CreateReportRepository();

            // Act
            var result = await reportRepository.GetReports();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportRepository = this.CreateReportRepository();
            string id = null;

            // Act
            var result = await reportRepository.GetReport(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task Run_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportRepository = this.CreateReportRepository();
            Report report = null;

            // Act
            await reportRepository.Run(
                report);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var reportRepository = this.CreateReportRepository();
            Report report = null;

            // Act
            var result = await reportRepository.Update(
                report);

            // Assert
            Assert.Fail();
        }
    }
}

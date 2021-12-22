using Contactlist.Contacts.Controllers;
using Contactlist.Contacts.Entities;
using Contactlist.Contacts.RepoSitories.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Contactlist.Contacts.Controllers
{
    [TestFixture]
    public class ContactControllerTests
    {
        private IContactRepository subContactRepository;
        private ILogger<ContactController> subLogger;

        [SetUp]
        public void SetUp()
        {
            this.subContactRepository = Substitute.For<IContactRepository>();
            this.subLogger = Substitute.For<ILogger<ContactController>>();
        }

        private ContactController CreateContactController()
        {
            return new ContactController(
                this.subContactRepository,
                this.subLogger);
        }

        [Test]
        public async Task GetContacts_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactController = this.CreateContactController();

            // Act
            var result = await contactController.GetContacts();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactController = this.CreateContactController();
            string id = null;

            // Act
            var result = await contactController.GetContact(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task CreateContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactController = this.CreateContactController();
            Contact contact = null;

            // Act
            var result = await contactController.CreateContact(
                contact);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task UpdateContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactController = this.CreateContactController();
            Contact contact = null;

            // Act
            var result = await contactController.UpdateContact(
                contact);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task DeleteContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactController = this.CreateContactController();
            string id = null;

            // Act
            var result = await contactController.DeleteContact(
                id);

            // Assert
            Assert.Fail();
        }
    }
}

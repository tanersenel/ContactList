using Contactlist.Contacts.Data.Interfaces;
using Contactlist.Contacts.Entities;
using Contactlist.Contacts.RepoSitories;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Contactlist.Contacts.RepoSitories
{
    [TestFixture]
    public class ContactRepositoryTests
    {
        private IContactContext subContactContext;

        [SetUp]
        public void SetUp()
        {
            this.subContactContext = Substitute.For<IContactContext>();
        }

        private ContactRepository CreateContactRepository()
        {
            return new ContactRepository(
                this.subContactContext);
        }

        [Test]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            Contact contact = null;

            // Act
            await contactRepository.Create(
                contact);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            string id = null;

            // Act
            var result = await contactRepository.Delete(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            string id = null;

            // Act
            var result = await contactRepository.GetContact(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetContacts_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();

            // Act
            var result = await contactRepository.GetContacts();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetContactsByLocation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            string loc = null;

            // Act
            var result = await contactRepository.GetContactsByLocation(
                loc);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetContactsByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            string name = null;

            // Act
            var result = await contactRepository.GetContactsByName(
                name);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            Contact contact = null;

            // Act
            var result = await contactRepository.Update(
                contact);

            // Assert
            Assert.Fail();
        }
    }
}

using Contactlist.Contacts.Data;
using Contactlist.Contacts.Settings;
using NSubstitute;
using NUnit.Framework;

namespace Contactlist.Contacts.Data
{
    [TestFixture]
    public class ContactContextTests
    {
        private IContactDatabaseSettings subContactDatabaseSettings;

        [SetUp]
        public void SetUp()
        {
            this.subContactDatabaseSettings = Substitute.For<IContactDatabaseSettings>();
        }

        private ContactContext CreateContactContext()
        {
            return new ContactContext(
                this.subContactDatabaseSettings);
        }

        [Test]
        public void TestMethod1()
        {
            // Arrange
            var contactContext = this.CreateContactContext();

            // Act


            // Assert
            Assert.Fail();
        }
    }
}

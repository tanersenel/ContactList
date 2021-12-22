using Contactlist.Contacts.Data;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Contactlist.Contacts.Data
{
    [TestFixture]
    public class ContactContextSeedTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private ContactContextSeed CreateContactContextSeed()
        {
            return new ContactContextSeed();
        }

        [Test]
        public void SeedData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactContextSeed = this.CreateContactContextSeed();
            IMongoCollection contactCollection = null;

            // Act
            contactContextSeed.SeedData(
                contactCollection);

            // Assert
            Assert.Fail();
        }
    }
}

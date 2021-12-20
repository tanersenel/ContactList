using Contactlist.Contacts.Data.Interfaces;
using Contactlist.Contacts.Entities;
using Contactlist.Contacts.Settings;
using MongoDB.Driver;

namespace Contactlist.Contacts.Data
{
    public class ContactContext : IContactContext
    {
        public ContactContext(IContactDatabaseSettings settings  )
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Contacts = database.GetCollection<Contact>(settings.CollectionName);
            ContactContextSeed.SeedData(Contacts);
        }
        public IMongoCollection<Contact> Contacts { get; }
    }
}

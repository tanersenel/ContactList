using Contactlist.Contacts.Entities;
using MongoDB.Driver;

namespace Contactlist.Contacts.Data.Interfaces
{
    public interface IContactContext
    {
        IMongoCollection<Contact> Contacts { get; }
    }
}

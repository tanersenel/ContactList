using Contactlist.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Contacts.RepoSitories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(string id);
        Task<IEnumerable<Contact>> GetContactsByName(string name);
        Task<IEnumerable<Contact>> GetContactsByLocation(string loc);
        Task Create(Contact contact);
        Task<bool> Update(Contact contact);
        Task<bool> Delete(string id);
    }
}

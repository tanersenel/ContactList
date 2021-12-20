using Contactlist.Contacts.Data.Interfaces;
using Contactlist.Contacts.Entities;
using Contactlist.Contacts.RepoSitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Contactlist.Contacts.RepoSitories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactContext _context;
        public ContactRepository(IContactContext context)
        {
            _context = context;
        }
        public async Task Create(Contact contact)
        {
            await _context.Contacts.InsertOneAsync(contact); 
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Contact>.Filter.Eq(c => c.UUID, id);
            DeleteResult deleteResult = await _context.Contacts.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Contact> GetContact(string id)
        {
            return await  _context.Contacts.Find(c => c.UUID==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context.Contacts.Find(c=>true).ToListAsync();
        }

        public Task<IEnumerable<Contact>> GetContactsByLocation(string loc)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetContactsByName(string name)
        {
            var filter = Builders<Contact>.Filter.Eq(c => c.Ad , name);
            return await _context.Contacts.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Contact contact)
        {
            
            var updateResult = await _context.Contacts.ReplaceOneAsync(filter:c=>c.UUID == contact.UUID,replacement:contact);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
           
        }
    }
}

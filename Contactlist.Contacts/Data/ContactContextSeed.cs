using Contactlist.Contacts.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Contacts.Data
{
    public class ContactContextSeed
    {
        public static void SeedData(IMongoCollection<Contact> contactCollection)
        {
            bool existContact = contactCollection.Find(c => true).Any();
            if(!existContact)
            {
                contactCollection.InsertManyAsync(GetConfigureContacts());
            }
        }

        private static IEnumerable<Contact> GetConfigureContacts()
        {
           return new List<Contact>()
           {
               new Contact
               {
                   Ad="Taner",
                   Soyad = "ŞENEL",
                   Firma ="Rise Teknoloji",
                   IletisimBilgileri = new List<ContactDetail>
                   {
                       new ContactDetail
                       {
                           BilgiTipi=(int)BilgiTipleri.Telefon,
                           BilgiIcerigi="5442277514"
                       }
                   }
               }
           };
        }
    }
}

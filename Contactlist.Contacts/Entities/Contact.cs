using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Contacts.Entities
{
    public class Contact
    {
        [BsonId]
        public int UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public List<ContactDetail> IletisimBilgileri { get; set; }
    }
    public class ContactDetail
    {
        public int BilgiTipi { get; set; }
        public string BilgiIcerigi { get; set; }
       
    }
}

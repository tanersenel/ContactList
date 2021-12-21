using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        [BsonElement("Ad")]
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

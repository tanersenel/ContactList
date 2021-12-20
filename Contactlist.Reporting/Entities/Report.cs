using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Entities
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public DateTime RaporTarihi { get; set; }
        public int RaporDurum { get; set; }
        public string RaporDurumText { get; set; }

    }
    public enum RaporDurum
    {
        Hazirlaniyor=1,
        Tamamlandi=2
    }
}

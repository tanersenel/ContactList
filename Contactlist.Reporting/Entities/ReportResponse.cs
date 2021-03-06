using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Entities
{
    public class ReportResponse
    {
        public string ReportUUID { get; set; }
        public string Konum { get; set; }
        public int KisiSayisi { get; set; }
        public int TelefonNoSayisi { get; set; }
    }
}

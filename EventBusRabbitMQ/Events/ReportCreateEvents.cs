using EventBusRabbitMQ.Events.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EventBusRabbitMQ.Events
{
    public class ReportCreateEvents:IEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public DateTime RaporTarihi { get; set; }
        public int RaporDurum { get; set; }
        public string RaporDurumText { get; set; }
        [JsonProperty("ReportResponse")]
        public List<ReportResponseModel> RaporSonuc { get; set; }

    }
    public class ReportResponseModel
    {
        public string ReportUUID { get; set; }
        public string Konum { get; set; }
        public int KisiSayisi { get; set; }
        public int TelefonNoSayisi { get; set; }
    }
}

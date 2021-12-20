using EventBusRabbitMQ.Events.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;
using System;

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
        public ReportResponseModel RaporSonuc { get; set; }

    }
    public class ReportResponseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public string ReportUUID { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Konum { get; set; }
        public int KisiSayisi { get; set; }
        public int TelefonNoSayisi { get; set; }
    }
}

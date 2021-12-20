using EventBusRabbitMQ.Events.Interfaces;
using MongoDB.Driver.GeoJsonObjectModel;

namespace EventBusRabbitMQ.Events
{
    public class ReportCreateEvents:IEvent
    {
        public string UUID { get; set; }
        public string ReportUUID { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Konum { get; set; }
        public int KisiSayisi { get; set; }
        public int TelefonNoSayisi { get; set; }

    }
}

using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Settings;
using MongoDB.Driver;

namespace Contactlist.Reporting.Data
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IReportDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Reports = database.GetCollection<Report>(nameof(Report));
            
        }
        public IMongoCollection<Report> Reports { get; }

    }
}

using Contactlist.Reporting.Entities;
using MongoDB.Driver;

namespace Contactlist.Reporting.Data
{
    public interface IReportContext
    {
        IMongoCollection<Report> Reports { get; }
        IMongoCollection<Contact> Contacts { get; }
    }
}

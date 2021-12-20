using Contactlist.Reporting.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Data
{
    public interface IReportContext
    {
        IMongoCollection<Report> Reports { get; }
        IMongoCollection<ReportResponse> ReportResponses { get; }
    }
}

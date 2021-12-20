﻿using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Data
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IReportDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Reports = database.GetCollection<Report>(nameof(Report));
            ReportResponses = database.GetCollection<ReportResponse>(nameof(ReportResponse));
            
        }
        public IMongoCollection<Report> Reports { get; }

        public IMongoCollection<ReportResponse> ReportResponses { get;  }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Settings
{
    public class ReportDatabaseSettings:IReportDatabaseSettings
    {

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

using Contactlist.Reporting.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Repostories.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReports();
        Task<Report> GetReport(string id);
        Task Create(Report report);

        Task<bool> Delete(string id);
        Task Run(Report report);
        Task<bool> Finish(Report report);
    }
}

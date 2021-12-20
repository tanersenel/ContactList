using Contactlist.Reporting.Data;
using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Repostories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Repostories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportContext _context;
        public ReportRepository(IReportContext context)
        {
            _context = context;
        }
        public async Task Create(Report report)
        {
            await _context.Reports.InsertOneAsync(report);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Report>.Filter.Eq(c => c.UUID, id);
            DeleteResult deleteResult = await _context.Reports.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> Finish(Report report)
        {
            report.RaporDurum = (int)RaporDurum.Tamamlandi;
            report.RaporDurumText = "Tamamlandı";
            var updateResult = await _context.Reports.ReplaceOneAsync(filter: c => c.UUID == report.UUID, replacement: report);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<IEnumerable<Report>> GetReports()
        {
            return await _context.Reports.Find(c => true).ToListAsync();
        }

        public async Task<Report> GetReport(string id)
        {
            return await _context.Reports.Find(c => c.UUID == id).FirstOrDefaultAsync();
        }

        public Task Run(Report report)
        {
            throw new System.NotImplementedException();
        }
    }
}

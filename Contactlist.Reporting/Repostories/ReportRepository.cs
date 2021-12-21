using Contactlist.Reporting.Data;
using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Hubs;
using Contactlist.Reporting.Repostories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Linq;

namespace Contactlist.Reporting.Repostories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportContext _context;
        
        private readonly IHubContext<ReportHub> _hub;
        public ReportRepository(IReportContext context, IHubContext<ReportHub> hub)
        {
            _context = context;
            _hub = hub;
        }
        public async Task Create(Report report)
        {
            await _context.Reports.InsertOneAsync(report);
            await _hub.Clients.All.SendAsync("Report", report);
            await Run(report);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Report>.Filter.Eq(c => c.UUID, id);
            DeleteResult deleteResult = await _context.Reports.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Report>> GetReports()
        {
            return await _context.Reports.Find(c => true).ToListAsync();
        }

        public async Task<Report> GetReport(string id)
        {
            return await _context.Reports.Find(c => c.UUID == id).FirstOrDefaultAsync();
        }

        public async Task Run(Report report)
        {
            var cont = _context.Contacts.AsQueryable().ToList();
           
           
            IEnumerable<IGrouping<string, Contact>> groups = cont
            .SelectMany(doc => doc.IletisimBilgileri, (doc, meta) => new { doc, meta })
            .Where(pair => pair.meta.BilgiTipi == 2)
            .GroupBy(pair => pair.meta.BilgiIcerigi, pair => pair.doc);
            

            report.RaporSonuc = new List<ReportResponse>();
            foreach (var item in groups)
            {
               
                report.RaporSonuc.Add(new ReportResponse() { 
                    KisiSayisi=item.Count(),
                    Konum = item.Key,
                    ReportUUID = report.UUID,
                    TelefonNoSayisi = item.ToList().Where(x => x.IletisimBilgileri.Where(y => y.BilgiTipi == 1).Any()).Count()
                   
                });
            }

            report.RaporDurum = (int)RaporDurum.Tamamlandi;
            report.RaporDurumText = "Tamamlandı";
            await Update(report);
            await _hub.Clients.All.SendAsync("Report", report);
        }

        public async Task<bool> Update(Report report)
        {
            var updateResult = await _context.Reports.ReplaceOneAsync(filter: c => c.UUID == report.UUID, replacement: report);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            
        }
    }
}

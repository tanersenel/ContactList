using Contactlist.Reporting.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Hubs
{
    public class ReportHub : Hub
    {
        public async Task SendReportAsync(Report report)
        {
            await Clients.All.SendAsync("Report", report);
        }
    }
}

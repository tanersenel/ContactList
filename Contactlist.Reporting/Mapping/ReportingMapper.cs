using AutoMapper;
using Contactlist.Reporting.Entities;
using EventBusRabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.Reporting.Mapping
{
    public class ReportingMapper:Profile
    {
        public ReportingMapper()
        {
            CreateMap<ReportCreateEvents, Report>().ReverseMap();
            CreateMap<ReportResponseModel , ReportResponse>().ReverseMap();
        }
    }
}

using AutoMapper;
using EventBusRabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactlist.WebApp.Mapping
{
    public class ReportMapping : Profile
    {
        public ReportMapping()
        {
            //CreateMap<ReportCreateEvents, ReportCreateCommand>().ReverseMap();
        }
    }
}

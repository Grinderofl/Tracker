using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Core.Domain;
using Tracker.Features.Events.Models;

namespace Tracker.Features.Core.Mapping
{
    public class EventMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Entry, EventListItem>()
                .ForMember(x => x.Raid, x => x.MapFrom(c => c.Raid != null ? c.Raid.Name  : ""))
                .ForMember(x => x.Participants, x => x.MapFrom(c => c.Attendances.Count));

            CreateMap<IEnumerable<Entry>, EventsListViewModel>()
                .ForMember(x => x.Events,
                    c => c.MapFrom(x => Mapper.Map<IEnumerable<Entry>, IEnumerable<EventListItem>>(x)));

            CreateMap<EventFieldsModel, Entry>();
            CreateMap<Raid, SelectListItem>()
                .ForMember(x => x.Text, x => x.MapFrom(c => c.Name))
                .ForMember(x => x.Value, x => x.MapFrom(c => c.Id));
        }
    }
}
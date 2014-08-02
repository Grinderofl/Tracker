using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Core.Domain;
using Core.Domain.Base;
using Tracker.Features.Core.Mapping;

namespace Tracker.Features.Events.Models.Mapping
{
    public class EventProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<IEnumerable<Entry>, EventsListViewModel>()
                .ForMember(x => x.Events,
                    c => c.MapFrom(x => Mapper.Map<IEnumerable<Entry>, IEnumerable<EventListItem>>(x)));
            CreateMap<Entry, EventListItem>()
                .ForMember(x => x.Raid, x => x.MapFrom(c => c.Raid != null ? c.Raid.Name : ""))
                .ForMember(x => x.Participants, x => x.MapFrom(c => c.Attendances.Count));

            CreateMap<Entry, EventFieldsModel>()
                .ForMember(x => x.PossibleRaids, x => x.ResolveUsing<RaidResolver>().FromMember(c => c.Raid))
                .ForMember(x => x.RaidId, x => x.MapFrom(c => c.Raid.Id))
                .ForMember(x => x.Attendees, x => x.ResolveUsing<EntryToAttendeesResolver>());

            CreateMap<EventFieldsModel, Entry>()
                .ConvertUsing<EventFieldsModelToEntryConverter>();

            CreateMap<EventFieldsModel, EventFieldsModel>()
                .ForMember(x => x.PossibleRaids, x => x.ResolveUsing<RaidResolver>())
                .ForMember(x => x.Attendees, x => x.ResolveUsing<EventFieldToAttendeesResolver>());

            CreateMap<Raid, SelectListItem>()
                .ForMember(x => x.Text, x => x.MapFrom(c => c.Name))
                .ForMember(x => x.Value, x => x.MapFrom(c => c.Id));
            
            CreateMap<Attendance, AttendanceItem>();
            CreateMap<Character, AttendanceItem>()
                .ForMember(x => x.Character, x => x.MapFrom(c => c.Name))
                .ForMember(x => x.CharacterId, x => x.MapFrom(c => c.Id));

            CreateMap<AttendanceItem, Attendance>()
                .ForMember(x => x.Attendee, x => x.Ignore());

        }
    }
}
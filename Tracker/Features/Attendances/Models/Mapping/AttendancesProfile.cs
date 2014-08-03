using System;
using System.Collections.Generic;
using System.Web;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.Domain;

namespace Tracker.Features.Attendances.Models.Mapping
{
    public class AttendancesProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Character, AttendanceListItem>()
                .ForMember(x => x.Attendances, x => x.Ignore())
                .ForMember(x => x.CharacterId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.Character, x => x.MapFrom(c => c.Name));
            CreateMap<IEnumerable<AttendancesFilterModel>, AttendancesListViewModel>().ConvertUsing<AttendancesFilterToListConverter>();
        }
    }
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Core.Domain;

namespace Tracker.Features.Events.Models.Mapping
{
    public class EventFieldToAttendeesResolver : ValueResolver<EventFieldsModel, AttendanceItem[]>
    {
        private readonly DbContext _context;

        public EventFieldToAttendeesResolver(DbContext context)
        {
            _context = context;
        }

        protected override AttendanceItem[] ResolveCore(EventFieldsModel source)
        {
            var characters = _context.Set<Character>().ToList();
            var result = new List<AttendanceItem>();
            foreach (var item in source.Attendees)
            {
                item.Character = characters.First(x => x.Id == item.CharacterId).Name;
                result.Add(item);
            }
            return result.ToArray();
        }
    }
}
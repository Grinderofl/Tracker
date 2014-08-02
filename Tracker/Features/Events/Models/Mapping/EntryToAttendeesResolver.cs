using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Core.Domain;

namespace Tracker.Features.Events.Models.Mapping
{
    public class EntryToAttendeesResolver : ValueResolver<Entry, AttendanceItem[]>
    {
        private readonly DbContext _context;

        public EntryToAttendeesResolver(DbContext context)
        {
            _context = context;
        }

        protected override AttendanceItem[] ResolveCore(Entry source)
        {
            var characters = _context.Set<Character>().ToList();
            var result = new List<AttendanceItem>();

            foreach (var character in characters)
            {
                var mapped = Mapper.Map<AttendanceItem>(character);
                var found = source.Attendances.FirstOrDefault(x => x.Attendee.Id == character.Id);
                Mapper.Map(found, mapped);

                result.Add(mapped);
            }

            return result.ToArray();
        }
    }
}
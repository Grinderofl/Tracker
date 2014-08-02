using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Core.Domain;

namespace Tracker.Features.Events.Models.Mapping
{
    public class EventFieldsModelToEntryConverter : ITypeConverter<EventFieldsModel, Entry>
    {
        private readonly DbContext _context;

        public EventFieldsModelToEntryConverter(DbContext context)
        {
            _context = context;
        }

        public Entry Convert(ResolutionContext context)
        {
            var source = ((EventFieldsModel) context.SourceValue);

            var entry =
                _context.Set<Entry>()
                    .Include(x => x.Attendances.Select(a => a.Attendee))
                    .First(x => x.Id == source.Id);

            // Ids of characters that should be included
            var ids = source.Attendees.Where(x => x.HasAttended).Select(x => x.CharacterId).ToList();
            var nonExistingIds =
                entry.Attendances.Where(x => !ids.Contains(x.Attendee.Id))
                    .Select(x => x.Attendee.Id)
                    .ToList();

            var idsThatExist =
                entry.Attendances.Where(x => ids.Contains(x.Attendee.Id))
                    .Select(x => x.Attendee.Id)
                    .ToList();

            // Remove nonexisting ones
            var nonexisting = entry.Attendances.Where(x => nonExistingIds.Contains(x.Attendee.Id))
                .ToList();
            _context.Set<Attendance>().RemoveRange(nonexisting);

            // Update existing ones
            foreach (var existing in entry.Attendances.Where(x => idsThatExist.Contains(x.Attendee.Id)).ToList())
            {
                Mapper.Map(source.Attendees.First(x => x.CharacterId == existing.Attendee.Id), existing);
            }

            var idsToAdd =
                ids.Except(idsThatExist)
                    .ToList();
            // Get all characters that should be added
            var characters = _context.Set<Character>().Where(x => idsToAdd.Contains(x.Id)).ToList();
            foreach (var attendance in source.Attendees.Where(x => idsToAdd.Contains(x.CharacterId)).ToList())
            {
                var attendee = Mapper.Map<AttendanceItem, Attendance>(attendance);
                attendee.Attendee = characters.First(x => x.Id == attendance.CharacterId);
                attendee.Entry = entry;
                _context.Set<Attendance>().Add(attendee);
            }
            return entry;
        }
    }
}
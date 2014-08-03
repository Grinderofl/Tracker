using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Ports;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Core.Domain;
using Microsoft.Ajax.Utilities;

namespace Tracker.Features.Attendances.Models.Mapping
{
    public class AttendancesFilterToListConverter : ITypeConverter<IEnumerable<AttendancesFilterModel>, AttendancesListViewModel>
    {
        private readonly DbContext _context;

        public AttendancesFilterToListConverter(DbContext context)
        {
            _context = context;
        }

        public AttendancesListViewModel Convert(ResolutionContext context)
        {
            var model = (AttendancesListViewModel) context.DestinationValue;

            int? sort = null;
            string order = "";

            foreach (var filter in model.Filter)
            {
                if (!filter.Sort.IsNullOrWhiteSpace())
                {
                    sort = model.Filter.IndexOf(filter);
                    order = filter.Sort;
                }
                var q = _context.Set<Entry>().AsQueryable();
                if (filter.Start.HasValue)
                    q = q.Where(x => x.RaidDate >= filter.Start.Value);
                if (filter.End.HasValue)
                    q = q.Where(x => x.RaidDate <= filter.End.Value);
                var count = q.Count();

                var l = q.SelectMany(x => x.Attendances).Select(x => x.Attendee.Id).ToList();

                foreach (var entry in model.Attendance)
                {
                    var attended = l.Count(x => x == entry.CharacterId);
                    entry.Attendances.Add((double)attended/count);
                }
            }
            if (sort != null)
                model.Attendance = order == "down"
                    ? model.Attendance.OrderBy(x => x.Attendances.ElementAt(0)).ToList()
                    : model.Attendance.OrderByDescending(x => x.Attendances.ElementAt(0)).ToList();
            

            return model;
        }
    }
}
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Core.Domain;
using Tracker.Features.Events.Models;

namespace Tracker.Features.Core.Mapping
{
    public class EventListItemRaidResolver : ValueResolver<EventFieldsModel, Raid>
    {
        private readonly DbContext _context;

        public EventListItemRaidResolver(DbContext context)
        {
            _context = context;
        }

        protected override Raid ResolveCore(EventFieldsModel source)
        {
            return _context.Set<Raid>().FirstOrDefault(x => x.Id == source.RaidId);
        }
    }
}
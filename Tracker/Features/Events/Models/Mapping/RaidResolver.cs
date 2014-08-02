using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Core.Domain;

namespace Tracker.Features.Events.Models.Mapping
{
    public class RaidResolver : IValueResolver
    {
        private readonly DbContext _context;

        public RaidResolver(DbContext context)
        {
            _context = context;
        }

        public ResolutionResult Resolve(ResolutionResult source)
        {
            var possibleRaids = Mapper.Map<IEnumerable<SelectListItem>>(_context.Set<Raid>().ToList());
            return source.New(possibleRaids, typeof(IEnumerable<SelectListItem>));
        }
    }
}
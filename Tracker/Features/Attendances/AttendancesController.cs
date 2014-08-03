using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Core.Domain;
using Core.Features.Extensions;
using Core.Features.Queries.Characters;
using Tracker.Features.Attendances.Models;

namespace Tracker.Features.Attendances
{
    public class AttendancesController : Controller
    {
        private readonly DbContext _context;

        public AttendancesController(DbContext context)
        {
            _context = context;
        }

        public ActionResult Index(IList<AttendancesFilterModel> filter = null)
        {
            var model = new AttendancesListViewModel();
            if (filter != null && filter.Any())
            {
                if (!filter.First().Add)
                    filter.Remove(filter.First());
                foreach (var value in filter.ToList())
                    if (value.Delete)
                        filter.Remove(value);
                model.Filter = filter;
            }

            var characters = _context.Query(new SelectActiveCharactersQuery()).ToList();

            model.Attendance = Mapper.Map<IEnumerable<AttendanceListItem>>(characters);

            if (filter != null)
                Mapper.Map(filter, model);
            
            return View(model);
        }
	}
}
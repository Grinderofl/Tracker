using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Core.Domain;
using Tracker.Features.Events.Models;

namespace Tracker.Features.Events
{
    public class EventsController : Controller
    {
        private DbContext _context;

        public EventsController(DbContext context)
        {
            _context = context;
        }

        public ActionResult Index(int page = 1)
        {
            var events =
                _context.Set<Entry>()
                    .Include(x => x.Raid)
                    .Include(x => x.Attendances)
                    .OrderBy(x => x.RaidDate)
                    .Skip((page - 1)*10)
                    .Take(10)
                    .ToList();
            return View(Mapper.Map<EventsListViewModel>(events));
        }

        public ActionResult Create()
        {
            var model = new EventFieldsModel
            {
                PossibleRaids = GetPossibleRaids()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EventFieldsModel model)
        {
            model.PossibleRaids = GetPossibleRaids();
            return View(model);
        }

        private IEnumerable<SelectListItem> GetPossibleRaids()
        {
            return Mapper.Map<IEnumerable<SelectListItem>>(_context.Set<Raid>().ToList());
        }
    }
}
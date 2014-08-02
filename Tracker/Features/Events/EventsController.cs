using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
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
        public ActionResult Create([Bind(Exclude = "Id")]EventFieldsModel model)
        {
            if (ModelState.IsValid)
            {
                var mapped = Mapper.Map<Entry>(model);
                _context.Set<Entry>().Add(mapped);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            model.PossibleRaids = GetPossibleRaids();
            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var loaded = _context.Set<Entry>().Include(x => x.Raid).Include(x => x.Attendances.Select(c => c.Attendee)).First(x => x.Id == id);

            var model =
                Mapper.Map<EventFieldsModel>(loaded);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventFieldsModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Map<Entry>(model);
                _context.SaveChanges();
            }
            return View(Mapper.Map<EventFieldsModel>(model));
        }

        private IEnumerable<SelectListItem> GetPossibleRaids()
        {
            return Mapper.Map<IEnumerable<SelectListItem>>(_context.Set<Raid>().ToList());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.Domain;
using Core;
using Tracker.Features.Core.Extensions;

namespace Tracker.Features.Characters
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: /Characters/
        public ActionResult Index()
        {
            return View(_db.Characters.ToList());
        }

        private void AssignViewItems()
        {
            ViewBag.Races = Races.BloodElf.ToSelectList();
            ViewBag.Classes = Classes.DeathKnight.ToSelectList();
        }

        // GET: /Characters/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: /Characters/Create
        public ActionResult Create()
        {
            AssignViewItems();
            return View();
        }

        // POST: /Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Class,Race")] Character character)
        {
            if (ModelState.IsValid)
            {
                _db.Characters.Add(character);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            AssignViewItems();
            return View(character);
        }

        // GET: /Characters/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: /Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Class,Race,Created,Modified")] Character character)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(character).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        // GET: /Characters/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: /Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Character character = _db.Characters.Find(id);
            _db.Characters.Remove(character);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Core.Domain;
using Core;
using Tracker.Features.Characters.Model;
using Tracker.Features.Core.Extensions;

namespace Tracker.Features.Characters
{
    public class CharactersController : Controller
    {
        private readonly DbContext _db;

        public CharactersController(DbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Set<Character>().ToList());
        }

        private void AssignViewItems()
        {
            ViewBag.Races = Races.BloodElf.ToSelectList();
            ViewBag.Classes = Classes.DeathKnight.ToSelectList();
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Set<Character>().Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        public ActionResult Create()
        {
            return View(new CharacterFieldsModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Name,Class,Race")] CharacterFieldsModel character)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<Character>(character);
                _db.Set<Character>().Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            AssignViewItems();
            return View(character);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Set<Character>().Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Class,Race")] Character character)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(character).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Set<Character>().Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Character character = _db.Set<Character>().Find(id);
            _db.Set<Character>().Remove(character);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

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

        public ActionResult Create(long? lastId)
        {
            if (Request.IsAjaxRequest())
                return PartialView("QuickCreate", new CharacterFieldsModel() {Id = lastId ?? 0});
            return View(new CharacterFieldsModel());
        }

        [HttpPost]
        public ActionResult Create(CharacterFieldsModel[] characters)
        {
            if (ModelState.IsValid)
            {
                var mapped = Mapper.Map<Character[]>(characters);
                foreach (var character in mapped.Where(x => string.IsNullOrWhiteSpace(x.Name)))
                {
                    _db.Set<Character>().Add(character);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            AssignViewItems();
            return View(characters);
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
            return View(Mapper.Map<CharacterFieldsModel>(character));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharacterFieldsModel model)
        {
            if (ModelState.IsValid)
            {
                var character = _db.Set<Character>().First(x => x.Id == model.Id);
                Mapper.Map(model, character);
                _db.Entry(character).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
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

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Core.Domain;

namespace Tracker.Features.Raids
{
    public class RaidsController : Controller
    {
        private readonly DbContext _db;
        public RaidsController(DbContext db)
        {
            _db = db;
        }

        // GET: /Raids/
        public ActionResult Index()
        {
            return View(_db.Set<Raid>().ToList());
        }

        // GET: /Raids/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = _db.Set<Raid>().Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View(raid);
        }

        // GET: /Raids/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Raids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Modified")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                _db.Set<Raid>().Add(raid);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raid);
        }

        // GET: /Raids/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = _db.Set<Raid>().Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View(raid);
        }

        // POST: /Raids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Modified")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(raid).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raid);
        }

        // GET: /Raids/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = _db.Set<Raid>().Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View(raid);
        }

        // POST: /Raids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Raid raid = _db.Set<Raid>().Find(id);
            _db.Set<Raid>().Remove(raid);
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

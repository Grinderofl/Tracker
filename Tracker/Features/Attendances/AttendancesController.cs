using System.Data.Entity;
using System.Web.Mvc;

namespace Tracker.Features.Attendances
{
    public class AttendancesController : Controller
    {
        private DbContext _context;

        public AttendancesController(DbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {

            return View();
        }
	}
}
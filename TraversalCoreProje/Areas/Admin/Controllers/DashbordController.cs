using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class DashbordController : Controller
    {
        DataAccessLayer.Concrate.Context c = new DataAccessLayer.Concrate.Context();
             private static int _visitorCount = 0;
        public IActionResult Index()
        {
            Interlocked.Increment(ref _visitorCount);
            ViewBag.VisitorCount = _visitorCount;//bunu veritabanında tutmak daha mantıklı olur
            var user = c.Users.Count();
            ViewBag.user = user.ToString();
            var destination = c.destinitons.Count().ToString();
            ViewBag.destination = destination;
            var reservation = c.reservitions.Where(x=>x.status== "Die Buchung ist bestätigt.").Count().ToString();
            ViewBag.reservation = reservation;
            return View();
        }
      

    }
}

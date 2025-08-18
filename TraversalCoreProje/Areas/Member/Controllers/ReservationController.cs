using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly UserManager<User> _usermanager;
        ReservationManager _bll = new ReservationManager(new EfReservationDAL());
        DestinitonsManager _destinitonbll = new DestinitonsManager(new EfDestinitionDAL());


        public ReservationController(UserManager<User> usermanager)
        {
            _usermanager = usermanager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
           
            var userr = await _usermanager.GetUserAsync(HttpContext.User);
            if (userr != null)
            {
                ViewBag.userid = userr.Id;
               
            }
            var dest = _destinitonbll.GetById(id);
            if (dest != null)
            {
                ViewBag.dencity=dest.City;
                ViewBag.desid = dest.DestinationID;
                ViewBag.guidid = dest.GuideId;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReservation( ReservationModel p)
        {
            var userr = await _usermanager.GetUserAsync(HttpContext.User);
            if (userr != null)
            {
                if (p != null)
                {

                    Reservition r = new Reservition()
                    {
                        Destintionid = p.Destintionid,
                        Guidid = p.Guidid,
                        HowmanyPapel = Convert.ToInt32(p.HowmanyPapel),
                        ReservDate =DateTime.Now,
                        ReservEnd = Convert.ToDateTime(p.ReservEnd),
                        ReservStart = Convert.ToDateTime(p.ReservStart),
                        status = p.status,
                        Userid = userr.Id,
                        Username = userr.Name,
                    };

                    _bll.Insert(r);
                }

                return View("reservitions");
            }
            else
            {
                return View("reservitions");
            }

        }
        [HttpGet]
        public async Task< IActionResult> GetReservations()
        {
            List<Reservition> reservitions = new List<Reservition>();
            var userr = await _usermanager.GetUserAsync(HttpContext.User);
            if (userr != null)
            {
                ViewBag.userid = userr.Id;
                reservitions = _bll.GetlistByuserid(userr.Id);
            }
            return View(reservitions);
        }

    }
}

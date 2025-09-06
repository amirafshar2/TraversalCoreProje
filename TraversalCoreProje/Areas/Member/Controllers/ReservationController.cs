using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;
using X.PagedList;
using X.PagedList.Extensions;
namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        #region DI
        private readonly UserManager<User> _usermanager;
        private readonly IReservationService _bll;
        private readonly IDestinitionServic _destinitonbll;
        public ReservationController(UserManager<User> usermanager, IReservationService bll, IDestinitionServic destinitonbll)
        {
            _usermanager = usermanager;
            _bll = bll;
            _destinitonbll = destinitonbll;
        }
        #endregion

        #region Create
        [HttpGet]//burasi creatin read kismi 
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
                ViewBag.dencity = dest.City;
                ViewBag.desid = dest.DestinationID;
                //ViewBag.guidid = dest.GuideId;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReservation(ReservationModel p)
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
                        ReservDate = DateTime.Now,
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
        #endregion

        #region Read

        #region waiting Reservations
        [HttpGet]
        public async Task<IActionResult> GetReservations(int page = 1)
        {
            int pageSize = 5
                ;
            List<Reservition> reservitions = new List<Reservition>();
            var userr = await _usermanager.GetUserAsync(HttpContext.User);
            if (userr != null)
            {
                ViewBag.userid = userr.Id;
                reservitions = _bll.GetlistByuserid(userr.Id).OrderBy(y => y.ReservDate).ToList();
                var pagedreservitions = reservitions.ToPagedList(page, pageSize);
                return View(pagedreservitions);
            }
            return View("/User/Login/");
        }
        #endregion
        #region accepted Reservations
        [HttpGet]
        public async Task<IActionResult> AcceptedReservations(int page = 1)
        {
            int pageSize = 5
                ;
            List<Reservition> reservitions = new List<Reservition>();
            var userr = await _usermanager.GetUserAsync(HttpContext.User);
            if (userr != null)
            {
                ViewBag.userid = userr.Id;
                reservitions = _bll.GetlistByuseridaccept(userr.Id).OrderBy(y => y.ReservDate).ToList();
                var pagedreservitions = reservitions.ToPagedList(page, pageSize);
                return View(pagedreservitions);
            }
            return View("/User/Login/");
        }
        #endregion
        #region canceled Reservations
        [HttpGet]
        public async Task<IActionResult> CanceledReservations(int page = 1)
        {
            int pageSize = 5
                ;
            List<Reservition> reservitions = new List<Reservition>();
            var userr = await _usermanager.GetUserAsync(HttpContext.User);
            if (userr != null)
            {
                ViewBag.userid = userr.Id;
                reservitions = _bll.GetlistByuseridcanceld(userr.Id).OrderBy(y => y.ReservDate).ToList();
                var pagedreservitions = reservitions.ToPagedList(page, pageSize);
                return View(pagedreservitions);
            }
            return View("/User/Login/");
        }
        #endregion



        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var r = _bll.GetById(id);
            if (r != null)
            {
                ViewBag.resid = r.id;
                ReservationModel model = new ReservationModel()
                {

                    HowmanyPapel = r.HowmanyPapel.ToString(),
                    ReservDate = r.ReservDate.ToString("dd-MM-yyyy"),
                    ReservStart = r.ReservStart.ToString("dd-MM-yyyy"),
                    ReservEnd = r.ReservEnd.ToString("dd-MM-yyyy"),
                    Userid = r.Userid,
                };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(ReservationModel p)
        {
            var rec = _bll.GetById(p.Userid);// burasi userid ye gore degil reservatıon id ye gore calisiyor vıew dan onu gonderıyorum
            if (rec != null)
            {
                rec.status = "Ihre Genehmigung ist ausstehend.";
                rec.HowmanyPapel = Convert.ToInt32(p.HowmanyPapel);
                rec.ReservStart = Convert.ToDateTime(p.ReservStart);
                rec.ReservEnd = Convert.ToDateTime(p.ReservEnd);
                _bll.Update(rec);
                return RedirectToAction("GetReservations");
            }
            return View(p);
        }
        #endregion

        #region delete
        public IActionResult Delate(int id)
        {
            var r = _bll.GetById(id);
            if (r != null)
            {
                r.status = "Storniert";
                _bll.Update(r);
                return RedirectToAction("GetReservations");
            }
            return RedirectToAction("GetReservations");
        }
        #endregion

    }
}

using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;
using TraversalCoreProje.Models.PicMethods;
using X.PagedList.Extensions;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinitonsManager _Bll = new DestinitonsManager(new EfDestinitionDAL());
        PicSave _pic = new PicSave();
        Context db = new Context();
        private readonly UserManager<EntityLayer.Concrate.User> _usermanager;
        public DestinationController(UserManager<EntityLayer.Concrate.User> usermanager)
        {
            _usermanager = usermanager;
        }
        #region GeminiAI

        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DestinationModel p)
        {
            try
            {
                var u = await _usermanager.GetUserAsync(HttpContext.User);
                if (u != null)
                { // CoverImage, Image2, Image3 zorunlu
                    if (p.coverImage == null || p.image2 == null || p.image3 == null)
                    {
                        ViewBag.message = "Please upload CoverImage, Image2 and Image3 (required).";
                        return View();
                    }
                    // Kaydetme işlemleri
                    p.Image = p.image != null ? await _pic.SaveFileAsync(p.image) : null;         // opsiyonel
                    p.CoverImage = await _pic.SaveFileAsync(p.coverImage); // zorunlu
                    p.Image2 = await _pic.SaveFileAsync(p.image2);         // zorunlu
                    p.Image3 = await _pic.SaveFileAsync(p.image3);         // zorunlu

                    // Entity dönüşümü
                    Destiniton d = DestinationModelToDestiniton(p);
                    d.DestinationID = 0;
                    d.Turlider = u.Id;
                    _Bll.Insert(d);

                    TempData["message"] = "Destination added successfully!";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Login", "User", new { area = "Default" });
            }
            catch (Exception ex)
            {
                ViewBag.message = "An error occurred while saving files: " + ex.Message;
                return View();
            }
        }




        #endregion

        #region read
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;
            var q = _Bll.GetWhitTourlider().OrderBy(y => y.DestinationID).Reverse();

            if (q != null)
            {
                List<DestinationModel> dess = new List<DestinationModel>();
                foreach (var item in q)
                {
                    var user = db.Users.Find(item.Turlider);
                    DestinationModel qe = DestinitonToDestinationModel(item);
                    qe.username = user.Name;
                    qe.usersurname = user.Surname;
                    qe.userimage = user.Image;
                    qe.DestinationID = item.DestinationID;
                    dess.Add(qe);
                }
                var viewpages = dess.ToPagedList(page, pageSize);
                return View(viewpages);
            }
            return View();
        }
        #endregion

        #region update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var q = _Bll.GetById(id);
            var model = DestinitonToDestinationModel(q);
            ViewBag.id = id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DestinationModel p)
        {
            try
            {
                if (p.coverImage != null)
                {
                    p.CoverImage = await _pic.SaveFileAsync(p.coverImage);
                }
                if (p.image != null)
                {
                    p.Image = await _pic.SaveFileAsync(p.image);
                }
                if (p.image2 != null)
                {
                    p.Image2 = await _pic.SaveFileAsync(p.image2);
                }
                if (p.image3 != null)
                {
                    p.Image3 = await _pic.SaveFileAsync(p.image3);
                }
                var q = DestinationModelToDestiniton(p);
                var dest = _Bll.GetById(p.DestinationID);
                dest.City = q.City;
                dest.DayNight = q.DayNight;
                dest.Price = q.Price;
                dest.Capacity = q.Capacity;
                dest.Description = q.Description;
                dest.Detail1 = q.Detail1;
                dest.Detail2 = q.Detail2;
                dest.Detail3 = q.Detail3;
                dest.Detail4 = q.Detail4;
                dest.Detail5 = q.Detail5;
                dest.Title1 = q.Title1;
                dest.Title3 = q.Title3;
                dest.Title4 = q.Title4;
                dest.Title5 = q.Title5;
                dest.Image = q.Image ?? dest.Image;
                dest.CoverImage = q.CoverImage ?? dest.CoverImage;
                dest.Image2 = q.Image2 ?? dest.Image2;
                dest.Image3 = q.Image3 ?? dest.Image3;
                dest.Status = q.Status;
                dest.Turlider = dest.Turlider;
                _Bll.Update(dest);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region delete
        public IActionResult Delete(int id)
        {
            _Bll.Delete(new Destiniton { DestinationID = id });
            return RedirectToAction("Index");
        }
        #endregion

        #region update status
        public IActionResult ChangeStatus(int id, bool status)
        {
            var q = _Bll.GetById(id);
            if (q != null)
            {
                q.Status = status;
                _Bll.Update(q);
                return Json(new { success = true, updated = status });
            }
            else
            {
                // Güncelleme reddedildi
                return Json(new { success = false });
            }

        }
        #endregion

        #region entity dönüşümü
        public Destiniton DestinationModelToDestiniton(DestinationModel p)
        {

            return new Destiniton
            {
                DestinationID = p.DestinationID,
                City = p.City,
                DayNight = p.DayNight,
                Price = p.Price,
                Capacity = p.Capacity,
                Image = p.Image,          // opsiyonel olabilir
                CoverImage = p.CoverImage,
                Image2 = p.Image2,
                Image3 = p.Image3,
                Description = p.Description,
                Status = true,
                Detail1 = p.Detail1,
                Detail2 = p.Detail2,
                Detail3 = p.Detail3,
                Detail4 = p.Detail4,
                Detail5 = p.Detail5,
                Title1 = p.Title1,
                Title3 = p.Title3,
                Title4 = p.Title4,
                Title5 = p.Title5,

            };
        }
        public DestinationModel DestinitonToDestinationModel(Destiniton d)
        {
            return new DestinationModel
            {

                City = d.City,
                DayNight = d.DayNight,
                Price = d.Price,
                Capacity = d.Capacity,
                Image = d.Image,          // opsiyonel olabilir
                CoverImage = d.CoverImage,
                Image2 = d.Image2,
                Image3 = d.Image3,
                Description = d.Description,
                Status = d.Status,
                Detail1 = d.Detail1,
                Detail2 = d.Detail2,
                Detail3 = d.Detail3,
                Detail4 = d.Detail4,
                Detail5 = d.Detail5,
                Title1 = d.Title1,
                Title3 = d.Title3,
                Title4 = d.Title4,
                Title5 = d.Title5,
                turliderid = d.Turlider,
            };
        }
        #endregion
    }

}

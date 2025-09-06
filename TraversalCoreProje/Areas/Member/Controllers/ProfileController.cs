using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;
using TraversalCoreProje.Models.PicMethods;
namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        #region DI
        private readonly UserManager<EntityLayer.Concrate.User> _usermanager;
        PicSave _pic = new PicSave();
        public ProfileController(UserManager<User> usermanager)
        {
            _usermanager = usermanager;
        }
        #endregion

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {

                var user = await _usermanager.GetUserAsync(HttpContext.User);

                UserModel u = new UserModel()
                {
                    email = user.Email,
                    name = user.Name,
                    surename = user.Surname,
                    phone = user.PhoneNumber,
                    gender = user.gender,
                    image = user.Image
                };


                return View(u);
            }
            return View(null);
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserModel user)
        {


            var u = await _usermanager.GetUserAsync(HttpContext.User);
            if (u != null)
            {
                if (user.ImageFile != null)
                {
                    user.image = await _pic.SaveFileAsync(user.ImageFile);
                }
                u.Name = user.name;
                u.PhoneNumber = user.phone;
                u.Surname = user.surename;
                u.Email = user.email;
                u.gender = user.gender;
                var q = await _usermanager.UpdateAsync(u);
                if (q.Succeeded)
                {
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    foreach (var error in q.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }
        #endregion

        #region PasswordChange
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UserModel p)
        {
            var u = await _usermanager.GetUserAsync(HttpContext.User);
            if (u != null)
            {

                if (p.password == p.passwordconfirm)
                {
                    p.name = u.Name;
                    p.email = u.Email;
                    p.surename = u.Surname;
                    p.phone = u.PhoneNumber;
                    p.gender = u.gender;
                    p.image = u.Image;

                    var q = await _usermanager.ChangePasswordAsync(u, p.passwordcurrent, p.passwordconfirm);
                    if (q.Succeeded)
                    {
                        return RedirectToAction("Index", "Profile");
                    }
                    else
                    {
                        foreach (var error in q.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Passwords do not match");
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }



            // اینجا باید همون View رو با مدل برگردونی تا خطاها نمایش داده بشن
            return View("Index", p);  // فرض کردم صفحه تغییر پسوردت Index هست
        }

        #endregion

    }
}

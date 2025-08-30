using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<EntityLayer.Concrate.User> _usermanager;

        public ProfileController(UserManager<User> usermanager)
        {
            _usermanager = usermanager;
        }
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

                    if (user.ImageFile != null && user.ImageFile.Length > 0)
                    {
                        // مسیر پوشه
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                        // اگه پوشه وجود نداره، بسازش
                        if (!Directory.Exists(uploadsFolder))
                            Directory.CreateDirectory(uploadsFolder);

                        // نام فایل یونیک
                        var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(user.ImageFile.FileName);

                        var filePath = Path.Combine(uploadsFolder, uniqueName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await user.ImageFile.CopyToAsync(stream);
                        }

                        // مسیر نسبی برای ذخیره تو دیتابیس
                        u.Image = "/uploads/" + uniqueName;
                    }
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



    }
}

using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        //All calling methods is hire
        #region Calling
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion
        //All calling methods is hire

        //Loging Methods
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            return RedirectToAction("Login", "User");
        }
        #endregion
        //Loging Methods

        //Registor Methods
        #region Registor
        [HttpGet]
        public IActionResult registor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> registor(TraversalCoreProje.Models.Usermodel p)
        {
            User user = new User()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                PhoneNumber = p.Telefonno,
                UserName = p.Email,
                PasswordHash = p.Password,                
                gender = p.Gender
            };
            if (p.imagefile!= null)
            {

                if (p.imagefile != null && p.imagefile.Length > 0)
                {
                    // مسیر پوشه
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                    // اگه پوشه وجود نداره، بسازش
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    // نام فایل یونیک
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(p.imagefile.FileName);

                    var filePath = Path.Combine(uploadsFolder, uniqueName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await p.imagefile.CopyToAsync(stream);
                    }

                    // مسیر نسبی برای ذخیره تو دیتابیس
                    user.Image = "/uploads/" + uniqueName;
                }
            }
         
            if (p.Password == p.PasswordConfirm)
            {
                var q = await _userManager.CreateAsync(user, p.PasswordConfirm);
                if (q.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in q.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
        #endregion 
        //Registor Methods


        //Logout Methods
        #region Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Default");
        }
        #endregion
        //Logout Methods
    }
}

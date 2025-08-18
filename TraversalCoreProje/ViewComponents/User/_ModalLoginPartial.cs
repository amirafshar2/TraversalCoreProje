using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.ViewComponents.User
{
    public class _ModalLoginPartial : ViewComponent
    {
        private readonly UserManager<EntityLayer.Concrate.User> _usermanager;

        public _ModalLoginPartial(UserManager<EntityLayer.Concrate.User> usermanager)
        {
            _usermanager = usermanager;
        }
        int Userid;
        public async Task<IViewComponentResult> InvokeAsync()
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = await _usermanager.GetUserAsync(HttpContext.User);
                ViewBag.Email = user.Email;
                ViewBag.name = user.Name;
                ViewBag.Surname = user.Surname;
                ViewBag.Telefonno = user.Image;
                return View();
            }
            return View(null);
        }
    }
}

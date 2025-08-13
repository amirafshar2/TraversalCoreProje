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
                Userid = user.Id;
                Usermodel u = new Usermodel()
                {
                    
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    Telefonno = user.Image
                };
                

                return View(u);
            }
            return View(null);
        }
    }
}

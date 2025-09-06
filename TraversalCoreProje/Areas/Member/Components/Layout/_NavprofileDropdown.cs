using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace TraversalCoreProje.Areas.Member.Components.Layout
{
    [Area("Member")]
    public class _NavprofileDropdown : ViewComponent
    {
        #region DI
        private readonly UserManager<User> _userManager;

        public _NavprofileDropdown(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        #endregion

        #region InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var q = await _userManager.GetUserAsync(HttpContext.User);
            if (q != null)
            {
                ViewBag.id= q.Id;
                ViewBag.name = q.Name;
                ViewBag.surename = q.Surname;
                ViewBag.image=q.Image;
                
            }
            return View();
        }
        #endregion
    }
}

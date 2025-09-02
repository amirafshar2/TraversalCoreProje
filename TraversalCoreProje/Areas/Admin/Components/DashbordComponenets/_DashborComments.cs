using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Components.DashbordComponenets
{
    public class _DashborComments: ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDAL());
        DestinitonsManager _destinationmanager = new DestinitonsManager(new EfDestinitionDAL());
        private readonly UserManager<EntityLayer.Concrate.User> _usermanager;
        public _DashborComments(UserManager<EntityLayer.Concrate.User> usermanager)
        {
            _usermanager = usermanager;
        }
        public IViewComponentResult Invoke()
        {
            var q = _commentManager.GetAll();
            
            return View(q);
        }
    }
}

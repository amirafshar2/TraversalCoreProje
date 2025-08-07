using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Destinion
{
    public class _CommentPartial : ViewComponent
    {
        CommentManager _Bll = new CommentManager(new EfCommentDAL());
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Id = id;
            var q = _Bll.GetCommentsByDestinionID(id);
            return View(q);
        }
    }
}

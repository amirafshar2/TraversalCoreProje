using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        Context _context = new Context();
        CommentManager Bll = new CommentManager(new EfCommentDAL());
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment([FromBody] mComment c)
        {
            var c1 = new EntityLayer.Concrate.Comment
            {
                CommentData = DateTime.Now,
                status = true,
                CommentContent = c.CommentContent,
                CommentUser = c.CommentUser,
                Destinitonid = c.Destiniton,
            };


            Bll.Insert(c1);
            return Json(new
            {
                success = true,
                comment = new
                {
                    name = c1.CommentUser,
                    content = c1.CommentContent,
                    date = c1.CommentData.ToLongDateString()
                }
            });

         
        }

    }
}

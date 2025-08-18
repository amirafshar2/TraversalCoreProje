using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        Context _context = new Context();
        CommentManager Bll = new CommentManager(new EfCommentDAL());
        
        private readonly UserManager<User> _usermanager;

        public CommentController(UserManager<User> usermanager)
        {
            _usermanager = usermanager;
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] mComment c)
        {
            var userr = await _usermanager.GetUserAsync(HttpContext.User);
            if (userr != null)
            {

                var c1 = new EntityLayer.Concrate.Comment
                {
                    CommentData = DateTime.Now,
                    status = true,
                    CommentContent = c.CommentContent,
                    CommentUser = userr.Name+ "" + userr.Surname,
                    Destinitonid = c.DestinationId,
                    Userid= userr.Id
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
            else
            {
                return View(c);
            }


        }

    }
}

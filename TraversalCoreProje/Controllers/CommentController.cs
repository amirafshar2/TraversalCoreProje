using BusinessLayer.Abstract;
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
        #region DI
        private readonly ICommentService _comment;
        private readonly UserManager<User> _usermanager;
        public CommentController(ICommentService comment, UserManager<User> usermanager)
        {
            _comment = comment;
            _usermanager = usermanager;
        }
        #endregion

        #region Create Comment
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
                    CommentUser = userr.Name + "" + userr.Surname,
                    Destinitonid = c.DestinationId,
                    Userid = userr.Id
                };



                _comment.Insert(c1);
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
        #endregion
    }

}

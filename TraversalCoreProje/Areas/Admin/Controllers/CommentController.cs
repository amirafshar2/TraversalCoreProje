using BusinessLayer.Abstract;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;
using X.PagedList.Extensions;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        #region Dependencies and Constructor
        private readonly ICommentService _Bll;
        private readonly UserManager<User> _usermanager;
        private readonly IUserService _userService;

        public CommentController(ICommentService bll, UserManager<User> usermanager, IUserService userService)
        {
            _Bll = bll;
            _usermanager = usermanager;
            _userService = userService;
        }

        #endregion

        #region Index
        public async Task<IActionResult> Index(int page = 1)
        {
            int pagesize = 8;
            List<CommentWhitUserModel> Com = new List<CommentWhitUserModel>();
            var val = _Bll.GetAll().OrderByDescending(x => x.CommentData);
            if (val != null)
            {
                foreach (var item in val)
                {
                    var user = _userService.GetById(item.Userid);
                    CommentWhitUserModel comment = new CommentWhitUserModel() { 
                    CommentContent=item.CommentContent,
                    CommentData=item.CommentData,
                    CommentUser=item.CommentUser,
                    Destinitonid=item.Destinitonid,
                    id=item.id,
                    status=item.status,
                    Userid=item.Userid,
                    UserImage= user.Image,
                    UserName=user.Name,
                    UserSurname=user.Surname
                    };
                    Com.Add(comment);
                }
            }
            var value = Com.ToPagedList(page, pagesize);
            return View(value);
        }
        #endregion
        #region Delate 
        public IActionResult Delate(int id)
        {
            _Bll.Delete(_Bll.GetById(id));
            return RedirectToAction("Index");
        }
        #endregion
    }
}

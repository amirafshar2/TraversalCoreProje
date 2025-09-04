using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.ViewComponents.Destinion
{
    public class _CommentPartial : ViewComponent
    {

        #region Dependencies and Constructor
        private readonly ICommentService _Bll;
        private readonly IUserService _user;
        private readonly UserManager<EntityLayer.Concrate.User> _usermanager;
        public _CommentPartial(ICommentService bll, IUserService user, UserManager<EntityLayer.Concrate.User> usermanager)
        {
            _Bll = bll;
            _user = user;
            _usermanager = usermanager;
        }
        #endregion

        #region Invoke
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var currentUser = await _usermanager.FindByNameAsync(User.Identity.Name);
            ViewData["ProfileImage"] = currentUser?.Image ?? "~/uploads/default.webp";
            ViewData["desid"] = id;
           var comments = _Bll.GetCommentsByDestinionID(id)
                               .OrderByDescending(x => x.CommentData)
                               .ToList();
            if (comments.Count() != 0)
            {

                var userIds = comments.Select(c => c.Userid).Distinct().ToList();
                var users = _user.GetAll().Where(u => userIds.Contains(u.Id)).ToList();

                var commentModels = comments.Select(item =>
                {
                    var user = users.FirstOrDefault(u => u.Id == item.Userid);
                    return new CommentWhitUserModel
                    {
                        CommentContent = item.CommentContent,
                        CommentData = item.CommentData,
                        CommentUser = item.CommentUser,
                        Destinitonid = item.Destinitonid,
                        id = item.id,
                        status = item.status,
                        Userid = item.Userid,
                        UserImage = user?.Image,
                        UserName = user?.Name,
                        UserSurname = user?.Surname
                    };
                }).ToList();

                return View(commentModels);
            }
            var commentList = new List<CommentWhitUserModel>();
            
            return View(commentList);
        }
        #endregion

    }
}

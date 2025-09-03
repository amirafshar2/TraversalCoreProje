using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Components.DashbordComponenets
{
    public class _DashborComments : ViewComponent
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
            var Commens = _commentManager.GetAll();
            List<CommentWithDestinationundUserModel> _commentWithDestinationundUserModel = new List<CommentWithDestinationundUserModel>();
            int i = 0;
            foreach (var item in Commens)
            {

                if (i < 5)
                {
                    var des = _destinationmanager.GetById(item.Destinitonid);
                    var user = _usermanager.FindByIdAsync(item.Userid.ToString()).Result;
                    CommentWithDestinationundUserModel commentmodel = new CommentWithDestinationundUserModel()
                    {
                        CommentContent = item.CommentContent,
                        CommentData = item.CommentData,
                        CommentUser = item.CommentUser,
                        DesCity = des.City,
                        UserName = user.UserName,
                        UserImage = user.Image,
                        DesImage = des.Image,
                        UserSurname = user.Surname,
                        UserID = user.Id,
                        DestinationID = des.DestinationID,
                        id = item.id,
                        status = item.status
                    };
                    _commentWithDestinationundUserModel.Add(commentmodel);
                    i++;
                }
                else
                {

                }
            }



            return View(_commentWithDestinationundUserModel);
        }
    }
}

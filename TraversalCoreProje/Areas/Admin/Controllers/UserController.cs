using BusinessLayer.Abstract;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TraversalCoreProje.Areas.Admin.Models;
using TraversalCoreProje.Models.PicMethods;
using X.PagedList.Extensions;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        #region DI
        PicSave PicSave = new PicSave();
        private readonly IUserService _User;
        private readonly ICommentService _comment;
        private readonly IDestinitionServic _destination;
        private readonly IReservationService _reservation;
        public UserController(IUserService user, ICommentService comment, IDestinitionServic destination, IReservationService reservation)
        {
            _User = user;
            _comment = comment;
            _destination = destination;
            _reservation = reservation;
        }


        #endregion

        #region Index
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;
            var values = _User.GetAll().ToPagedList(page, pageSize);

            return View(values);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _User.GetById(id);
            UserModel model = new UserModel()
            {
                id = user.Id,
                name = user.Name,
                surename = user.Surname,
                email = user.Email,
                phone = user.PhoneNumber,
                image = user.Image,
                gender = user.gender
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserModel user)
        {


            var u = _User.GetById(user.id);
            if (u != null)
            {
                u.Image = await PicSave.SaveFileAsync(user.ImageFile);
                u.Name = user.name;
                u.PhoneNumber = user.phone;
                u.Surname = user.surename;
                u.Email = user.email;
                u.gender = user.gender;
                _User.Update(u);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete  
        public IActionResult Delete(int id)
        {
            var value = _User.GetById(id);
            if (value != null)
            {
                _User.Delete(value);
            }
            return RedirectToAction("Index");
        }
        #endregion


        #region GetComments
        public IActionResult Comments(int id, int page = 1)
        {
            int pagesize = 6;
            var user = _User.GetById(id);
            var Commentvalues = _comment.GetCommentsByUserID(id);
            var reservationcount = _reservation.GetlistByuseridaccept(id);
            ViewBag.UserName = user.Name + user.Surname;
            ViewBag.UserImage = user.Image;
            ViewBag.Userid = user.Id;
            if (Commentvalues != null)
            {

                ViewBag.CountComment = Commentvalues.Count();
                if (reservationcount != null)
                {
                    ViewBag.ReservationCount = reservationcount.Count();
                }



                List<CommentWithDestinationundUserModel> Models = new List<CommentWithDestinationundUserModel>();
                foreach (var item in Commentvalues)
                {
                    var Destination = _destination.GetById(item.Destinitonid);
                    CommentWithDestinationundUserModel Commnetmodel = new CommentWithDestinationundUserModel()
                    {
                        id = item.id,
                        CommentContent = item.CommentContent,
                        CommentData = item.CommentData,
                        CommentUser = item.CommentUser,
                        DestinationID = item.Destinitonid,
                        UserID = item.Userid,
                        UserImage = user.Image,
                        UserName = user.Name,
                        UserSurname = user.Surname,
                        status = item.status,
                        DesCity = Destination.City,
                        DesImage = Destination.Image
                    };
                    Models.Add(Commnetmodel);

                }
                var Moldess = Models.ToPagedList(page, pagesize);
                return View(Moldess);
            }
            return View(new List<CommentWithDestinationundUserModel>().ToPagedList(page, pagesize));

        }

        #endregion

        #region DelateComment 
        [Route("Admin/User/DelateComment/{idc}/{id}")]

        public IActionResult DelateComment(int idc , int id)
        {
            _comment.Delete(_comment.GetById(idc));
            return RedirectToAction("Comments", new { id = id });
        }
        #endregion

    }
}

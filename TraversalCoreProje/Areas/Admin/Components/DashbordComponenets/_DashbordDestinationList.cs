using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using DataAccessLayer.Migrations;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;
using TraversalCoreProje.Areas.Admin.Mthods;
using X.PagedList;
using X.PagedList.Extensions;

namespace TraversalCoreProje.Areas.Admin.Components.DashbordComponenets
{
    public class _DashbordDestinationList : ViewComponent
    {
        #region DI
        private readonly IDestinitionServic _bll;
        private readonly UserManager<EntityLayer.Concrate.User> _usermanager;
        EntityTauchen _entity = new EntityTauchen();
        public _DashbordDestinationList(IDestinitionServic bll, UserManager<User> usermanager)
        {
            _bll = bll;
            _usermanager = usermanager;
        }
        #endregion

        #region Invoke
        public IViewComponentResult Invoke()
        {

            var values = _bll.GetAll().OrderByDescending(x => x.DestinationID);
            List<DestinationModel> dess = new List<DestinationModel>();
            int i = 0;
            foreach (var item in values)
            {
                if (i < 7)
                {
                    var user = _usermanager.FindByIdAsync(item.Turlider.ToString()).Result;
                    DestinationModel qe = _entity.DestinitonToDestinationModel(item);
                    qe.DestinationID = item.DestinationID;
                    qe.username = user.Name;
                    qe.usersurname = user.Surname;
                    qe.userimage = user.Image;
                    qe.DestinationID = item.DestinationID;
                    dess.Add(qe);
                    i++;
                }
                else
                {

                }
            }

            return View(dess);
        }
        #endregion
    }
}

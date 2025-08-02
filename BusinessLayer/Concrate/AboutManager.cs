using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class AboutManager : IAboutServic
    {
        IAbouteDAL _iaboutedal;

        public AboutManager(IAbouteDAL iaboutedal)
        {
            _iaboutedal = iaboutedal;
        }

        public void Delete(About entity)
        {
            _iaboutedal.Delete(entity);
        }

        public List<About> GetAll()
        {
            return _iaboutedal.GetList();
        }

        public About GetById(int id)
        {
            return _iaboutedal.Get(id);
        }

        public void Insert(About entity)
        {
            _iaboutedal.Insert(entity);
        }

        public void Update(About entity)
        {
            _iaboutedal.Updater(entity);
        }
    }
}

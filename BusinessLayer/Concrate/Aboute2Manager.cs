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
    public class Aboute2Manager : IAbout2Service
    {
        IAbout2DAL _iabout2dal;

        public Aboute2Manager(IAbout2DAL iabout2dal)
        {
            _iabout2dal = iabout2dal;
        }

        public void Delete(About2 entity)
        {
            throw new NotImplementedException();
        }

        public List<About2> GetAll()
        {
            return _iabout2dal.GetList();
        }

        public About2 GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(About2 entity)
        {
            throw new NotImplementedException();
        }

        public void Update(About2 entity)
        {
            throw new NotImplementedException();
        }
    }
}

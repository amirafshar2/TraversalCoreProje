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
    public class GuidManager : IGuideServic
    {
        IGuidDAL _dal;

        public GuidManager(IGuidDAL dal)
        {
            _dal = dal;
        }

        public void Delete(Guide entity)
        {
            throw new NotImplementedException();
        }

        public List<Guide> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guide GetById(int id)
        {
           return _dal.Get(id);
        }

        public void Insert(Guide entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Guide entity)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class DestinitonsManager : IDestinitionServic
    {
        IDestinationDAL _ıDestinationDal;

        public DestinitonsManager(IDestinationDAL ıDestinationDal)
        {
            _ıDestinationDal = ıDestinationDal;
        }

        public void Delete(Destiniton entity)
        {
            throw new NotImplementedException();
        }

        public List<Destiniton> GetAll()
        {
            var q = _ıDestinationDal.GetList();
            List<Destiniton> list = new List<Destiniton>();
            list.AddRange(q.Where(e=>e.Status== true));
            return list;
        }

        public Destiniton GetById(int id)
        {
          return _ıDestinationDal.Get(id);
        }

        public void Insert(Destiniton entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Destiniton entity)
        {
            throw new NotImplementedException();
        }
    }
}

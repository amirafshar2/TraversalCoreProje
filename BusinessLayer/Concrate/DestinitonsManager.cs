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
            return _ıDestinationDal.GetList();
        }

        public Destiniton GetById(int id)
        {
            throw new NotImplementedException();
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

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
            _ıDestinationDal.Delete(entity);
        }

        public List<Destiniton> GetAll()
        {
            return  _ıDestinationDal.GetList();   
        }

        public Destiniton GetById(int id)
        {
          return _ıDestinationDal.Get(id);
        }

        public List<Destiniton> GetWhitTourlider()
        {
            return _ıDestinationDal.GetallWhitTourlider();
        }

        public void Insert(Destiniton entity)
        {
            _ıDestinationDal.Insert(entity);
        }

        public void Update(Destiniton entity)
        {
            _ıDestinationDal.Updater(entity);
        }
    }
}

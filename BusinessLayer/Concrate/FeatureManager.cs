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
    public class FeatureManager : IFeatureServic
    {
        IFeatureDAL _iFeauterdal;

        public FeatureManager(IFeatureDAL iFeauterdal)
        {
            _iFeauterdal = iFeauterdal;
        }

        public void Delete(Feature entity)
        {
            throw new NotImplementedException();
        }

        public List<Feature> GetAll()
        {
            return _iFeauterdal.GetList();
        }

        public Feature GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Feature entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Feature entity)
        {
            throw new NotImplementedException();
        }
    }
}

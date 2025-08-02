using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenerikDAL <T>
    {
        void Insert(T t);
        void Delete(T t);
        void Updater(T t);
        List<T> GetList();
        T Get(int id);
    }

}

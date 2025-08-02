using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenerikDAL<T> where T : class
    {
        public void Delete(T t)
        {
            var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T Get(int id)
        {
            using var c = new Context(); 
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Updater(T t)
        {
            var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}

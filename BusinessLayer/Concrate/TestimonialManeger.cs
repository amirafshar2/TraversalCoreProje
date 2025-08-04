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
    public class TestimonialManeger : ITestimonialServic
    {
        ITestimonialDAL _itestimonialdal;

        public TestimonialManeger(ITestimonialDAL itestimonialdal)
        {
            _itestimonialdal = itestimonialdal;
        }

        public void Delete(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetAll()
        {
            return _itestimonialdal.GetList();
        }

        public Testimonial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Testimonial entity)
        {
            throw new NotImplementedException();
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class CommentManager : ICommentService
    {
        ICommentDAL _icommentdal;

        public CommentManager(ICommentDAL icommentdal)
        {
            _icommentdal = icommentdal;
        }

        public void Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByDestinionID(int id)
        {
            List<Comment> comments = new List<Comment>();
            var q = _icommentdal.GetCommentsByDestinationID(id);
            comments.AddRange(q.Where(i => i.status == true));
            return comments;
            throw new NotImplementedException();

        }

        public void Insert(Comment entity)
        {
            _icommentdal.Insert(entity);
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}

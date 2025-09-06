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
            _icommentdal.Delete(entity);
        }

        public List<Comment> GetAll()
        {
            return _icommentdal.GetList()
                .Where(x => x.status == true)
                .OrderByDescending(x => x.CommentData)
                .ToList();
        }

        public Comment GetById(int id)
        {
            return _icommentdal.Get(id);
        }

        public List<Comment> GetCommentsByDestinionID(int id)
        {
            List<Comment> comments = new List<Comment>();
            var q = _icommentdal.GetCommentsByDestinationID(id);
            comments.AddRange(q.Where(i => i.status == true));
            return comments;
            throw new NotImplementedException();

        }

        public List<Comment> GetCommentsByUserID(int id)
        {
            return _icommentdal.GetCommentsByUserID(id);
        }

        public void Insert(Comment entity)
        {
            _icommentdal.Insert(entity);
        }

        public void Update(Comment entity)
        {
            _icommentdal.Updater(entity);
        }
    }
}

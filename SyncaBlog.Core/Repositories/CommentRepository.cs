using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncaBlog.Core.EF;
using SyncaBlog.Core.Interfaces;
using SyncaBlog.Core.Models;

namespace SyncaBlog.Core.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private MyContext db;

        public CommentRepository(MyContext context)
        {
            this.db = context;
        }
        public void Create(Comment item)
        {
            if (item != null)
                db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment com = db.Comments.Include(e=>e.MyPost).FirstOrDefault(e=>e.Id==id);
            if (com != null)
                db.Comments.Remove(com);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return db.Comments.Where(predicate).ToList();
        }

        public IEnumerable<Comment> FindWithInclude()
        {
            return db.Comments;
        }

        public Comment Get(int id)
        {
           return db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }

        public Comment GetWithInclude(int id)
        {
            return db.Comments.Find(id);
        }

        public void Update(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

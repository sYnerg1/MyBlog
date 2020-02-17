using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncaBlog.Core.EF;
using SyncaBlog.Core.Interfaces;
using SyncaBlog.Core.Models;
using System.Data.Entity;

namespace SyncaBlog.Core.Repositories
{
    class PostRepository : IRepository<Post>
    {
        private MyContext db;

        public PostRepository(MyContext context)
        {
            this.db = context;
        }
        public void Create(Post item)
        {
            if (item != null)
                db.Posts.Add(item);
        }

        public void Delete(int id)
        {
            Post p = db.Posts.Include(e=>e.MyBlog).Include(e=>e.MyComment).Include(e=>e.MyTag).FirstOrDefault(e=>e.Id==id);
            if (p != null)
                db.Posts.Remove(p);
        }

        public IEnumerable<Post> Find(Func<Post, bool> predicate)
        {
            return db.Posts.Include(e=>e.MyTag).Where(predicate);
        }

        public IEnumerable<Post> FindWithInclude()
        {

            return db.Posts.Include(e => e.MyBlog).Include(e => e.MyTag).Include(e => e.MyComment);
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public IEnumerable<Post> GetAll()
        {
            
            return db.Posts;
        }

        public Post GetWithInclude(int id)
        {
            return db.Posts.Include(e => e.MyBlog).Include(e => e.MyTag).Include(e => e.MyComment).FirstOrDefault(e=>e.Id==id);
        }

        public void Update(Post item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

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
    class BlogRepository: IRepository<Blog>
    {
        private MyContext db;

        public BlogRepository(MyContext context)
        {
               
            this.db = context;
        }

        public void Create(Blog item)
        {
            if (item != null)
                db.Blogs.Add(item);
        }

        public void Delete(int id)
        {
         Blog b = db.Blogs.Find(id);
            if (b != null)          
                db.Entry(b).State = EntityState.Deleted;
        }

        public IEnumerable<Blog> Find(Func<Blog, bool> predicate)
        {
            return db.Blogs.Where(predicate).ToList();
        }
        public IEnumerable<Blog> FindWithInclude()
        {

            return db.Blogs.Include(o => o.MyPost);
        }

        public Blog Get(int id)
        {
            Blog b = db.Blogs.Find(id);        
            return b;
        }

        public IEnumerable<Blog> GetAll()
        {
            return db.Blogs;
        }

        public Blog GetWithInclude(int id)
        {
            return db.Blogs.Include(e => e.MyPost.Select(y=>y.MyTag)).FirstOrDefault(e=>e.Id==id);
        }

        public void Update(Blog item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

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
    class TagRepository : IRepository<Tag>
    {
        private MyContext db;

        public TagRepository(MyContext context)
        {
            this.db = context;
        }
        public void Create(Tag item)
        {
            if (item != null)
                db.Tags.Add(item);
        }

        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
                db.Entry(tag).State = EntityState.Deleted;
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            return db.Tags.Where(predicate);
        }

        public IEnumerable<Tag> FindWithInclude()
        {
            return db.Tags.Include(e=>e.MyPost);
        }

        public Tag Get(int id)
        {
            
            return db.Tags.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        public Tag GetWithInclude(int id)
        {
            return db.Tags.Include(e => e.MyPost).FirstOrDefault(e => e.Id == id);
        }

        public void Update(Tag item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

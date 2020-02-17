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
    class UserRepository : IUserService<User>
    {

        private MyContext db;

        public UserRepository(MyContext context)
        {
           
            this.db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }
        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public User Find(Func<User, bool> predicate)
        {
            return db.Users.FirstOrDefault(predicate);
        }

        public User Get(string name)
        {
           return  db.Users.FirstOrDefault(e=>e.Email==name);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public IEnumerable<User> GetAllWithInclude()
        {
            return db.Users.Include(e => e.Role);
        }

        public IEnumerable<User> GetByName(string start)
        {
            return db.Users.Where(e => e.Email.ToLower().StartsWith(start.ToLower()));
        }

        public IEnumerable<User> GetByRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}

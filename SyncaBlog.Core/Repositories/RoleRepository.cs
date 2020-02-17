using SyncaBlog.Core.EF;
using SyncaBlog.Core.Interfaces;
using SyncaBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.Repositories
{
    public class RoleRepository : IRoleService<Role>
    {

        private MyContext db;

        public RoleRepository(MyContext context)
        {

            this.db = context;
        }
        public IEnumerable<Role> GetAll()
        {
            return db.Roles;
        }
    }
}

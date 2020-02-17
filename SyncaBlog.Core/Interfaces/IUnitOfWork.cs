using SyncaBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Blog> Blogs { get; }
        IRepository<Post> Posts { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Comment> Comments { get;  }
        IRoleService<Role> Roles { get;  }
        IUserService<User> Users { get;  }
        void Save();
    }
}

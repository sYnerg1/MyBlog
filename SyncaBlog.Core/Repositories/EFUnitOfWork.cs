using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncaBlog.Core.EF;
using SyncaBlog.Core.Interfaces;
using SyncaBlog.Core.Models;

namespace SyncaBlog.Core.Repositories
{
   public class EFUnitOfWork : IUnitOfWork
    {
        private MyContext db;
        private BlogRepository blogRepository;
        private PostRepository postRepository;
        private TagRepository tagRepository;
        private CommentRepository commentRepository;
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        public EFUnitOfWork(string EFDbContext)
        {
            db = new MyContext(EFDbContext);
        }
        public IUserService<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRoleService<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }
        public IRepository<Blog> Blogs
        {
            get
            {
                if (blogRepository == null)
                    blogRepository = new BlogRepository(db);
                return blogRepository;
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository(db);
                return postRepository;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

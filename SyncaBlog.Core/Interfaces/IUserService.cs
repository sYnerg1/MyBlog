using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.Interfaces
{
   public interface IUserService<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByName(string start);
        IEnumerable<T> GetByRole(string role);
        IEnumerable<T> GetAllWithInclude();
        T Get(string name);   
        void Create(T item);
        void Update(T item);
        T Find(Func<T, Boolean> predicate);


    }
}

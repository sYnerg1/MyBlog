using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.Interfaces
{
    public interface ISpecialPostRepository<T> where T : class
    {

        T GetWithAllInclude(int id);
        IQueryable<T> ForSearh(Func<T, Boolean> predicate);
        IEnumerable<T> FindWithInclude();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}

using SyncaBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.Interfaces
{
    public interface IRoleService<T>  where T:class
    {
        IEnumerable<T> GetAll();
    }
}

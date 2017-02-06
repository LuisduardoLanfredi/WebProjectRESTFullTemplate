using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IRepository<T>
    {
        T Insert(T data);
        T Get(int id);
        IEnumerable<T> List();
    }
}

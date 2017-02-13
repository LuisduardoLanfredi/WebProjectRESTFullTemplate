using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T, P>
    {
        T Insert(T data);
        T Get(int id);
        IEnumerable<T> List(P criteria, string[] fields);
    }
}

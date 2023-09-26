using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILib
{
    public interface ICRUD<T>
    {
        T Get(string id);
        ICollection<T> GetList();
        void Change(string id, T newData);
        void Delete(string id);
        void Add(T newData);
    }
}

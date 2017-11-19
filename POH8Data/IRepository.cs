using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POH8Data
{
    public interface IRepository<T>
    {
        bool Lisaa(T o);
        bool Poista(int id);
        bool Muuta(T o);
        T Hae(int id);
        List<T> HaeKaikki();
    }
}


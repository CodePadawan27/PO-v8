using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POH5Luokat;

namespace POH8Data
{
    public class TuoteRyhmaRepository : IRepository<TuoteRyhma>
    {
        DataContext _dc = new DataContext();

        public TuoteRyhma Hae(int id)
        {
            return _dc.Ryhmat.Where(r => r.Id == id).SingleOrDefault();
        }


        public List<TuoteRyhma> HaeKaikki()
        {
            List<TuoteRyhma> pp = new List<TuoteRyhma>();
            foreach (var item in _dc.Ryhmat)
            {
                pp.Add(item);
            }
            //var tuoteRyhmat = _dc.Ryhmat.ToList();
            return pp;
        }

        public bool Lisaa(TuoteRyhma o)
        {
            _dc.Ryhmat.Add(o);
            return (_dc.SaveChanges() == 1);
        }

        public bool Poista(int id)
        {
            var PoistetavaTuoteRyhma = _dc.Ryhmat.Where(r => r.Id == id).SingleOrDefault();
            _dc.Ryhmat.Remove(PoistetavaTuoteRyhma);
            return (_dc.SaveChanges() == 1);
        }



        public bool Muuta(TuoteRyhma o)
        {
            TuoteRyhma muutettava = Hae(o.Id);
            muutettava.Nimi = o.Nimi;
            muutettava.Kuvaus = o.Kuvaus;
            return (_dc.SaveChanges() == 1);
        }

    }
}

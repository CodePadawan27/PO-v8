using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POH5Luokat;

namespace POH8Data
{
    public class ToimittajaRepository : IRepository<Toimittaja>
    {
        DataContext _dc = new DataContext();

        public Toimittaja Hae(int id)
        {
            return _dc.Toimittajat.Where(r => r.Id == id).SingleOrDefault();
        }

        public List<Toimittaja> HaeKaikki()
        {
            var toimittajat = _dc.Toimittajat.ToList();
            return toimittajat;
        }

        public bool Lisaa(Toimittaja t)
        {
            _dc.Toimittajat.Add(t);
            return (_dc.SaveChanges() == 1);
        }

        public bool Poista(int id)
        {
            var PoistetavaToimittaja = _dc.Toimittajat.Where(t => t.Id == id).SingleOrDefault();
            _dc.Toimittajat.Remove(PoistetavaToimittaja);
            return (_dc.SaveChanges() == 1);
        }

        public bool Muuta(Toimittaja t)
        {
            Toimittaja muutettava = Hae(t.Id);
            muutettava.Katuosoite = t.Katuosoite;
            muutettava.Kaupunki = t.Kaupunki;
            muutettava.Maa = t.Maa;
            muutettava.Nimi = t.Nimi;
            muutettava.PostiKoodi = t.PostiKoodi;
            muutettava.Tuotteet = t.Tuotteet;
            muutettava.YhteysHenkilo = t.YhteysHenkilo;
            muutettava.YhteysTitteli = t.YhteysTitteli;
            return (_dc.SaveChanges() == 1);
        }
    }
}

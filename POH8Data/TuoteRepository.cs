using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POH5Luokat;

namespace POH8Data
{
    public class TuoteRepository
    {
        DataContext _dc = new DataContext();

        public Tuote Hae(int id)
        {
            return _dc.Tuotteet.Where(r => r.Id == id).SingleOrDefault();
        }

        public List<Tuote> HaeKaikki()
        {
            var tuotteet = _dc.Tuotteet.ToList();
            return tuotteet;
        }

        public bool Lisaa(Tuote t)
        {
            _dc.Tuotteet.Add(t);
            return (_dc.SaveChanges() == 1);
        }

        public bool Poista(int id)
        {
            var PoistetavaTuote = _dc.Tuotteet.Where(t => t.Id == id).SingleOrDefault();
            _dc.Tuotteet.Remove(PoistetavaTuote);
            return (_dc.SaveChanges() == 1);
        }

        public bool Muuta(Tuote t)
        {
            Tuote muutettava = Hae(t.Id);
            muutettava.HalytysRaja = t.HalytysRaja;
            muutettava.Nimi = t.Nimi;
            muutettava.Ryhma = t.Ryhma;
            muutettava.RyhmaId = t.RyhmaId;
            muutettava.TilausSaldo = t.TilausSaldo;
            muutettava.Toimittaja = t.Toimittaja;
            muutettava.ToimittajaId = t.ToimittajaId;
            muutettava.VarastoSaldo = t.VarastoSaldo;
            muutettava.YksikkoHinta = t.YksikkoHinta;
            muutettava.YksikkoKuvaus = t.YksikkoKuvaus;
            return (_dc.SaveChanges() == 1);
        }
    }
}

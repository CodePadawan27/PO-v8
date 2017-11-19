using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using POH8Data.Mapping;
using POH5Luokat;

namespace POH8Data
{
    partial class DataContext : DbContext
    {
        public DbSet<Tuote> Tuotteet { get; set; }
        public DbSet<Toimittaja> Toimittajat { get; set; }
        public DbSet<TuoteRyhma> Ryhmat { get; set; }

        public DataContext() : base("Name=DB")
        {

        }

        static DataContext()
        {
            //Tämä määrittää EF:lle, että tietokanta on jo olemassa.
            //Näin ollen sitä ei yritetä tehdä luokkien perusteella.
            Database.SetInitializer<DataContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TuoteMap());
            modelBuilder.Configurations.Add(new ToimittajaMap());
            modelBuilder.Configurations.Add(new TuoteRyhmaMap());
        }
    }
}

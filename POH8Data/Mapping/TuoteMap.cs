using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using POH5Luokat;

namespace POH8Data.Mapping 
{
    class TuoteMap : EntityTypeConfiguration<Tuote>
    {
        public TuoteMap()
        {
            //Perusavain
            HasKey(t => t.Id);
            // ja sen määrittelyssä on IDentity eli tietokanta tuottaa arvon
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Muut sarakaemääritykset
            Property(t => t.Nimi).IsRequired().HasMaxLength(40);
            Property(t => t.YksikkoKuvaus).HasMaxLength(20);
            Property(t => t.EiKaytossa).IsRequired();

            //Taulu & Sarake -mäppäykset
            ToTable("Products", "dbo");
            Property(t => t.Id).HasColumnName("ProductID");
            Property(t => t.Nimi).HasColumnName("ProductName");
            Property(t => t.ToimittajaId).HasColumnName("SupplierID");
            Property(t => t.RyhmaId).HasColumnName("CategoryID");
            Property(t => t.YksikkoKuvaus).HasColumnName("QuantityPerUnit");
            Property(t => t.YksikkoHinta).HasColumnName("UnitPrice");
            Property(t => t.VarastoSaldo).HasColumnName("UnitsInStock");
            Property(t => t.TilausSaldo).HasColumnName("UnitsOnOrder");
            Property(t => t.HalytysRaja).HasColumnName("ReorderLevel");
            Property(t => t.EiKaytossa).HasColumnName("Discontinued");

            //Viiteavaimet (määritetään mikä ominaisuus populoidaan viiteavainta vastaavasta ominaisuuden perusteella ja
            //mikä on kohteena olevan olion kokoelmaominaisuus viittavan olion tyyppisiin olioihin).
            //Koska viiteavainarvo ei ole pakollinen, käytetään metodia HasOptional, muuten käytettäisiin metodia HasRequired
            HasOptional(t => t.Toimittaja).WithMany(x => x.Tuotteet).HasForeignKey(d => d.ToimittajaId);
            HasOptional(t => t.Ryhma).WithMany(x => x.Tuotteet).HasForeignKey(d => d.RyhmaId);
        }
    }
}

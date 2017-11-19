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
    class ToimittajaMap : EntityTypeConfiguration<Toimittaja>
    {
        public ToimittajaMap()
        {
            //Perusavain
            HasKey(t => t.Id);
            // ja sen määrittelyssä on IDentity eli tietokanta tuottaa arvon
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Muut sarakaemääritykset
            Property(t => t.Nimi).IsRequired().HasMaxLength(15);

            //Taulu & Sarake -mäppäykset
            ToTable("Categories", "dbo");
            Property(t => t.Nimi).IsRequired().HasMaxLength(40);
            Property(t => t.YhteysHenkilo).HasMaxLength(30);
            Property(t => t.YhteysTitteli).HasMaxLength(30);
            Property(t => t.Katuosoite).HasMaxLength(60);
            Property(t => t.Kaupunki).HasMaxLength(15);
            Property(t => t.PostiKoodi).HasMaxLength(10);
            Property(t => t.Maa).HasMaxLength(15);
            //Taulu & Sarkae -mäppäykset
            ToTable("Suppliers", "dbo");
            Property(t => t.Id).HasColumnName("SupplierID");
            Property(t => t.Nimi).HasColumnName("CompanyName");
            Property(t => t.YhteysHenkilo).HasColumnName("ContactName");
            Property(t => t.YhteysTitteli).HasColumnName("ContactTitle");
            Property(t => t.Katuosoite).HasColumnName("Address");
            Property(t => t.Kaupunki).HasColumnName("City");
            Property(t => t.PostiKoodi).HasColumnName("PostalCode");
            Property(t => t.Maa).HasColumnName("Country");
        }
    }
}

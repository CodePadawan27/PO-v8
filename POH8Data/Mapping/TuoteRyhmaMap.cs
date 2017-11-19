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
    class TuoteRyhmaMap : EntityTypeConfiguration<TuoteRyhma>
    {
        public TuoteRyhmaMap()
        {
            //Perusavain
            HasKey(t => t.Id);
            // ja sen määrittelyssä on IDentity eli tietokanta tuottaa arvon
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Muut sarakaemääritykset
            Property(t => t.Nimi).IsRequired().HasMaxLength(15);

            //Taulu & Sarake -mäppäykset
            ToTable("Categories", "dbo");
            Property(t => t.Id).HasColumnName("CategoryID");
            Property(t => t.Nimi).HasColumnName("CategoryName");
            Property(t => t.Kuvaus).HasColumnName("Description");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DepartamentConfiguration : EntityTypeConfiguration<Departament>
    {
        public DepartamentConfiguration() : base()
        {            
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).
               IsRequired();

            Property(p => p.Title)
                .HasMaxLength(30);

            HasMany(p => p.Specializations)
               .WithRequired(p => p.Departament);

            HasMany(p => p.Professors)
               .WithRequired(p => p.Departament);

            ToTable("dbo.Departament");
        }
    }
}

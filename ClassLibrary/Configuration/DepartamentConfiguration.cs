using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    public class DepartamentConfiguration : EntityTypeConfiguration<Departament>
    {
        public DepartamentConfiguration()
        {            
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);               

            Property(p => p.Title)
                .HasMaxLength(30);

            HasMany(p => p.Specializations)
               .WithRequired(p => p.Departament)
               .WillCascadeOnDelete(false); ;

            HasMany(p => p.Professors)
               .WithRequired(p => p.Departament)
               .WillCascadeOnDelete(false); 

            ToTable("dbo.Departament");
        }
    }
}

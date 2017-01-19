using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    public class EntrantConfiguration : EntityTypeConfiguration<Entrant>
    {
        public EntrantConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).
               IsRequired();

            Property(p => p.Passport)
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            Property(p => p.LastName)
                .HasMaxLength(30)
                .IsRequired();        

            HasMany(p => p.Results)                
               .WithRequired(p => p.Entrant);          

            ToTable("dbo.Entrant");
        }
    }
}

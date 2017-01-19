using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    class ProfessorConfiguration : EntityTypeConfiguration<Professor>
    {
        public ProfessorConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);               

            Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            HasMany(p => p.Schedules)
                .WithRequired(p => p.Professor);

            ToTable("dbo.Professor");
        }
    }
}

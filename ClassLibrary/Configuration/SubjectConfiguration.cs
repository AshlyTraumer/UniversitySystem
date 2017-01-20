using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration() : base()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Title)
                .HasMaxLength(30);            

            HasMany(p => p.Results)
               .WithRequired(p => p.Subject)
               .WillCascadeOnDelete(false); ;

            HasMany(p => p.Schedules)
               .WithRequired(p => p.Subject)
               .WillCascadeOnDelete(false); ;

            HasMany(p => p.SubjectSpecializations)
               .WithRequired(p => p.Subject)
               .WillCascadeOnDelete(false); ;

            ToTable("dbo.Subject");
        }
    }
}

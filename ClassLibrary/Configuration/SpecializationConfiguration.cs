using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    public class SpecializationConfiguration : EntityTypeConfiguration<Specialization>
    {
        public SpecializationConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Title)
                .HasMaxLength(30)
                .IsRequired();

            HasMany(p => p.SubjectSpecializations)
               .WithRequired(p => p.Specialization)
               .WillCascadeOnDelete(false); ;

            ToTable("dbo.Specialization");
        }
    }
}

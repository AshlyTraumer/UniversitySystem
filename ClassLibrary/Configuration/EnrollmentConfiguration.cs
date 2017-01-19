using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    class EnrollmentConfiguration : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);             
            
            Property(p => p.RegistrationStatus)
                .IsRequired();

            HasRequired(c => c.Entrant)
                .WithRequiredPrincipal(c => c.Enrollment);

            ToTable("dbo.Enrollment");
        }
    }
}

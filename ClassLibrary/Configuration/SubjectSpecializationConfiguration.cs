using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    class SubjectSpecializationConfiguration : EntityTypeConfiguration<SubjectSpecialization>
    {
        public SubjectSpecializationConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("dbo.SubjectSpecialization");

            Property(x => x.SpecializationId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                    new IndexAttribute("IX_SubjectSpecialization", 1) { IsUnique = true }));

            Property(x => x.SubjectId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                    new IndexAttribute("IX_SubjectSpecialization", 2) { IsUnique = true }));
        }
    }
}

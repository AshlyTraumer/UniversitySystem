using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary
{
    class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            ToTable("dbo.Result");

            Property(x => x.EntrantId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                    new IndexAttribute("IX_EntrantSubject", 1) { IsUnique = true }));

            Property(x => x.SubjectId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                    new IndexAttribute("IX_EntrantSubject", 2) { IsUnique = true }));

        }
    }
}

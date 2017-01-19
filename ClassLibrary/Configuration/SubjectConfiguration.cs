using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
               .WithRequired(p => p.Subject);

            HasMany(p => p.Schedules)
               .WithRequired(p => p.Subject);

            HasMany(p => p.SubjectSpecializations)
               .WithRequired(p => p.Subject);

            ToTable("dbo.Subject");


        }
    }
}

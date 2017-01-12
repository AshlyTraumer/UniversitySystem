using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Authorization
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration() : base()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).
               HasColumnName("Id").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Login)
                .HasMaxLength(30);

            ToTable("dbo.Authorization");
        }
    }
}

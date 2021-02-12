using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagerCA.Core.Entities;

namespace PasswordManagerCA.Infrastructure.Data.Config
{
    public class AppPasswordHistoryConfiguration : EntityTypeConfiguration<AppPasswordHistory>
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppPasswordHistory>()
                .Property(e => e.oldPasswordHash)
                .IsUnicode(false);
        }
    }
}

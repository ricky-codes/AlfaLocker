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
    public class AccountAppsConfiguration : EntityTypeConfiguration<AccountApps>
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountApps>()
                .Property(e => e.appName)
                .IsUnicode(false);

            modelBuilder.Entity<AccountApps>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.AccountApps)
                .HasForeignKey(e => e.accountApp)
                .WillCascadeOnDelete();
        }
    }
}

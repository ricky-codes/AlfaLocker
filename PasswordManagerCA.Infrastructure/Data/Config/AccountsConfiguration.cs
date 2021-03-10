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
    public class AccountsConfiguration : EntityTypeConfiguration<Accounts>
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .Property(e => e.accountUsername)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .Property(e => e.accountPasswordEncrypt)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .Property(e => e.accountWebsiteLink)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .HasMany(e => e.AccountsPasswordHistory)
                .WithOptional(e => e.Accounts)
                .HasForeignKey(e => e.accountID)
                .WillCascadeOnDelete();
        }
    }
}

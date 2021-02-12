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
    public class AppUsersConfiguration : EntityTypeConfiguration<AppUsers>
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUsers>()
                .Property(e => e.appUsersUsername)
                .IsUnicode(false);

            modelBuilder.Entity<AppUsers>()
                .Property(e => e.appUsersEmail)
                .IsUnicode(false);

            modelBuilder.Entity<AppUsers>()
                .Property(e => e.appUsersPasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<AppUsers>()
                .Property(e => e.appUsersFirstname)
                .IsUnicode(false);

            modelBuilder.Entity<AppUsers>()
                .Property(e => e.appUsersLastname)
                .IsUnicode(false);

            modelBuilder.Entity<AppUsers>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.AppUsers)
                .HasForeignKey(e => e.accountAppUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AppUsers>()
                .HasMany(e => e.AppPasswordHistory)
                .WithOptional(e => e.AppUsers)
                .HasForeignKey(e => e.relatedAppUser)
                .WillCascadeOnDelete();
        }
    }
}

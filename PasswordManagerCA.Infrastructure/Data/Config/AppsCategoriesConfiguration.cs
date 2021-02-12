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
    public class AppsCategoriesConfiguration : EntityTypeConfiguration<AppsCategories>
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppsCategories>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<AppsCategories>()
                .Property(e => e.categoryType)
                .IsUnicode(false);

            modelBuilder.Entity<AppsCategories>()
                .HasMany(e => e.AccountApps)
                .WithOptional(e => e.AppsCategories)
                .HasForeignKey(e => e.appCategory);
        }
    }
}

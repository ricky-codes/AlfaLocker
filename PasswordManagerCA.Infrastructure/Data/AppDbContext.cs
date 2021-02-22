using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagerCA.Core.Entities;
using PasswordManagerCA.Infrastructure.Data.Config;
using PasswordManagerCA.SharedKernel;

namespace PasswordManagerCA.Infrastructure.Data
{
    public partial class AppDbModel : DbContext
    {
        public AppDbModel()
            : base("name=SQLExpressConnection")
        {
        }

        public virtual DbSet<AccountApps> AccountApps { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<AccountsPasswordHistory> AccountsPasswordHistory { get; set; }
        public virtual DbSet<AppPasswordHistory> AppPasswordHistory { get; set; }
        public virtual DbSet<AppsCategories> AppsCategories { get; set; }
        public virtual DbSet<AppUsers> AppUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountAppsConfiguration());
            modelBuilder.Configurations.Add(new AccountsConfiguration());
            modelBuilder.Configurations.Add(new AccountsPasswordHistoryConfiguration());
            modelBuilder.Configurations.Add(new AppPasswordHistoryConfiguration());
            modelBuilder.Configurations.Add(new AppsCategoriesConfiguration());
            modelBuilder.Configurations.Add(new AppUsersConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

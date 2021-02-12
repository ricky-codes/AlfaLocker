namespace PasswordManagerCA.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PasswordManagerCA.SharedKernel;
    using PasswordManagerCA.SharedKernel.Interfaces;

    public partial class AccountApps : BaseEntity, IAggregateRoot
    {
        
        public AccountApps()
        {
            Accounts = new HashSet<Accounts>();
        }

        [StringLength(50)]
        public string appName { get; set; }

        public int? appCategory { get; set; }

        public virtual AppsCategories AppsCategories { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}

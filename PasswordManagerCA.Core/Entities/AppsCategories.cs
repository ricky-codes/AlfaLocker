namespace PasswordManagerCA.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PasswordManagerCA.SharedKernel;
    using PasswordManagerCA.SharedKernel.Interfaces;

    public partial class AppsCategories : BaseEntity, IAggregateRoot
    {
        public AppsCategories()
        {
            AccountApps = new HashSet<AccountApps>();
        }

        [StringLength(40)]
        public string categoryName { get; set; }

        [StringLength(10)]
        public string categoryType { get; set; }

        public virtual ICollection<AccountApps> AccountApps { get; set; }
    }
}

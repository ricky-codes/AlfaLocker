namespace PasswordManagerCA.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PasswordManagerCA.SharedKernel;
    using PasswordManagerCA.SharedKernel.Interfaces;

    public partial class Accounts : BaseEntity, IAggregateRoot
    {
        public Accounts()
        {
            AccountsPasswordHistory = new HashSet<AccountsPasswordHistory>();
        }

        [StringLength(200)]
        public string accountUsername { get; set; }

        [Required]
        [StringLength(100)]
        public string accountPasswordHash { get; set; }

        [Required]
        [StringLength(30)]
        public string accountPasswordSalt { get; set; }

        [StringLength(300)]
        public string accountWebsiteLink { get; set; }

        public int? accountApp { get; set; }

        public int? accountAppUser { get; set; }

        public virtual AccountApps AccountApps { get; set; }

        public virtual AppUsers AppUsers { get; set; }

        public virtual ICollection<AccountsPasswordHistory> AccountsPasswordHistory { get; set; }
    }
}

namespace PasswordManagerCA.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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
        public string accountPasswordEncrypt { get; set; }

        [StringLength(300)]
        public string accountWebsiteLink { get; set; }

        public virtual int? accountApp { get; set; }

        public virtual int? accountAppUser { get; set; }

        [ForeignKey("accountApp")]
        public virtual AccountApps AccountApps { get; set; }

        [ForeignKey("accountAppUser")]
        public virtual AppUsers AppUsers { get; set; }

        public virtual ICollection<AccountsPasswordHistory> AccountsPasswordHistory { get; set; }
    }
}

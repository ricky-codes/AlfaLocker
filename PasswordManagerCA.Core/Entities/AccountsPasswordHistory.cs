namespace PasswordManagerCA.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using PasswordManagerCA.SharedKernel;
    using PasswordManagerCA.SharedKernel.Interfaces;

    [Table("AccountsPasswordHistory")]
    public partial class AccountsPasswordHistory : BaseEntity, IAggregateRoot
    {
        public DateTime modifiedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string oldPasswordHash { get; set; }

        [Required]
        [StringLength(30)]
        public string oldPasswordSalt { get; set; }

        public int? accountID { get; set; }

        public virtual Accounts Accounts { get; set; }
    }
}

namespace PasswordManagerCA.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using PasswordManagerCA.SharedKernel;
    using PasswordManagerCA.SharedKernel.Interfaces;

    [Table("AppPasswordHistory")]
    public partial class AppPasswordHistory : BaseEntity, IAggregateRoot
    {

        public DateTime modifiedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string oldPasswordHash { get; set; }

        public int? relatedAppUser { get; set; }

        public virtual AppUsers AppUsers { get; set; }
    }
}

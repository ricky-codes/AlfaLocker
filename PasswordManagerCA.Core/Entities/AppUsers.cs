namespace PasswordManagerCA.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PasswordManagerCA.SharedKernel;
    using PasswordManagerCA.SharedKernel.Interfaces;

    public partial class AppUsers : BaseEntity, IAggregateRoot
    {
        public AppUsers()
        {
            Accounts = new HashSet<Accounts>();
            AppPasswordHistory = new HashSet<AppPasswordHistory>();
        }

        [Required]
        [StringLength(30)]
        public string appUsersUsername { get; set; }

        [Required]
        [StringLength(60)]
        public string appUsersEmail { get; set; }

        [Required]
        [StringLength(100)]
        public string appUsersPasswordHash { get; set; }

        [StringLength(30)]
        public string appUsersFirstname { get; set; }

        [StringLength(30)]
        public string appUsersLastname { get; set; }

        public int appUsersPhoneNumber { get; set; }

        public DateTime? createdAt { get; set; }

        public int? appUsersVerificationCode { get; set; }

        public bool isVerified { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }

        public virtual ICollection<AppPasswordHistory> AppPasswordHistory { get; set; }
        
    }
}

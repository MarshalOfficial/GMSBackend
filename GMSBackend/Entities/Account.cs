using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GMSBackend.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public bool? Gender { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Mobile { get; set; }

        public string Tel { get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string Telegram { get; set; }

        public string Instagram { get; set; }

        public string Address { get; set; }

        public DateTime? JoinDate { get; set; }

        public long? Referral { get; set; }

        public long? VisitorID { get; set; }
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }

        public int AccountTypeId { get; set; }
        public AccountType? AccountType { get; set; }

        public int? MembershipJoinTypeId { get; set; }
        public MembershipJoinType? MembershipJoinType { get; set; }

        public int? JobInfoId { get; set; }
        public JobInfo? JobInfo { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class AccTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public bool IsVariz { get; set; }   

        public int AccountTypeID { get; set; } 

        [ForeignKey("AccountTypeID")]  
        public AccountType AccountType { get; set; }

        public long AccountID { get; set; }

        [ForeignKey("AccountID")]
        public Account Account { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public long UserID { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}

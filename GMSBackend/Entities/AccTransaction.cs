using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class AccTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public bool is_variz { get; set; }   

        public int account_type_id { get; set; }    

        [ForeignKey("account_type_id")]  
        public AccountType account_type { get; set; }

        public long account_id { get; set; }

        [ForeignKey("account_id")]
        public Account account { get; set; }

        public decimal price { get; set; }

        public string description { get; set; }

        public long user_id { get; set; }

        public DateTime create_date { get; set; }

        public bool is_deleted { get; set; }

        public DateTime? deleted_date { get; set; }

        public long? invoice_id { get; set; }   

    }
}

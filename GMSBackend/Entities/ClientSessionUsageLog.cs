using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class ClientSessionUsageLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }


        public long account_id { get; set; }
        [ForeignKey("account_id")]
        public Account account { get; set; }


        public long sale_invoice_details_id { get; set; }
        [ForeignKey("sale_invoice_details_id")]
        public SaleInvoiceDetails sale_invoice_details { get; set; }


        public DateTime create_date { get; set; }

        
        [StringLength(1000)]
        public string description { get; set; }

        public bool is_deleted { get; set; }

        public int qty { get; set; }    
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class SaleInvoiceHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public DateTime inv_date { get; set; }

        public long account_id { get; set; }

        [ForeignKey("account_id")] 
        public Account account { get; set; }    

        public long? visitor_id { get; set; }

        public short inv_type { get; set; }

        public double? price { get; set; }

        public double? reduction { get; set; }

        public string memo { get; set; }    

        public DateTime create_date { get; set; }

        public bool is_deleted { get; set; }

        public List<SaleInvoiceDetails> sale_invoice_details { get; set; }

        public List<SaleInvoicePayment> sale_invoice_payments { get; set; }         
    }
}

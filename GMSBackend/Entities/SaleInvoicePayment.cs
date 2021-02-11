using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Entities
{
    public class SaleInvoicePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long invoice_id { get; set; }

        [ForeignKey("invoice_id")] 
        public SaleInvoiceHeader sale_invoice_header { get; set; }

        public int sale_invoice_payment_type_id { get; set; }

        [ForeignKey("sale_invoice_payment_type_id")]
        public SaleInvoicePaymentType sale_invoice_payment_type { get; set; }

        public decimal price { get; set; }

        public string description { get; set; }

        public DateTime create_date { get; set; }    
    }
}

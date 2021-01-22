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
        public long ID { get; set; }

        public long InvoiceID { get; set; }

        [ForeignKey("InvoiceID")] 
        public SaleInvoiceHeader SaleInvoiceHeader { get; set; }

        public int SaleInvoicePaymentTypeId { get; set; }

        [ForeignKey("SaleInvoicePaymentTypeId")]
        public SaleInvoicePaymentType SaleInvoicePaymentType { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }    
    }
}

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
        public long ID { get; set; }

        public DateTime InvDate { get; set; }

        public long AccountID { get; set; }

        [ForeignKey("AccountID")] 
        public Account Account { get; set; }    

        public long? VisitorID { get; set; }

        public short InvType { get; set; }

        public double? Price { get; set; }

        public double? Reduction { get; set; }

        public string Memo { get; set; }    

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }

        public List<SaleInvoiceDetails> SaleInvoiceDetails { get; set; }

        public List<SaleInvoicePayment> SaleInvoicePayments { get; set; }       
    }
}

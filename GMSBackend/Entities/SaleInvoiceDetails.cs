using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class SaleInvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long invoice_id { get; set; }

        [ForeignKey("invoice_id")] 
        public SaleInvoiceHeader sale_invoice_header { get; set; }    

        public long product_id { get; set; }
        [ForeignKey("product_id")]
        public Product product { get; set; }

        public string product_name { get; set; }

        public int qty { get; set; }    

        public double price { get; set; }

        public short? reduction_percent { get; set; }

        public double? reduction_price { get; set; }

        public string memo { get; set; }    

        public int session_qty { get; set; }

        public int session_reserved { get; set; }

        public int session_used { get; set; }

        public DateTime create_date { get; set; }

        public bool is_deleted { get; set; }
    }
}

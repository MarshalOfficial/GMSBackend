using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class SaleInvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public long HeaderID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }    

        public double Price { get; set; }

        public short? Reduction_Percent { get; set; }

        public double? Reduction_Price { get; set; }

        public string Memo { get; set; }    

        public int SessionQty { get; set; }

        public int SessionReserved { get; set; }

        public int SessionUsed { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class ProductMain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public DateTime CreateDate { get; set; }

        public long CodingID { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public double? BuyPrice { get; set; }

        public double? SalePrice { get; set; }

        public double? SalePrice2 { get; set; }

        public string ProductBarCode { get; set; }

        public int? SessionCount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}

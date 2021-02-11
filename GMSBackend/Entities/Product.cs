using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public DateTime create_date { get; set; }

        public long coding_id { get; set; }

        public string product_code { get; set; }

        public string product_name { get; set; }

        public double? buy_price { get; set; }

        public double? sale_price { get; set; }

        public double? sale_price2 { get; set; }

        public string product_barcode { get; set; }

        public int? session_count { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public bool is_active { get; set; }

        public bool is_deleted { get; set; }
    }
}

using System;

namespace GMSBackend.Models
{
    public class ProductUpdateModel
    {
        public long id { get; set; }

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
        
    }
}

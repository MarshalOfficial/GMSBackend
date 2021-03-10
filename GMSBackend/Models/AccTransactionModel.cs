using System;

namespace GMSBackend.Models
{
    public class AccTransactionModel
    {
        public bool is_variz { get; set; }

        public int? account_type_id { get; set; }
        
        public long account_id { get; set; }
        
        public decimal price { get; set; }

        public string description { get; set; }

        public long user_id { get; set; }

        public DateTime create_date { get; set; }

        public bool is_deleted { get; set; }

        public long? invoice_id { get; set; }
    }
}

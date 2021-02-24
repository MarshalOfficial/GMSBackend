namespace GMSBackend.Models
{
    public class ClientSessionUsageModel
    {
        public long customer_id { get; set; }
        public long sale_invoice_details_id { get; set; }
        public string description { get; set; }
        public bool is_use { get; set; }
                
    }
}

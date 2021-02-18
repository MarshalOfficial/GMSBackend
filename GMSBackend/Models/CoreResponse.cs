namespace GMSBackend.Models
{
    public class CoreResponse
    {
        public bool is_success { get; set; }
        public string user_message { get; set; }
        public string dev_message { get; set; }        
        public long? total_items { get; set; }
        public long? total_pages { get; set; }
        public int? current_page { get; set; }
        public object data { get; set; }
    }
}

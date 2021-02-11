namespace GMSBackend.Models
{
    public class CoreResponse
    {
        public bool is_success { get; set; }
        public string user_message { get; set; }
        public string dev_message { get; set; }
        public object data { get; set; }
    }
}

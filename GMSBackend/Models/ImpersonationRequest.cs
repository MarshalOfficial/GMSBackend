using System.Text.Json.Serialization;

namespace GMSBackend.Models
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}

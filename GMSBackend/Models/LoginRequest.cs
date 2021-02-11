using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GMSBackend.Models
{
    public class LoginRequest
    {
        [Required]
        public string user_name { get; set; }

        [Required]
        public string password { get; set; }
    }
}

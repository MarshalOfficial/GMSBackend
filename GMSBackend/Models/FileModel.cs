using Microsoft.AspNetCore.Http;

namespace GMSBackend.Models
{
    public class FileModel
    {
        public string file_name { get; set; }
        public IFormFile form_file { get; set; }
    }
}

using GMSBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GMSBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        [HttpPost]
        [Route("upload")]
        public async Task<object> Upload([FromForm] FileModel file)
        {
            try
            {
                var storage = Path.Combine(Directory.GetCurrentDirectory(), "storage");
                if (!Directory.Exists(storage))
                {
                    Directory.CreateDirectory(storage);
                }
                if (file.form_file.Length > 0)
                {
                    var filePath = Path.Combine(storage, file.file_name);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.form_file.CopyToAsync(fileStream);
                    }
                }


                return new CoreResponse() { is_success = true, data = file };
            }
            catch (Exception ex)
            {
                return new CoreResponse() { is_success = false, data = file, dev_message = ex.Message };
            }
        }

        [HttpGet]
        [Route("download")]
        public async Task<object> Download([FromQuery] string file)
        {
            try
            {
                var storage = Path.Combine(Directory.GetCurrentDirectory(), "storage");
                var filePath = Path.Combine(storage, file);
                if (!System.IO.File.Exists(filePath))
                    return StatusCode(StatusCodes.Status404NotFound);

                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;

                return File(memory, GetContentType(filePath), file);
            }
            catch (Exception ex)
            {
                return new CoreResponse() { is_success = false, dev_message = ex.Message };
            }
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}

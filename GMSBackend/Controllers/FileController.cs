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
        public async Task<ActionResult> Upload([FromForm] FileModel file)   
        {
            try
            {
                var storage = Path.Combine(Directory.GetCurrentDirectory(), "storage");
                if (!Directory.Exists(storage))
                {
                    Directory.CreateDirectory(storage);
                }
                if (file.FormFile.Length > 0)
                {
                    var filePath = Path.Combine(storage, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.FormFile.CopyToAsync(fileStream);
                    }
                }

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("download")]
        public async Task<ActionResult> Download([FromQuery] string file)
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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

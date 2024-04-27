using FileUpload.Data;
using FileUpload.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.StaticFiles;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {

        public readonly DataContext _context;

        public UploadFileController(DataContext _context)
        {
            this._context = _context;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {

            var result = await WriteFile(file);

            var newFile = new Models.File
            {
                FileName = result,
                FilePath = result

            };

            _context.Add(newFile);
            await _context.SaveChangesAsync();


            return Ok(result);
        }

        private async Task<string> WriteFile(IFormFile file)
        {
            string fileName = "";

            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks.ToString() + extension;
                Console.WriteLine("filename: " +fileName);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                Console.WriteLine("filepath: " + filePath);

                if(!Directory.Exists(filePath)) {
                    Directory.CreateDirectory(filePath);
                }

                var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);

                Console.WriteLine("exactpath: " + exactPath);

                using (var stream = new FileStream(exactPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not uploaded");
            }
            return (fileName);
        }

        


        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);

            var provider = new FileExtensionContentTypeProvider();
            if(!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-strease";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}

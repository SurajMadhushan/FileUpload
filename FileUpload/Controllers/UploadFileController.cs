using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadFileController(IWebHostEnvironment _environment)
        {
            this._environment = _environment;
        }
    }
}

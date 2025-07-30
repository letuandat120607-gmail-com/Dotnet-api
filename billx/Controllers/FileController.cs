using Microsoft.AspNetCore.Mvc;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("api/File")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileService _fileStorageService;
        public const long MAX_UPLOAD_FILE_SIZE = 25000000;//File size must lower than 25MB
        public FileController(IFileService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }
        /// <summary>
        /// Upload file (FileType: System=1, Player=2)
        /// </summary>
        /// <param name="type"></param>
        [HttpPost]
        public async Task<ActionResult<string>> UploadFile(IFormFile file)
        {
            if (file.Length > MAX_UPLOAD_FILE_SIZE)
                return BadRequest("Exceed 25MB");
            string url = await _fileStorageService.uploadFile(file.OpenReadStream(), file.FileName);
            return Ok(url);
        }
    }
}

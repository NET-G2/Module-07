using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DiyorMarketApi.Controllers
{
    [Route("api/files")]
    [ApiController]

    public class FilesController : ControllerBase
    {

        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet("{id}")]
        public ActionResult GetFileById(int id)
        {
            string fileName = id == 1 ?  "C:\\Users\\VICTUS\\OneDrive\\Documents\\GitHub\\Module-07\\Lesson01\\DiyorMarketApi\\NabiddinovAbrorRezyume.pdf" : "text.txt";
            if (!System.IO.File.Exists(fileName))
            {
                return NotFound();
            }
            if(!_fileExtensionContentTypeProvider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stauts";
            }

            var bytes = System.IO.File.ReadAllBytes(fileName);
            return File(bytes, contentType, fileName);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DiyorMarketApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }


        [HttpGet("{id}")]
        public ActionResult GetFileById(int id)
        {
            string fileName = id == 1 ? "D:\\github darslar\\Module-07\\Lesson01\\DiyorMarketApi\\Resources\\ExamResults.pdf"
                : "D:\\github darslar\\Module-07\\Lesson01\\DiyorMarketApi\\Resources\\New Text Document.txt";

            if(!System.IO.File.Exists(fileName))
            {
                return NotFound();
            }

            if(!_fileExtensionContentTypeProvider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(fileName);
            return File(bytes, contentType, fileName);
        }
    }
}

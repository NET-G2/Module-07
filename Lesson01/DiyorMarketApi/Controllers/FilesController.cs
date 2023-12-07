using Microsoft.AspNetCore.Http;
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
        public  ActionResult GetFileById(int id)
        {
            string fileName =id==1? ".Net Developer.pdf":"txt.txt";
            if(!System.IO.File.Exists(fileName)) 
            {
               return NotFound();
            }
            if (!_fileExtensionContentTypeProvider.TryGetContentType(fileName,out var contentType))

            {
                contentType = "application/octet-string";
            }
            var bytes = System.IO.File.ReadAllBytes(fileName);
            return File(bytes, "application/pdf", fileName);

        }
    }
}

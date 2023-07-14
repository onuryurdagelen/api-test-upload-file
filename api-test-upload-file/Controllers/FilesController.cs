using api_test_upload_file.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace api_test_upload_file.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public FilesController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }




        [HttpPost]
        [Route("uploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            var result = await _fileManager.UploadFile(formFile);
            return Ok(result);
        }
        [HttpGet]
        [Route("downloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var result = await _fileManager.DownloadFile(fileName);
            return File(result.Item1,result.Item2,result.Item3);
        }



        //[HttpPost]
        //[Route("UploadFile")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]

        //public async Task<IActionResult> UploadFile(IFormFile file,CancellationToken cancellationToken)
        //{
        //    var result = await WriteFile(file);
        //    return Ok(result);
        //}
        //private async Task<string> WriteFile(IFormFile file)
        //{
        //    string fileName = "";
        //    try
        //    {
        //        var extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];
        //        fileName = DateTime.Now.Ticks.ToString() + extension;

        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

        //        if(!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
        //        using (var stream = new FileStream(exactPath,FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return fileName;
        //}
        //[HttpGet]
        //[Route("DownloadFile")]
        //public async Task<IActionResult> DownloadFile(string fileName)
        //{
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files",fileName);

        //    var provider = new FileExtensionContentTypeProvider();

        //    if(!provider.TryGetContentType(filePath, out var contentType))
        //    {
        //        contentType = "application/octet-stream";
        //    }
        //    var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        //    return File(bytes, contentType, Path.GetFileName(filePath));
        //}
    }
}

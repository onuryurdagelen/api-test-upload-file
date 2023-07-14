using api_test_upload_file.Helper;
using Microsoft.AspNetCore.StaticFiles;
using System.IO.Pipelines;

namespace api_test_upload_file.Services
{
    public class FileManager : IFileManager
    {
        public async Task<(byte[], string, string)> DownloadFile(string fileName)
        {
            string FileName = "";

            try
            {
               var FilePath = Common.GetFilePath(fileName);
                var provider = new FileExtensionContentTypeProvider();

                if(!provider.TryGetContentType(FilePath, out var contentType))
                {
                    contentType = "application/oclet-stream";
                }
                byte[] byteToRead = await File.ReadAllBytesAsync(FilePath);

                return (byteToRead, contentType, Path.GetFileName(FilePath));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UploadFile(IFormFile _file)
        {
            string FileName = "";

            try
            {
                FileInfo fileInfo = new FileInfo(_file.FileName);
                FileName = _file.FileName + "_" + DateTime.Now.Ticks.ToString() + fileInfo.Extension;
                var FilePath = Common.GetFilePath(FileName);
                using (var fs = new FileStream(FilePath, FileMode.Create))
                {
                    await _file.CopyToAsync(fs);
                }
                return FileName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

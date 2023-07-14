namespace api_test_upload_file.Services
{
    public interface IFileManager
    {
        Task<string> UploadFile(IFormFile _file);

        Task<(byte[], string, string)> DownloadFile(string fileName);
    }
}

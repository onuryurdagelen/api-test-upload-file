namespace api_test_upload_file.Helper
{
    public static class Common
    {
        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
        public static string GetStaticContentDirectory()
        {
            var result = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\StaticContent\\");
            if(!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;
        }
        public static string GetFilePath(string FileName)
        {
            string StaticContentDirectory = GetStaticContentDirectory();
            string result = Path.Combine(StaticContentDirectory, FileName);
            return result;
        }
    }
}

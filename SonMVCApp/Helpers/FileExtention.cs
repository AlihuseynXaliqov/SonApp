namespace SonMVCApp.Helpers
{
    public static class FileExtention
    {
        public static string Upload(this IFormFile formFile, string rootPath, string folderName)
        {
            string fileName = formFile.FileName;
            if (fileName.Length > 64)
            {
                fileName = fileName.Substring(fileName.Length - 64);
            }
            fileName = Guid.NewGuid() + fileName;
            string path = Path.Combine(rootPath, folderName, fileName);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fs);
            }
            return fileName;
        }
        public static bool Delete(string rootPath, string folderName, string fileName)
        {
            string path = Path.Combine(rootPath, folderName, fileName);
            if (!File.Exists(path))
            {
                return false;
            }
            File.Delete(path);
            return true;
        }
    }
}

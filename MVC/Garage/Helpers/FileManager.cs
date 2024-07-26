namespace Garage.Helpers
{
    public static class FileManager
    {
        public static string Upload(this IFormFile file, string env, string folderName)
        {
            string fileName = file.FileName;
            fileName = Guid.NewGuid().ToString() + fileName;
            string path = env + folderName + fileName;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
    }
}

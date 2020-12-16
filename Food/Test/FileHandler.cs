using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Test
{
    public class FileHandler
    {
        public static string WebRoot { get; set; }

        public static string DefaultProfileImg = "img/default.png";
        public static string SaveFileAndGetPath(IFormFile file, string directory)
        {
            // путь к папке
            string path = directory + 
                          DateTime.Now.Year +
                          DateTime.Now.Month +
                          DateTime.Now.Day+
                          DateTime.Now.Hour+
                          DateTime.Now.Minute+
                          DateTime.Now.Second+
                          DateTime.Now.Millisecond + file.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            var fileStream = new FileStream(WebRoot + path,
                FileMode.Create);
            file.CopyToAsync(fileStream);
            return new string(path.Skip(1).ToArray());
        }
    }
}
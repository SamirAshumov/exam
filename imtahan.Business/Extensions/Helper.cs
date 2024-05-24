using imtahan.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Business.Extensions
{
    public static class Helper
    {

        public static string SaveFile(string rootpath,string folder, IFormFile file)
        {

            if (file.ContentType.Contains("image/")) throw new FileContentTypeException("ImageFile", "File content is incorrect!");
            if(file.Length > 2097152) throw new FileSizeException("ImageFile", "File size is more than 2 mb!");

                       

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string path = rootpath + @$"\{folder}\" + fileName;


            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            };

            return fileName;
        }


        public static void DeleteFile(string rootpath, string folder, string fileName)
        {


            string path = rootpath + @$"\{folder}\" + fileName;

            if (!File.Exists(path)) throw new EntityNotFoundException("", "Speaker is not found!");

        }






    }
}

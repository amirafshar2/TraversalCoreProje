using EntityLayer.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TraversalCoreProje.Models.PicMethods
{
    public class PicSave
    {
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null; // opsiyonel olan image boş geçilebilir

            // مسیر پوشه
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            // اگه پوشه وجود نداره، بسازش
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // نام فایل یونیک
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolder, uniqueName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // مسیر نسبی برای ذخیره تو دیتابیس
            return  "/uploads/" + uniqueName;
        }
    }
}

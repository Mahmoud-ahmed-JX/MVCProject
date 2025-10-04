using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.AttatchmentServices
{
    public class AttachmentServices : IAttachmentServices
    {
        List<string> allowedExtensions = new List<string> { ".jpg", ".png", ".jpeg" };
        const int maxsize=2_097_152;//2MB

        public string? Upload(IFormFile file, string folderName)
        {
            //1-check Extension
            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName))) 
                return null;    
            //2-check Size
            if(file.Length > maxsize|| file.Length==0) 
                return null;
            //3-Get Folder Path
            string folderPath= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Files", folderName);
            //4-Make Attachment Name (Unique)
            string fileName=$"{Guid.NewGuid()}_{file.FileName}";
            //5-Get File Path
            string filePath=Path.Combine(folderPath,fileName);
            //6-Create File Stream To Copy File To Server
            using FileStream fs=new FileStream(filePath,FileMode.Create);
            //7-Use Stream To Copy File To Server
            file.CopyTo(fs);
            //8-Return File Path
            return fileName;

        }

        public bool Delete(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                return true;
            } 
            return false;
        }

     
    }
}

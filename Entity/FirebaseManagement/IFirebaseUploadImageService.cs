using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.FirebaseManagement
{
    public interface IFirebaseUploadImageService
    {
        Task<string> FireBaseUploadImageAsync(string fileName, string filePath, string folderName);
        Task<string> FireBaseDeleteImageAsync(string fileName, string folderName);
        Task<string> FireBaseGetImageAsync(string fileName, string folderName);
    }
}

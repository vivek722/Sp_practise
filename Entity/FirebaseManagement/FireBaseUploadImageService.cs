using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.FirebaseManagement
{
    public class FireBaseUploadImageService : IFirebaseUploadImageService
    {
        private readonly FirebaseService _storage;

        public FireBaseUploadImageService(FirebaseService firebaseStorage)
        {
            _storage = firebaseStorage;
        }
        public async Task<string> FireBaseDeleteImageAsync(string fileName, string folderName)
        {
            var storage = new FirebaseStorage(_storage._bucketName);
            await storage.Child(folderName).Child(fileName).DeleteAsync();
            return fileName;

        }

        public async Task<string> FireBaseGetImageAsync(string fileName, string folderName)
        {
            var storage = new FirebaseStorage(_storage._bucketName);
            var DowloadUrl = await storage.Child(folderName).Child(fileName).GetDownloadUrlAsync();
            return DowloadUrl;
        }

        public async Task<string> FireBaseUploadImageAsync(string fileName, string filePath, string folderName)
        {
            var storage = new FirebaseStorage(_storage._bucketName);
                var DowloadUrl = await storage.Child(folderName).Child(fileName).PutAsync(File.OpenRead(filePath));
            return DowloadUrl;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.FirebaseManagement
{
    public class FirebaseService
    {
        public string _bucketName { get; set; }
        public string _FirebaseURL { get; set; }

        public FirebaseService(string bucketName,string FirebaseURL)
        {
            _bucketName = bucketName;
            _FirebaseURL = FirebaseURL; 
        }
    }
}

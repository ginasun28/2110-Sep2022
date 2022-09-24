using _2110_Sep2022.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.BlobStorage
{
    public class CustomerBlobStorageRepository : BaseBlobStorageRepository
    {
        public CustomerBlobStorageRepository(IStorageConfiguration storageConfiguration, string containerName, string blobName) :
            base(storageConfiguration, containerName, blobName)
        { 
        }

        public void UploadFile(string filePath)
        {
            var blobClient = this.GetBlobClient();
        }

        public void Download()
        {

        }
    }
}

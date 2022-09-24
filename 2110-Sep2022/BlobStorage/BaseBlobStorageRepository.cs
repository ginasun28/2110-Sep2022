using System;
using System.Collections.Generic;
using _2110_Sep2022.Common;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace _2110_Sep2022.BlobStorage
{
    public class BaseBlobStorageRepository
    {
        protected IStorageConfiguration storageConfiguration;
        protected string containerName;
        protected string blobName;


        public BaseBlobStorageRepository(IStorageConfiguration storageConfiguration, string containerName, string blobName)
        {
            this.containerName = containerName;
            this.blobName = blobName;
            this.storageConfiguration = storageConfiguration;
        }

        protected BlobClient GetBlobClient()
        {
            return new BlobClient(storageConfiguration.GetStorageConnectionString(), this.containerName, this.blobName);
        }
    }
}

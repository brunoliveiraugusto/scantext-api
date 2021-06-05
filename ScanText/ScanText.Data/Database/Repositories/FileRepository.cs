using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Data.Database.Settings;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly string _connectionStringStorageAzure;
        private readonly string _blobContainerNameAzure;
        private readonly CloudBlobContainer _cloudBlobContainer;
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudBlobClient _blobClient;

        public FileRepository(IOptions<StorageAzureSettings> options)
        {
            _connectionStringStorageAzure = options.Value.ConnectionString;
            _blobContainerNameAzure = options.Value.BlobContainerName;
            _storageAccount = CloudStorageAccount.Parse(_connectionStringStorageAzure);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _cloudBlobContainer = _blobClient.GetContainerReference(_blobContainerNameAzure);
        }

        public async Task<string> Upload(string fileName, byte[] file)
        {
            try
            {                
                var blobClient = new BlobClient(_connectionStringStorageAzure, _blobContainerNameAzure, fileName);
                using (var stream = new MemoryStream(file))
                {
                    await blobClient.UploadAsync(stream);
                }

                return blobClient.Uri.AbsoluteUri;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(string fileName)
        {
            try
            {
                var blob = _cloudBlobContainer.GetBlockBlobReference(fileName);
                return await blob.DeleteIfExistsAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
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

        public FileRepository(IOptions<StorageAzureSettings> options)
        {
            _connectionStringStorageAzure = options.Value.ConnectionString;
            _blobContainerNameAzure = options.Value.BlobContainerName;
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
    }
}

using Azure.Storage.Blobs.Models;

namespace HPlusSports.Shared.Blob
{
    public class BlobService : IBlobService
    {
        private readonly IBlobContainerClientFactory _clientFactory;

        public BlobService(IBlobContainerClientFactory clientFactory) 
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> UploadBlobImageAsync(string containerName, string blobName, Stream imageStream)
        {
            var containerClient = _clientFactory.GetBlobContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(
                imageStream,
                new BlobHttpHeaders
                {
                    ContentType = "image/jpeg",
                    CacheControl = "public"
                });

            return blobClient.Uri.ToString();
        }
    }
}

using Azure.Storage.Blobs;

namespace HPlusSports.Shared.Blob
{
    public interface IBlobContainerClientFactory
    {
        BlobContainerClient GetBlobContainerClient(string container);
    }
}

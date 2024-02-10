using Azure.Storage.Blobs;

using Microsoft.Extensions.Options;

using System.Collections.Concurrent;

namespace HPlusSports.Shared.Blob
{
    public class BlobContainerClientFactory : IBlobContainerClientFactory
    {
        private readonly BlobOptions _options;
        private readonly ConcurrentDictionary<string, BlobContainerClient> _clientCache = new ConcurrentDictionary<string, BlobContainerClient>();

        public BlobContainerClientFactory(IOptions<BlobOptions> options) 
        {
            _options = options.Value;
        }

        public BlobContainerClient GetBlobContainerClient(string container)
        {
            return _clientCache.GetOrAdd(container, new BlobContainerClient(_options.ConnectionString, container));
        }
    }
}

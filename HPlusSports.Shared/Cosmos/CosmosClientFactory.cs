using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

using System.Collections.Concurrent;

namespace HPlusSports.Shared.Cosmos
{
    public class CosmosClientFactory : ICosmosClientFactory
    {
        private readonly CosmosDBOptions _defaultOptions;
        private readonly ConcurrentDictionary<string, CosmosClient> _clientsCache = new ConcurrentDictionary<string, CosmosClient>();

        public CosmosClientFactory(IOptions<CosmosDBOptions> options) 
        {
            _defaultOptions = options.Value;
            _clientsCache.TryAdd(_defaultOptions.Endpoint, new CosmosClient(_defaultOptions.Endpoint, _defaultOptions.Key));
        }

        public CosmosClient GetCosmosClient() 
        {
            return _clientsCache[_defaultOptions.Endpoint];
        }

        public CosmosClient GetCosmosClient(CosmosDBOptions options)
        {
            return _clientsCache.GetOrAdd(
                options.Endpoint, 
                new CosmosClient(
                    options.Endpoint, 
                    options.Key));
        }
    }
}

using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace HPlusSports.Shared.Cosmos
{
    public class CosmosContainerFactory : ICosmosContainerFactory
    {
        private readonly ICosmosClientFactory _clientFactory;
        private readonly CosmosDBOptions _options;

        public CosmosContainerFactory (ICosmosClientFactory clientFactory, IOptions<CosmosDBOptions> options)
        {
            _clientFactory = clientFactory;
            _options = options.Value;
        }

        public Container GetContainer(string containerName)
        {
            return _clientFactory.GetCosmosClient().GetContainer(_options.Database, containerName);
        }
    }
}

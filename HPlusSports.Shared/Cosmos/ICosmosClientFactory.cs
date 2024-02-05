using Microsoft.Azure.Cosmos;

namespace HPlusSports.Shared.Cosmos
{
    public interface ICosmosClientFactory
    {
        CosmosClient GetCosmosClient();

        CosmosClient GetCosmosClient(CosmosDBOptions options);
    }
}

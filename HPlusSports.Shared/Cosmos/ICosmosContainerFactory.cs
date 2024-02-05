using Microsoft.Azure.Cosmos;

namespace HPlusSports.Shared.Cosmos
{
    public interface ICosmosContainerFactory
    {
        Container GetContainer(string containerName);
    }
}

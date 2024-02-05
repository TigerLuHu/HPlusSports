using HPlusSports.Shared.Models;

namespace HPlusSports.Shared.Cosmos
{
    public interface ICosmosRepositoryFactory
    {
        ICosmosRepository<T> CreateRepository<T>(string containerName) where T : EntityBase;

        ICosmosRepository<T> CreateRepository<T>() where T : EntityBase;
    }
}

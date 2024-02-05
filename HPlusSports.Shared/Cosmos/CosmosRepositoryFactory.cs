using HPlusSports.Shared.Models;

namespace HPlusSports.Shared.Cosmos
{
    public class CosmosRepositoryFactory : ICosmosRepositoryFactory
    {
        private readonly IContainerNameResolver _containerNameResolver;
        private readonly ICosmosContainerFactory _containerFactory;

        public CosmosRepositoryFactory(ICosmosContainerFactory containerFactory, IContainerNameResolver containerNameResolver)
        {
            _containerFactory = containerFactory;
            _containerNameResolver = containerNameResolver;
        }

        public ICosmosRepository<T> CreateRepository<T>(string containerName) where T : EntityBase
        {
            return new CosmosRepository<T>(_containerFactory.GetContainer(containerName));
        }

        public ICosmosRepository<T> CreateRepository<T>() where T : EntityBase
        {
            return CreateRepository<T>(_containerNameResolver.Resolve<T>());
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace HPlusSports.Shared.Cosmos.Extensions
{
    public static class CosmosServiceExtensions
    {
        public static IServiceCollection AddCosmosService(this IServiceCollection services) 
        {
            return services
                .AddSingleton<ICosmosClientFactory, CosmosClientFactory>()
                .AddSingleton<ICosmosContainerFactory, CosmosContainerFactory>()
                .AddSingleton<ICosmosRepositoryFactory, CosmosRepositoryFactory>()
                .AddSingleton<IContainerNameResolver, ContainerNameResolver>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace HPlusSports.Shared.Table.Extensions
{
    public static class AzureTableExtensions
    {
        public static IServiceCollection AddAzureTableServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IAzureTableClientFactory, AzureTableClientFactory>()
                .AddSingleton<ITableNameResolver, TableNameResolver>()
                .AddSingleton<IAzureTableService, AzureTableService>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace HPlusSports.Shared.Queue.Extensions
{
    public static class AzureQueueExtensions
    {
        public static IServiceCollection AddAzureQueueServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IAzureQueueClientFactory, AzureQueueClientFactory>()
                .AddSingleton<IQueueNameResolver, QueueNameResolver>()
                .AddSingleton<IAzureQueueService, AzureQueueService>();
        }
    }
}

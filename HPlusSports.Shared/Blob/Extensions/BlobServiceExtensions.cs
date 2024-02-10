using Microsoft.Extensions.DependencyInjection;

namespace HPlusSports.Shared.Blob.Extensions
{
    public static class BlobServiceExtensions
    {
        public static IServiceCollection AddBlobServices(this IServiceCollection services) 
        {
            return services
                .AddSingleton<IBlobContainerClientFactory, BlobContainerClientFactory>()
                .AddSingleton<IBlobService, BlobService>();
        }
    }
}

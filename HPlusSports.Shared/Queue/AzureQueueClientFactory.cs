using Azure.Storage.Queues;

using Microsoft.Extensions.Options;

using System.Collections.Concurrent;

namespace HPlusSports.Shared.Queue
{
    public class AzureQueueClientFactory : IAzureQueueClientFactory
    {
        private readonly AzureQueueOptions _options;
        private readonly ConcurrentDictionary<string, QueueClient> _cache = new ConcurrentDictionary<string, QueueClient>();

        public AzureQueueClientFactory(IOptions<AzureQueueOptions> options)
        {
            _options = options.Value;
        }

        public QueueClient GetQueueClient(string queue)
        {
            return _cache.GetOrAdd(queue, new QueueClient(_options.ConnectionString, queue));
        }
    }
}

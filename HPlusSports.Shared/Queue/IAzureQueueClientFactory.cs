using Azure.Storage.Queues;

namespace HPlusSports.Shared.Queue
{
    public interface IAzureQueueClientFactory
    {
        QueueClient GetQueueClient(string queue);
    }
}

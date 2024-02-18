namespace HPlusSports.Shared.Queue
{
    public interface IAzureQueueService
    {
        Task SendMessageAsync<T>(T item, string queue = "");

        Task<T> ReceiveMessageAsync<T>(string queue = "");

        Task SendMessageAsync(string message, string queue);
    }
}

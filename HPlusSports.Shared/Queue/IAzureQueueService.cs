namespace HPlusSports.Shared.Queue
{
    public interface IAzureQueueService
    {
        /// <summary>
        /// Send message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="queue"></param>
        /// <returns>Message ID</returns>
        Task<string> SendMessageAsync<T>(T item, string queue = "");

        Task<T> ReceiveMessageAsync<T>(string queue = "");

        Task SendMessageAsync(string message, string queue);
    }
}

using Newtonsoft.Json;

namespace HPlusSports.Shared.Queue
{
    public class AzureQueueService : IAzureQueueService
    {
        private readonly IAzureQueueClientFactory _factory;
        private readonly IQueueNameResolver _resolver;

        public AzureQueueService(IAzureQueueClientFactory factory, IQueueNameResolver resolver) 
        {
            _factory = factory;
            _resolver = resolver;
        }

        public async Task<T> ReceiveMessageAsync<T>(string queue = "")
        {
            var client = _factory.GetQueueClient(!string.IsNullOrEmpty(queue) ? queue : _resolver.Resolve<T>());
            var message = await client.ReceiveMessageAsync();

            return JsonConvert.DeserializeObject<T>(message.Value.Body.ToString());
        }

        public async Task<string> SendMessageAsync<T>(T item, string queue = "")
        {
            var client = _factory.GetQueueClient(!string.IsNullOrEmpty(queue) ? queue : _resolver.Resolve<T>());
            var response = await client.SendMessageAsync(JsonConvert.SerializeObject(item));
            return response.Value.MessageId;
        }

        public async Task SendMessageAsync(string message, string queue)
        {
            var client = _factory.GetQueueClient(queue);
            await client.SendMessageAsync(message);
        }
    }
}

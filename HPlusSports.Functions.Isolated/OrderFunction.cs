using HPlusSports.Functions.Isolated.Models;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace HPlusSports.Functions.Isolated
{
    public class OrderFunction
    {
        private readonly ILogger _logger;

        public OrderFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<OrderFunction>();
        }

        [Function("OrderFunction")]
        [TableOutput("orderhistory", Connection = "AzureWebJobsStorage")]
        public async Task<OrderHistoryEntity[]> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            Order order;
            using (var streamReader = new StreamReader(req.Body))
            {
                var body = await streamReader.ReadToEndAsync();
                order = JsonConvert.DeserializeObject<Order>(body);
            }

            var orderHistoryEntities = new List<OrderHistoryEntity>();
            foreach (var item in order.Items)
            {
                var orderHistoryEntity = new OrderHistoryEntity(item);
                orderHistoryEntity.PartitionKey = item.Category;
                orderHistoryEntity.RowKey = $"{order.Id}-{item.Id}";

                // orderHistoryEntity.Timestamp = DateTime.UtcNow;

                orderHistoryEntities.Add(orderHistoryEntity);
            }

            return orderHistoryEntities.ToArray();
        }
    }
}

using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Azure.Functions.Worker;
using HPlusSports.Functions.Models;
using System.Collections.Generic;
using System;

namespace HPlusSports.Functions
{
    public static class OrderFunction
    {
        [FunctionName("OrderFunction")]
        [TableOutput("orderhistory", Connection = "AzureWebJobsStorage")]
        public static async Task<OrderHistoryEntity[]> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var order = await req.Content.ReadAsAsync<Order>();

            var orderHistoryEntities = new List<OrderHistoryEntity>();
            foreach (var item in order.Items)
            {
                var orderHistoryEntity = new OrderHistoryEntity(item);
                orderHistoryEntity.PartitionKey = item.Category;
                orderHistoryEntity.RowKey = $"{order.Id}-{item.Id}";

                orderHistoryEntity.Timestamp = DateTime.UtcNow;
                orderHistoryEntity.ETag = DateTime.UtcNow.Ticks.ToString();

                orderHistoryEntities.Add(orderHistoryEntity);
            }

            return orderHistoryEntities.ToArray();
        }
    }
}

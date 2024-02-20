using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
// using Microsoft.Azure.Functions.Worker;
using HPlusSports.Functions.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSports.Functions
{
    public static class OrderFunction
    {
        [FunctionName("OrderFunction")]
        // [TableOutput("orderhistory", Connection = "AzureWebJobsStorage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            [Table("orderhistory")] ICollector<OrderHistoryEntity> entities,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));

            try
            {
                var order = await req.Content.ReadAsAsync<Order>();

                var orderHistoryEntities = new List<OrderHistoryEntity>();
                foreach (var item in order.Items)
                {
                    var orderHistoryEntity = new OrderHistoryEntity(item);
                    orderHistoryEntity.PartitionKey = item.Category;
                    orderHistoryEntity.RowKey = $"{order.Id}-{item.Id}";
                    orderHistoryEntities.Add(orderHistoryEntity);

                    entities.Add(orderHistoryEntity);
                }
            }
            catch (Exception ex) 
            {
                log.LogError(ex.ToString());
            }

            // return orderHistoryEntities.ToArray();
            return new OkResult();
        }
    }
}

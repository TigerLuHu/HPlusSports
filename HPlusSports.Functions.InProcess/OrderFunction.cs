using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using HPlusSports.Functions.InProcess.Models;
using System;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSports.Functions.InProcess
{
    public static class OrderFunction
    {
        [FunctionName("OrderFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            [Table("orderhistory")] ICollector<OrderHistoryEntity> entities,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                var order = await req.Content.ReadAsAsync<Order>();
                foreach (var item in order.Items)
                {
                    var orderHistoryEntity = new OrderHistoryEntity(item);
                    orderHistoryEntity.PartitionKey = item.Category;
                    orderHistoryEntity.RowKey = $"{order.Id}-{item.Id}";

                    entities.Add(orderHistoryEntity);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
            }
            return new OkResult();
        }
    }
}

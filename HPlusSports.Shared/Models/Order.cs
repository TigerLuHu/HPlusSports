using HPlusSports.Shared.Queue.Attributes;

namespace HPlusSports.Shared.Models
{
    [AzureQueueName("orders")]
    public class Order : EntityBase
    {
        public List<OrderItem> Items { get; set; }
    }
}

using Azure;
using Azure.Data.Tables;

using HPlusSports.Shared.Table.Attributes;

namespace HPlusSports.Shared.Models
{
    [AzureTableName("orderhistory")]
    public class OrderHistoryEntity : OrderItem, ITableEntity
    {
        public OrderHistoryEntity() { }

        public OrderHistoryEntity(OrderItem orderItem)
        {
            Id = orderItem.Id;
            Name = orderItem.Name;
            Category = orderItem.Category;
            Quantity = orderItem.Quantity;
            Size = orderItem.Size;
        }

        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }
    }
}

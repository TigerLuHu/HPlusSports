using System;

namespace HPlusSports.Functions.Isolated.Models
{
    public class OrderHistoryEntity : OrderItem
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

        public DateTimeOffset Timestamp { get; set; }

        public string ETag { get; set; }
    }
}

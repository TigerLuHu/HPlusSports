using Azure;
using Azure.Data.Tables;

using HPlusSports.Shared.Table.Attributes;

namespace HPlusSports.Shared.Models
{
    [AzureTableName("orderhistory")]
    public class OrderHistoryEntity : OrderItem, ITableEntity
    {
        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }
    }
}

using Azure.Data.Tables;

namespace HPlusSports.Shared.Table
{
    public interface IAzureTableClientFactory
    {
        TableClient GetTableClient(string table);
    }
}

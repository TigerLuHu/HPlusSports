using Azure.Data.Tables;

using Microsoft.Extensions.Options;

using System.Collections.Concurrent;

namespace HPlusSports.Shared.Table
{
    public class AzureTableClientFactory : IAzureTableClientFactory
    {
        private readonly AzureTableOptions _options;
        private readonly ConcurrentDictionary<string, TableClient> _cache = new ConcurrentDictionary<string, TableClient>();
        private readonly TableServiceClient _tableServiceClient;

        public AzureTableClientFactory(IOptions<AzureTableOptions> options) 
        {
            _options = options.Value;
            _tableServiceClient = new TableServiceClient(_options.ConnectionString);
        }

        public TableClient GetTableClient(string table)
        {
            return _cache.GetOrAdd(table, _tableServiceClient.GetTableClient(table));
        }
    }
}

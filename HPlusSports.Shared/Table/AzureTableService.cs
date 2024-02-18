using Azure.Data.Tables;

namespace HPlusSports.Shared.Table
{
    public class AzureTableService : IAzureTableService
    {
        private readonly IAzureTableClientFactory _factory;
        private readonly ITableNameResolver _resolver;

        public AzureTableService(IAzureTableClientFactory factory, ITableNameResolver resolver) 
        {
            _factory = factory;
            _resolver = resolver;
        }

        // CAUTION: This shouldn't be used in real product
        public async Task<List<T>> ListAll<T>() where T : class, ITableEntity
        {
            var resultList = new List<T>();

            var tableClient = _factory.GetTableClient(_resolver.Resolve<T>());
            var pages = tableClient.QueryAsync((T _) => true);
            await foreach (var page in pages.AsPages()) 
            {
                resultList.AddRange(page.Values);
            }

            return resultList;
        }
    }
}

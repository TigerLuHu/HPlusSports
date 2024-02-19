using Azure.Data.Tables;

namespace HPlusSports.Shared.Table
{
    public interface IAzureTableService
    {
        Task<List<T>> ListAllAsync<T>() where T : class, ITableEntity;

        Task<T> FindAsync<T>(string partitionkey, string id) where T : class, ITableEntity;
    }
}

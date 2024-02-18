using Azure.Data.Tables;

namespace HPlusSports.Shared.Table
{
    public interface IAzureTableService
    {
        Task<List<T>> ListAll<T>() where T : class, ITableEntity;
    }
}

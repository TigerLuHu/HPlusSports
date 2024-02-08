using HPlusSports.Shared.Models;

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace HPlusSports.Shared.Cosmos
{
    public class CosmosRepository<T> : ICosmosRepository<T>
        where T : EntityBase
    {
        private readonly Container _container;

        public CosmosRepository(Container container)
        {
            _container = container;
        }

        public async Task<T> CreateAsync(T entity, string partition)
        {
            var response = await _container.CreateItemAsync(entity, GetPartitionKey(partition));
            return response.Resource;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var response = await _container.ReplaceItemAsync(entity, entity.Id);
            return response.Resource;
        }

        public async Task<T> FindByIdAsync(string id, string partition)
        {
            var response = await _container.ReadItemAsync<T>(id, GetPartitionKey(partition));
            return response.Resource;
        }

        public async Task DeleteAsync(T entity, string partition)
        {
            await _container.DeleteItemAsync<T>(entity.Id, GetPartitionKey(partition));
        }

        public async Task<List<T>> ListAllAsync()
        {
            using (var iterator = _container.GetItemLinqQueryable<T>().ToFeedIterator())
            {
                var results = new List<T>();

                while (iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync())
                    {
                        results.Add(item);
                    }
                }

                return results;
            }
        }

        private PartitionKey GetPartitionKey(string partition)
        {
            return string.IsNullOrEmpty(partition) ? PartitionKey.None : new PartitionKey(partition);
        }
    }
}

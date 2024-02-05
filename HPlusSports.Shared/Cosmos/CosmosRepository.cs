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

        public async Task<T> CreateAsync(T entity, string partion)
        {
            var response = await _container.CreateItemAsync(entity, string.IsNullOrEmpty(partion) ? PartitionKey.None : new PartitionKey(partion));
            return response.Resource;
        }

        public async Task<T> UpdateAsync(T entity, string partion)
        {
            var response = await _container.ReplaceItemAsync(entity, entity.Id, string.IsNullOrEmpty(partion) ? PartitionKey.None : new PartitionKey(partion));
            return response.Resource;
        }

        public async Task<T> FindByIdAsync(string id, string partion)
        {
            var response = await _container.ReadItemAsync<T>(id, string.IsNullOrEmpty(partion) ? PartitionKey.None : new PartitionKey(partion));
            return response.Resource;
        }

        public async Task DeleteAsync(T entity, string partion)
        {
            await _container.DeleteItemAsync<T>(entity.Id, string.IsNullOrEmpty(partion) ? PartitionKey.None : new PartitionKey(partion));
        }

        public async Task<List<T>> FindAsync(Func<T, bool> predict)
        {
            using (var iterator = _container.GetItemLinqQueryable<T>().Where(t => predict(t)).ToFeedIterator())
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
    }
}

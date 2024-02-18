using HPlusSports.Shared.Cosmos;
using HPlusSports.Shared.Models;

namespace HPlusSportsAPI.Services.Ropository
{
    public class ProductRepository<T> : IProductRepository<T>
        where T : ProductBase
    {
        private readonly ICosmosRepository<T> _cosmosRepository;

        public ProductRepository(ICosmosRepositoryFactory cosmosRepositoryFactory) 
        {
            _cosmosRepository = cosmosRepositoryFactory.CreateRepository<T>();
        }

        public Task<T> AddProductAsync(T product)
        {
            return _cosmosRepository.CreateAsync(product, product.Id);
        }

        public Task<T> FindAsync(string id)
        {
            return _cosmosRepository.FindByIdAsync(id, id);
        }

        public Task<List<T>> ListAllAsync()
        {
            return _cosmosRepository.ListAllAsync();
        }

        public Task<T> UpdateProductAsync(T product)
        {
            return _cosmosRepository.UpdateAsync(product);
        }
    }
}

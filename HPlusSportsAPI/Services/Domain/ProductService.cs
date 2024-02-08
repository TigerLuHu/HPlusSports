using HPlusSports.Shared.Models;

using HPlusSportsAPI.Services.Ropository;

namespace HPlusSportsAPI.Services.Domain
{
    public class ProductService<T> : IProductService<T>
        where T : ProductBase
    {
        private readonly IProductRepository<T> _productRepository;

        public ProductService(IProductRepository<T> repository) 
        {
            _productRepository = repository;
        }

        public Task<T> AddProductAsync(T product)
        {
            return _productRepository.AddProductAsync(product);
        }

        public Task AddProductImage(string id, Stream imageStream)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetProductAsync(string id)
        {
            return _productRepository.FindAsync(id);
        }

        public Task<List<T>> GetProductsAsync()
        {
            return _productRepository.ListAllAsync();
        }
    }
}

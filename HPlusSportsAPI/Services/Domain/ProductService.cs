using HPlusSports.Shared.Models;

using HPlusSportsAPI.Services.Ropository;

namespace HPlusSportsAPI.Services.Domain
{
    public class ProductService<T> : IProductService<T>
        where T : ProductBase
    {
        private readonly IProductRepository<T> _productRepository;
        private readonly IImageService _imageService;

        public ProductService(IProductRepository<T> repository, IImageService imageService) 
        {
            _productRepository = repository;
            _imageService = imageService;
        }

        public Task<T> AddProductAsync(T product)
        {
            return _productRepository.AddProductAsync(product);
        }

        public async Task<T> AddProductImage(string id, Stream imageStream)
        {
            var imageName = $"{id}.jpg";
            var imageUri = await _imageService.UploadImageAsync(imageName, imageStream);
            var product = await GetProductAsync(id);
            product.Image = imageUri;
            product.ImageTitle = imageName;

            return await _productRepository.UpdateProductAsync(product);
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

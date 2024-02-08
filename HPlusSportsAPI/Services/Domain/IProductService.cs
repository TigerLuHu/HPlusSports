using HPlusSports.Shared.Models;

namespace HPlusSportsAPI.Services.Domain
{
    public interface IProductService<T>
        where T : ProductBase
    {
        Task<List<T>> GetProductsAsync();

        Task<T> GetProductAsync(string id);

        Task AddProductImage(string id, Stream imageStream);

        Task<T> AddProductAsync(T product);
    }
}

using HPlusSports.Shared.Models;

namespace HPlusSportsAPI.Services.Ropository
{
    public interface IProductRepository<T> : IRepository<T>
        where T : ProductBase
    {
        Task<T> AddProductAsync(T product);

        Task<T> UpdateProductAsync(T product);
    }
}

using HPlusSports.Shared.Models;

namespace HPlusSports.Shared.Cosmos
{
    public interface ICosmosRepository<T>
        where T : EntityBase
    {
        Task<T> CreateAsync(T entity, string partition = "");

        Task<T> UpdateAsync(T entity);

        Task<T> FindByIdAsync(string id, string partition = "");

        Task<List<T>> ListAllAsync();

        Task DeleteAsync(T entity, string partition = "");
    }
}

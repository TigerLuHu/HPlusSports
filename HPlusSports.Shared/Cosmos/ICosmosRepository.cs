using HPlusSports.Shared.Models;

namespace HPlusSports.Shared.Cosmos
{
    public interface ICosmosRepository<T>
        where T : EntityBase
    {
        Task<T> CreateAsync(T entity, string partion);

        Task<T> UpdateAsync(T entity, string partion);

        Task<T> FindByIdAsync(string id, string partion);

        Task<List<T>> FindAsync(Func<T, bool> predict);

        Task DeleteAsync(T entity, string partion);
    }
}

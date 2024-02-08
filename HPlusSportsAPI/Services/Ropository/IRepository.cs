using HPlusSports.Shared.Models;

namespace HPlusSportsAPI.Services.Ropository
{
    public interface IRepository<T>
        where T : EntityBase
    {
        public Task<List<T>> ListAllAsync();

        public Task<T> FindAsync(string id);
    }
}

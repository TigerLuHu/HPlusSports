using HPlusSports.Shared.Models;

namespace HPlusSportsAPI.Services.Domain
{
    public interface IOrderService
    {
        Task AddOrderAsync<T>(T order) where T : Order;

        Task<List<T>> GetOrdersAsync<T>() where T : OrderHistoryEntity;

        Task<T> GetOrderAsync<T>(string id) where T : OrderHistoryEntity;
    }
}

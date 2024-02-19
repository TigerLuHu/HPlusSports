using HPlusSports.Shared.Models;
using HPlusSports.Shared.Queue;
using HPlusSports.Shared.Table;

namespace HPlusSportsAPI.Services.Domain
{
    public class OrderService: IOrderService
    {
        private readonly IAzureQueueService _queueService;
        private readonly IAzureTableService _tableService;

        public OrderService(IAzureQueueService queueService, IAzureTableService tableService) 
        {
            _queueService = queueService;
            _tableService = tableService;
        }

        public async Task AddOrderAsync<T>(T order) where T : Order
        {
            await _queueService.SendMessageAsync(order);
        }

        public async Task<T> GetOrderAsync<T>(string id, string category) where T : OrderHistoryEntity
        {
            return await _tableService.FindAsync<T>(category, id);
        }

        public async Task<List<T>> GetOrdersAsync<T>() where T : OrderHistoryEntity
        {
            return await _tableService.ListAllAsync<T>();
        }
    }
}

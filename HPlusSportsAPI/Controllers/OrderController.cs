using HPlusSports.Shared.Models;

using HPlusSportsAPI.Services.Domain;

using Microsoft.AspNetCore.Mvc;

namespace HPlusSportsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task CreateOrder(Order order)
        {
            await _orderService.AddOrderAsync(order);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Get(string id, [FromQuery] string category)
        {
            var order = await _orderService.GetOrderAsync<OrderHistoryEntity>(id, category);
            return new JsonResult(order);
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var orders = await _orderService.GetOrdersAsync<OrderHistoryEntity>();
            return new JsonResult(orders);
        }
    }
}

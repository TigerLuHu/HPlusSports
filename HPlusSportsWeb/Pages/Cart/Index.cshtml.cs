using HPlusSports.Shared.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HPlusSportsWeb.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task OnPostSubmitOrder([FromBody]Order order)
        {
            if (string.IsNullOrEmpty(order.Id))
            {
                order.Id = Guid.NewGuid().ToString();
            }

            await _httpClient.PostAsJsonAsync("order", order);
        }
    }
}
